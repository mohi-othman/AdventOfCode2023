namespace AdventOfCode2023.Solvers
{
    public class Day02 : IDay
    {
        private const string Red = "red";
        private const string Green = "green";
        private const string Blue = "blue";

        private List<string> colors = new List<string>
        {
            Red, Green, Blue,
        };

        private Dictionary<string, int> targets = new()
        {
            { Red, 12 },
            { Green, 13 },
            { Blue, 14 },
        };


        public string SolveFirst(string input)
        {
            var entries = input.ParseToLines();
            var gameDict = GetGamesDict(entries);

            var result = new List<int>();
            foreach (var game in gameDict)
            {
                var pass = true;
                foreach (var color in colors)
                {
                    if (game.Value[color] > targets[color])
                    {
                        pass = false;
                        break;
                    }
                }
                if (pass)
                {
                    result.Add(game.Key);
                }
            }
            return result.Sum().ToString();
        }

        public string SolveSecond(string input)
        {
            var entries = input.ParseToLines();
            var gameDict = GetGamesDict(entries);

            var result = new List<int>();
            foreach (var game in gameDict)
            {
                var power = 1;
                foreach (var color in colors)
                {
                    power *= game.Value[color];
                }
                result.Add(power);
            }
            return result.Sum().ToString();
        }

        private Dictionary<int, Dictionary<string, int>> GetGamesDict(List<string> entries)
        {
            var gameDict = new Dictionary<int, Dictionary<string, int>>();
            foreach (var entry in entries)
            {
                var maxDict = new Dictionary<string, int>();
                foreach (var color in colors)
                {
                    maxDict.Add(color, 0);
                }
                var split = entry.Split(':');
                var gameNumber = int.Parse(split[0].Split(' ')
                                                    .Last());
                var rounds = split[1].Split(';')
                                        .Select(x => x.Trim());
                foreach (var round in rounds)
                {
                    var counts = round.Split(",")
                                        .Select(x => x.Trim());
                    foreach (var count in counts)
                    {
                        var countSplit = count.Split(' ')
                                        .Select(x => x.Trim());
                        var currMax = maxDict[countSplit.Last()];
                        var currValue = int.Parse(countSplit.First());
                        maxDict[countSplit.Last()] = Math.Max(currMax, currValue);
                    }
                }
                gameDict.Add(gameNumber, maxDict);
            }
            return gameDict;
        }
    }
}
