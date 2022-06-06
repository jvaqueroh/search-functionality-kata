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

        [Test]
        public void return_no_results_if_text_search_if_fewer_than_2_chars()
        {
            var result = citiesFinder.GetCities("");

            result.Should().BeEmpty();
        }
    }
}