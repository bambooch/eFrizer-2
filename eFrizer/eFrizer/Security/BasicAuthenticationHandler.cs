﻿using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace eFrizer.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IApplicationUserService _appUserService;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                          ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
                                          IApplicationUserService appUserService)
        : base(options, logger, encoder, clock)
        {
            _appUserService = appUserService;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            Model.ApplicationUser user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var username = credentials[0];
                var password = credentials[1];

                user = await _appUserService.Login(username, password);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            } 

            if (user == null)
                return AuthenticateResult.Fail("Invalid username or password");

            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name)
            };

            foreach (var role in user.ApplicationUserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

    }
}
