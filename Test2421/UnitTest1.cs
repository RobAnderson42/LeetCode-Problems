using Problem2421;

namespace Test2421
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] vals = { 1, 3, 2, 1, 3 };
            int[][] edges = new int[][]{ new[]{ 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 2, 4 } };
            int expected = 6;

            RunTest(vals, edges, expected);
        }

        [Fact]
        public void Test2()
        {
            int[] vals = { 1, 1, 2, 2, 3 };
            int[][] edges = new int[][] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 2, 4 } };
            int expected = 7;

            RunTest(vals, edges, expected);
        }

        [Fact]
        public void Test3()
        {
            int[] vals = { 1 };
            int[][] edges = new int[][] { };
            int expected = 1;

            RunTest(vals, edges, expected);
        }

        private void RunTest(int[] vals, int[][] edges, int expected)
        {
            var sut = new Solution();
            var result = sut.NumberOfGoodPaths(vals, edges);

            Assert.Equal(expected, result);
        }
    }
}