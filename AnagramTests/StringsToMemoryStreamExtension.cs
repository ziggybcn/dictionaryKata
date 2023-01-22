namespace AnagramTests;
/// <summary>
/// This is just an extension class to allow strings to be converted to MemoryStreams easily.
/// </summary>
internal static class StringsToMemoryStreamExtension
{
    /// <summary>
    /// This extension method converts a String into a MemoryStream that contains the string content
    /// </summary>
    internal static Stream ToMemoryStream(this string data)
    {
        var stream = new MemoryStream();

        var stringWriter = new StreamWriter(stream);

        stringWriter.Write(data);
        stringWriter.Flush();
        stream.Position = 0;
        return stream;
    }
}