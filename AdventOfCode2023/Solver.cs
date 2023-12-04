using AdventOfCode2023.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal static class Solver
    {
        static Dictionary<int, IDay> solvers = new()
        {
            { 1, new Day01() },
        };

        public static string Solve(int day, int part)
        {
            var solver = solvers[day];
            var data = Helpers.ReadFile(day, part);
            if(part == 1)
            {
                return solver.SolveFirst(data);
            }
            else
            {
                return solver.SolveSecond(data);
            }
        }

    }
}
