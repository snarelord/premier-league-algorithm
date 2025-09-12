namespace premier_league_algorithm.Helpers
{
    public static class EvertonLiverpoolClash
    {
        public static void ResolveEvertonLiverpoolHomeClash(
            List<List<(string Home, string Away)>> gameweeks
        )
        {
            for (int week = 0; week < gameweeks.Count; week++)
            {
                int evertonIndex = -1;
                int liverpoolIndex = -1;
                for (int i = 0; i < gameweeks[week].Count; i++)
                {
                    if (gameweeks[week][i].Home == "Everton")
                    {
                        evertonIndex = i;
                    }
                    if (gameweeks[week][i].Home == "Liverpool")
                    {
                        liverpoolIndex = i;
                    }
                }
                // If both are home swap Evertons fixture
                if (evertonIndex != -1 && liverpoolIndex != -1)
                {
                    var (Home, Away) = gameweeks[week][evertonIndex];
                    gameweeks[week][evertonIndex] = (Away, Home);
                }
            }
        }
    }
}
