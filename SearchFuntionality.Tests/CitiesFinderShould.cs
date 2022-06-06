using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SearchFunctionality;

namespace SearchFuntionality.Tests
{
    public class CitiesFinderShould
    {
        private CitiesFinder citiesFinder;

        [SetUp]
        public void Setup()
        {
            citiesFinder = new CitiesFinder();
        }

        [Test]
        public void return_all_the_cities_if_text_search_is_asterisk()
        {
            var result = citiesFinder.GetCities("*");

            result.Should().BeEquivalentTo(CitiesData.Cities);
        }

        [TestCase("")]
        [TestCase("V")]
        public void return_no_results_if_text_search_if_fewer_than_2_chars(string searchText)
        {
            var result = citiesFinder.GetCities(searchText);

            result.Should().BeEmpty();
        }

        [Test]
        public void return_cities_starting_with_text_search()
        {
            var expectedCities = new[] { "Valencia", "Vancouver" };

            var result = citiesFinder.GetCities("Va");

            result.Should().BeEquivalentTo(expectedCities);
        }

        [TestCase("va")]
        [TestCase("VA")]
        public void return_cities_searching_by_case_insensitive_text(string searchText)
        {
            var expectedCities = new[] { "Valencia", "Vancouver" };

            var result = citiesFinder.GetCities(searchText);

            result.Should().BeEquivalentTo(expectedCities);
        }

        [Test]
        public void return_cities_containing_the_text_search()
        {
            var expectedCities = new[] { "Budapest" };

            var result = citiesFinder.GetCities("ape");

            result.Should().BeEquivalentTo(expectedCities);
        }
    }
}