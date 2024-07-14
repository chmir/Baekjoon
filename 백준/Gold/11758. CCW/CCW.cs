/*
 * bj11758 /g5 /CCW /240714
 * CCW는 선분이 교차하는지 여부를 계산할 때 사용한다. 
 * 세 점이 반시계 방향이라면 CCW는 0 초과의 값이 나오고
 * 세 점이 시계 방향이라면 CCW는 0 미만의 값이 나온다
 * CCW가 0인 경우에는 세 점이 일직선 상에 있다는 것
 * 이 연산은 벡터와 행렬식의 이해가 필요하다. 
 * 세 점 A, B, C에 대하여 벡터A->B와, A->C를 만든다. 
 * AB =(x2−x1,y2−y1) / AC=(x3−x1,y3−y1)
 * 그리고 두 벡터의 방향을 판단하기 위해 다음과 같은 행렬식을 계산한다
 * | x2 - x1 | x3 - x1 |
 * | y2 - y1 | y3 - y1 |
 * 즉, 행렬식의 값은 아래와 같이 계산할 수 있다. 
 * Det=(x2−x1)×(y3−y1)−(y2−y1)×(x3−x1)
 * 이 값이 양수면 반시계 방향, 음수면 시계방향이 된다. 이를 단순화한 게 여기서 작성한 ccw함수
 * 이걸 이용한 문제는 17386, 17387을 참고하세요
*/

using System;

class Program
{
    static long CCW(long x1, long y1, long x2, long y2, long x3, long y3)
    {
        long res = x1 * y2 + x2 * y3 + x3 * y1 - x2 * y1 - x3 * y2 - x1 * y3;
        return res == 0 ? 0 : res > 0 ? 1 : -1; //0, 1, -1
    }

    static void Main()
    {
        // 입력 값 읽기
        var point1 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        var point2 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        var point3 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long x1 = point1[0], y1 = point1[1];
        long x2 = point2[0], y2 = point2[1];
        long x3 = point3[0], y3 = point3[1];
        //CCW 연산
        Console.WriteLine(CCW(x1, y1, x2, y2, x3, y3));
    }
}