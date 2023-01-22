namespace Kata;

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