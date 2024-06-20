using System;
using System.Collections.Generic;
using System.IO;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //bj6549 /p5 /히스토그램에서 가장 큰 직사각형 /240131
            //bj1725가 더이상 점수를 주지 않는다는 슬픈사실에 새로 풀었습니다. 

            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            while (true)
            {
                string input = sr.ReadLine(); // 입력 받기
                string[] parts = input.Split(); // 공백으로 분리
                int N = int.Parse(parts[0]); // 막대 개수 읽기
                if (N == 0) break; // 막대 개수가 0이면 종료

                var H = new long[N + 1]; // 히스토그램 막대의 높이를 저장할 배열, 마지막에 0 추가
                for (int j = 0; j < N; j++)
                {
                    H[j] = long.Parse(parts[j + 1]); // 높이 값 저장
                }
                //H[N] = 0; // 히스토그램의 끝에 0을 추가하여 스택을 비울 수 있도록 함

                long maxA = 0; // 최대 직사각형 넓이
                var stk = new Stack<(long Order, long Height)>(); // 스택 선언

                for (int i = 0; i <= N; i++)
                {
                    long refIdx = i; // 가장 왼쪽 인덱스
                    // 현재 막대가 이전 막대보다 낮으면 스택을 비우면서 최대 직사각형 계산
                    while (stk.Count > 0 && stk.Peek().Height >= H[i])
                    {
                        // 스택에서 막대를 꺼내고 너비와 넓이를 계산
                        refIdx = stk.Peek().Order;
                        long width = i - refIdx; // 현재 막대의 너비 계산
                        long tempA = width * stk.Peek().Height; // 현재 막대로 만들 수 있는 직사각형 넓이 계산

                        if (maxA < tempA) maxA = tempA; // 최대 넓이 갱신
                        stk.Pop(); // 현재 막대 제거
                    }
                    // 새로운 막대 추가
                    stk.Push((refIdx, H[i]));
                }

                sw.WriteLine(maxA); // 결과 출력
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
