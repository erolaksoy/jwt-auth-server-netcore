using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Services;

namespace WorkJwtExampleServer.Service.Services
{
    public class TokenService : ITokenService
    {
        public TokenDto CreateToken(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public TokenDto CreateTokenByClient(ClientTokenDto clientTokenDto)
        {
            throw new NotImplementedException();
        }
    }
}
