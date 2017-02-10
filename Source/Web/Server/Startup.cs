using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Helpers;

namespace ScotlandsMountains.Web.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddMvc();b

            services
                .AddCors()
                .AddMvcCore()
                .AddJsonFormatters(x =>
                {
                    x.Formatting = Newtonsoft.Json.Formatting.Indented;
                    x.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddDataAnnotations();

            services.Configure<Configuration>(Configuration.GetSection("ScotlandsMountains"));

            services.AddSingleton<IDomainRoot>(x => DomainRoot.Load());
            services.AddSingleton<IEmailHelper,EmailHelper>();
            services.AddSingleton<IRecaptchaHelper, RecaptchaHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
                .UseSpaRouting()
                .UseStaticFiles()
                .UseCors(builder => builder
                    .WithOrigins(
                        "https://scotlandsmountains.net",
                        "http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseMvc();
        }
    }

    public static class SpaRoutingExtension
    {
        public static IApplicationBuilder UseSpaRouting(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
        }
    }
}
