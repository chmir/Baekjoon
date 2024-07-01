using System;

class Program
{
    const int MAX = 301;
    static int N;
    static int[] Arr = new int[MAX];    // 계단을 나타내는 배열
    static int[] DP = new int[MAX];    // 해당 계단까지의 Max값을 나타내는 배열

    static int Max(int A, int B)
    {
        return A > B ? A : B;
    }

    static void Input()
    {
        N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)
        {
            Arr[i] = int.Parse(Console.ReadLine());
        }
    }

    static void Solution()
    {
        DP[1] = Arr[1];    // 첫 번째 계단까지의 Max 값은 첫번째 계단 값이지
        DP[2] = Arr[1] + Arr[2];
        DP[3] = Max(Arr[1] + Arr[3], Arr[2] + Arr[3]);

        for (int i = 4; i <= N; i++)
        {
            DP[i] = Max(DP[i - 2] + Arr[i], DP[i - 3] + Arr[i - 1] + Arr[i]);
        }

        Console.WriteLine(DP[N]);
    }

    static void Solve()
    {
        Input();
        Solution();
    }

    static void Main(string[] args)
    {
        Solve();
    }
}