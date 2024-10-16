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
        // 집의 수 N을 입력받습니다.
        int N = int.Parse(Console.ReadLine());

        // 각 집을 색칠하는 비용을 저장할 2차원 배열을 선언합니다.
        int[,] cost = new int[N, 3];

        // 동적 계획법을 위한 dp 배열을 선언합니다.
        int[,] dp = new int[N, 3];

        // 각 집의 색상 비용을 입력받습니다.
        for (int i = 0; i < N; i++)
        {
            // 한 줄에 세 개의 정수를 입력받습니다.
            string[] input = Console.ReadLine().Split();

            // 문자열 배열을 정수로 변환하여 저장합니다.
            cost[i, 0] = int.Parse(input[0]); // 빨강 비용
            cost[i, 1] = int.Parse(input[1]); // 초록 비용
            cost[i, 2] = int.Parse(input[2]); // 파랑 비용
        }

        // 첫 번째 집의 경우, 이전 집이 없으므로 비용을 그대로 사용합니다.
        dp[0, 0] = cost[0, 0];
        dp[0, 1] = cost[0, 1];
        dp[0, 2] = cost[0, 2];

        // 두 번째 집부터 마지막 집까지 순회합니다.
        for (int i = 1; i < N; i++)
        {
            //집을 칠하는대에는 세가지의 경우가 있을 것
            // 현재 집을 빨강으로 칠하는 경우
            dp[i, 0] = cost[i, 0] + Math.Min(dp[i - 1, 1], dp[i - 1, 2]);
            // 현재 집을 초록으로 칠하는 경우
            dp[i, 1] = cost[i, 1] + Math.Min(dp[i - 1, 0], dp[i - 1, 2]);
            // 현재 집을 파랑으로 칠하는 경우
            dp[i, 2] = cost[i, 2] + Math.Min(dp[i - 1, 0], dp[i - 1, 1]);
        }

        // 마지막 집까지의 최소 비용을 계산합니다.
        int result = Math.Min(dp[N - 1, 0], Math.Min(dp[N - 1, 1], dp[N - 1, 2]));

        // 결과를 출력합니다.
        Console.WriteLine(result);
    }
}