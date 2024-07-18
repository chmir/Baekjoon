using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //bj11873 /p3 /최대 직사각형 /240719
        //1725, 6549번 히스토그램 문제와 유사하게 풀이함

        int n, m;
        // 반복적으로 입력을 받아 테스트 케이스를 처리합니다.
        while (true)
        {
            // 입력받은 값을 공백 기준으로 나눕니다.
            string[] input = Console.ReadLine().Split();
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            // n과 m이 모두 0이면 반복을 종료합니다.
            if (n == 0 && m == 0) break;

            // 결과값을 저장할 변수와 높이 배열을 초기화합니다.
            int result = 0;
            int[] heights = new int[m + 1]; // 높이 배열의 크기를 m + 1로 설정

            // 각 행을 처리합니다.
            for (int i = 0; i < n; i++)
            {
                // 현재 행의 값을 입력받습니다.
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    // 현재 열의 값을 읽고, 현재 높이를 업데이트합니다.
                    heights[j] = (int.Parse(row[j]) == 1) ? heights[j] + 1 : 0;
                }

                // 스택을 초기화합니다.
                Stack<int> stack = new Stack<int>();
                // 각 열을 포함하여 마지막 높이를 처리합니다.
                for (int j = 0; j <= m; j++)
                {
                    // 스택을 이용해 최대 직사각형의 넓이를 계산합니다.
                    // 현재 높이가 스택의 꼭대기 높이보다 작다면 스택을 팝하며 넓이를 계산
                    while (stack.Count > 0 && heights[stack.Peek()] > heights[j])
                    {
                        // 스택에서 높이를 꺼냅니다.
                        int height = heights[stack.Pop()];
                        // 너비는 현재 인덱스와 스택의 꼭대기 인덱스의 차이로 계산합니다.
                        int width = (stack.Count == 0) ? j : j - stack.Peek() - 1;
                        // 최대 넓이를 갱신합니다.
                        result = Math.Max(result, height * width);
                    }
                    // 현재 열의 인덱스를 스택에 추가합니다.
                    stack.Push(j);
                }
            }
            // 각 테스트 케이스의 결과를 출력합니다.
            Console.WriteLine(result);
        }
    }
}
