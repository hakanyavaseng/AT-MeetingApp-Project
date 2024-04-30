using MeetingApp.Service.Auth;
using MeetingApp.Service.Services.Abstractions;
using MeetingApp.Service.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeetingApp.Service.Extensions
{
    public static class ServiceLayerExtensions 
    {
        public static void AddServiceLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding services
            services.AddScoped<IUserService, UserService>();

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Token service 
            services.AddTransient<ITokenService, TokenService>(); 


        }
    }
}
