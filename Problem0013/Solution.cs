namespace Problem0013;

public class Solution
{
    public int RomanToInt(string s)
    {
        int result = 0;

        Dictionary<char, int> numeralValues = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        int i = 0;
        do
        {
            if (i+1 < s.Length && numeralValues[s[i+1]] > numeralValues[s[i]])
            {
                result += (numeralValues[s[i + 1]] - numeralValues[s[i]]);
                i++;
            }
            else
            {
                result += numeralValues[s[i]];
            }

            i++;
        } while (i < s.Length);

        return result;
    }
}
