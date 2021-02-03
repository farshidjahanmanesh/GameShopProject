using AutoMapper;
using ServiceLayer.AutoMapperConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest
{
    static class InfrastructureFunctions
    {
        public static IMapper GetMapperInstance()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperServiceLayerProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
