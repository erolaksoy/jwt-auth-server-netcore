using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;

namespace WorkJwtExampleServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto CreateTokenByClient(ClientDto clientDto);
    }
}
