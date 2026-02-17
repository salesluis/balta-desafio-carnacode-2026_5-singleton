using DesignPatternChallenge.Singletons;

namespace DesignPatternChallenge.Services;

public class CacheService
{
    private static readonly Lazy<CacheService> _instance =
        new(() => new CacheService());

    private readonly ConfigurationManagerSingleton _config;

    public CacheService()
    {
        // Problema: Mais uma instância duplicada
        _config =  ConfigurationManagerSingleton.GetInstance;
    }

    public void Connect()
    {
        var cacheServer = _config.GetSetting("CacheServer");
        Console.WriteLine($"[CacheService] Conectando ao cache: {cacheServer}");
    }

    public static CacheService GetInstance() => _instance.Value;
}