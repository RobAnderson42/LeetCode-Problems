using Problem1061;

namespace TestProblem1061
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("parker", "morris", "parser", "makkek")]
        [InlineData("hello", "world", "hold", "hdld")]
        [InlineData("leetcode", "programs", "sourcecode", "aauaaaaada")]
        public void Test1(string s1, string s2, string baseStr, string expectedResult)
        {
            var solution = new Solution();
            var result = solution.SmallestEquivalentString(s1, s2, baseStr);

            Assert.Equal(expectedResult, result);
        }
    }
}