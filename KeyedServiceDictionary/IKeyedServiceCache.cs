namespace KeyedServiceDictionary;

public interface IKeyedServiceCache<TKey, TService>
{
    TKey[] Keys { get; }
}