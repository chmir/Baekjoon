//bj17404 /g4 /RGB거리 2 /240916
//1149번에서 1번과 N번집은 같으면 안된다는 조건이 추가로 붙었음
//그래서 풀이방식을 조금 달리해야 할 필요가 있다
//첫번째 집의 색상 정보도 알아야 하는 게 포인트인듯?
//으 DP너무 어려웡

class MACROXX_82_99__Bad_Girl_w_Lancaster
{
    static void Main()
    {
        //이 문제에서 나올 수 있는 가장 큰 수에 1을 더함
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

        int result = INF; //최소값을 찾기 위해 일단 정답은 INF로 대입해놓고...

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