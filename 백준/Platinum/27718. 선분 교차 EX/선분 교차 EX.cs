using System;
using System.IO;
using System.Linq;

public class Program
{
    /*
     * bj27718 /p5 /선분 교차 EX /240716
     * 처음엔 그냥 20149번 문제에서 조금만 변형하고... 
     * 여러번 입력받으니까 빠른 입출력쓰면 되겠지 싶었지만 뭔가 계속 아니었다.
     * 채찍피티한테 말끔하게 정리해달라고 계속 부탁 한 게 오히려 독이된 듯, 
     * 다음부턴 막히면 그냥 혼자 해버릇하자.
     * 이것저것 해봤는데 빠른 입출력 자체는 일단 배열에 받고 그 담에 출력하는 게 그나마 나은듯
     * 연산을 N*N하는 것 보다 그냥 (N*N)/2 - N 정도만 연산하고 출력을 N*N번하는 게 좋아보여요
     * 왜 (N*N)/2 - N 연산이냐면 선분끼리의 상태를 2차원 배열상에 저장했다 쳤을 때 
     * arr[n,n]은 항상 3이거든, 선분 자기 자신과 비교하면 그냥 겹칠 수밖에, 길이가 0은 없다고 하니까 뭐
     * 문제 풀이 과정:
     * 1. 표준 입력에서 선분의 개수 n을 읽어들인다.
     * 2. n개의 선분을 읽어서 각 선분을 (x1,y1),(x2,y2) 배열 형태로 저장한다.
     * 3. 모든 선분 쌍을 비교하여 교차 여부를 검사한다.
     * 4. 결과를 2차원 배열에 저장한다. (대칭으로 저장)
     * 5. 2차원 배열의 결과를 출력한다.
     * *나름대로 정리한다고 정리했지만 틀린내용이 있을 수도 있습니다.
     * CCW가 무엇인지? 에 대한 주석은 이미 이전문제에서 적어놨기에 여기선 생략하겠습니다. 
     * 해결한 관련 문제들: 11758(CCW), 17386(선분교차1), 17387(선분교차2), 20149(선분교차3)
     */

    public static void Main()
    {
        // 빠른 입출력
        using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 선분의 개수를 입력받음
        var n = int.Parse(sr.ReadLine());
        var lines = new ((long Y, long X) p1, (long Y, long X) p2)[n];
        var results = new int[n, n];

        // 각 선분의 좌표를 입력받아 저장
        for (var idx = 0; idx < n; idx++)
        {
            var l = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            lines[idx] = ((l[1], l[0]), (l[3], l[2]));
        }

        // 모든 선분 쌍을 비교하여 교차 여부를 검사
        // 1과 3 선분을 비교했다면 3과 1선분을 비교할 필요는 없다
        // 그리고 자기 자신의 선분과는 항상 겹친다
        for (var y = 0; y < n; y++)
        {
            results[y, y] = 3; // 자기 자신과의 교차 결과는 항상 3
            for (var x = y + 1; x < n; x++)
            {
                //교차여부 검사 너무 길어서 메서드로 빼는 게 좋다고 생각했음
                int result = Intersect(lines[y], lines[x]);
                results[y, x] = result;
                results[x, y] = result; // 대칭 결과 저장, 선분 n->m 비교하든 m->n 비교하든 같으니까
            }
        }

        // 결과를 출력
        for (var y = 0; y < n; y++)
        {
            for (var x = 0; x < n; x++)
                sw.Write(results[y, x]);

            sw.WriteLine();
        }

        // 출력 버퍼를 플러시하여 모든 데이터를 출력
        sw.Flush();
    }

    // 두 선분이 교차하는지 여부를 판단하는 함수
    private static int Intersect(((long Y, long X) p1, (long Y, long X) p2) l1, ((long Y, long X) p1, (long Y, long X) p2) l2)
    {
        // CCW (Counter-Clockwise) 값을 계산하여 방향성을 판단
        var c1 = CCW(l1.p1, l1.p2, l2.p1); //선 하나랑 점 하나 ccw 연산
        var c2 = CCW(l1.p1, l1.p2, l2.p2);
        var c3 = CCW(l2.p1, l2.p2, l1.p1);
        var c4 = CCW(l2.p1, l2.p2, l1.p2);

        // CCW 값에 따라 두 선분이 교차하지 않는 경우
        if (c1 * c2 > 0 || c3 * c4 > 0) return 0;
        // 두 선분이 교차하는 경우
        if (c1 * c2 < 0 && c3 * c4 < 0) return 2;

        // 선분의 끝점이 다른 선분 위에 있는 경우 찾기
        bool v1 = IsInsideLine(l1, l2.p1);
        bool v2 = IsInsideLine(l1, l2.p2);
        bool v3 = IsInsideLine(l2, l1.p1);
        bool v4 = IsInsideLine(l2, l1.p2);

        // 네 점이 일직선 위에 있는 경우
        if (c1 == 0 && c2 == 0 && c3 == 0 && c4 == 0)
        {
            //선분의 끝점이 다른 선분 위에 있는 경우
            if (v1 || v2 || v3 || v4)
            {
                // 선분이 겹치는 길이를 계산
                var xlen = Overlap(l1.p1.X, l1.p2.X, l2.p1.X, l2.p2.X);
                var ylen = Overlap(l1.p1.Y, l1.p2.Y, l2.p1.Y, l2.p2.Y);
                //안겹치면 1
                if (xlen == 0 && ylen == 0) return 1;
                //겹쳤으면 3
                return 3;
            }
            //안 만났으니 0
            return 0;
        }
        else //아마 여기까지왔다면 두 선분이 한 점에서 딱 만난 경우겠지, 또는 ㅏ 모양?
        {
            //이 경우는 1 아니면 0 뿐임
            if (v1 || v2 || v3 || v4) return 1;
            else return 0;
        }
    }

    // 두 선분의 겹치는 길이를 계산하는 함수
    private static long Overlap(long x1, long x2, long x3, long x4)
    {
        var xst = Math.Max(Math.Min(x1, x2), Math.Min(x3, x4));
        var xed = Math.Min(Math.Max(x1, x2), Math.Max(x3, x4));

        return xed - xst;
    }

    // 점이 선분 위에 있는지 여부를 판단하는 함수
    private static bool IsInsideLine(((long Y, long X) p1, (long Y, long X) p2) l1, (long Y, long X) p)
    {
        var (p1, p2) = l1;

        // CCW 값을 이용해 점이 선분 위에 있는지 판단
        // 선분 (p1, p2)와 점 p의 CCW 값이 0이어야 같은 선상에 있음
        int ccwValue = CCW(p1, p2, p);
        if (ccwValue != 0) return false; // CCW 값이 0이 아니면 점 p는 선분 (p1, p2) 위에 있지 않음

        // 점 p의 X 좌표가 선분 (p1, p2)의 X 좌표 범위 내에 있는지 확인
        // 그리고 점 p의 Y 좌표가 선분 (p1, p2)의 Y 좌표 범위 내에 있는지 확인
        // 이 조건이 만족되면 점 p는 선분 (p1, p2) 위에 있음
        return Math.Min(p1.X, p2.X) <= p.X && p.X <= Math.Max(p1.X, p2.X) &&
               Math.Min(p1.Y, p2.Y) <= p.Y && p.Y <= Math.Max(p1.Y, p2.Y);
    }

    // 세 점이 일직선 상에 있는지 여부를 판단하는 CCW 함수
    private static int CCW((long Y, long X) p, (long Y, long X) a, (long Y, long X) b)
    {
        (long Y, long X) va = (a.Y - p.Y, a.X - p.X);
        (long Y, long X) vb = (b.Y - p.Y, b.X - p.X);
        return Math.Sign(va.Y * vb.X - va.X * vb.Y);
    }
}