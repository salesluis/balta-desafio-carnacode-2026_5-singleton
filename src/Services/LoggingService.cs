using DesignPatternChallenge.Singletons;

namespace DesignPatternChallenge.Services;

public class LoggingService
{
    private static readonly Lazy<LoggingService> _instance =
        new(() => new LoggingService());

    private readonly ConfigurationManagerSingleton _config;
    
    public LoggingService()
    {
        _config = ConfigurationManagerSingleton.GetInstance;
    }
    
    public void Log(string message)
    {
        var logLevel = _config.GetSetting("LogLevel");
        Console.WriteLine($"[LoggingService] [{
            
            logLevel}] {message}");
    }
    
    public static LoggingService GetInstance() => _instance.Value;
}