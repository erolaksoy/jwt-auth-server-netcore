using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Services;

namespace WorkJwtExampleServer.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthService _authService;
     
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(AppUserLoginDto appUserLoginDto)
        {
            var result = await _authService.CreateTokenAsync(appUserLoginDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientDto clientDto)
        {
            var result = _authService.CreateTokenByClientAsync(clientDto);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.RevokeRefreshToken(refreshTokenDto.RefreshToken);
            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.CreateTokenByRefreshTokenAsync(refreshTokenDto.RefreshToken);
            return ActionResultInstance(result);
        }
    }
}
