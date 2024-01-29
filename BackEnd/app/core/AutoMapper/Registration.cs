using Application.Interfaces.AutoMapper;
using Mapper.Mapppers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public static class Registration
    {
        public static void AddMapper( this IServiceCollection services)
        {
            services.AddSingleton<IAutoMapper,AutoMapperCommon>();
        }
    }
}
