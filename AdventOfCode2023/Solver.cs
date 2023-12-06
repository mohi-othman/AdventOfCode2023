using AdventOfCode2023.Solvers;

namespace AdventOfCode2023
{
    internal static class Solver
    {
        static Dictionary<int, (IDay solver, bool reUseFile)> solvers = new()
        {
            { 1, (new Day01(), true) },
            { 2, (new Day02(), true) },
            { 3, (new Day03(), true) },
            { 4, (new Day04(), true) },
        };

        public static string Solve(int day, int part)
        {
            var daySolver = solvers[day];
            var data = Helpers.ReadFile(day, daySolver.reUseFile ? 1 : part);
            if (part == 1)
            {
                return daySolver.solver.SolveFirst(data);
            }
            else
            {
                return daySolver.solver.SolveSecond(data);
            }
        }

    }
}
