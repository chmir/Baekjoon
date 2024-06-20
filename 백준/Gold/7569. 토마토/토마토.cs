//bj7569 /토마토 /240305
//7576의 확장버전, 위 아래를 확인하는 좌표배열 필요
class Program
{
    //상자의 크기
    static int M, N, H; //가로 세로 높이
    //맵
    static int[,,] map; //M 2~100 * N 2~100 * H 1~100
    //BFS용 큐 인접행렬 방식이니 x, y 좌표 저장
    static Queue<(int h, int n, int m)> queue = new Queue<(int, int, int)>();
    //상하좌우 탐색용 좌표배열
    static readonly int[] dx = { -1, 1, 0, 0, 0, 0 };
    static readonly int[] dy = { 0, 0, -1, 1, 0, 0 };
    static readonly int[] dh = { 0, 0, 0, 0, 1, -1 }; //높이

    static void BFS()
    {
        while (queue.Count != 0) //큐가 빌 때까지
        {
            var cur = queue.Dequeue(); //큐에서 빼고 저장
            //pop됐을때의 x좌표와 y좌표, h
            int curh = cur.h;
            int curx = cur.n;
            int cury = cur.m;

            //상하좌우 체크
            for (int i = 0; i < 6; i++)
            {
                curx = cur.n + dx[i];
                cury = cur.m + dy[i];
                curh = cur.h + dh[i];
                //인덱스 범위를 벗어나면 continue
                if (curx < 0 || cury < 0 || curh < 0 || curx >= N || cury >= M || curh >= H)
                    continue;
                //이미 방문했거나 벽이라면 continue
                if (map[curh, curx, cury] != 0)
                    continue;
                //방문하지 않은 길이라면 다음에 탐색하기 위해 큐에 넣는다. 
                //큐는 가장 이전에 입력받은 게 먼저 출력되므로 
                //탐색방식도 DFS와 달리 넓게넓게 퍼지면서 탐색할 수 있게 된다.
                queue.Enqueue((curh, curx, cury));

                //지금 탐색한 위치는 이전 위치의 거리값에 +1한 값이다
                map[curh, curx, cury] = map[cur.h, cur.n, cur.m] + 1;
            }
        }
    }
    static void Main()
    {
        //빠른 입출력
        var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //M, N, H 입력
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        M = arr[0];
        N = arr[1];
        H = arr[2];
        map = new int[H, N, M];
        //map 입력, 0, 1, -1
        //H가 가장 밖에 있어야 할듯
        for (int h = 0; h < H; h++)
        {
            for (int i = 0; i < N; i++)
            {
                //입력은 어차피 정수만 받을테니 아싸리 형변환 해준다
                int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < M; j++)
                {
                    map[h, i, j] = input[j];
                    //익은 토마토라면 큐에 넣어준다
                    if (map[h, i, j] == 1) queue.Enqueue((h, i, j));
                }
            }
        }


        //방문 배열은 테스트 케이스 하나만 쓰니까 초기화 필요없음

        //토마토 익기 시작
        BFS();

        //출력을 위한 예외처리
        int ans = 1; //정답
        for (int h = 0; h < H; h++)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    //안 익은 토마토가 남아있다면 -1
                    if (map[h, i, j] == 0)
                    {
                        sw.WriteLine("-1");
                        sr.Close();
                        sw.Flush();
                        sw.Close();
                        return;
                    }
                    //더 큰 값 초기화
                    ans = Math.Max(ans, map[h, i, j]);
                }
            }
        }


        //정답, 1부터 시작했기에 하루 빼야 함
        sw.WriteLine(ans - 1);
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}