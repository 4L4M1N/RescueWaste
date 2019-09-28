using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using RescueWaste.API.Data;
using RescueWaste.API.Helpers;
using RescueWaste.API.Models;
using RescueWaste.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace RescueWaste.API
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("RescueWasteDB")
                )
            );
            services.AddControllers();
            
            services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<DataContext>();
            services.AddMvc()
             .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling =            
                Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .ConfigureApiBehaviorOptions(options =>{
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressMapClientErrors = true;
                // options.SuppressModelStateInvalidFilter = false;
                //options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;
                
                // For Model Error!
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    return result;
                };
            });

            // Automapper configuaration

            services.AddCors();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IPromocodeRepository, PromocodeRepository>();

            // Cloudinary Settings

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>{
                    builder.Run(async context => {
                        //Save error code to context
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        
                        //store errors 
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error!=null)
                        {
                            //Save message to context
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseHttpsRedirection();
            
            
        }
    }
}
