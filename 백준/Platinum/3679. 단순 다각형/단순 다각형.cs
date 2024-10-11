using System;
using System.Collections.Generic;

public class Program
{
    // Point 구조체: 점의 좌표와 입력 순서를 저장합니다.
    public struct Point : IComparable<Point>
    {
        public int x;   // x좌표
        public int y;   // y좌표
        public int id;  // 입력된 순서 (인덱스)

        // 생성자: x, y 좌표와 id를 설정합니다.
        public Point(int x, int y, int id)
        {
            this.x = x;
            this.y = y;
            this.id = id;
        }

        // IComparable 인터페이스 구현: 점들을 비교할 때 사용됩니다.
        // y좌표가 작을수록, y좌표가 같다면 x좌표가 작을수록 앞에 옵니다.
        public int CompareTo(Point other)
        {
            if (this.y != other.y)
                return this.y.CompareTo(other.y);
            if (this.x != other.x)
                return this.x.CompareTo(other.x);
            return this.id.CompareTo(other.id);
        }
    }

    // ccw 함수: 세 점의 방향을 판단합니다.
    // 반환값이 1이면 반시계 방향, -1이면 시계 방향, 0이면 일직선상에 있습니다.
    static int ccw(Point a, Point b, Point c)
    {
        // 외적 계산을 통해 방향성을 구합니다.
        long t = (long)(b.x - a.x) * (c.y - b.y) - (long)(c.x - b.x) * (b.y - a.y);
        if (t > 0) return 1;    // 반시계 방향
        if (t < 0) return -1;   // 시계 방향
        return 0;               // 일직선상
    }

    // dist 함수: 두 점 사이의 거리의 제곱을 계산합니다.
    static long dist(Point a, Point b)
    {
        long dx = (long)(a.x - b.x);
        long dy = (long)(a.y - b.y);
        return dx * dx + dy * dy;   // 거리의 제곱을 반환
    }

    public static void Main()
    {
        // 테스트 케이스의 수를 입력받습니다.
        int T = int.Parse(Console.ReadLine());

        // 각 테스트 케이스에 대해 반복합니다.
        while (T-- > 0)
        {
            // 한 줄의 입력을 받아 공백으로 분리합니다.
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);  // 점의 개수

            // 점들을 저장할 리스트를 생성합니다.
            List<Point> points = new List<Point>();

            // 입력된 좌표들을 처리하여 points 리스트에 저장합니다.
            for (int i = 0; i < N; i++)
            {
                int x = int.Parse(input[1 + i * 2]);        // x좌표
                int y = int.Parse(input[1 + i * 2 + 1]);    // y좌표
                points.Add(new Point(x, y, i));             // Point 객체 생성 후 추가
            }

            // 가장 작은 점(기준점)을 첫 번째로 이동합니다.
            int minIndex = 0;   // 최소값의 인덱스 초기화
            for (int i = 1; i < N; i++)
            {
                // CompareTo 메서드를 사용하여 더 작은 점을 찾습니다.
                if (points[i].CompareTo(points[minIndex]) < 0)
                {
                    minIndex = i;   // 현재 점이 더 작으면 minIndex 갱신
                }
            }

            // 기준점을 첫 번째 위치로 이동시킵니다.
            Point temp = points[0];
            points[0] = points[minIndex];
            points[minIndex] = temp;

            Point basePoint = points[0];  // 기준점 설정

            // 기준점을 제외한 나머지 점들을 정렬합니다.
            // 정렬 기준:
            // 1. 기준점과의 ccw 값이 양수인 점이 먼저 옴 (반시계 방향)
            // 2. ccw 값이 0이면 기준점과의 거리가 가까운 점이 먼저 옴
            // 3. 거리도 같으면 입력된 순서(id)가 작은 점이 먼저 옴
            points.Sort(1, N - 1, Comparer<Point>.Create((a, b) =>
            {
                int ccwResult = ccw(basePoint, a, b);   // ccw 값을 계산
                if (ccwResult != 0)
                    return -ccwResult;  // ccwResult > 0이면 a가 먼저 옴
                long distA = dist(basePoint, a);    // 기준점과 a의 거리 제곱
                long distB = dist(basePoint, b);    // 기준점과 b의 거리 제곱
                if (distA != distB)
                    return distA.CompareTo(distB);  // 거리가 가까운 순으로 정렬
                return a.id.CompareTo(b.id);        // 거리도 같으면 id 순으로 정렬
            }));

            // 일직선상에 있는 끝부분의 점들을 뒤집습니다.
            // 이는 반시계 방향 정렬에서 일직선상에 있는 점들의 순서를 올바르게 하기 위함입니다.
            int idx = N - 1;    // 마지막 인덱스부터 시작
            while (idx > 1 && ccw(basePoint, points[idx - 1], points[idx]) == 0)
                idx--;  // 일직선상에 있는 점들의 시작 인덱스를 찾음

            // 일직선상에 있는 점들의 부분을 뒤집습니다.
            points.Reverse(idx, N - idx);

            // 결과를 출력합니다.
            for (int i = 0; i < N; i++)
            {
                Console.Write(points[i].id);    // 각 점의 입력 순서(id)를 출력
                if (i != N - 1)
                    Console.Write(" ");         // 마지막이 아니면 공백 추가
            }
            Console.WriteLine();                // 각 테스트 케이스마다 줄 바꿈
        }
    }
}
