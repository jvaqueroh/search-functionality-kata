namespace SearchFunctionality;

public class CitiesFinder
{
    public ICollection<string> GetCities(string searchText)
    {
        if (searchText.Equals("*"))
            return CitiesData.Cities;
        if (searchText.Length < 2)
            return new List<string>();
        return CitiesData.Cities
            .Where(city => city.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }
}