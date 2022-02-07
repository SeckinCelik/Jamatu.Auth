using Jamatu.Auth.Api.Middleware;
using Jamatu.Auth.Core.Model;
using Jamatu.Auth.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jamatu.Auth.Api.Registration
{
    public static class ModuleRegistrationExtension
    {
        public static IServiceCollection AddApiModule(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment Environment)
        {
            services.AddControllers();

            if (Environment.IsProduction())
                services.AddDbContext<DataContext>();
            else
                services.AddDbContext<DataContext, SqlLiteDbContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);



            return services;
        }
        public static IApplicationBuilder UseApiModule(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(env.IsDevelopment() ? "/error-local-development" : "/error");

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
