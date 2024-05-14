using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityAssignment.Infrastructure.Abstract;
using UniversityAssignment.Infrastructure;

namespace UniversityAssignment.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();

        services.AddScoped<IUniversityRepository, UniversityRepository>();

        services.AddHttpContextAccessor();
    }
}