using BallotElectionsDAL;
using BallotElectionsDAL.DTOS;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsBLL
{
   
    public class AccountHandler
    {
        static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        private static AccountDALHandler accountDalHandler
        {
            get => new AccountDALHandler();
        }

        public async Task<int> Register(int idVoter,  string tz,string email, string fullName, bool gender, string city,  string password)
        {
            if (idVoter != 0)
            {
                string message = "Can't create duplicate voter";
                throw new Exception(message);
            }
            int result = await accountDalHandler.Register(tz, email, fullName, gender, city, password);
            return result;
        }
        public async Task<string> Login(string tz, string password)
        {
            if (string.IsNullOrEmpty(tz))
            {
                string message = "Can't do login";
                throw new Exception(message);
            }
           if(! await accountDalHandler.Login(tz,  password))
            {
                string message = "Password not valid";
                throw new Exception(message);
            }
           
            string stringToken = GenerateToken();
            return stringToken;
        }

        private string GenerateToken()
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: "Sample",
                audience: "Sample",
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, "meziantou")
                },
                expires: DateTime.UtcNow.AddDays(1));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }
    }

}
