using FluentAssertions;
using NUnit.Framework;

namespace SearchFunctionality.Tests
{
    public class CitiesSearcherShould
    {
        private CitiesSearcher citiesSearcher;

        [SetUp]
        public void Setup()
        {
            citiesSearcher = new CitiesSearcher();
        }

        [Test]
        public void return_no_results_if_search_text_if_fewer_than_2_chars()
        {
            var result = citiesSearcher.Search("A");

            result.Should().BeEmpty();
        }
    }
}