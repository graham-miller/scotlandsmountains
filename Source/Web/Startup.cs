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
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters(x => {
                    x.Formatting = Newtonsoft.Json.Formatting.Indented;
                    x.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton(x => DomainRoot.Load());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
