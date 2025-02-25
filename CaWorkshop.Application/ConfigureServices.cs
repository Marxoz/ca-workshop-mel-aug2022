﻿using System.Reflection;
using CaWorkshop.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(PerformanceBehaviour<,>));
        
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(UnhandledExceptionBehaviour<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));

        return services;
    }
}