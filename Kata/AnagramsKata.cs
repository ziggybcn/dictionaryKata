using System.Collections.Concurrent;
using System.Diagnostics;
// ReSharper disable PossibleMultipleEnumeration

namespace Kata;

public class AnagramsKata
{
    private readonly List<AnagramGroup> _anagrams = new(5000);

    public IEnumerable<IEnumerable<string>> Anagrams => _anagrams;

    public long CalculateAnagrams(Stream stream, bool verbose = false)
    {
        ClearUpFromPreviousIteration();

        var time = Stopwatch.StartNew();
    
        var words = GetAllWords(stream);
        var wordHashTuplesList = GenerateWordsHashTuples(words);
        var dictionaryProcessor = new DictionaryProcessor(wordHashTuplesList);
        dictionaryProcessor.GroupAllAnagrams(
            detectedAnagramGroup => _anagrams.Add(detectedAnagramGroup));
        
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
    
}