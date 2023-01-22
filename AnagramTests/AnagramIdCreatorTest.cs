using Kata;

namespace AnagramTests;

class AnagramIdCreatorTest
{
    [Test]
    public void AnagramsShouldHaveTheSameAnagramId()
    {
        Assert.Multiple(() =>
        {
            Assert.That("hola".CreateAnagramHash() == "laho".CreateAnagramHash());
            Assert.That("hola".CreateAnagramHash() == "halo".CreateAnagramHash());
            Assert.That("hola".CreateAnagramHash() == "olha".CreateAnagramHash());
        });
    }

    [Test]
    public void NotAnagramsShouldNotHaveTheSameAnagramId()
    {
        Assert.Multiple(() =>
        {
            Assert.That("hola".CreateAnagramHash() != "lolo".CreateAnagramHash());
            Assert.That("hola".CreateAnagramHash() != "holas".CreateAnagramHash());
            Assert.That("hola".CreateAnagramHash() != "ffff".CreateAnagramHash());
        });
    }
}