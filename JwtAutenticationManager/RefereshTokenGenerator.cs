using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace JwtAutenticationManager
{
    public class RefereshTokenGenerator:IRefreshTokenGenerator
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];
            using(var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
