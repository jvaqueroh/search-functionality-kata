using System.Collections.Generic;
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

        [TestCase("")]
        [TestCase("A")]
        public void return_no_results_if_search_text_if_fewer_than_2_chars(string searchText)
        {
            var result = citiesSearcher.Search(searchText);

            result.Should().BeEmpty();
        }

        [TestCase("Va", new[]{"Valencia", "Vancouver"})]
        public void return_cities_starting_with_search_text(string searchText, string[] expectedResults)
        {
            var result = citiesSearcher.Search(searchText);

            result.Should().HaveCount(expectedResults.Length);
            result.Should().Contain(expectedResults[0]);
            result.Should().Contain(expectedResults[1]);
        }
    }
}