using IdentityServer4.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Secret = IdentityServer4.Models.Secret;
using IdentityServer4.Test;
using IdentityServer4;
using static IdentityServer4.IdentityServerConstants;

namespace ServerPart.IdentityServer4
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ServerPart.API" )
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "ServerPart.API" }
                },
                // test 
                new Client
                {
                    ClientId = "client1",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret1".Sha256())
                    },
                    AllowedScopes = { "ServerPart.API",StandardScopes.Address },
                    AllowOfflineAccess=true,
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username="lascodaniil@gmail.com",
                    Password ="password"
                }
            };
        }
    }
}
