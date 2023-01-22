
namespace Kata;
/// <summary>
/// This class gets a collection of WordHashTuple elements, and detects all of the items that have the same agram hash.
/// </summary>
internal class DictionaryProcessor
{
    private const int MinimumWordsToBeAnAnagram = 2;
    // ReSharper disable once InconsistentNaming (I prefer code-fields to be uppercase)
    private Action<AnagramGroup> NewAnagramGroupAction;
    private readonly IEnumerable<WordHashTuple> _dictionaryWords;

    internal DictionaryProcessor(IEnumerable<WordHashTuple> dictionary)
    {
        _dictionaryWords = dictionary;
        NewAnagramGroupAction = (_) => { };
    }
    
/// <summary>
/// This method goes through all the elements in the dictionary and detects all groups of anagrams.
/// </summary>
/// <param name="newAnagramAction">This action will be invoked whenever a new group of anagrams is detected in the dictionary.</param>
    internal void GroupAllAnagrams(Action<AnagramGroup> newAnagramAction)
    {
        NewAnagramGroupAction = newAnagramAction;
        var anagramsIdDictionary = new Dictionary<string, AnagramGroup>();
        foreach (var dictionaryWord in _dictionaryWords)
            ProcessWord(anagramsIdDictionary, dictionaryWord);
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
            NewAnagramGroupAction(anagramsGroup);
            anagramsGroup.MarkedAsValidAnagramGroup = true;
        }
    }
    
    
}