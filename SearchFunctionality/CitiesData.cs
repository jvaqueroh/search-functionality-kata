namespace SearchFunctionality
{
    public static class CitiesData
    {
        public static ICollection<string> Cities { get; private set; }

        static CitiesData()
        {
            Cities = new List<string>()
            {
                "Paris", "Budapest", "Skopje", "Rotterdam", 
                "Valencia", "Vancouver", "Amsterdam", "Vienna", 
                "Sydney", "New York City", "London", "Bangkok", 
                "Hong Kong", "Dubai", "Rome", "Istanbul"
            };
        }
    }
}