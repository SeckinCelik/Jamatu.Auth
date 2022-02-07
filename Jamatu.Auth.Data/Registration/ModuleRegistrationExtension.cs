using Jamatu.Auth.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jamatu.Auth.Data.Registration
{
    public static class ModuleRegistrationExtension
    {
        public static IServiceCollection AddDataModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }
        public static IApplicationBuilder UseDataModule(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DbContext>();
            context?.Database.Migrate();

            return app;
        }
    }
}
