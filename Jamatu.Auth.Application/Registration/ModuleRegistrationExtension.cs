using FluentValidation;
using Jamatu.Auth.Application.Infrastructure;
using Jamatu.Auth.Application.Services;
using Jamatu.Auth.Core.Helper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jamatu.Auth.Application.Registration
{
    public static class ModuleRegistrationExtension
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<TokenHelper>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMappingAdapter, MappingAdapter>();
            return services;
        }
    }
}
