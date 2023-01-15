namespace Problem1061;

public class Solution
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        string result = String.Empty;
        List<SortedSet<char>> charGroups = new List<SortedSet<char>>();

        for (int i = 0; i < s1.Length; i++)
        {
            var group1 = FindGroup(charGroups, s1[i]);
            var group2 = FindGroup(charGroups, s2[i]);

            // If c1 is in a group and c2 is not, add c2 to group with c1.
            // If c2 is in a group and c1 is not, add c1 to group with c2.
            // If c1 is in a group and c2 is in a different group, combine groups containing c1 and c2.
            // If c1 is in a group and c2 is in the same group, do nothing.
            // If neither c1 or c2 is in a group, create a new group with c1 and c2.

            if (group1 != null)
            {
                if (group2 == null)
                {
                    group1.Add(s2[i]);
                }
                else if (group1 != group2)
                {
                    foreach(char c in group2)
                    {
                        group1.Add(c);
                    }
                    charGroups.Remove(group2);
                }
            }
            else if (group2 != null) // group1 == null
            {
                group2.Add(s1[i]);
            }
            else // group1 == null && group2 == null
            {
                var group = new SortedSet<char>
                {
                    s1[i],
                    s2[i]
                };
                charGroups.Add(group);
            }
        }

        for (int i = 0; i < baseStr.Length; i++)
        {
            var group = FindGroup(charGroups, baseStr[i]);
            if (group != null)
            {
                result += group.First();
            }
            else
            {
                result += baseStr[i];
            }
        }

        return result;
    }

    public SortedSet<char> FindGroup(List<SortedSet<char>> charGroups, char c)
    {
        foreach(var group in charGroups)
        {
            if (group.Contains(c))
                return group;
        }

        return null;
    }
}
