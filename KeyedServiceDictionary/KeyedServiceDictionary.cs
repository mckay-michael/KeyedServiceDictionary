using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedServiceDictionary;

public class KeyedServiceDictionary<TKey, TService> :
    ReadOnlyDictionary<TKey, TService>,
    IKeyedServiceDictionary<TKey, TService>
        where TKey : notnull
        where TService : notnull
{
    public KeyedServiceDictionary(
        IKeyedServiceCache<TKey, TService> keys,
        IServiceProvider provider) : base(Create(keys, provider)) { }

    private static Dictionary<TKey, TService> Create(
        IKeyedServiceCache<TKey, TService> keys,
        IServiceProvider provider)
    {
        var dict = new Dictionary<TKey, TService>(capacity: keys.Keys.Length);

        foreach (TKey key in keys.Keys)
        {
            dict[key] = provider.GetRequiredKeyedService<TService>(key);
        }

        return dict;
    }
}

