using System;
using System.Linq;

/* bj1126 /p3 /같은 탑 /240726
 * 첫째줄에는 블럭의 개수, 둘째줄에는 각 블럭의 높이가 주어짐
 * 두개의 탑이 높이가 같으면서 만들 수 있는 가장 높은 높이를 쌓아야 한다.
 * 먼저 블록의 개수와, 두 탑의 높이 차이를 뜻하는 dp[cur][diff]를 만든다.
 * 높이 차이는 0 또는 양수를 저장한다.(절댓값 사용)
 * 그리고 그 안에 저장되는 값은 첫 블록부터 cur번째 블록까지 고려했을 때,
 * 두 탑의 높이차이가 diff가 되는, 두 탑의 높이 합의 최댓값을 저장함.
 * 
 * 각 블록을 두 탑에 놓으려 할 때, 세 가지 선택지를 생각해볼 수 있다:
 * 1. 현재 블록을 아예 사용하지 않는 경우: 변하는 값 없음.
 * 2. 현재 블록을 더 높은 탑에 추가하는 경우: 높이 차이는 diff+현재 블록의 높이로 증가.
 * 3. 현재 블록을 더 낮은 탑에 추가하는 경우: 높이 차이는 |diff-현재 블록의 높이|로 갱신.
 * 초기 조건과 계산:
 * dp[0][0] = 0으로 시작. 이는 아무 블록도 사용하지 않은 상태를 나타냄.
 * 모든 블록에 대해 위의 전이를 계산 후, 최종적으로 dp[n][0]의 값을 확인.
 * 그 값이 0보다 크면 두 탑의 높이를 같게 만들 수 있는 최대 높이 합이고, 
 * 0이라면 두 탑의 높이를 같게 만드는 것이 불가능하다.
 * dp[n][0] == 0 이면 두 탑의 높이를 같게 만들 수 있는 경우가 없음을 의미하므로 -1을 출력.
 */
class Program
{
    static int[] arr;  // 블록의 높이를 저장하는 배열
    static int[,] dp;  // 메모리제이션을 위한 2차원 배열
    static int n;      // 블록의 총 개수

    // 동적 프로그래밍을 이용한 문제 해결 함수
    static int Dpf(int cur, int diff)
    {
        if (dp[cur, diff] != 0) return dp[cur, diff];  // 이미 계산된 값이 있으면 반환

        if (cur == n)  // 모든 블록을 고려했을 때
        {
            if (diff != 0) return int.MinValue;  // 높이 차이가 0이 아니면 유효하지 않은 경우
            return 0;  // 유효한 경우 기본값 반환
        }

        int without = Dpf(cur + 1, diff);  // 현재 블록을 사용하지 않는 경우
        int withPositive = Dpf(cur + 1, diff + arr[cur]) + arr[cur];  // 현재 블록을 더 높은 탑에 추가
        int withNegative = Dpf(cur + 1, Math.Abs(diff - arr[cur])) + (diff - arr[cur] < 0 ? arr[cur] - diff : 0);  // 현재 블록을 더 낮은 탑에 추가

        return dp[cur, diff] = Math.Max(Math.Max(without, withPositive), withNegative);  // 세 경우 중 최댓값을 메모이제이션
    }

    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());  // 사용자로부터 블록의 개수 입력 받음
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();  // 블록의 높이 입력 받음
        dp = new int[51, 500001];  // dp 배열 초기화

        int ans = Dpf(0, 0);  // 동적 프로그래밍 함수 호출

        Console.WriteLine(ans > 0 ? ans : -1);  // 결과 출력
    }
}
