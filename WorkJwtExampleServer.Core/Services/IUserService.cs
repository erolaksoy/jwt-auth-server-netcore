using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<AppUserDto>> GetUserByUserName(string userName);
    }
}
