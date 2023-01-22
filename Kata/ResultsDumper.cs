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
        foreach (var group in _anagrams){
            DumpAnagramsGroup(group);
        }
    }

    private void DumpAnagramsGroup(IEnumerable<string> list)
    {
        foreach (var item in list){
            Console.Write(item + ", ");
        }

        Console.WriteLine();
    }
}