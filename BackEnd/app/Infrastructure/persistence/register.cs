﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace persistence
{
   public static class register
    {
        public static void AddPersistence(this IServiceCollection services , IConfiguration configuration) {
            
            services.AddDbContext<AddDbContexts>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnect")));
                
        }
    }
}
