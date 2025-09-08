namespace premier_league_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] teams =
            [
                "Arsenal",
                "Aston Villa",
                "AFC Bournemouth",
                "Brentford",
                "Brighton & Hove Albion",
                "Burnley",
                "Chelsea",
                "Crystal Palace",
                "Everton",
                "Fulham",
                "Leeds United",
                "Liverpool",
                "Manchester City",
                "Manchester United",
                "Newcastle United",
                "Nottingham Forest",
                "Sunderland",
                "Tottenham Hotspur",
                "West Ham United",
                "Wolverhampton Wanderers",
            ];

            // int totalGames = 380;
            int gamesPerWeek = 10;

            // Round robin fixture
            int numTeams = teams.Length;
            List<List<(string Home, string Away)>> gameweeks = [];

            // Create list for the first half of season (home / away)
            string[] teamsCopy = new string[numTeams];
            Array.Copy(teams, teamsCopy, numTeams);

            for (int round = 0; round < numTeams - 1; round++)
            {
                List<(string Home, string Away)> weekFixtures = [];
                for (int match = 0; match < numTeams / 2; match++)
                {
                    string home = teamsCopy[match];
                    string away = teamsCopy[numTeams - 1 - match];
                    weekFixtures.Add((home, away));
                }
                gameweeks.Add(weekFixtures);
                // Rotate teams except the first
                string last = teamsCopy[numTeams - 1];
                for (int i = numTeams - 1; i > 1; i--)
                    teamsCopy[i] = teamsCopy[i - 1];
                teamsCopy[1] = last;
            }

            for (int week = 0; week < gameweeks.Count; week++)
            {
                Console.WriteLine($"\nGameweek {week + 1}:");
                for (int game = 0; game < gameweeks[week].Count; game++)
                {
                    var (Home, Away) = gameweeks[week][game];
                    Console.WriteLine($"  Game {game + 1}: {Home} vs {Away}");
                }
            }
            Console.WriteLine($"\nTotal fixtures: {gameweeks.Count * gamesPerWeek}");
        }
    }
}
