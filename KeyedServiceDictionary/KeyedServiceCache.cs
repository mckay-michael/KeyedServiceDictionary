using System;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedServiceDictionary;

public class KeyedServiceCache<TKey, TService> : IKeyedServiceCache<TKey, TService>
{
    public TKey[] Keys { get; }

    public KeyedServiceCache(IServiceCollection serviceDescriptors)
    {
        Keys = serviceDescriptors
            .Where(service => service.ServiceKey != null
                && service.ServiceKey!.GetType() == typeof(TKey)
                && service.ServiceType == typeof(TService))
            .Select(service => (TKey)service.ServiceKey!)
            .ToArray();
    }
}

