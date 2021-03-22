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
            CreateMap<FlashCard, FlashCardAddDto>().ReverseMap();
            CreateMap<AppUser, AppUserLoginDto>().ReverseMap();
        }
    }
}
