using System;
using Xunit;

namespace Classes.Tests
{
    public class ValueTests
    {
        [Fact]
        public void ReturnsTrueForAStringValueArray()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("[\"a\"]").Success());
            Assert.Empty(pattern.Match("[\"a\"]").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForTwoValuesArray()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("[\" a 3 \"]").Success());
            Assert.Empty(pattern.Match("[\" a 3 \"]").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForOneObject()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("{\n\"name\": \"John\"\n}").Success());
            Assert.Empty(pattern.Match("{\n\"name\": \"John\"\n}").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForOneObjectTwoValues()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("{\n\"name\": \"John\",\n\"age\": 20\n}").Success());
            Assert.Empty(pattern.Match("{\n\"name\": \"John\",\n\"age\": 20\n}").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForOneObjectTwoValuesArray()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("[{\n\"name\": \"John\",\n\"age\": 20\n}]").Success());
            Assert.Empty(pattern.Match("[{\n\"name\": \"John\",\n\"age\": 20\n}]").RemainingText());
        }

        [Fact]
        public void ReturnsTrueForComplexObjectsArray()
        {
            var pattern = new Value();
            Assert.True(pattern.Match("[\n{\n\"id\": 1,\n\"name\": \"An ice sculpture\",\n\"price\": 12.50,\n\"tags\": [\"cold\", \"ice\"]\n},\n{\n\"id\": 1,\n\"name\": \"A blue Mouse\",\n\"price\": 25.50,\n\"tags\": [\"animal\", \"blue\"]\n}\n]").Success());
            Assert.Empty(pattern.Match("[\n{\n\"id\": 1,\n\"name\": \"An ice sculpture\",\n\"price\": 12.50,\n\"tags\": [\"cold\", \"ice\"]\n},\n{\n\"id\": 1,\n\"name\": \"A blue Mouse\",\n\"price\": 25.50,\n\"tags\": [\"animal\", \"blue\"]\n}\n]").RemainingText());
        }
    }
}
