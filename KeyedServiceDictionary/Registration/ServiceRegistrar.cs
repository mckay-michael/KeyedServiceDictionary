using System;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedServiceDictionary.Registration;

public static class ServiceRegistrar
{
    public static void AllowResolvingKeyedServicesAsDictionary(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IKeyedServiceCache<,>), typeof(KeyedServiceCache<,>));

        services.AddSingleton(services);

        services.AddTransient(typeof(IKeyedServiceDictionary<,>), typeof(KeyedServiceDictionary<,>));
    }
}