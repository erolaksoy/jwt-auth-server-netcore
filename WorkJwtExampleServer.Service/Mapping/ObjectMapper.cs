using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace WorkJwtExampleServer.Service.Mapping
{
    public static class ObjectMapper
    {
        public static IMapper Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            return config.CreateMapper();
        }
    }
}
