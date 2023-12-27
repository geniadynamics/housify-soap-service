using System;
namespace utils;

using System;
using System.IO;

public class EnvironmentVariablesLoader
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            utils.Logger.Log.Info(
                "Proceding without loading local .env variables file."
            );
            return;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('=', 2);
            if (parts.Length != 2)
            {
                throw new FormatException("Invalid environment variable format");
            }

            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
        }
    }
}