namespace SearchFunctionality;

public class CitiesFinder
{
    public ICollection<string> GetCities(string searchText)
    {
        if (searchText.Equals("*"))
            return CitiesData.Cities;
        return new List<string>();
    }
}