using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Repositories;
using WorkJwtExampleServer.Core.Services;
using WorkJwtExampleServer.Core.UnitOfWork;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly List<ClientDto> _clientOptions;
        private readonly IGenericRepository<UserRefreshToken> _refreshTokenRepo;
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, IOptions<List<ClientDto>> clientOptions, IGenericRepository<UserRefreshToken> refreshTokenRepo, IUnitOfWork uow, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _clientOptions = clientOptions.Value;
            _refreshTokenRepo = refreshTokenRepo;
            _uow = uow;
        }
        public async Task<Response<TokenDto>> CreateTokenAsync(AppUserLoginDto appUserLoginDto)
        {
            if (appUserLoginDto == null) throw new ArgumentNullException(nameof(appUserLoginDto));
            var user = await _userManager.FindByEmailAsync(appUserLoginDto.Email);
            if (user == null) return Response<TokenDto>.Fail("Wrong username or password", 400, true);
            if (!(await _userManager.CheckPasswordAsync(user, appUserLoginDto.Password))) return Response<TokenDto>.Fail("Wrong username or password", 400, true);

            var token = _tokenService.CreateToken(user);
            var userRefreshToken = await _refreshTokenRepo.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _refreshTokenRepo.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    RefreshToken = token.RefreshToken,
                    RefreshTokenExpiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.RefreshToken = token.RefreshToken;
                userRefreshToken.RefreshTokenExpiration = token.RefreshTokenExpiration;
            }

            await _uow.CommitAsync();
            return Response<TokenDto>.Success(token, 200);


        }

        public Response<ClientTokenDto> CreateTokenByClientAsync(ClientDto clientDto)
        {
            var client = _clientOptions.SingleOrDefault(x => x.ClientId == clientDto.ClientId && x.ClientSecret == clientDto.ClientSecret);

            if (client == null) return Response<ClientTokenDto>.Fail("Client is not available!", 404, true);
            var clientToken = _tokenService.CreateTokenByClient(clientDto);
            return Response<ClientTokenDto>.Success(clientToken, 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _refreshTokenRepo.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null)
                return Response<TokenDto>.Fail("Refresh token wrong or not available!", 404, true);

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) return Response<TokenDto>.Fail("Something went wrong!", 400, true);
            var newToken = _tokenService.CreateToken(user);
            existRefreshToken.RefreshToken = newToken.RefreshToken;
            existRefreshToken.RefreshTokenExpiration = newToken.RefreshTokenExpiration;
            await _uow.CommitAsync();
            return Response<TokenDto>.Success(newToken, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _refreshTokenRepo.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null)
                return Response<NoDataDto>.Fail("Refresh token is not avaliable!", 404, true);

            _refreshTokenRepo.Remove(existRefreshToken);
            await _uow.CommitAsync();

            return Response<NoDataDto>.Success(200);
        }
    }
}
