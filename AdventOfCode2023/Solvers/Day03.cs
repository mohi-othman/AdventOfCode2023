namespace AdventOfCode2023.Solvers
{
    public class Day03 : IDay
    {
        public string SolveFirst(string input)
        {
            var entries = input.ParseToLines();
            var height = entries.Count();
            var width = entries[0].Count();
            var partNumbers = GetParts(entries);
            var result = new HashSet<PartNumber>();
            for (var y = 0; y < entries.Count; y++)
            {
                var line = entries[y];
                for (var x = 0; x < entries.Count(); x++)
                {
                    var ch = line[x];
                    if (!char.IsDigit(ch) && ch != '.')
                    {
                        var neighbors = GetNeighbors(x, y);
                        neighbors = neighbors.Where(c => c.X >= 0 && c.Y >= 0 && c.X < width && c.Y < height)
                                            .ToList();
                        foreach (var part in partNumbers)
                        {
                            if (part.Coords.Intersect(neighbors).Any())
                            {
                                result.Add(part);
                            }
                        }
                    }
                }
            }
            return result.Sum(x => x.Number).ToString();
        }

        public string SolveSecond(string input)
        {
            var entries = input.ParseToLines();
            var height = entries.Count();
            var width = entries[0].Count();
            var partNumbers = GetParts(entries);
            var result = new List<int>();
            for (var y = 0; y < entries.Count; y++)
            {
                var line = entries[y];
                for (var x = 0; x < entries.Count(); x++)
                {
                    var ch = line[x];
                    if (ch == '*')
                    {
                        var neighbors = GetNeighbors(x, y);
                        neighbors = neighbors.Where(c => c.X >= 0 && c.Y >= 0 && c.X < width && c.Y < height)
                                            .ToList();
                        var parts = new List<PartNumber>();
                        foreach (var part in partNumbers)
                        {
                            if (part.Coords.Intersect(neighbors).Any())
                            {
                                parts.Add(part);
                            }
                        }
                        if(parts.Count == 2)
                        {
                            result.Add(parts.First().Number * parts.Last().Number);
                        }
                    }
                }
            }
            return result.Sum().ToString();
        }

        private List<PartNumber> GetParts(List<string> lines)
        {
            var result = new List<PartNumber>();
            for (var y = 0; y < lines.Count; y++)
            {
                var line = lines[y];
                var parts = new List<PartNumber>();
                var buffer = "";
                var coordList = new List<Coord>();

                void addPart(ref string buffer, List<PartNumber> parts, List<Coord> coordList)
                {
                    if (buffer.Count() > 0)
                    {
                        parts.Add(new PartNumber(int.Parse(buffer), new List<Coord>(coordList)));
                        buffer = "";
                        coordList.Clear();
                    }
                }

                for (var x = 0; x < line.Count(); x++)
                {
                    var ch = line[x];
                    if (char.IsDigit(ch))
                    {
                        buffer += ch;
                        coordList.Add(new Coord(x, y));
                    }
                    else
                    {
                        addPart(ref buffer, parts, coordList);
                    }
                }
                addPart(ref buffer, parts, coordList);
                result.AddRange(parts);
            }
            return result;
        }

        private record PartNumber(int Number, List<Coord> Coords) { }

        private List<Coord> GetNeighbors(int x, int y) => new List<Coord> {
                            new Coord(x + 1, y),
                            new Coord(x - 1, y),
                            new Coord(x, y + 1),
                            new Coord(x, y - 1),
                            new Coord(x + 1, y + 1),
                            new Coord(x - 1, y - 1),
                            new Coord(x + 1, y - 1),
                            new Coord(x - 1, y + 1),
                        };

        private record Coord(int X, int Y) { }
    }
}
