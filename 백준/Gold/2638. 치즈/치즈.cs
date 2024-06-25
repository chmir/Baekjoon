using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    const int REAL_BLANK = 3;
    const int CHEESE = 1;
    const int BLANK = 0;
    const int MELT = 5;

    static int[] dy = { -1, 1, 0, 0 };
    static int[] dx = { 0, 0, -1, 1 };
    static int N, M, time;

    static int[,] arr;
    static bool[,] visit;

    static void FillBlank()
    {
        Array.Clear(visit, 0, visit.Length);

        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));
        visit[0, 0] = true;

        while (q.Count > 0)
        {
            var (y, x) = q.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int ty = y + dy[i];
                int tx = x + dx[i];
                if (ty >= 0 && tx >= 0 && ty < N && tx < M && !visit[ty, tx] && arr[ty, tx] != CHEESE)
                {
                    visit[ty, tx] = true;
                    arr[ty, tx] = REAL_BLANK;
                    q.Enqueue((ty, tx));
                }
            }
        }
    }

    static void Simulation()
    {
        bool cheeseExists;
        while (true)
        {
            FillBlank();

            cheeseExists = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == CHEESE)
                    {
                        int cnt = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            int ty = i + dy[k];
                            int tx = j + dx[k];
                            if (ty >= 0 && tx >= 0 && ty < N && tx < M && arr[ty, tx] == REAL_BLANK)
                            {
                                cnt++;
                            }
                        }
                        if (cnt >= 2)
                        {
                            arr[i, j] = MELT;
                            cheeseExists = true;
                        }
                    }
                }
            }

            if (!cheeseExists) break;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == MELT)
                    {
                        arr[i, j] = BLANK;
                    }
                }
            }

            time++;
        }
    }

    public static void Main()
    {
        var Line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        N = Line[0];
        M = Line[1];

        arr = new int[N, M];
        visit = new bool[N, M];

        for (int i = 0; i < N; i++)
        {
            Line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 0; j < M; j++)
            {
                arr[i, j] = Line[j];
            }
        }

        Simulation();
        Console.WriteLine(time);
    }
}
