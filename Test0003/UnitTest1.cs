using Problem0003;

namespace Test0003
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("tmmzuxt", 5)]
        public void Test1(string s, int expected)
        {
            var sut = new Solution();
            var result = sut.LengthOfLongestSubstring(s);

            Assert.Equal(expected, result);
        }
    }
}