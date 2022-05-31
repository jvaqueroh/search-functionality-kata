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

        [TestCase("Va", new[] { "Valencia", "Vancouver" })]
        [TestCase("Val", new[] { "Valencia" })]
        [TestCase("VAL", new[] { "Valencia" })]
        [TestCase("ape", new[] { "Budapest" })]
        [TestCase("ON", new[] { "London", "Hong Kong" })]
        public void return_cities_containing_search_text_case_insensitive(string searchText, string[] expectedResults)
        {
            var result = citiesSearcher.Search(searchText);

            result.Should().HaveCount(expectedResults.Length);
            result.Should().Contain(expectedResults);
        }

        [Test]
        public void return_all_cities_when_search_text_is_an_asterisk()
        {
            var allTheCities = CitiesData.Cities;

            var result = citiesSearcher.Search("*");

            result.Should()
                .HaveCount(allTheCities.Count)
                .And.Contain(allTheCities);
        }
    }
}