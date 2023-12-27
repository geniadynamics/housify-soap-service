using System;
using System.IO;

namespace utils
{
    /// <summary>
    /// Utility class for loading environment variables from a file.
    /// </summary>
    public class EnvironmentVariablesLoader
    {
        /// <summary>
        /// Loads environment variables from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the .env file.</param>
        public static void Load(string filePath)
        {
            // Check if the file exists.
            if (!File.Exists(filePath))
            {
                // Log a message and proceed without loading local .env variables file.
                utils.Logger.Log.Info("Proceeding without loading local .env variables file.");
                return;
            }

            // Read each line from the file and set environment variables.
            foreach (var line in File.ReadAllLines(filePath))
            {
                // Split the line into key and value parts.
                var parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid environment variable format");
                }

                // Set the environment variable.
                Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
            }
        }
    }
}
