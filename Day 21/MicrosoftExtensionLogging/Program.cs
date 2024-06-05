
using Microsoft.Extensions.Logging;
using System;

class Program
{
    // Create a LoggerFactory instance
    private static readonly ILoggerFactory LoggerFactory = LoggerFactory.Create(builder =>
    {
        // Add console logger
        builder.AddConsole();
        // You can add other logging providers here (e.g., AddDebug, AddFile, etc.)
    });

    // Create a logger
    private static readonly ILogger Logger = LoggerFactory.CreateLogger<Program>();

    static void Main(string [] args)
    {
        // Example log messages
        Logger.LogInformation("Information log");
        Logger.LogWarning("Warning log");
        Logger.LogError("Error log");

        try
        {
            // Simulate an exception
            throw new Exception("Exception occurred");
        }
        catch (Exception ex)
        {
            // Log exception details
            Logger.LogError(ex, "Exception log");
        }

        Console.ReadKey();
    }
}
