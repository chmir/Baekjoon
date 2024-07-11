using System;

public class Knapsack
{
    public static void Main()
    {
        // 입력을 읽습니다.
        int[] inputs = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int n = inputs[0];
        int k = inputs[1];
        int[] DP = new int[k + 1];

        for (int i = 1; i <= n; i++)
        {
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
            int weight = temp[0];
            int value = temp[1];

            for (int j = k; j >= weight; j--)
            {
                DP[j] = Math.Max(DP[j], DP[j - weight] + value);
            }
        }

        // 결과 출력
        Console.WriteLine(DP[k]);
    }
}
