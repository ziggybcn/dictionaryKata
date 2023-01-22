using System.Text;

namespace Kata;

/// <summary>
///     This is an extension class for the StreamReader class that allows us to read a stream of text with the required
///     formatting for this Kata, so no additional processing is required.
/// </summary>
public static class StreamReaderDictionaryExtension
{
    private const int DefaultWordSize = 16;

    private static readonly StringBuilder WordBuilder = new(DefaultWordSize);

    //private static List<char> wordChars = new(defaultWordSize);
    /// <summary>
    ///     Returns the next word in a stream. It will normalize the word to lowercase and ignore any non a-z character.
    ///     Also, it will ignore any character following a slash.
    ///     The End of line character (chr 10) will be considered the end of the word.
    /// </summary>
    /// <returns>A string containing the word, or an empty string if the stream is empty or there are no more word to return.</returns>
    public static string GetNextDictionaryWord(this StreamReader reader)
    {
        while (true){
            if (reader.EndOfStream) return string.Empty;
            WordBuilder.Clear();
            var garbageCharacters = false;
            var endOfWord = false;

            while (!endOfWord){
                var character = (char)reader.Read();
                if (character == '/') garbageCharacters = true;
                if (character == '\n') endOfWord = true;
                if (!endOfWord && !garbageCharacters && character.IsValid()) 
                    WordBuilder.Append(char.ToLowerInvariant(character));
                if (reader.EndOfStream) endOfWord = true;
            }
            if (WordBuilder.Length != 0) 
                return WordBuilder.ToString();
            if (reader.EndOfStream) 
                return string.Empty;
        }
    }

    private static bool IsValid(this char chr)
    {
        return chr is >= 'a' and <= 'z' || chr is >= 'A' and <= 'Z';
    }
}