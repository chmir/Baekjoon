using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 문제: bj14002 /g4 /가장 긴 증가하는 부분 수열 4 /240505
        // 이분탐색 방식은 정확한 LIS 수열을 출력하지 않기 때문에 동적 계획법 사용
        int n = int.Parse(Console.ReadLine());  // 수열의 크기 입력 받기
        int[] sequence = new int[n + 1]; // 수열을 저장하는 배열

        List<int> increase = new List<int>(); // LIS를 저장하는 리스트
        int[] DP = new int[n + 1]; // 각 위치에서의 LIS의 길이를 저장하는 배열

        DP[0] = 1; // 초기값 설정
        int len = 0; // 최대 LIS의 길이

        string[] inputs = Console.ReadLine().Split(' ');  // 두 번째 줄에 수열 입력 받기
        for (int i = 1; i <= n; i++)
        {
            sequence[i] = int.Parse(inputs[i - 1]);  // 수열의 각 요소를 저장

            DP[i] = 1; // 초기값 설정
            for (int j = 1; j < i; j++)
            {
                if (DP[i] <= DP[j] && sequence[j] < sequence[i])
                {
                    DP[i] = DP[j] + 1; // DP[i]를 갱신하여 LIS의 길이를 구함
                }
            }
            len = Math.Max(len, DP[i]); // 최대 LIS의 길이 갱신
        }

        Console.WriteLine(len);  // 가장 긴 증가하는 부분 수열의 길이 출력
        for (int i = n; i > 0; i--)
        {
            if (DP[i] == len)
            {
                increase.Add(sequence[i]); // 최대 LIS의 뒤에서부터 순회하며 LIS의 요소를 추가
                len--; // LIS의 길이를 줄임
            }
        }

        for (int i = increase.Count - 1; i >= 0; i--)
        {
            Console.Write(increase[i] + " ");  // 가장 긴 증가하는 부분 수열 출력
        }
    }
}