﻿using MeetingApp.Data.Contexts;
using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Data.Repositories.Concretes;
using MeetingApp.Entity.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MeetingApp.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static void AddDataLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<MeetingAppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });

            //Identity
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<MeetingAppDbContext>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //RepositoryManager
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            
        }
    }
}
