using Problem0013;

namespace Test0013
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Test1(string s, int expected)
        {
            var sut = new Solution();
            var result = sut.RomanToInt(s);

            Assert.Equal(expected, result);

        }
    }
}