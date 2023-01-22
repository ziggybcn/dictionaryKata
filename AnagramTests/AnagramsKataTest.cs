using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Kata;

namespace AnagramTests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
internal class AnagramsKataTest
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
            Assert.That(kata.Anagrams.Any(i => i.Contains("hola") & i.Contains("halo")));
            Assert.That(kata.Anagrams.Any(i => i.Contains("saca") & i.Contains("casa")));
        });
    }

    [Test]
    public void SpecialCharsAreIgnoredOnAnagrams()
    {
        var input = "hola/W\nha-lo\ncasa/W45\nsac'a\npepito";
        var kata = new AnagramsKata();
        kata.CalculateAnagrams(input.ToMemoryStream());
        kata.Anagrams.Should().HaveCount(2);
        Assert.Multiple(() =>
        {
            Assert.That(kata.Anagrams.Any(i => i.Contains("hola") & i.Contains("ha-lo")));
            Assert.That(kata.Anagrams.Any(i => i.Contains("sac'a") & i.Contains("casa")));
        });
    }
    [Test]
    public void DuplicatesAreDiscarded()
    {
        var input = "hola\nho-la";
        var kata = new AnagramsKata();
        kata.CalculateAnagrams(input.ToMemoryStream());
        kata.Anagrams.Should().HaveCount(0);
    }
}