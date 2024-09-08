using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 점의 개수 입력
        int n = int.Parse(Console.ReadLine());

        // 좌표를 저장할 리스트
        List<(long x, long y)> v = new List<(long x, long y)>();

        // n개의 점을 입력받아 리스트에 추가
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            v.Add((input[0], input[1])); // (x, y) 형태로 추가
        }

        // 입력받은 선분들을 시작점 기준으로 정렬
        v.Sort();

        // 첫 번째 구간의 시작과 끝점 설정
        long left = v[0].x;
        long right = v[0].y;
        long result = 0;

        // 나머지 구간들을 처리
        for (int i = 1; i < n; i++)
        {
            // 선분이 겹치는지 확인
            if (v[i].x > right)
            {
                // 겹치지 않으면 이전 구간의 길이를 더함
                result += right - left;
                left = v[i].x;
                right = v[i].y;
            }
            else
            {
                // 겹치면 끝점을 확장
                right = Math.Max(right, v[i].y);
            }
        }

        // 마지막 구간의 길이를 더함
        result += right - left;

        // 결과 출력
        Console.WriteLine(result);
    }
}
