using JwtAutenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JwtAutenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "47706896ADA532A104EE78A38CF466489E26012DF70042CACEDBC2B52571E341";
        private const int JWT_TOKEN_VALIDITY_INTERVAL = 20;

        private readonly List<User> _user;
        
        public JwtTokenHandler()
        {
            _user = new List<User>{
                new User{UserName = "Admin",Password = "admin123",role = "Admin"},
                new User{UserName = "User",Password = "user123",role = "User"}
            };
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public AuthenticationResponse? GenerateToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;
            var usr = _user.Where(x => x.UserName == authenticationRequest.UserName || x.Password == authenticationRequest.Password).FirstOrDefault();
            if (usr == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_INTERVAL);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim("Role", usr.role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = usr.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
                RefreshToken = GenerateRefreshToken()
            };

        }
    }
}
