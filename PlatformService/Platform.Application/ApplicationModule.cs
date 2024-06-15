using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Platform.Application;

public static class ApplicationModule
{
    public static IServiceCollection LoadApplicationDependencies(this IServiceCollection service)
    {
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return service;
    }
}
