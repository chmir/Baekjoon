/*
 * bj20149 /p4 /선분 교차 3 /240715
 * 17387과 다른점은, 두 선분이 한 점에서 교차한다면 그 점의 x, y를 출력
 * 우선 두 선분의 시작점과 끝점의 x,y좌표를 입력받고... 
 * 첫번째 선분의 각 끝 점을 a, b 그리고 두번째 선분은 c, d라고 가정하고
 * 세 점(a,b,c)이 반시계 방향으로 돌면 ccw값은 1이 되고 시계방향이면 -1가 된다.
 * 점 A(x1, y1), 점 B(x2, y2), 점 C(x3, y3)가 있을 때, CCW 계산은 다음과 같다.
 * 1. 세 점의 위치를 곱하고 더한다: a=x1×y2+x2×y3+x3×y1
 * 2. 반대로 곱하고 더한다: b=y1×x2+y2×x3+y3×x1
 * 3. a - b 값을 계산: 0보다 작으면 ccw값은 1(반시계 방향)
 * 0보다 크다면 ccw값은 -1(시계 방향)
 * 0이라면 세 점이 일직선 상에 있다는 뜻
 * 이 연산은 벡터와 행렬식의 이해가 필요하다. 
 * 세 점 A, B, C에 대하여 벡터A->B와, A->C를 만든다. 
 * AB =(x2−x1,y2−y1) / AC=(x3−x1,y3−y1)
 * 그리고 두 벡터의 방향을 판단하기 위해 다음과 같은 행렬식을 계산한다
 * | x2 - x1 | x3 - x1 |
 * | y2 - y1 | y3 - y1 |
 * 즉, 행렬식의 값은 아래와 같이 계산할 수 있다. 
 * Det=(x2−x1)×(y3−y1)−(y2−y1)×(x3−x1)
 * 이 값이 양수면 반시계 방향, 음수면 시계방향이 된다. 이를 단순화한 게 여기서 작성한 ccw함수
 * 이렇게 abc, abd, cda, cbd에 대한 ccw값을 계산한 후에
 * 선분이 교차하려면 다음의 두 조건을 만족해야한다. 
 * abc와 abd값이 서로 다른 방향이어야 함 즉 abc * abd <= 0 이어야 함
 * cda와 cdb값도 서로 다른 방향이어야 함 즉 cda * cdb <= 0 이어야 함 
 * 두 선분이 끝점에서 만나는 경우, 완전히 겹친 경우도 교차한다고 합니다. 
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 하나의 점을 저장할 리스트
        var v = new List<(long X, long Y)>();
        //입력
        for (int i = 0; i < 2; i++)
        {
            var inputs = Console.ReadLine().Split();
            v.Add((long.Parse(inputs[0]), long.Parse(inputs[1])));
            v.Add((long.Parse(inputs[2]), long.Parse(inputs[3])));
        }
        // 4개의 점 
        var A = v[0]; var B = v[1]; var C = v[2]; var D = v[3];

        // CCW 메서드, 좌표를 튜플로하니까 편하긴 하다
        long CCW((long X, long Y) p1, (long X, long Y) p2, (long X, long Y) p3)
        {
            long result = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
            return result == 0 ? 0 : result > 0 ? 1 : -1;
        }

        // abc * abd가 <= 0 이면서, cda * cdb가 <= 0 이면 선분 교차
        long ans1 = CCW(A, B, C) * CCW(A, B, D);
        long ans2 = CCW(C, D, A) * CCW(C, D, B);

        if (ans1 == 0 && ans2 == 0) // 두 선분이 평행하거나 양 끝점이 접촉해 있을 때
        {
            // A, B를 정렬하여 A가 B보다 앞에 오도록
            if (A.CompareTo(B) > 0)
            {
                var temp = A;
                A = B;
                B = temp;
            }
            // C, D를 정렬하여 C가 D보다 앞에 오도록
            if (C.CompareTo(D) > 0)
            {
                var temp = C;
                C = D;
                D = temp;
            }

            // A <= D && B >= C의 조건을 만족하는지
            //서로 겹치거나 끝 점이 맞닿아 있는 경우
            if (A.CompareTo(D) <= 0 && B.CompareTo(C) >= 0)
            {
                Console.WriteLine(1);
                FindIntersection(A, B, C, D); // 교점 출력
            }
            else
            {
                Console.WriteLine(0); 
            }
        }
        else // 두 선분이 교차하거나 한 점이 다른 선분 위에 있을 때
        {
            //서로 +나 ㅓ 모양으로 교차하는 경우
            if (ans1 <= 0 && ans2 <= 0)
            {
                Console.WriteLine(1);
                FindIntersection(A, B, C, D); // 교점 출력
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }

    // 두 선분이 한 점에서 교차하는지 여부 확인 후 출력 함수
    static void FindIntersection((long X, long Y) A, (long X, long Y) B, (long X, long Y) C, (long X, long Y) D)
    {
        double px = (A.X * B.Y - A.Y * B.X) * (C.X - D.X) - (A.X - B.X) * (C.X * D.Y - C.Y * D.X);
        double py = (A.X * B.Y - A.Y * B.X) * (C.Y - D.Y) - (A.Y - B.Y) * (C.X * D.Y - C.Y * D.X);
        double p = (A.X - B.X) * (C.Y - D.Y) - (A.Y - B.Y) * (C.X - D.X);

        if (p == 0) // 평행할 때
        {
            if (B == C && A.CompareTo(C) <= 0)
                Console.WriteLine($"{B.X} {B.Y}");
            else if (A == D && C.CompareTo(A) <= 0)
                Console.WriteLine($"{A.X} {A.Y}");
        }
        else // 교차할 때
        {
            double x = px / p;
            double y = py / p;

            Console.WriteLine($"{x:F16} {y:F16}");
        }
    }
}

// 확장 메서드를 통해 튜플 비교 연산자 구현
public static class TupleExtensions
{
    public static int CompareTo(this (long X, long Y) a, (long X, long Y) b)
    {
        int compareX = a.X.CompareTo(b.X);
        return compareX != 0 ? compareX : a.Y.CompareTo(b.Y);
    }
}
