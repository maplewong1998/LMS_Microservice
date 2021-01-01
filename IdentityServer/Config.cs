using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "LMSClientWithIdentity",
                        ClientName = "LMS Client With Identity",
                        AllowedGrantTypes = GrantTypes.Hybrid,
                        RequirePkce = false,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        RedirectUris = 
                        {
                            "https://localhost:5011/signin-oidc" //client app port signin
                        },
                        PostLogoutRedirectUris = 
                        { 
                            "https://localhost:5011/signout-callback-oidc" //client app port signout
                        },
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Email,
                            IdentityServerConstants.StandardScopes.Profile,
                            "name",
                            "userId",
                            "role",
                            "account_status",
                            "bookAPI",
                            "userManagerAPI"
                        },
                    },
                    new Client
                    {
                        ClientId = "LMSClient",
                        ClientName = "LMS Client",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        RequirePkce = false,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = new List<string>
                        {
                            "bookAPI",
                            "userManagerAPI"
                        },

                    }
                };
            }
        }

        public static IEnumerable<ApiScope> ApiScopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope(name: "bookAPI", displayName: "Book API"),
                    new ApiScope(name: "userManagerAPI", displayName: "User Manager API")
                };
            }
        }

        public static IEnumerable<ApiResource> ApiResources
        {
            get
            {
                return new List<ApiResource> { };
            }
        }

        public static IEnumerable<IdentityResource> IdentityResources
        {
            get
            {
                return new List<IdentityResource> {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile(),
                    new IdentityResource("name", new List<string>() { "name" }),
                    new IdentityResource("userId", new List<string>() { "userId" }),
                    new IdentityResource("role", new List<string>() { "role" }),
                    new IdentityResource("account_status", new List<string>() { "account_status" })
                };
            }
        }
    }
}
