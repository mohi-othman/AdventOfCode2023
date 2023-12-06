namespace AdventOfCode2023_UnitTests
{
    public class Day04_UnitTest
    {
        [Fact]
        public void TestFirst()
        {
            var solver = new Day04();
            var result = solver.SolveFirst(Helpers.ReadFile(4, 1));
            result.Should()
                .Be("13");
        }

        [Fact]
        public void TestSecond()
        {
            var solver = new Day04();
            var result = solver.SolveSecond(Helpers.ReadFile(4, 1));
            result.Should()
                .Be("30");
        }
    }
}
