﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IsubuIdentitiyServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_katalog")
                {
                    Scopes = { "katalog" }
                },
                new ApiResource("resource_fotografDepo")
                {
                    Scopes ={ "fotograf" }
                },
                new ApiResource("resource_sepet")
                {
                    Scopes = {"sepet"}
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("katalog"),
                new ApiScope("fotograf"),
                new ApiScope("sepet")

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "IsubuSatisMVC",
                    ClientName = "Isubu Satış Uygulaması",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ISUBU_Secret".Sha256()) },

                    AllowedScopes = { "scope1", "katalog"}
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "IsubuSatisMvcForUser",
                    ClientSecrets = { new Secret("ISUBUUser_Secret".Sha256()) },
                    AllowedScopes = { "openid", "profile", "katalog", "fotograf", "sepet" },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 300000
                    //RedirectUris = { "https://localhost:44300/signin-oidc" },
                    //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    
                    
                },
            };
    }
}