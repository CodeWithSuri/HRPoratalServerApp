using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HRPoratalServerApp.RepositoryPattren;

namespace HRPoratalServerApp.Models
{
    public static class ServiceExtensios
    {


        //public static void ConfigureDBConnection(this IServiceCollection services,IConfiguration configuration)
        //{

        //    var connstring = configuration["HRComPortalDbContextConnection"];

        //    services.AddDbContext<RepositryPattrenContext>(con => con.UseSqlServer(connstring));
           
        //}


        //public static void ConfigureRepoWrapper(this IServiceCollection services)
        //{

           
        //}
    }
}
