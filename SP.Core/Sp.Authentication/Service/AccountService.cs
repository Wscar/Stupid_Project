using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sp.Authentication.Dtos;
using System.Net.Http;
using IdentityServer4.Validation;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4.Models;
using Newtonsoft.Json.Linq;
using IdentityModel;

namespace Sp.Authentication.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory httpClient;
        public AccountService(IHttpClientFactory _httpClinet)
        {
            httpClient = _httpClinet;
        }
        public async Task<GrantValidationResult> SignIn(string userName, string password)
        {
            using (var client = this.httpClient.CreateClient())
            {
                var url = "http://localhost:5000/api/user/signIn";
                var postKeys = new Dictionary<string, string>();
                postKeys.Add("userName", userName);
                postKeys.Add("password", password);
                var response = await client.PostAsync(url, new FormUrlEncodedContent(postKeys));
                var userResult = await response.Content.ReadAsStringAsync();
                var userResponseDto = JsonConvert.DeserializeObject<ResponseDto>(userResult);
                if (userResponseDto.Status == Status.Success)
                {
                    var userInfo = JsonConvert.DeserializeObject<UserDto>( JObject.Parse(userResult)["data"].ToString());
                    var role = userInfo.Roles[0];
                    return new GrantValidationResult(userInfo.Id.ToString(), role, this.GetClaims(userInfo));
                }
                else
                {
                    return new GrantValidationResult(TokenRequestErrors.InvalidRequest, userResponseDto.Msg);
                }
            }
          
        }
        private Claim[] GetClaims(UserDto dto)
        {
            List<Claim> claims = new List<Claim>();
            dto.Roles.ForEach(x => { claims.Add(new Claim(JwtClaimTypes.Role, x)); });
            claims.Add(new Claim("nickName", dto.NickName));
            claims.Add(new Claim("avatar", dto.Avatar));
            return claims.ToArray();
        }
    }
}
