using System;

public class Knapsack
{
    public static void Main()
    {
        // 입력을 읽습니다.
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int[] W = new int[N + 1];
        int[] V = new int[N + 1];

        for (int i = 1; i <= N; i++)
        {
            input = Console.ReadLine().Split();
            W[i] = int.Parse(input[0]);
            V[i] = int.Parse(input[1]);
        }

        // DP 배열 초기화
        int[,] DP = new int[N + 1, K + 1];

        // DP 테이블 채우기
        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= K; j++)
            {
                if (W[i] > j)
                {
                    DP[i, j] = DP[i - 1, j];
                }
                else
                {
                    DP[i, j] = Math.Max(DP[i - 1, j], DP[i - 1, j - W[i]] + V[i]);
                }
            }
        }

        // 결과 출력
        Console.WriteLine(DP[N, K]);
    }
}
