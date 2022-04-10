﻿using System.Reflection;
using EasyMed.Application.Utils.SecurityTokens;
using EasyMed.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EasyMed.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ApplicationSettings settings)
    {
        services.AddSingleton(settings);
        services.AddSingleton(settings.AccessTokenSettings);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ISecurityTokenService, SecurityTokenService>();
        
        return services;
    }
}