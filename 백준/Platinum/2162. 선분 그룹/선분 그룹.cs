//bj2162 /p5 /선분그룹 /240919
//서로 겹친 선분은 같은 그룹,
//서로 일직선 상에 겹쳐도 겹쳤다고 봄


class Program
{
    // 선분을 나타내는 클래스
    class Line
    {
        public int x1, y1, x2, y2;
        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1; this.y1 = y1;
            this.x2 = x2; this.y2 = y2;
        }
    }

    // Union-Find 자료구조를 위한 배열
    static int[] parent;

    // Find 함수 (경로 압축 포함)
    static int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]); // 경로 압축
        return parent[x];
    }

    // Union 함수
    static void Union(int a, int b)
    {
        a = Find(a);
        b = Find(b);
        if (a != b)
            parent[b] = a; // 부모를 동일하게 설정하여 집합 합치기
    }

    // 세 점의 CCW 값 계산
    static int CCW(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        int result = (x1 * y2 + x2 * y3 + x3 * y1)
                    - (x2 * y1 + x3 * y2 + x1 * y3);
        return result > 0 ? 1 : result < 0 ? -1 : 0;
    }

    // 두 선분이 교차하는지 확인하는 함수
    static bool IsIntersect(Line a, Line b)
    {
        int ab = CCW(a.x1, a.y1, a.x2, a.y2, b.x1, b.y1)
               * CCW(a.x1, a.y1, a.x2, a.y2, b.x2, b.y2);
        int cd = CCW(b.x1, b.y1, b.x2, b.y2, a.x1, a.y1)
               * CCW(b.x1, b.y1, b.x2, b.y2, a.x2, a.y2);

        // ab와 cd가 모두 0인 경우, 선분이 일직선상에 있는 경우
        if (ab == 0 && cd == 0)
        {
            return Overlap(a, b); // 겹치는지 확인
        }
        return ab <= 0 && cd <= 0;
    }

    // 일직선상에 있는 두 선분이 겹치는지 확인하는 함수
    static bool Overlap(Line a, Line b)
    {
        // x, y 좌표 범위가 겹치는지 확인
        return Math.Max(Math.Min(a.x1, a.x2), Math.Min(b.x1, b.x2)) <= Math.Min(Math.Max(a.x1, a.x2), Math.Max(b.x1, b.x2))
            && Math.Max(Math.Min(a.y1, a.y2), Math.Min(b.y1, b.y2)) <= Math.Min(Math.Max(a.y1, a.y2), Math.Max(b.y1, b.y2));
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine()); // 선분의 개수
        Line[] lines = new Line[N];
        parent = new int[N];

        // Union-Find 부모 배열 초기화
        for (int i = 0; i < N; i++)
            parent[i] = i;

        // 모든 선분 정보 입력
        for (int i = 0; i < N; i++)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            lines[i] = new Line(input[0], input[1], input[2], input[3]);
        }

        // 모든 선분 쌍에 대해 교차 여부 확인
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (IsIntersect(lines[i], lines[j]))
                {
                    Union(i, j); // 교차하면 합집합 수행
                }
            }
        }

        // 각 그룹의 크기와 그룹 수 계산
        Dictionary<int, int> groupCount = new Dictionary<int, int>();
        int maxSize = 0;

        for (int i = 0; i < N; i++)
        {
            int root = Find(i);
            if (groupCount.ContainsKey(root))
                groupCount[root]++;
            else
                groupCount[root] = 1;

            if (groupCount[root] > maxSize)
                maxSize = groupCount[root];
        }

        Console.WriteLine(groupCount.Count); // 그룹의 수 출력
        Console.WriteLine(maxSize);          // 가장 큰 그룹의 크기 출력
    }
}
