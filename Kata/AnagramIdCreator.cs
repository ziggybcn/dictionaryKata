namespace Kata;

public static class AnagramIdCreator {
    /// <summary>
    /// This method returns an anagram identifier for the given string.
    /// Any string with the same letters will have the same anagram identifier.
    /// Notice that this function is case sensitive.
    /// </summary>
    /// <returns>The anagram ID.</returns>
    public static string CreateAnagramHash(this string origin)
    {
        return origin.Length == 0 ? "" : new(origin.OrderDescending().ToArray());
    } 

    
}
