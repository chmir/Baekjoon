class Program
{
    static int[,] arr = new int[10, 10];
    static int[,] arr2 = new int[10, 10];
    static int[,] virus = new int[64, 2];
    static int num = 0;
    static int n, m;

    static int[] xx = { 0, 0, -1, 1 };
    static int[] yy = { 1, -1, 0, 0 };

    static void Dfs(int x, int y)
    {
        for (int i = 0; i < 4; i++)
        {
            int X = x + xx[i];
            int Y = y + yy[i];

            if (X > 0 && X <= n && Y > 0 && Y <= m && arr2[X, Y] == 0)
            {
                arr2[X, Y] = 2;
                Dfs(X, Y);
            }
        }
    }

    static void Main()
    {
        int x1, x2, x3, y1, y2, y3;
        int ans = 0;

        var nm = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        n = nm[0];
        m = nm[1];

        for (int i = 1; i <= n; i++)
        {
            var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 1; j <= m; j++)
            {
                arr[i, j] = line[j - 1];
                arr2[i, j] = arr[i, j];

                if (arr[i, j] == 2)
                {
                    virus[num, 0] = i;
                    virus[num, 1] = j;
                    num++;
                }
            }
        }

        for (int i = 0; i < n * m; i++)
        {
            x1 = i / m + 1; y1 = i % m + 1;
            if (arr2[x1, y1] == 0)
                for (int j = i + 1; j < n * m; j++)
                {
                    x2 = j / m + 1; y2 = j % m + 1;
                    if (arr2[x2, y2] == 0)
                        for (int k = j + 1; k < n * m; k++)
                        {
                            x3 = k / m + 1; y3 = k % m + 1;
                            if (arr2[x3, y3] == 0)
                            {
                                arr2[x1, y1] = 1;
                                arr2[x2, y2] = 1;
                                arr2[x3, y3] = 1;

                                for (int p = 0; p < num; p++)
                                    Dfs(virus[p, 0], virus[p, 1]);

                                int cnt = 0;

                                for (int p = 1; p <= n; p++)
                                    for (int q = 1; q <= m; q++)
                                        if (arr2[p, q] == 0) cnt++;

                                if (ans < cnt)
                                    ans = cnt;

                                for (int p = 1; p <= n; p++)
                                    for (int q = 1; q <= m; q++)
                                        arr2[p, q] = arr[p, q];
                            }
                        }
                }
        }

        Console.WriteLine(ans);
    }
}