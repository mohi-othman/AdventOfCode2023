namespace AdventOfCode2023_UnitTests
{
    public class Day03_UnitTest
    {
        [Fact]
        public void TestFirst()
        {
            var solver = new Day03();
            var result = solver.SolveFirst(Helpers.ReadFile(3, 1));
            result.Should()
                .Be("4361");
        }

        [Fact]
        public void TestSecond()
        {
            var solver = new Day03();
            var result = solver.SolveSecond(Helpers.ReadFile(3, 1));
            result.Should()
                .Be("467835");
        }
    }
}
