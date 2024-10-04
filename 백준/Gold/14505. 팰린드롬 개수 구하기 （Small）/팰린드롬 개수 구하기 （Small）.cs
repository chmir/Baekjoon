using System;

class Program
{
    static void Main()
    {
        // 사용자로부터 문자열을 입력받습니다.
        string s = Console.ReadLine();
        int len = s.Length;

        // dp[i, j]: 문자열 s의 인덱스 i부터 j까지의 부분 문자열에서의 팰린드롬 부분 수열의 개수를 저장하는 2차원 배열
        long[,] dp = new long[len, len];

        // 길이 1인 부분 수열에 대한 초기화
        for (int i = 0; i < len; i++)
        {
            dp[i, i] = 1; // 자기 자신만으로 이루어진 부분 수열은 항상 팰린드롬이므로 개수는 1

            // 길이 2인 부분 수열에 대한 처리
            if (i + 1 < len)
            {
                if (s[i] == s[i + 1])
                    dp[i, i + 1] = 3; // 두 문자가 같으면 부분 수열은 3개 (s[i], s[i+1], s[i]s[i+1])
                else
                    dp[i, i + 1] = 2; // 두 문자가 다르면 부분 수열은 2개 (s[i], s[i+1])
            }
        }

        // 길이 3 이상인 부분 수열에 대한 동적 계획법 적용
        for (int length = 2; length < len; length++) // 부분 문자열의 길이를 3부터 len까지 증가시킴
        {
            for (int j = 0; j < len - length; j++) // 시작 인덱스 j를 0부터 len - length까지 순회
            {
                int k = j + length; // 끝 인덱스 k를 계산

                if (s[j] == s[k])
                    // 양 끝 문자가 같을 경우
                    dp[j, k] = dp[j + 1, k] + dp[j, k - 1] + 1;
                // dp[j + 1, k]: 첫 번째 문자를 제외한 부분 수열의 개수
                // dp[j, k - 1]: 마지막 문자를 제외한 부분 수열의 개수
                // +1: 양 끝 문자를 포함한 새로운 팰린드롬 부분 수열
                else
                    // 양 끝 문자가 다를 경우
                    dp[j, k] = dp[j + 1, k] + dp[j, k - 1] - dp[j + 1, k - 1];
                // 중복된 부분 수열(dp[j + 1, k - 1])을 빼줌
            }
        }

        // 전체 문자열에 대한 팰린드롬 부분 수열의 개수를 출력
        Console.WriteLine(dp[0, len - 1]);
    }
}
