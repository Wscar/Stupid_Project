using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace YMB.AuthenticationCenter
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="mvc",
                    ClientName="myMvc",
                    ClientSecrets=new List<Secret>{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Implicit,
                    RedirectUris={ "https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        }
                },
                // vue客户端
                new Client
                {
                    ClientId="vue-client",
                    ClientName="vue客户端",
                    ClientUri="http://localhost:4000",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser=true,
                    RequireConsent=true,
                    AccessTokenLifetime=60,
                    //登陆和刷新token的地址
                    RedirectUris={"http://localhost:4000/signin-oidc", "http://localhost:4000/redirect-silentrenew" },
                    //退出地址
                    PostLogoutRedirectUris={"http://localhost:4000" },
                    //跨域 
                    AllowedCorsOrigins={"http://localhost:4000" },
                    AllowedScopes=  new List<string>
                        {   "api1",
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile
                        }
                }

            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","test_api1")
            };
        }
        public static List<TestUser> Users()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="yemobai",
                    Password="123"
                }
            };
        }
    }
}
