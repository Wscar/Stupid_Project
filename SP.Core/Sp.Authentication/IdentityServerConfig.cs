using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.Authentication
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
              

                new ApiResource("sp_api","sp_api service"),
                
                //并且要把contactapi加入到apiResource,并加入到 client的allowedScopes中 
               // new ApiResource("contact_api","contact_api service")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {

            return new List<IdentityResource>()
            {
                 new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
                 new IdentityResources.Email()
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
          {
              new Client
              {
                    ClientId="pc",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("yemobai".Sha256()) },
                     RefreshTokenUsage=TokenUsage.ReUse,
                     AlwaysIncludeUserClaimsInIdToken = true,
                     AllowOfflineAccess = true,
                     AccessTokenLifetime=(int)TimeSpan.FromMinutes(1).TotalSeconds,
                    AllowedScopes=new List<string>
                    {
                       "sp_api",
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                    }

              }
          };
        }
    }
}
