using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace BallotElectionsBLL
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        // Dependency Injection
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Reading the AuthHeader which is signed with JWT
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader == null || (!ValidateToken(authHeader)))
            {
                return;
            }
            //Pass to the next middleware
            await _next(context);
        }


        public JsonWebKey GetToken()
        {
            string filename = Path.Combine(System.AppDomain.CurrentDomain.RelativeSearchPath ?? "", "Files\\key.jwk");
            JsonWebKey jwk = null;
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                jwk = new JsonWebKey(json);
            }
            return jwk;
        }
        private bool ValidateToken(string authToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            JsonWebKey jwk = GetToken();
            if (jwk == null)
            {
                return false;
            }

            TokenValidationParameters validationParameters = GetValidationParameters(jwk);

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters(JsonWebKey key)
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = key
            };
        }

    }
}
