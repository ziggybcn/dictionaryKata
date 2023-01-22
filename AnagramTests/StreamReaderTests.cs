using FluentAssertions;
using Kata;

namespace AnagramTests;

public class StreamReaderTests
{
    [Test]
    public void StreamReaderCanReadLastWord([Values("TEST", "COSA", "PEPITO")] string data)
    {
        var reader = new StreamReader(data.ToMemoryStream());
        reader.GetNextDictionaryWord().Should().Be(data.ToLowerInvariant());
    }

    [Test]
    [Sequential]
    public void StreamReaderIgnoresNonValidCharacters(
        [Values("HolaÑs", "co$sa")] string input,
        [Values("holas", "cosa")] string output)
    {
        var reader = new StreamReader(input.ToMemoryStream());
        reader.GetNextDictionaryWord().Should().Be(output);
    }

    [Test]
    [Sequential]
    public void StreamReaderRemovesGarbage(
        [Values("Hola/W45", "tExto/JARL")] string input,
        [Values("hola", "texto")] string output)
    {
        var reader = new StreamReader(input.ToMemoryStream());
        reader.GetNextDictionaryWord().Should().Be(output);
    }

    [Test]
    public void StreamReaderParsesLines()
    {
        var input = "Hola\nCosa\n\nQue";

        var reader = new StreamReader(input.ToMemoryStream());
        var result = new List<string>();
        do{
            result.Add(reader.GetNextDictionaryWord());
        } while (!reader.EndOfStream);

        result.Should().Contain("hola", "cosa", "que").And.HaveCount(3);
    }
}