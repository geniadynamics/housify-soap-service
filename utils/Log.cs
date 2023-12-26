using NLog;

using System;
namespace utils;

/// <summary>
///     Logger Class
/// </summary>
public static class Logger
{
    /// <summary>
    ///     Where to store logs on the server.
    /// </summary>
    private static readonly string LogPath = "file.log";

    /// <summary>
    ///     Logger method
    /// </summary>
    public static readonly NLog.Logger Log =
        NLog.LogManager.GetCurrentClassLogger();

    /// <summary>
    ///     Init Logger
    /// </summary>
    public static void LoggerInit()
    {
        NLog.LogManager.Setup().LoadConfiguration(builder =>
        {
            builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
            builder.ForLogger()
                .FilterMinLevel(LogLevel.Debug)
                .WriteToFile(fileName: LogPath);
        });
    }
}