using System.Diagnostics.CodeAnalysis;
namespace Kata;

[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
public struct WordHashTuple
{
    public WordHashTuple (string hash, string word)
    {
        AnagramHash = hash;
        Word = word;
    }
    public string AnagramHash;
    public string Word;
}