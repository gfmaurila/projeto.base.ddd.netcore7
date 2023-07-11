﻿using Application.Services;
using Application.Validators;
using Data.Repository.Repositories;
using Data.Repository.Repositories.EF;
using Data.SQLServer.Config;
using Domain.Contract.Repositories;
using Domain.Contract.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC;
public class Config
{
    public static void ConfigDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
    }

    public static void ConfigRepository(IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IUserRepository, UserEFRepository>();
    }

    public static void ConfigService(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

    public static void ConfigValidator(IServiceCollection services)
    {
        services.AddScoped<CreateUserValidator>();
    }

    public static void ConfigBusService(IServiceCollection services)
    {
    }
}
