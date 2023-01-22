namespace Kata;

public static class Runner
{
    public static int Main(string[] args)
    {
        var time = long.MaxValue;
        long accumulated = 0;
        long iterations = 250;
        Console.WriteLine($"Running the anagrams kata {iterations} iterations...");
        for (var i = 0; i < iterations; i++){
            var kata = new AnagramsKata();
            var execution = kata.CalculateAnagrams(new FileStream(@$"{AppDomain.CurrentDomain.BaseDirectory}/documents/English.txt", FileMode.Open));
            if (execution < time) time = execution;
            accumulated += execution;
        }

        Console.WriteLine($"Fastest execution took {time}ms and average time is {accumulated / iterations}ms");
        return 0;
    }
}