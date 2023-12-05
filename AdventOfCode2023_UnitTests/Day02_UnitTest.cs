namespace AdventOfCode2023_UnitTests
{
    public class Day02_UnitTest
    {
        [Fact]
        public void TestFirst()
        {
            var solver = new Day02();
            var result = solver.SolveFirst(Helpers.ReadFile(2, 1));
            result.Should()
                .Be("8");
        }

        [Fact]
        public void TestSecond()
        {
            var solver = new Day02();
            var result = solver.SolveSecond(Helpers.ReadFile(2, 1));
            result.Should()
                .Be("2286");
        }
    }
}