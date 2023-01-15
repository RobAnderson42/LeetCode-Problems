namespace Problem0003;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int result = 0;
        Dictionary<char, int> charDict = new Dictionary<char, int>();

        int start = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (charDict.ContainsKey(c))
            {
                start = Math.Max(charDict[c]+1, start);
            }
            result = Math.Max(result, i - start + 1);
            charDict[c] = i;
        }

        return result;
    }
}
