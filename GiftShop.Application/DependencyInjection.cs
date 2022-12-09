using GiftShop.Application.Services;
using GiftShop.Application.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GiftShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Identity            
            services.AddTransient<IdentityInitializerService>();

            // Services            
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}