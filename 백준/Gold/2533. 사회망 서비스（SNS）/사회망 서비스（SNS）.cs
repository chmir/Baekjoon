using System;
using System.Collections.Generic;

class Program
{
    static int n;
    static List<int>[] e;
    static int[,] dp; // 0 is for adapter, 1 is for non-adapter
    static bool[] visited;

    static void Find(int x)
    {
        visited[x] = true;
        dp[x, 0] = 1;
        for (int i = 0; i < e[x].Count; i++)
        {
            int child = e[x][i];
            if (visited[child]) continue;
            Find(child);
            dp[x, 1] += dp[child, 0];
            dp[x, 0] += Math.Min(dp[child, 1], dp[child, 0]);
        }
    }

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        e = new List<int>[n + 1];
        dp = new int[n + 1, 2];
        visited = new bool[n + 1];

        for (int i = 0; i <= n; i++)
        {
            e[i] = new List<int>();
        }

        for (int i = 0; i < n - 1; i++)
        {
            var input = Console.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            e[u].Add(v);
            e[v].Add(u);
        }

        Find(1);

        Console.WriteLine(Math.Min(dp[1, 0], dp[1, 1]));
    }
}
