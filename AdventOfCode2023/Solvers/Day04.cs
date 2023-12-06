namespace AdventOfCode2023.Solvers
{
    public class Day04 : IDay
    {
        public string SolveFirst(string input)
        {
            var entries = input.ParseToLines();
            var cards = GetCards(entries);
            var result = 0;
            foreach (var card in cards)
            {
                var matchCount = card.Winners.Intersect(card.Owned)
                                        .Count();
                if (matchCount > 0)
                {
                    result += (int)Math.Pow(2, matchCount - 1);
                }
            }
            return result.ToString();
        }

        public string SolveSecond(string input)
        {
            var entries = input.ParseToLines();
            var cards = GetCards(entries);
            var numbers = cards.Select(x => x.Number).Distinct().Order().ToList();
            var numberCount = numbers.ToDictionary(x=>x, x=>1);

            foreach (var number in numbers)
            {
                var matches = cards.Where(x => x.Number == number);
                if (!matches.Any())
                {
                    continue;
                }
                var card = matches.First();
                var matchCount = card.Winners.Intersect(card.Owned)
                                        .Count();
                for (var i = 1; i <= matchCount; i++)
                {
                    numberCount[number + i] = numberCount[number + i] + matches.Count() * numberCount[number];
                }
            }
            return numberCount.Sum(x => x.Value).ToString(); ;
        }

        private record Card(int Number, List<int> Winners, List<int> Owned)
        {
            public Card(Card source)
            {
                Number = source.Number;
                Winners = source.Winners;
                Owned = source.Owned;
            }
        }

        private List<int> GetNumbers(string input) => input.SplitAndTrim(' ')
                                                            .Where(x => !string.IsNullOrWhiteSpace(x))
                                                            .Select(x => int.Parse(x))
                                                            .ToList();

        private List<Card> GetCards(List<string> entries)
        {
            var cards = new List<Card>();
            foreach (var entry in entries)
            {
                var splits = entry.SplitAndTrim(':');
                var number = int.Parse(splits[0].SplitAndTrim(' ')[1]);
                var numberSplits = splits[1].SplitAndTrim('|');
                cards.Add(new Card(
                        number,
                        GetNumbers(numberSplits[0]),
                        GetNumbers(numberSplits[1])
                    ));
            }
            return cards;
        }

    }
}
