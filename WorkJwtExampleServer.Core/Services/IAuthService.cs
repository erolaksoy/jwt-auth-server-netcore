using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Core.Services
{
    public interface IAuthService
    {
        Task<Response<TokenDto>> CreateTokenAsync(AppUserLoginDto appUserLoginDto);
        Response<ClientTokenDto> CreateTokenByClientAsync(ClientDto clientDto);
        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

    }
}
