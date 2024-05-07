
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UniversityAssignment.Infrastructure.Abstract;
using UniversityAssignment.Infrastructure.Persistance;


namespace UniversityAssignment.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<UniversityDBContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());
        services.AddScoped<IUniversityRepository, UniversityRepository>();


        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        services.AddAutoMapper(applicationAssembly);
        services.AddHttpContextAccessor();

    }
}
