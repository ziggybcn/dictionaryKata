using System.Collections.Concurrent;
using System.Diagnostics;

// ReSharper disable PossibleMultipleEnumeration

namespace Kata;

public class AnagramsKata
{
    private const int MinimumWordsToBeAnAnagram = 2;
    private readonly List<AnagramGroup> _anagrams = new(5000);

    public IEnumerable<IEnumerable<string>> Anagrams => _anagrams;

    public long CalculateAnagrams(Stream stream, bool verbose = false)
    {
        ClearUpFromPreviousIteration();

        var time = Stopwatch.StartNew();

        var words = GetAllWords(stream);
        var wordHashTuplesList = GenerateWordsHashTuples(words);
        ProcessAllDictionaryWords(wordHashTuplesList);

        var timeLapse = time.ElapsedMilliseconds;

        if (verbose){
            Console.WriteLine("Time it took to calculate anagrams: " + timeLapse + "ms");
            Console.WriteLine(
                $"There are {_anagrams.Count()} anagram groups in the dictionary of {wordHashTuplesList.Count()} words.");
        }

        GC.Collect(); //Prevent garbage to impact on subsequent executions of the algorithm.
        return timeLapse;
    }

    private void ClearUpFromPreviousIteration()
    {
        _anagrams.Clear(); //this will generate tones of garbage so we're collecting before the algorithm kicks in.
        GC.Collect();
    }

    private void ProcessAllDictionaryWords(IEnumerable<WordHashTuple> dictionaryWords)
    {
        var anagramsIdDictionary = new Dictionary<string, AnagramGroup>();
        foreach (var dictionaryWord in dictionaryWords)
            ProcessWord(anagramsIdDictionary, dictionaryWord);
    }

    private static IEnumerable<WordHashTuple> GenerateWordsHashTuples(IEnumerable<string> words)
    {
        var wordHashTuples = new ConcurrentBag<WordHashTuple>();

        Parallel.ForEach(words, word =>
        {
            var item = new WordHashTuple (word.CreateAnagramHash(), word);
            wordHashTuples.Add(item);
        });
        return wordHashTuples;
    }

    private static List<string> GetAllWords(Stream stream)
    {
        const int expectedDictionaryWords = 56000;

        var dictionaryWordsReader = new StreamReader(stream);

        var words = new List<string>(expectedDictionaryWords);

        var currentWord = dictionaryWordsReader.GetNextDictionaryWord();

        while (!dictionaryWordsReader.EndOfStream){
            words.Add(currentWord);
            currentWord = dictionaryWordsReader.GetNextDictionaryWord();
        }

        return words;
    }

    private void ProcessWord(IDictionary<string, AnagramGroup> anagramsIdDictionary, WordHashTuple word)
    {
        var thisAnagramGroupExists = anagramsIdDictionary.TryGetValue(word.AnagramHash, out var anagramsGroup);
        if (thisAnagramGroupExists){
            AddWordToExistingAnagramsGroup(word, anagramsGroup!);
        }
        else{
            anagramsGroup = new AnagramGroup { word.Word };
            anagramsIdDictionary.Add(word.AnagramHash, anagramsGroup);
        }
    }

    private void AddWordToExistingAnagramsGroup(WordHashTuple word, AnagramGroup anagramsGroup)
    {
        if (anagramsGroup.Contains(word.Word)) return;
        anagramsGroup.Add(word.Word);
        if (anagramsGroup is { Count: >= MinimumWordsToBeAnAnagram, MarkedAsValidAnagramGroup: false }){
            _anagrams.Add(anagramsGroup);
            anagramsGroup.MarkedAsValidAnagramGroup = true;
        }
    }
    private class AnagramGroup : List<string>
    {
        public bool MarkedAsValidAnagramGroup;
    }
}