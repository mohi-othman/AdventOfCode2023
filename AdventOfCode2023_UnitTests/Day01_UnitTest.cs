namespace AdventOfCode2023_UnitTests
{
    public class Day01_UnitTest
    {
        [Fact]
        public void TestFirst()
        {
            var solver = new Day01();
            var result = solver.SolveFirst(Helpers.ReadFile(1, 1));
            result.Should()
                .Be("142");
        }

        [Fact]
        public void TestSecond()
        {
            var solver = new Day01();
            var result = solver.SolveSecond(Helpers.ReadFile(1, 2));
            result.Should()
                .Be("281");
        }
    }
}