using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScotlandsMountains.Domain;
using Newtonsoft.Json.Serialization;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method tadd services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(x => {
                    x.Formatting = Newtonsoft.Json.Formatting.Indented;
                    x.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton(x => DomainRoot.Load());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
        }
    }
}
