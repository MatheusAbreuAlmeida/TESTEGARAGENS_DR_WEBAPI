using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TESTEGARAGENS_DR_WEBAPI.Data;

namespace TESTEGARAGENS_DR_WEBAPI
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
            services.AddDbContext<DAL>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("TesteGaragensAPI",
                         new Microsoft.OpenApi.Models.OpenApiInfo()
                         {
                             Title = "Teste Garagens Web API",
                             Version = "1.0",
                             Description = "API de teste Garagens, Estapar e Digital Republic_",
                             License = new Microsoft.OpenApi.Models.OpenApiLicense
                             {
                                Name = "Digital Republic_",
                                Url = new Uri("https://www.digitalrepublic.com.br/")
                             },
                             Contact = new Microsoft.OpenApi.Models.OpenApiContact
                             {
                                Name = "Matheus Abreu de Almeida",
                                Email = "matheus.a.contato@outlook.com",
                                Url = new Uri("https://github.com/MatheusAbreuAlmeida")
                             }
                         }

                    );

                 var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                 options.IncludeXmlComments(xmlCommentsFullPath);

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
               .UseSwaggerUI(Options =>
               {
                   Options.SwaggerEndpoint("/swagger/TesteGaragensAPI/swagger.json", "TesteGaragensAPI");
                   Options.RoutePrefix = "";
               })
            ;
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
