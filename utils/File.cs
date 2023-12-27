using System.Text;
namespace utils;

/// <summary>
///     File Class
/// </summary>
public static class FileHandler
{
    /// <summary>
    ///     write text to a file asynchronously.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="text"></param>
    /// <returns>an awaitable task</returns>
    public static async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.UTF8.GetBytes(text);

        await using var sourceStream = new FileStream(
                   filePath, FileMode.Append, FileAccess.Write, FileShare.None,
                   bufferSize: 4096, useAsync: true);

        await sourceStream.WriteAsync(encodedText);

    }

    /// <summary>
    ///     Copy files asynchronously.
    /// </summary>
    /// <param name="sourceFile"> source path</param>
    /// <param name="destinationFile"> destination path</param>
    /// <returns> An awaitable Task </returns>
    public static async Task CopyFileAsync(string sourceFile,
                                           string destinationFile)
    {
        using var sourceStream = new FileStream(
                sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
                FileOptions.Asynchronous |
                    FileOptions
                        .SequentialScan); using var destinationStream =
                                                     new FileStream(
                                                         destinationFile,
                                                         FileMode.CreateNew,
                                                         FileAccess.Write,
                                                         FileShare.None, 4096,
                                                         FileOptions.Asynchronous |
                                                             FileOptions
                                                                 .SequentialScan);
        await sourceStream.CopyToAsync(destinationStream);
    }
}