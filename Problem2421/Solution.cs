namespace Problem2421;

public class Solution
{
    public int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        int goodPaths = 0;
        UnionFind uf = new UnionFind(vals.Length);
        SortedDictionary<int, List<int>> valueNodeDict = new SortedDictionary<int, List<int>>();
        Dictionary<int, List<int>> neighborDict = new Dictionary<int, List<int>>();

        for (int i = 0; i < vals.Length; i++)
        {
            if (!valueNodeDict.ContainsKey(vals[i]))
            {
                valueNodeDict.Add(vals[i], new List<int>());
            }
            valueNodeDict[vals[i]].Add(i);
        }

        for (int i = 0; i < edges.Length; i++)
        {
            int[] edge = edges[i];
            if (!neighborDict.ContainsKey(edge[0]))
            {
                neighborDict.Add(edge[0], new List<int>());
            }
            neighborDict[edge[0]].Add(edge[1]);

            if (!neighborDict.ContainsKey(edge[1]))
            {
                neighborDict.Add(edge[1], new List<int>());
            }
            neighborDict[edge[1]].Add(edge[0]);
        }

        foreach (int key in valueNodeDict.Keys)
        {
            foreach(int node in valueNodeDict[key])
            {
                if (neighborDict.ContainsKey(node))
                {
                    foreach (int neighbor in neighborDict[node])
                    {
                        if (vals[node] >= vals[neighbor])
                        {
                            uf.unionSet(node, neighbor);
                        }
                    }
                }
            }

            Dictionary<int, int> groupCount = new Dictionary<int, int>();
            foreach(int u in valueNodeDict[key])
            {
                groupCount[uf.find(u)] = groupCount.GetValueOrDefault(uf.find(u), 0) + 1;
            }

            foreach (int group in groupCount.Keys)
            {
                int count = groupCount[group];
                goodPaths += count * (count + 1) / 2;
            }
        }

        return goodPaths;
    }
}

public class UnionFind
{
    private int[] root;
    private int[] rank;

    public UnionFind(int n)
    {
        root = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int find(int i)
    {
        if (root[i] == i)
        {
            return i;
        }
        root[i] = find(root[i]);
        return root[i];
    }

    public bool connected(int x, int y)
    {
        return find(x) == find(y);
    }

    public void unionSet(int x, int y)
    {
        int rootX = find(x);
        int rootY = find(y);

        if (rootX != rootY)
        {
            if (rank[rootX] < rank[rootY])
            {
                root[rootX] = rootY;
            }
            else
            {
                root[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                {
                    rank[rootX]++;
                }
            }
        }
    }
}
