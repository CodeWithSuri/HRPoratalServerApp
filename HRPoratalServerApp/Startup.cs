using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPoratalServerApp.Repositories;
using HRPoratalServerApp.Models;
using HRPoratalServerApp.RepositoryPattren;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRPoratalServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            /**Add custoum extenstion methods to service */
            services.AddDbContext<RepositryPattrenContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("HRComPortalDbContextConnection")));

            services.AddSingleton<IEmpRepo, EmpRepo>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            /**Add custoum extenstion methods to service */

            

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                ).AddJwtBearer(options =>
                {

                    options.SaveToken = true;

                    options.RequireHttpsMetadata = true;

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {


                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "http://localhost:54552/",
                        ValidAudience = "http://localhost:54552/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Amar00547455Amar"))
                    };

                });

            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id}"
                    );
            });

        }
    }
}
