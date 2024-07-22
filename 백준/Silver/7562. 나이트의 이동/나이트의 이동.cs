using System;
using System.Collections.Generic;

class Program
{
    static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

    static int[,] check = new int[300, 300];
    static int[,] visited = new int[300, 300];
    static Queue<(int, int)> q = new Queue<(int, int)>();

    static void BFS(int targetX, int targetY, int l)
    {
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            int x = current.Item1;
            int y = current.Item2;
            visited[x, y] = 1;

            if (x == targetX && y == targetY)
            {
                Console.WriteLine(check[x, y]);
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX >= 0 && nextX < l && nextY >= 0 && nextY < l && visited[nextX, nextY] == 0)
                {
                    visited[nextX, nextY] = 1;
                    check[nextX, nextY] = check[x, y] + 1;
                    q.Enqueue((nextX, nextY));
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        while (t-- > 0)
        {
            int l = int.Parse(Console.ReadLine());
            var knightStart = Console.ReadLine().Split(' ');
            int knightX = int.Parse(knightStart[0]);
            int knightY = int.Parse(knightStart[1]);

            var target = Console.ReadLine().Split(' ');
            int targetX = int.Parse(target[0]);
            int targetY = int.Parse(target[1]);

            q.Enqueue((knightX, knightY));
            BFS(targetX, targetY, l);

            Array.Clear(check, 0, check.Length);
            Array.Clear(visited, 0, visited.Length);
            q.Clear();
        }
    }
}
