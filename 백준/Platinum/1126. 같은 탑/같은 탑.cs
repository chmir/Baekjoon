/* bj1126 /p3 /같은 탑 /240716
 * dp[cur][diff] 방식 보다 더 빠른 방법이 있음을 확인, 정리해보자
 * 그냥 정리만 하는대도 dp 넘 어려워요
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

        // DP 테이블을 생성하고 -1로 초기화 (-1은 접근 불가한 상태)
        int[,] dp = new int[2, 500001]; //dp[이전상태와현재상태, 가능한 범위 차이] = 지금까지 쌓은 두 탑의 높이 합
        for (int i = 0; i < 500001; i++) //i가 1부터 시작해도 상관 없긴함
        {
            dp[0, i] = -1; //이전까지의 상태
            dp[1, i] = -1; //현재 블록을 추가한 상태
        }
        dp[0, 0] = 0; // 기본 상태: 높이 차이가 0일 때 두 탑의 높이 합은 0

        int maxLen = 0;  // 효율성을 위해 최대 인덱스를 추적합니다.

        // 각 블록을 처리합니다.
        for (int i = 0; i < n; i++)
        {
            //현재 블록을 처리하면서, 높이 차이를 기준으로 가능한 상태를 갱신
            for (int j = 0; j <= maxLen; j++)
            {
                if (dp[0, j] == -1) continue;  // 현재 diff가 달성 불가능하면 스킵

                // 현재 블록을 더 높은 탑에 추가
                int highIndex = j + blocks[i]; // 새 높이차이는 j + block
                if (highIndex < 500001)
                {
                    dp[1, highIndex] = Math.Max(dp[1, highIndex], dp[0, j] + blocks[i]);
                }

                // 현재 블록을 더 낮은 탑에 추가하거나 기존 탑 높이를 조정
                int lowIndex = Math.Abs(j - blocks[i]); // 새 높이차이는 |j - block|
                if (lowIndex < 500001)
                {
                    dp[1, lowIndex] = Math.Max(dp[1, lowIndex], dp[0, j] + (j < blocks[i] ? blocks[i] - j : 0));
                }

                // 현재 상태를 유지하고 블록을 추가하지 않는 경우
                dp[1, j] = Math.Max(dp[1, j], dp[0, j]);
            }
            // 현재까지 고려한 모든 블록의 최대 높이합으로 갱신
            maxLen += blocks[i];
            for (int k = 0; k <= maxLen; k++) // maxLen 이후는 아직 접근하지 않은 영역
            {
                dp[0, k] = dp[1, k]; // dp[1] 결과를 dp[0]로 복사
                dp[1, k] = -1; // dp[1]을 초기화
            }
        }

        // 결과 출력
        // 두 탑의 높이차이가 0인 경우가 정답, 경로가 없었다면 0이 들어있겠지
        Console.WriteLine(dp[0, 0] > 0 ? dp[0, 0] : -1);
    }
}
