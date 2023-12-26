namespace utils;

/// <summary>
///     Security Class
/// </summary>
public static class Security
{
    /// <summary>
    ///     512 bits hash from a string input to string in hex (utf8 encoded)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string SHA512(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashedInputBytes = System.Security.Cryptography.SHA512.HashData(bytes);

        // Convert to text
        // StringBuilder Capacity is 128, 512 bits / 8 bits in byte * 2(hex)
        var hashedInputStringBuilder = new System.Text.StringBuilder(128);
        foreach (var b in hashedInputBytes)
            // Convert to hex.
            hashedInputStringBuilder.Append(b.ToString("x2"));
        return hashedInputStringBuilder.ToString();
    }

    /// <summary>
    ///     256 bits hash from a string input to string in hex (utf8 encoded)
    /// </summary>
    /// <param name="input"> input</param>
    /// <returns>an hash</returns>
    public static string SHA256(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashedInputBytes = System.Security.Cryptography.SHA256.HashData(bytes);

        // Convert to text
        // StringBuilder Capacity is 64, 256 bits / 8 bits in byte * 2(hex)
        var hashedInputStringBuilder = new System.Text.StringBuilder(64);
        foreach (var b in hashedInputBytes)
            // Convert to hex.
            hashedInputStringBuilder.Append(b.ToString("x2"));
        return hashedInputStringBuilder.ToString();
    }

    /// <summary>
    ///     128 bits hash from a string input to string in hex (utf8 encoded)
    /// </summary>
    /// <param name="input">input</param>
    /// <returns> an hash </returns>
    public static string SHA128(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hashedInputBytes = System.Security.Cryptography.SHA1.HashData(bytes);

        // Convert to text
        // StringBuilder Capacity is 32, because 128 bits / 8 bits in byte * 2
        var hashedInputStringBuilder = new System.Text.StringBuilder(32);
        foreach (var b in hashedInputBytes)
            // Convert to hex.
            hashedInputStringBuilder.Append(b.ToString("x2"));
        return hashedInputStringBuilder.ToString();
    }
}