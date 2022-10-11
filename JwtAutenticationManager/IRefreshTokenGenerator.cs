using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAutenticationManager
{
    public interface IRefreshTokenGenerator
    {
        public string GenerateToken();
    }
}
