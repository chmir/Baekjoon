//bj1708 /p5 /볼록 껍질 /240722
//CCW를 사용하여 풀이한다. -> 이렇게 풀어야겠다! 라고 바로 생각나진 않았지만 뭔가 그럴 거 같더라
//처음에 가장 y가 낮은 점을 구하고 그 점부터 시작하여...
//그 점을 기준으로 ccw로 구한 각을 기준으로 정렬 (반시계방향으로 순환할 것임)
//각이 가장 작은 점(dist로 구함)부터 조사하여 볼록 껍질인지 아닌지 확인 후 추가
//볼록껍질인지 아닌지는 이전점, 지금점, 다음점이 시계방향이라면 그건 볼록 껍질이 아니게 됨
//각을 소숫점으로 정렬하면 오차가 있을 수 있어 그냥 시계인지 반시계인지만 그 여부를 반환
//문제 풀이에 사용된 알고리즘은 Graham Scan 알고리즘, 스택에 점 넣어서 Convex Hull 여부 판단하는 거
//아님말고

public class ConvexHull
{
    // 점의 리스트를 저장할 리스트입니다.
    public static List<(long x, long y)> points = new List<(long x, long y)>();

    // CCW 함수는 세 점이 반시계 방향인지 여부를 계산합니다.
    public static long CCW((long x, long y) pt1, (long x, long y) pt2, (long x, long y) pt3)
    {
        long ret = pt1.x * pt2.y + pt2.x * pt3.y + pt3.x * pt1.y;
        ret -= (pt2.x * pt1.y + pt3.x * pt2.y + pt1.x * pt3.y);
        return ret;
    }

    // Dist 함수는 두 점 사이의 거리의 제곱을 계산합니다.
    public static long Dist((long x, long y) pt1, (long x, long y) pt2)
    {
        long dx = pt2.x - pt1.x;
        long dy = pt2.y - pt1.y;
        return dx * dx + dy * dy;
    }

    public static void Main(string[] args)
    {
        // 점의 개수를 입력받습니다.
        int N = int.Parse(Console.ReadLine());

        // 각 점의 좌표를 입력받아 리스트에 추가합니다.
        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine().Split(' ');
            points.Add((long.Parse(input[0]), long.Parse(input[1])));
        }

        // 점들을 정렬하여 가장 작은 y 값을 가지는 점을 찾습니다.
        points.Sort((a, b) => {
            if (a.y != b.y) return a.y.CompareTo(b.y);
            return a.x.CompareTo(b.x);
        });

        // 기준점은 가장 작은 y 값을 가지는 점입니다.
        var basePoint = points[0];
        points.RemoveAt(0);

        // 기준점을 기준으로 나머지 점들을 각도 순으로 정렬합니다.
        points.Sort((x, y) => { //반시계방향을 우선하여 정렬할거임!
            long cw = CCW(basePoint, x, y);
            if (cw == 0) return Dist(basePoint, x).CompareTo(Dist(basePoint, y));
            // CCW 값이 양수이면 x가 y의 반시계 방향에 위치 (각도 순으로 정렬)
            return -cw.CompareTo(0); // CCW 값이 양수이면 반시계, 음수이면 시계 방향이므로 -cw로 정렬
        });
        points.Insert(0, basePoint);

        // 볼록 껍질을 저장할 스택입니다.
        Stack<(long x, long y)> hull = new Stack<(long x, long y)>();

        // 정렬된 점들을 순서대로 처리하여 볼록 껍질을 형성합니다.
        foreach (var point in points)
        {
            //현재 점이 볼록 껍질인지 아닌지 판별하는 부분(중요함)
            while (hull.Count >= 2)
            {
                var top = hull.Pop(); // 스택에서 최상단 점을 제거하고
                var nextToTop = hull.Peek(); // 그 아래의 점을 확인합니다.
                // nextToTop -> top -> point가 시계 방향이면 top을 제거합니다.
                if (CCW(nextToTop, top, point) > 0) //이전점, 지금점, 다음점
                {
                    hull.Push(top); // 다시 top을 스택에 넣고 루프를 종료합니다.
                    break;
                }
            }
            // 현재 점을 껍질에 추가합니다.
            hull.Push(point);
        }

        // 볼록 껍질을 이루는 점들의 개수를 출력합니다.
        Console.WriteLine(hull.Count);
    }
}