using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solvers
{
    public class Day01 : IDay
    {
        public string SolveFirst(string input)
        {
            var entries = input.ParseToLines();
            var values = new List<int>();
            foreach (var entry in entries)
            {
                var numbers = GetNumbers(entry);
                values.Add(int.Parse($"{numbers.First()}{numbers.Last()}"));
            }
            return values.Sum().ToString();
        }

        public string SolveSecond(string input)
        {
            var entries = input.ParseToLines();
            var values = new List<int>();
            foreach (var entry in entries)
            {
                var numbers = GetNumbersWithNames(entry);
                values.Add(int.Parse($"{numbers.First()}{numbers.Last()}"));
            }
            return values.Sum().ToString();
        }


        private List<int> GetNumbers(string value)
        {
            var result = new List<int>();
            foreach (var ch in value)
            {
                if (char.IsDigit(ch))
                {
                    result.Add((int)char.GetNumericValue(ch));
                }
            }
            return result;
        }

        List<NumberName> NumberNames = new()
        {
            new NumberName{ Name = "one", Value = 1},
            new NumberName{ Name = "two", Value = 2},
            new NumberName{ Name = "three", Value = 3},
            new NumberName{ Name = "four", Value = 4},
            new NumberName{ Name = "five", Value = 5},
            new NumberName{ Name = "six", Value = 6},
            new NumberName{ Name = "seven", Value = 7},
            new NumberName{ Name = "eight", Value = 8},
            new NumberName{ Name = "nine", Value = 9},
        };

        private List<int> GetNumbersWithNames(string value)
        {
            value = value.ToLower();
            var result = new List<int>();
            var firstLetters = NumberNames.Select(x => x.FirstLetter)
                                            .Distinct()
                                            .ToList();
            var lettersDict = new Dictionary<char, List<NumberName>>();
            foreach (var letter in firstLetters)
            {
                lettersDict.Add(letter, NumberNames.Where(x => x.FirstLetter == letter).ToList());
            }

            var i = 0;
            while (i < value.Length)
            {
                var ch = value[i];
                if (char.IsDigit(ch))
                {
                    result.Add((int)char.GetNumericValue(ch));

                }
                else if (firstLetters.Contains(ch))
                {
                    foreach (var letter in lettersDict[ch])
                    {
                        if (value.Length - i >= letter.Length &&
                            value[i..(i + letter.Length)] == letter.Name)
                        {
                            result.Add(letter.Value);
                            break;
                        }
                    }
                }

                i++;
            }
            return result;
        }

        record NumberName
        {
            public required string Name { get; set; }
            public required int Value { get; set; }
            public char FirstLetter => Name[0];
            public int Length => Name.Length;
        }
    }
}
