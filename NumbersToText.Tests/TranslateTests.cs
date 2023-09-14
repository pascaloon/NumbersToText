namespace NumbersToText.Tests
{
    public class FrenchTranslateTests
    {
        [Fact]
        public void Simple()
        {
            var t = new FrenchTranslator();
            Assert.Equal("un", t.Translate(1));
            Assert.Equal("cent", t.Translate(100f));
            Assert.Equal("mille", t.Translate(1_000f));
            Assert.Equal("un million", t.Translate(1_000_000f));
        }

        [Fact]
        public void Mix()
        {
            var t = new FrenchTranslator();
            Assert.Equal("cent un", t.Translate(101));
            Assert.Equal("cent onze", t.Translate(111));
            Assert.Equal("cent vingt-trois", t.Translate(123f));
        }

        [Fact]
        public void High()
        {
            var t = new FrenchTranslator();
            Assert.Equal("mille milliard", t.Translate(1_000_000_000_000));
        }
    }

    public class EnglishTranslateTests
    {
        [Fact]
        public void Simple()
        {
            var t = new EnglishTranslator();
            Assert.Equal("one", t.Translate(1));
            Assert.Equal("one hundred", t.Translate(100f));
            Assert.Equal("one thousand", t.Translate(1_000f));
            Assert.Equal("one million", t.Translate(1_000_000f));
        }

        [Fact]
        public void Mix()
        {
            var t = new EnglishTranslator();
            Assert.Equal("one hundred one", t.Translate(101));
            Assert.Equal("one hundred eleven", t.Translate(111));
            Assert.Equal("one hundred twenty-three", t.Translate(123f));
        }

        [Fact]
        public void High()
        {
            var t = new EnglishTranslator();
            Assert.Equal("one thousand billion", t.Translate(1_000_000_000_000));
        }
    }
}