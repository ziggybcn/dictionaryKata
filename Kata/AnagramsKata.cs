using System.Collections.Concurrent;
// ReSharper disable PossibleMultipleEnumeration

namespace Kata;

public class AnagramsKata
{
    private readonly List<AnagramGroup> _anagrams = new(5000);

    public IEnumerable<IEnumerable<string>> Anagrams => _anagrams;

    private const int MinimumWordsToBeAnAnagram = 2;

    public long CalculateAnagrams(Stream stream, bool verbose = false)
    {
        _anagrams.Clear();

        var time = System.Diagnostics.Stopwatch.StartNew();

        var words = GetAllWords(stream);

        var wordHashTuplesList = GenerateWordsHashTuples(words);
        
        ProcessAllDictionaryWords(wordHashTuplesList);

        var timeLapse = time.ElapsedMilliseconds;

        if (verbose){
            Console.WriteLine("Time it took to calculate anagrams: " + timeLapse + "ms");
            Console.WriteLine(
                $"There are {_anagrams.Count()} anagram groups in the dictionary of {wordHashTuplesList.Count()} words.");
        }

        return timeLapse;
    }

    private void ProcessAllDictionaryWords(IEnumerable<WordHashTuple> dictionaryWords)
    {
        var anagramsIdDictionary = new Dictionary<string, AnagramGroup>();
        foreach (var dictionaryWord in dictionaryWords){
            ProcessWord(anagramsIdDictionary, dictionaryWord.Hash, dictionaryWord.Word);
        }
    }

    private static IEnumerable<WordHashTuple> GenerateWordsHashTuples(IEnumerable<string> words)
    {
        var wordHashTuples = new ConcurrentBag<WordHashTuple>();

        Parallel.ForEach(words, word =>
        {
            var item = new WordHashTuple { Hash = word.CreateAnagramHash(), Word = word };
            wordHashTuples.Add(item);
        });
        return wordHashTuples;
    }

    private static List<string> GetAllWords(Stream stream)
    {
        var dictionaryWordsReader = new StreamReader(stream);

        var words = new List<string>(55000);

        var currentWord = dictionaryWordsReader.GetNextWord();
        
        while (!dictionaryWordsReader.EndOfStream){
            words.Add(currentWord);
            currentWord = dictionaryWordsReader.GetNextWord();
        }

        return words;
    }

    private void ProcessWord(IDictionary<string, AnagramGroup> anagramsIdDictionary, string anagramId,
        string currentWord)
    {
        if (anagramsIdDictionary.TryGetValue(anagramId, out AnagramGroup? anagramsGroup) == false){
            anagramsGroup = new AnagramGroup();
            anagramsIdDictionary.Add(anagramId, anagramsGroup);
        }

        if (anagramsGroup.Contains(currentWord) == false)
            anagramsGroup.Add(currentWord);

        if (anagramsGroup is { Count: >= MinimumWordsToBeAnAnagram, AlreadyDetectedAsAnagram: false }){
            _anagrams.Add(anagramsGroup);
            anagramsGroup.AlreadyDetectedAsAnagram = true;
        }
    }

    private class AnagramGroup : List<string>
    {
        public bool AlreadyDetectedAsAnagram;
    }
}