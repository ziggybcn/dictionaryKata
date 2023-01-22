using FluentAssertions;
using Kata;

namespace AnagramTests;

class AnagramsKataTest
{
    [Test]
    public void AnagramsAreDetected()
    {
        var input = "hola\nhalo\ncasa\nsaca\npepito"; 
        var kata = new AnagramsKata();
        kata.CalculateAnagrams(input.ToMemoryStream());
        kata.Anagrams.Should().HaveCount(2);
        Assert.Multiple(() =>
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.That(kata.Anagrams.Any(i => i.Contains("hola") & i.Contains("halo")));
            Assert.That(kata.Anagrams.Any(i => i.Contains("saca") & i.Contains("casa")));
        });
    }

    [Test]
    public void AnagramsWithSpecialCharsAreDetected()
    {
        var input = "hola/W\nha-lo\ncasa/W45\nsac'a\npepito";
        var kata = new AnagramsKata();
        kata.CalculateAnagrams(input.ToMemoryStream());
        kata.Anagrams.Should().HaveCount(2);
        Assert.Multiple(() =>
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.That(kata.Anagrams.Any(i => i.Contains("hola") & i.Contains("halo")));
            Assert.That(kata.Anagrams.Any(i => i.Contains("saca") & i.Contains("casa")));
        });
    }
}