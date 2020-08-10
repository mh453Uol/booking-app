using System.Collections.Generic;
using BarberBooking.Utilities;
using Xunit;

namespace BarberBooking.Tests.UnitTests
{
    public class GrammarUtilTests
    {
        [Fact]
        public void CommaSeparated_AddAddInBetweenTwoWords()
        {
            var words = new List<string> { "tomatos", "beans" };

            var commaSeparated = words.CommaSeparated();

            Assert.Equal("tomatos and beans", commaSeparated);
        }

        [Fact]
        public void CommaSeparated_DoesNotAddCommaOrAnd_WhenOnlyOneWordPassedIn() {
            var word = new List<string> { "tomatos" };

            var commaSeparated = word.CommaSeparated();

            Assert.Equal("tomatos", commaSeparated);
        }

        [Fact]
        public void CommaSeparated_AddCommaBetweenWordsAndOneAddAtTheEnd() {
            var words = new List<string> { "tomatos", "beans", "brocolli" };

            var commaSeparated = words.CommaSeparated();

            Assert.Equal("tomatos, beans and brocolli", commaSeparated);
        }

        [Fact]
        public void CommaSeparated_AddCommaBetweenManyWords() {
            var words = new List<string> { "a", "b", "c", "d", "e" };

            var commaSeparated = words.CommaSeparated();

            Assert.Equal("a, b, c, d and e", commaSeparated);
        }
    }
}