using System;

class Program
{
    // bj1064 /s4 /평행사변형 /240710
    // 이 프로그램은 주어진 세 점을 이용해 평행사변형을 만들 수 있는지 확인하고,
    // 평행사변형을 만들 수 있다면 가장 큰 둘레와 가장 작은 둘레의 차이를 계산합니다.
    // 세 점이 동일한 직선상에 있거나 평행사변형을 만들 수 없는 경우 -1을 출력합니다.
    // 복습필요

    static void Main()
    {
        // 입력 값을 받아 각 변수에 할당
        string[] input = Console.ReadLine().Split();
        int XA = int.Parse(input[0]);
        int YA = int.Parse(input[1]);
        int XB = int.Parse(input[2]);
        int YB = int.Parse(input[3]);
        int XC = int.Parse(input[4]);
        int YC = int.Parse(input[5]);

        double answer = 0.0;

        // 세 점이 동일한 직선상에 있는지 확인
        if (XA == XB && XB == XC || YA == YB && YB == YC)
        {
            // 모든 x좌표 또는 y좌표가 동일하면 동일한 직선상에 존재
            answer = -1.0;
        }
        else if ((YA - YB != 0) && (YA - YC != 0) && (YB - YC != 0) &&
                 (double)(XA - XB) / (YA - YB) == (double)(XB - XC) / (YB - YC) &&
                 (double)(XB - XC) / (YB - YC) == (double)(XA - XC) / (YA - YC))
        {
            // 세 점이 직선상에 존재하는지 확인
            // 기울기를 비교하여 세 점이 동일한 직선상에 있는 경우를 확인
            answer = -1.0;
        }
        else
        {
            // 각 변의 거리 계산
            double dAB = Math.Sqrt(Math.Pow(XA - XB, 2) + Math.Pow(YA - YB, 2));
            double dBC = Math.Sqrt(Math.Pow(XB - XC, 2) + Math.Pow(YB - YC, 2));
            double dCA = Math.Sqrt(Math.Pow(XC - XA, 2) + Math.Pow(YC - YA, 2));

            // 최대 둘레와 최소 둘레의 차이 계산
            answer = (Math.Max(dAB, Math.Max(dBC, dCA)) - Math.Min(dAB, Math.Min(dBC, dCA))) * 2;
        }

        // 결과 출력
        Console.WriteLine(answer);
    }
}