namespace SearchFunctionality;

public class CitiesSearcher
{
    public ICollection<string> Search(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
            return new List<string>();

        return CitiesData.Cities
            .Where(c => c.StartsWith(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }
}