/*
 * bj17286 /s5 /유미 /240703
 * 복습필요
 * 
*/
using System;

class Program
{
    static (int, int)[] points = new (int, int)[4];
    static double[,] dist = new double[4, 4];
    static bool[] visit = new bool[4];
    static int ans = int.MaxValue;

    static void Main(string[] args)
    {
        for (int i = 0; i < 4; i++)
        {
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            points[i] = (x, y);
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                dist[i, j] = dist[j, i] = GetDistance(points[i], points[j]);
            }
        }

        DFS(0, 0, 0);

        Console.WriteLine(ans);
    }

    public static double GetDistance((int x, int y) a, (int x, int y) b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }

    public static void DFS(int idx, double sum, int cnt)
    {
        if (cnt == 4)
        {
            ans = Math.Min(ans, (int)sum);
            return;
        }

        if (visit[idx]) return;

        visit[idx] = true;

        for (int i = 0; i < 4; i++)
        {
            DFS(i, sum + dist[idx, i], cnt + 1);
        }

        visit[idx] = false;
    }
}
