/* bj1126 /p3 /같은 탑 /240716
 * dp[cur][diff] 방식 보다 더 빠른 방법이 있음을 확인, 정리해보자
 * 이전과 다르게 입력받은 블럭들을 오름차 순으로 정렬한다. (인덱스 0번부터 점점 커지게 정렬)
 * 
 */
class Program
{
    static void Main(string[] args)
    {
        // 블록의 수와, 블럭의 높이를 입력받습니다.
        int n = int.Parse(Console.ReadLine());
        int[] blocks = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 블록들을 정렬하여 계산을 용이하게 합니다.
        Array.Sort(blocks);

        // DP 테이블을 생성하고 초기화합니다.
        int[,] dp = new int[2, 500001];
        for (int i = 1; i < 500001; i++)
        {
            dp[0, i] = -1;  // -1로 초기화합니다. (접근 불가능한 상태)
            dp[1, i] = -1;
        }
        //dp[0, 0] = dp[1, 0] = 0;  // 기본 상태: 높이 차이가 0은 0의 높이로 달성 가능

        int maxLen = 0;  // 효율성을 위해 최대 인덱스를 추적합니다.

        // 각 블록을 처리합니다.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= maxLen; j++)
            {
                if (dp[0, j] == -1) continue;  // 현재 diff가 달성 불가능하면 스킵

                // 현재 블록을 더 높은 탑에 추가
                int highIndex = j + blocks[i];
                if (highIndex < 500001)
                {
                    dp[1, highIndex] = Math.Max(dp[1, highIndex], dp[0, j] + blocks[i]);
                }

                // 현재 블록을 더 낮은 탑에 추가하거나 기존 탑 높이를 조정
                int lowIndex = Math.Abs(j - blocks[i]);
                if (lowIndex < 500001)
                {
                    dp[1, lowIndex] = Math.Max(dp[1, lowIndex], dp[0, j] + (j < blocks[i] ? blocks[i] - j : 0));
                }

                // 현재 상태를 유지하고 블록을 추가하지 않는 경우
                dp[1, j] = Math.Max(dp[1, j], dp[0, j]);
            }
            maxLen += blocks[i];
            for (int k = 0; k <= maxLen; k++)  // dp[1] 결과를 dp[0]로 복사
                dp[0, k] = dp[1, k];

            for (int k = 0; k <= maxLen; k++)  // dp[1]을 초기화
                dp[1, k] = -1;
        }

        // 결과 출력
        Console.WriteLine(dp[0, 0] > 0 ? dp[0, 0] : -1);
    }
}
