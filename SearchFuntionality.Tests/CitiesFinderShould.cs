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

        [Test]
        public void return_cities_searching_by_case_insensitive_text()
        {
            var expectedCities = new[] { "Valencia", "Vancouver" };

            var result = citiesFinder.GetCities("va");

            result.Should().BeEquivalentTo(expectedCities);
        }
    }
}