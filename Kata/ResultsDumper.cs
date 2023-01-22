namespace Kata;

internal class ResultsDumper
{
    private readonly IEnumerable<IEnumerable<string>> _anagrams;

    public ResultsDumper(AnagramsKata kata)
    {
        _anagrams = kata.Anagrams;
    }

    internal void ShowResultsInConsole()
    {
        Console.WriteLine($"There are {_anagrams.Count()} anagram groups:");
        foreach (var group in _anagrams) DumpAnagramsGroup(group);
    }

    private void DumpAnagramsGroup(IEnumerable<string> list)
    {
        var items = string.Join(",", list);
        Console.WriteLine("{" + items + "}");
    }
}