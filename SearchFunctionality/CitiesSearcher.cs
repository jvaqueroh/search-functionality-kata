namespace SearchFunctionality;

public class CitiesSearcher
{
    public ICollection<string> Search(string searchText)
    {
        if (searchText.Equals("*"))
            return CitiesData.Cities;

        if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
            return new List<string>();

        return CitiesData.Cities
            .Where(c => c.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }
}