namespace AnagramTests;
using Kata;
using FluentAssertions;

public class StreamReaderTests
{
    
    [Test]
    public void StreamReaderCanReadLastWord([Values("TEST", "COSA", "PEPITO")] string data)
    {
        var reader = new StreamReader(data.ToMemoryStream());
        reader.GetNextWord().Should().Be(data.ToLowerInvariant());
    }

    [Test, Sequential]
    public void StreamReaderIgnoresNonValidCharacters(
        [Values("Hola's", "co-sa")] string input, 
        [Values("holas", "cosa")] string output)
    {
        
        var reader = new StreamReader(input.ToMemoryStream());
        reader.GetNextWord().Should().Be(output);
    }

    [Test, Sequential]
    public void StreamReaderRemovesGarbage(
        [Values("Hola/W45", "tExto/JARL")] string input, 
        [Values("hola", "texto")] string output)
    {
        
        var reader = new StreamReader(input.ToMemoryStream());
        reader.GetNextWord().Should().Be(output);
    }
 
    [Test]
    public void StreamReaderParsesLines()
    {
        var input = "Hola\nCosa\nQue";
        
        var reader = new StreamReader(input.ToMemoryStream());
        var result = new List<string>();
        do
        {
            result.Add(reader.GetNextWord());
        } while (!reader.EndOfStream);

        result.Should().Contain("hola", "cosa", "que").And.HaveCount(3);
        
    }
}