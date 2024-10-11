// bj3679 /p4 /단순 다각형 /241011
// n개의 점의 집합이 주어졌을 때, 모든 점을 포함하면서 변이 교차하지 않는 단순 다각형을 만들어야 하는 문제
// 1708번 볼록껍질 문제와는 달리, 이 문제는 볼록껍질을 만들 필요가 없어 그라함 스캔을 사용하지 않았음
// 대신, 점들을 기준점(좌표평면에서 가장 아래쪽에 위치한 점)으로부터 반시계 방향으로 정렬하여 단순 다각형을 구성
//
// **기준점 선택**
// - y좌표가 가장 작은 점을 기준점으로 선택
// - y좌표가 같다면 x좌표가 가장 작은 점을 선택
// - 이는 정렬의 일관성을 유지하고 알고리즘의 안정성을 보장하기 위함
//
// **점들의 정렬 기준**
// 1. **CCW 함수를 사용하여 반시계 방향으로 정렬**
//    - CCW 값이 양수인 순서로 정렬하여 기준점에서 반시계 방향으로 점들을 나열.
// 2. **CCW 값이 0인 경우(일직선상에 있는 점들)**
//    - **기준점과의 거리의 제곱이 작은 순서**로 정렬
//    - 이는 동일한 각도를 가진 점들에 대해 가까운 점부터 연결하여 변이 겹치는 것을 방지하기 위함
// 3. **거리도 같은 경우**:
//    - **입력된 순서(index)가 작은 순서**로 정렬하여 정렬의 안정성을 유지
//
// **일직선상에 있는 점들의 처리**
// - 일직선상에 있는 점들은 정렬 시 끝부분에 모이게 된다. (CCW 값이 0인 점들)
// - 이 점들을 거리가 가까운 순서대로 그대로 연결하면 변이 교차하여 단순 다각형이 되지 않을 수 있다.
// - **해결 방법**:
//   - 해당 점들의 순서를 뒤집어 가장 먼 점부터 연결하여 변의 교차를 방지한다.
//   - 코드에서는 `Array.Reverse` 함수를 사용함
//
// **그 외**
// - 변이 교차하는 이유와 이를 방지하는 방법에 대한 자세한 설명은 이 사이트를 참고했음: https://syerco0.com/15
// - 3개 이상의 점이 일직선 상에 있으면 그 중간에 있는것도 꼭짓점이라 할 수 있는가?
//   - 눈으로 보기에는 변이 꺾여있지 않아도, 그 모든 점을 이어 다각형을 구성하므로 꼭짓점이라 할 수 있다...
// - 아직 완벽히 이해하지 못한 부분이 남아있으므로 복습 필요! 설명도 틀린 부분이 있을 수 있다.
using System.Text;

public class Engelwood__Immaculate_Taste
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