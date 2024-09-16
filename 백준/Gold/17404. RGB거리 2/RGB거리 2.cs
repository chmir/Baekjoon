//bj1149 /s1 /RGB거리 /240916
//집의 수 N개와, 각 집을 RGB로 칠하는 비용이 하나씩 주어졌을 때...
//1. 1번과 2번집은 서로 다른 색
//2. N번과 N-1번은 서로 다른 색
//3. i번과 i-1, i+1은 서로 다른 색 (2 ≤ i ≤ N-1)
//말 그대로 인접한 점들끼리 서로 다른 색이어야 한다. (i-1과 i+1은 같아도 ㄱㅊ)
//첫번째 집의 색을 세가지 전부 고려하여 시작하고
//다음 집으로 나아갈 때마다 이전집과 색이 다르기만 하면 됨

class NATIONAL_ナショナル__ＴＲＯＰＩＣΛＬ_ゴニが
{
    static void Main()
    {
        const int INF = 1000 * 1000 + 1; // 충분히 큰 수로 설정

        // 집의 수 N을 입력받습니다.
        int N = int.Parse(Console.ReadLine());

        // 각 집을 색칠하는 비용을 저장할 2차원 배열을 선언합니다.
        int[,] cost = new int[N, 3];

        // 각 집의 색상 비용을 입력받습니다.
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();

            cost[i, 0] = int.Parse(input[0]); // 빨강 비용
            cost[i, 1] = int.Parse(input[1]); // 초록 비용
            cost[i, 2] = int.Parse(input[2]); // 파랑 비용
        }

        int result = INF;

        // 첫 번째 집의 색상을 0(빨강), 1(초록), 2(파랑)으로 고정하여 세 번 반복합니다.
        for (int firstColor = 0; firstColor < 3; firstColor++)
        {
            // DP 배열을 선언하고 INF로 초기화합니다.
            int[,] dp = new int[N, 3];

            // 첫 번째 집의 색상을 고정하고, 나머지 색상은 INF로 설정합니다.
            for (int color = 0; color < 3; color++)
            {
                if (color == firstColor)
                    dp[0, color] = cost[0, color];
                else
                    dp[0, color] = INF;
            }

            // 두 번째 집부터 마지막 집까지 DP를 진행합니다.
            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = cost[i, 0] + Math.Min(dp[i - 1, 1], dp[i - 1, 2]);
                dp[i, 1] = cost[i, 1] + Math.Min(dp[i - 1, 0], dp[i - 1, 2]);
                dp[i, 2] = cost[i, 2] + Math.Min(dp[i - 1, 0], dp[i - 1, 1]);
            }

            // 마지막 집에서 첫 번째 집의 색상과 다른 색상만 고려합니다.
            for (int lastColor = 0; lastColor < 3; lastColor++)
            {
                if (lastColor == firstColor)
                    continue; // 같은 색상은 건너뜁니다.

                // 현재까지의 최소 비용을 갱신합니다.
                result = Math.Min(result, dp[N - 1, lastColor]);
            }
        }

        // 결과를 출력합니다.
        Console.WriteLine(result);
    }
}
