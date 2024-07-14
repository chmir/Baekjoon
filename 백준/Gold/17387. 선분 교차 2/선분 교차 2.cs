/*
 * bj17387 /g2 /선분 교차 2 /240714
 * 17386과 다른점은, 세 점이 일직선 위에 있는 경우가 있다는 거
 * 우선 두 선분의 시작점과 끝점의 x,y좌표를 입력받고... 
 * 첫번째 선분의 각 끝 점을 a, b 그리고 두번째 선분은 c, d라고 가정하고
 * 세 점(a,b,c)이 반시계 방향으로 돌면 ccw값은 1이 되고 시계방향이면 -1가 된다.
 * 점 A(x1, y1), 점 B(x2, y2), 점 C(x3, y3)가 있을 때, CCW 계산은 다음과 같다.
 * 1. 세 점의 위치를 곱하고 더한다: a=x1×y2+x2×y3+x3×y1
 * 2. 반대로 곱하고 더한다: b=y1×x2+y2×x3+y3×x1
 * 3. a - b 값을 계산: 0보다 작으면 ccw값은 1(반시계 방향)
 * 0보다 크거나 같다면 ccw값은 -1(시계 방향)
 * 이 연산은 벡터와 행렬식의 이해가 필요하다. 
 * 점 A에서 B로가는 벡터A->B와, A->C를 만든다. 
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

class Program
{
    static long CCW(long x1, long y1, long x2, long y2, long x3, long y3)
    {
        long a = x1 * y2 + x2 * y3 + x3 * y1;
        long b = y1 * x2 + y2 * x3 + y3 * x1;

        // CCW (Counter Clock Wise) 계산
        if (a - b > 0) return 1; // 반시계 방향
        else if (a - b < 0) return -1; // 시계 방향
        // 둘 다 아니라면
        return 0; // 일직선 상에 있음
    }

    static void Main()
    {
        // 입력 값 읽기
        var input1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var input2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int x1 = input1[0], y1 = input1[1], x2 = input1[2], y2 = input1[3];
        int x3 = input2[0], y3 = input2[1], x4 = input2[2], y4 = input2[3];

        // 점 A, B, C에 대한 CCW 계산
        long abc = CCW(x1, y1, x2, y2, x3, y3);
        // 점 A, B, D에 대한 CCW 계산
        long abd = CCW(x1, y1, x2, y2, x4, y4);
        // 점 C, D, A에 대한 CCW 계산
        long cda = CCW(x3, y3, x4, y4, x1, y1);
        // 점 C, D, B에 대한 CCW 계산
        long cdb = CCW(x3, y3, x4, y4, x2, y2);

        // 두 선분이 교차하는지 확인
        if (abc * abd <= 0 && cda * cdb <= 0)
        {
            //두 선분이 일직선 상에 있는지 확인
            if (abc == 0 && abd == 0 && cda == 0 && cdb == 0)
            {
                // 일직선 상에 있는 경우, 선분의 범위가 겹치는지 확인
                //A, B의 x좌표 범위가 C, D의 x좌표 범위와 겹치는지 확인
                //A, B의 y좌표 범위가 C, D의 y좌표 범위와 겹치는지 확인
                //1번 선분의 맨 뒤보다, 2번 선분의 맨 앞이 더 크면서
                //2번 선분의 맨 뒤가 1번 선분의 맨 앞보다 작다면 그건 겹친거다
                //선분 하나가 다른 선분의 안에 있어도, 아니면 서로 조금씩 겹쳐도 성립됨
                if (Math.Min(x1, x2) <= Math.Max(x3, x4) &&
                    Math.Min(x3, x4) <= Math.Max(x1, x2) &&
                    Math.Min(y1, y2) <= Math.Max(y3, y4) &&
                    Math.Min(y3, y4) <= Math.Max(y1, y2))
                {
                    Console.WriteLine(1); //겹침
                    return;
                }
                else
                {
                    Console.WriteLine(0); //안겹침
                    return;
                }
            }
            Console.WriteLine(1); //교차함
            return;
        }

        // 교차하지 않는 경우
        Console.WriteLine(0);
    }
}