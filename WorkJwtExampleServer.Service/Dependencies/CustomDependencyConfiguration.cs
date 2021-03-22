using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WorkJwtExampleServer.Core.Repositories;
using WorkJwtExampleServer.Core.Services;
using WorkJwtExampleServer.Core.UnitOfWork;
using WorkJwtExampleServer.Data.Repositories;
using WorkJwtExampleServer.Data.UnitOfWork;
using WorkJwtExampleServer.Service.Services;

namespace WorkJwtExampleServer.Service.Dependencies
{
    public static class CustomDependencyConfiguration
    {
        public static void AddCustomDependencyConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
