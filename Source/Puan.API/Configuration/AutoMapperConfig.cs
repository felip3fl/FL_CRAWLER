using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Puan.API.Models;
using Puan.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puan.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public static void RegisterMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<PointTimeModel, PointTime> ();
                    cfg.CreateMap<PointTime, PointTimeModel>();
                }
                );

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
