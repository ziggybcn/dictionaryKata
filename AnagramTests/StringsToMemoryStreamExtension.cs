namespace AnagramTests;

internal static class StringsToMemoryStreamExtension
{
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