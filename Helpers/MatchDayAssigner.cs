using premier_league_algorithm.Classes;

namespace premier_league_algorithm.Helpers
{
    public static class MatchDayAssigner
    {
        public static List<(string Home, string Away, string Matchday)> AssignMatchdaysToGameweek(
            List<(string Home, string Away)> fixtures,
            int weekNumber
        )
        {
            string[] matchdays = Matchdays.Days;
            var assigned = new List<(string Home, string Away, string Matchday)>();
            // Rotate Friday and Monday
            int offset = weekNumber % fixtures.Count;
            for (int i = 0; i < fixtures.Count; i++)
            {
                int dayIndex = (i + offset) % matchdays.Length;
                assigned.Add((fixtures[i].Home, fixtures[i].Away, matchdays[dayIndex]));
            }
            return assigned;
        }
    }
}
