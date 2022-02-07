using Jamatu.Auth.Api.Registration;
using Jamatu.Auth.Application.Registration;
using Jamatu.Auth.Data.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jamatu.Auth.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDataModule()
                .AddApplicationModule()
                .AddApiModule(Configuration, Environment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDataModule()
                .UseApiModule(env, Configuration);
        }
    }
}
