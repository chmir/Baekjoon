/*
 * bj14502 /g2 /연구소 /240702
 * 
 * 이 문제는 연구소의 배치를 나타내는 2차원 배열이 주어지고, 특정 위치에 벽을 세워 바이러스의 확산을 막는 것입니다. 목표는 벽을 세운 후 바이러스가 퍼지지 않은 안전한 영역의 최대 크기를 구하는 것입니다.
 * 
 * 입력:
 * 첫 번째 줄에 연구소의 세로 크기 n과 가로 크기 m이 주어집니다.
 * 두 번째 줄부터 n개의 줄에 연구소의 상태가 주어집니다.
 * 0은 빈 칸, 1은 벽, 2는 바이러스를 의미합니다.
 * 
 * 출력:
 * 바이러스가 퍼지지 않도록 벽을 세웠을 때 안전 영역의 최대 크기를 출력합니다.
 * 
*/

class Program
{
    // 연구소의 상태를 저장할 배열
    static int[,] arr = new int[10, 10];
    // 벽을 세운 후의 상태를 저장할 배열
    static int[,] arr2 = new int[10, 10];
    // 바이러스의 위치를 저장할 배열
    static int[,] virus = new int[64, 2];
    // 바이러스의 수
    static int num = 0;
    // 연구소의 세로 크기와 가로 크기
    static int n, m;

    // 네 방향 이동을 위한 배열 (상, 하, 좌, 우)
    static int[] xx = { 0, 0, -1, 1 };
    static int[] yy = { 1, -1, 0, 0 };

    // 깊이 우선 탐색(DFS) 함수
    static void Dfs(int x, int y)
    {
        for (int i = 0; i < 4; i++)
        {
            int X = x + xx[i]; // 새로운 x 좌표
            int Y = y + yy[i]; // 새로운 y 좌표

            // 연구소 범위 내에 있고, 빈 칸인 경우
            if (X > 0 && X <= n && Y > 0 && Y <= m && arr2[X, Y] == 0)
            {
                arr2[X, Y] = 2; // 바이러스 확산
                Dfs(X, Y); // 재귀적으로 확산
            }
        }
    }

    static void Main()
    {
        int x1, x2, x3, y1, y2, y3; // 세울 벽의 위치
        int ans = 0; // 안전 영역의 최대 크기

        // 연구소의 세로 크기와 가로 크기 입력
        var nm = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        n = nm[0];
        m = nm[1];

        // 연구소의 상태 입력
        for (int i = 1; i <= n; i++)
        {
            var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 1; j <= m; j++)
            {
                arr[i, j] = line[j - 1];
                arr2[i, j] = arr[i, j];

                // 바이러스 위치 저장
                if (arr[i, j] == 2)
                {
                    virus[num, 0] = i;
                    virus[num, 1] = j;
                    num++;
                }
            }
        }

        // 세 벽을 세울 모든 조합을 시도
        for (int i = 0; i < n * m; i++)
        {
            x1 = i / m + 1; y1 = i % m + 1;
            if (arr2[x1, y1] == 0) // 첫 번째 벽 위치
                for (int j = i + 1; j < n * m; j++)
                {
                    x2 = j / m + 1; y2 = j % m + 1;
                    if (arr2[x2, y2] == 0) // 두 번째 벽 위치
                        for (int k = j + 1; k < n * m; k++)
                        {
                            x3 = k / m + 1; y3 = k % m + 1;
                            if (arr2[x3, y3] == 0) // 세 번째 벽 위치
                            {
                                arr2[x1, y1] = 1; // 첫 번째 벽 세우기
                                arr2[x2, y2] = 1; // 두 번째 벽 세우기
                                arr2[x3, y3] = 1; // 세 번째 벽 세우기

                                // 모든 바이러스에 대해 DFS 실행
                                for (int p = 0; p < num; p++)
                                    Dfs(virus[p, 0], virus[p, 1]);

                                int cnt = 0; // 안전 영역 크기 계산

                                // 안전 영역 크기 세기
                                for (int p = 1; p <= n; p++)
                                    for (int q = 1; q <= m; q++)
                                        if (arr2[p, q] == 0) cnt++;

                                // 최대 안전 영역 크기 갱신
                                if (ans < cnt)
                                    ans = cnt;

                                // arr2 배열을 초기 상태로 복구
                                for (int p = 1; p <= n; p++)
                                    for (int q = 1; q <= m; q++)
                                        arr2[p, q] = arr[p, q];
                            }
                        }
                }
        }

        // 결과 출력
        Console.WriteLine(ans);
    }
}