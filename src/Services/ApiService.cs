using DesignPatternChallenge.Singletons;

namespace DesignPatternChallenge.Services;

public class ApiService
{
    private static readonly Lazy<ApiService> _instance =
        new(() => new ApiService());

    private readonly ConfigurationManagerSingleton _config;

    public ApiService()
    {
        // Problema: Nova instância = novos carregamentos desnecessários
        _config =  ConfigurationManagerSingleton.GetInstance;
    }

    public void MakeRequest()
    {
        var apiKey = _config.GetSetting("ApiKey");
        Console.WriteLine($"[ApiService] Fazendo requisição com API Key: {apiKey}");
    }

    public static ApiService GetInstance() => _instance.Value;
}