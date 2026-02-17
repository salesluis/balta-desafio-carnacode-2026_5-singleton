using DesignPatternChallenge.Singletons;

namespace DesignPatternChallenge.Services;

public class DatabaseService
{
    private static readonly Lazy<DatabaseService> _instance =
        new(() => new DatabaseService());

    private readonly ConfigurationManagerSingleton _config;

    public DatabaseService()
    {
        _config = ConfigurationManagerSingleton.GetInstance;
    }

    public void Connect()
    {
        var connectionString = _config.GetSetting("DatabaseConnection");
        Console.WriteLine($"[DatabaseService] Conectando ao banco: {connectionString}");
    }
    
    public static DatabaseService GetInstance() => _instance.Value;
}