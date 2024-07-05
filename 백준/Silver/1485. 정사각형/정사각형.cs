using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //bj1485 /s3 /정사각형 /240705
        // 4개의 점이 주어질 때, 이 점들이 정사각형을 이루는지 판별하는 문제입니다.
        // 각 점 사이의 거리 제곱을 구하여 네 변의 길이가 모두 같고
        // 두 대각선의 길이가 같으면 정사각형으로 간주합니다.
        // 복습필요 (특히 람다식 사용에서)

        // 테스트 케이스의 수를 입력 받음
        int n = int.Parse(Console.ReadLine());

        // 각 테스트 케이스 처리
        while (n-- > 0)
        {
            // 4개의 점을 저장할 튜플 배열
            (int x, int y)[] p = new (int, int)[4];

            // 4개의 점을 입력받아 배열 p에 저장
            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine().Split();
                p[i] = (int.Parse(input[0]), int.Parse(input[1]));
            }

            // 점들을 x좌표를 기준으로 정렬, x좌표가 같으면 y좌표를 기준으로 정렬
            Array.Sort(p, (a, b) =>
            {
                if (a.x != b.x) return a.x.CompareTo(b.x);
                return a.y.CompareTo(b.y);
            });

            // 각 점 사이의 거리 제곱을 저장할 배열
            long[,] dis = new long[4, 4];

            // 두 점 사이의 거리 제곱을 계산하여 dis 배열에 저장
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j) continue; // 같은 점이면 거리 0
                    dis[i, j] = DistSquare(p[i], p[j]);
                }
            }

            // 네 변의 길이가 같고 대각선의 길이가 같은지 확인
            //조건을 만족하면 1, 아니면 0
            Console.WriteLine(dis[0, 1] == dis[0, 2] && dis[3, 2] == dis[3, 1] && dis[0, 3] == dis[1, 2] ? 1 : 0);
        }
    }

    // 두 점 사이의 거리 제곱을 계산하는 함수 (유클리드 거리 계산)
    // 루트를 씌워서 정확한 거리를 계산할 필요까진 없으므로 제곱인 채로 저장함
    static long DistSquare((int x, int y) a, (int x, int y) b)
    {
        return ((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y));
    }
}