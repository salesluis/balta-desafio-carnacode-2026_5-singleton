using DesignPatternChallenge.Services;
using DesignPatternChallenge.Singletons;

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Configurações ===\n");
            
            Console.WriteLine("Inicializando serviços...\n");
            
            var dbService = DatabaseService.GetInstance();
            var apiService = ApiService.GetInstance();
            var cacheService = CacheService.GetInstance();
            var logService = LoggingService.GetInstance();

            Console.WriteLine("\nUsando os serviços...\n");
            
            dbService.Connect();
            apiService.MakeRequest();
            cacheService.Connect();
            logService.Log("Sistema iniciado");
            
            Console.WriteLine("\n--- Tentativa de atualização ---\n");
            
            var config1 = ConfigurationManagerSingleton.GetInstance;
            config1.LoadConfigurations();
            config1.UpdateSetting("LogLevel", "Debug");

            var config2 = ConfigurationManagerSingleton.GetInstance;
            config2.LoadConfigurations();
            Console.WriteLine($"Config1 LogLevel: {config1.GetSetting("LogLevel")}");
            Console.WriteLine($"Config2 LogLevel: {config2.GetSetting("LogLevel")}");
            Console.WriteLine("⚠️ Inconsistência: Instâncias diferentes têm valores diferentes!");

            // Problema 3 Resolvido: Desperdício de memória e processamento sanado 
            // pois agora trabalhamos com as mesmas instancias sem nescessidade de
            // crair novas
            Console.WriteLine("\n--- Impacto de Performance ---");
            Console.WriteLine("Cada serviço carregou as mesmas configurações");
            Console.WriteLine("Isso otimiza o uso de memória e tempo de inicialização");
        }
    }