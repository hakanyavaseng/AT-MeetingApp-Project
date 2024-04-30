using MeetingApp.Service.Services.Abstractions;
using MeetingApp.Service.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeetingApp.Service.Extensions
{
    public static class ServiceLayerExtensions 
    {
        public static void AddServiceLayerExtensions(this IServiceCollection services)
        {
            //Adding services
            services.AddScoped<IUserService, UserService>();

            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
