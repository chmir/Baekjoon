using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    // 점(Point)을 나타내는 구조체입니다.
    struct Point
    {
        public int x, y;    // 점의 x, y 좌표
        public int index;   // 입력된 순서 (인덱스)

        // 생성자: 점의 인덱스와 좌표를 초기화합니다.
        public Point(int idx, int xPos, int yPos)
        {
            index = idx;
            x = xPos;
            y = yPos;
        }
    }

    // 세 점 a, b, c에 대해 CCW(Counter Clock Wise)를 계산합니다.
    // 반환값이 양수이면 반시계 방향, 음수이면 시계 방향, 0이면 일직선상에 있습니다.
    static int CCW(Point a, Point b, Point c)
    {
        // 외적(cross product)을 사용하여 세 점의 방향성을 판단합니다.
        long cross = (long)(b.x - a.x) * (c.y - a.y) - (long)(b.y - a.y) * (c.x - a.x);
        if (cross > 0) return 1;    // 반시계 방향
        if (cross < 0) return -1;   // 시계 방향
        return 0;                   // 일직선상에 있음
    }

    // 두 점을 비교하는 함수입니다.
    // 기준점 pivot에 대하여 각 점 a, b를 비교합니다.
    static bool Compare(Point a, Point b, Point pivot)
    {
        int ccwResult = CCW(pivot, a, b);   // CCW 값을 계산하여 방향성을 판단합니다.
        if (ccwResult != 0)
            return ccwResult > 0;   // CCW > 0이면 a가 b보다 먼저 옵니다.
        // CCW 값이 0이면(일직선상에 있으면) 거리 비교를 합니다.
        long distA = (long)(a.x - pivot.x) * (a.x - pivot.x) + (long)(a.y - pivot.y) * (a.y - pivot.y);
        long distB = (long)(b.x - pivot.x) * (b.x - pivot.x) + (long)(b.y - pivot.y) * (b.y - pivot.y);
        if (distA != distB)
            return distA < distB;   // 거리가 짧은 점이 먼저 옵니다.
        return a.index < b.index;   // 거리도 같으면 입력된 순서가 빠른 점이 먼저 옵니다.
    }

    public static void Main()
    {
        int T = int.Parse(Console.ReadLine());  // 테스트 케이스의 수를 입력받습니다.
        StringBuilder sb = new StringBuilder(); // 결과를 저장할 StringBuilder를 생성합니다.

        while (T-- > 0)
        {
            string[] input = Console.ReadLine().Split();   // 한 줄의 입력을 공백으로 분리합니다.
            int N = int.Parse(input[0]);   // 점의 개수를 읽어옵니다.
            Point[] points = new Point[N]; // 점들을 저장할 배열을 생성합니다.
            Point pivot = new Point(-1, int.MaxValue, int.MaxValue);  // 기준점(pivot)을 초기화합니다.
            int pivotIndex = -1;   // 기준점의 인덱스를 저장할 변수입니다.

            // 모든 점들을 입력받아 배열에 저장합니다.
            for (int i = 0; i < N; i++)
            {
                int x = int.Parse(input[1 + i * 2]);       // x 좌표
                int y = int.Parse(input[1 + i * 2 + 1]);   // y 좌표
                points[i] = new Point(i, x, y);            // 점을 생성하여 배열에 저장

                // 기준점(pivot)을 찾습니다.
                // y 좌표가 가장 작고, y 좌표가 같다면 x 좌표가 가장 작은 점을 선택합니다.
                if (pivot.y > y || (pivot.y == y && pivot.x > x))
                {
                    pivot = new Point(i, x, y);    // 새로운 기준점으로 설정
                    pivotIndex = i;                // 기준점의 인덱스 저장
                }
            }

            // 기준점을 첫 번째로 이동시킵니다.
            Point temp = points[0];
            points[0] = points[pivotIndex];
            points[pivotIndex] = temp;

            Point basePoint = points[0];   // 기준점을 basePoint로 설정합니다.

            // 기준점을 제외한 나머지 점들을 정렬합니다.
            // 정렬 기준:
            // 1. CCW 값이 양수인 순서 (반시계 방향으로 정렬)
            // 2. CCW 값이 0이면 기준점과의 거리의 제곱이 작은 순서
            // 3. 거리도 같으면 입력된 순서(index)가 작은 순서
            Array.Sort(points, 1, N - 1, Comparer<Point>.Create((a, b) =>
            {
                int ccwResult = CCW(basePoint, a, b);  // CCW 값을 계산
                if (ccwResult != 0)
                    return -ccwResult; // CCW > 0이면 a가 먼저 오도록 (-ccwResult 사용)
                long distA = (long)(a.x - basePoint.x) * (a.x - basePoint.x) + (long)(a.y - basePoint.y) * (a.y - basePoint.y);
                long distB = (long)(b.x - basePoint.x) * (b.x - basePoint.x) + (long)(b.y - basePoint.y) * (b.y - basePoint.y);
                if (distA != distB)
                    return distA.CompareTo(distB); // 거리의 제곱이 작은 순서로 정렬
                return a.index.CompareTo(b.index); // 입력된 순서(index)가 작은 순서로 정렬
            }));

            // 일직선상에 있는 끝부분 점들을 뒤집습니다.
            // 이는 동일한 각도(즉, CCW 값이 0)인 점들의 순서를 올바르게 하기 위함입니다.
            int l;
            for (l = N - 2; l > 0; l--)
                if (CCW(basePoint, points[l], points[N - 1]) != 0)
                    break;  // CCW 값이 0이 아닌 지점을 찾습니다.
            l++;

            // 일직선상에 있는 점들의 순서를 뒤집습니다.
            Array.Reverse(points, l, N - l);

            // 결과를 출력합니다.
            for (int i = 0; i < N; i++)
            {
                sb.Append(points[i].index);    // 각 점의 index(입력된 순서)를 추가
                if (i != N - 1)
                    sb.Append(" ");            // 마지막이 아니면 공백 추가
            }
            sb.AppendLine();   // 각 테스트 케이스마다 줄바꿈 추가
        }

        Console.Write(sb.ToString());  // 최종 결과를 한 번에 출력합니다.
    }
}
