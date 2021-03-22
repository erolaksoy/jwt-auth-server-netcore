using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Services;
using WorkJwtExampleServer.Service.Mapping;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        

        public async Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var newUser = new AppUser
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email
            };
            var result = await _userManager.CreateAsync(newUser, createUserDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<AppUserDto>.Fail(new CustomError(errors,true),400);
            }
            return Response<AppUserDto>.Success(ObjectMapper.Mapper().Map<AppUserDto>(newUser),201);
        }

        public async Task<Response<AppUserDto>> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user==null) return Response<AppUserDto>.Fail("User is not avaliable",404,true);
            return Response<AppUserDto>.Success(ObjectMapper.Mapper().Map<AppUserDto>(user),200);
        }
    }
}
