using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WorkJwtExampleServer.Core.DTOs;
using WorkJwtExampleServer.Core.Entities;

namespace WorkJwtExampleServer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<FlashCard, FlashCardDto>().ReverseMap();
            CreateMap<AppUser, AppUserLoginDto>().ReverseMap();
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            
        }
    }
}
