using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using IdentityServer4.Models;
using Sp.Authentication.Dtos;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Sp.Authentication.Service;
namespace Sp.Authentication
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IHttpClientFactory httpClient;
        private readonly IAccountService accountService;
        public ResourceOwnerPasswordValidator(IHttpClientFactory _httpCilent, IAccountService _accountService)
        {
            httpClient = _httpCilent;
            accountService = _accountService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var result= await accountService.SignIn(context.UserName, context.Password);
            context.Result = result;           
        }
    }
}
