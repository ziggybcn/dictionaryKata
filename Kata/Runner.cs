namespace Kata;

public static class Runner
{
    const long NumberOfIterations = 250;

    /// <summary>
    /// This method is the entry point of the kata. It executes the algorithm a number of times and gets
    /// the best iteration time, and the average iteration time.
    /// </summary>
    public static int Main(string[] args)
    {
        var bestExecutionTime = long.MaxValue;
        long accumulated = 0;

        var filePath = AppDomain.CurrentDomain.BaseDirectory + "/documents/English.txt";

        ShowResultsOfOneIteration(filePath);

        Console.WriteLine($"Running the anagrams kata {NumberOfIterations} iterations...");

        for (var i = 0; i < NumberOfIterations; i++){
            var kata = new AnagramsKata();
            var dataStream = new FileStream(filePath, FileMode.Open);
            var executionTime = kata.CalculateAnagrams(dataStream);
            bestExecutionTime = long.Min(bestExecutionTime, executionTime);
            accumulated += executionTime;
        }

        var averageTime = accumulated / NumberOfIterations;
        Console.WriteLine($"Best execution time was {bestExecutionTime}ms and average time is {averageTime}ms");
        return 0;
    }

    private static void ShowResultsOfOneIteration(string filePath)
    {
        var kataExecutor = new AnagramsKata();
        var stream = new FileStream(filePath, FileMode.Open);
        kataExecutor.CalculateAnagrams(stream);
        var dumper = new ResultsDumper(kataExecutor);
        dumper.ShowResultsInConsole();
    }
}