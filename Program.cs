using premier_league_algorithm.Classes;
using premier_league_algorithm.Helpers;

namespace premier_league_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] teams = Teams.teams;

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

            // Second half of season reverse home / away
            for (int round = 0; round < numTeams - 1; round++)
            {
                List<(string Home, string Away)> weekFixtures = [];
                for (int match = 0; match < numTeams / 2; match++)
                {
                    string home = gameweeks[round][match].Away;
                    string away = gameweeks[round][match].Home;
                    weekFixtures.Add((home, away));
                }
                gameweeks.Add(weekFixtures);
            }

            // Print gameweeks
            // Resolve Everton/Liverpool home match clashes
            EvertonLiverpoolClash.ResolveEvertonLiverpoolHomeClash(gameweeks);

            for (int week = 0; week < gameweeks.Count; week++)
            {
                Console.WriteLine($"\nGameweek {week + 1}:");
                var fixturesWithDays = MatchDayAssigner.AssignMatchdaysToGameweek(
                    gameweeks[week],
                    week
                );
                for (int game = 0; game < fixturesWithDays.Count; game++)
                {
                    var (Home, Away, Matchday) = fixturesWithDays[game];
                    Console.WriteLine($"  {Matchday}: {Home} vs {Away}");
                }
            }
            Console.WriteLine($"\nTotal fixtures: {gameweeks.Count * gamesPerWeek}");
        }
    }
}
