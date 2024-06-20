//bj7576 /토마토 /240305
//처음에 여러개의 bfs를 어떻게 돌릴지, 일자 우선순위도 생각해봤는데
//...생각해보니 bfs잖아? 그냥 처음부터 큐에다가 익은애들을 다 넣으면 
//알아서 돌아간다.. 나 바본가?
class Program
{
    //상자의 크기
    static int N, M;
    //맵
    static int[,] map;//1~1000 * 1~1000
    //BFS용 큐 인접행렬 방식이니 x, y 좌표 저장
    static Queue<(int, int)> queue = new Queue<(int, int)>();
    //상하좌우 탐색용 좌표배열
    static readonly int[] dx = { -1, 1, 0, 0 };
    static readonly int[] dy = { 0, 0, -1, 1 };

    static void BFS()
    {
        while (queue.Count != 0) //큐가 빌 때까지
        {
            var cur = queue.Dequeue(); //큐에서 빼고 저장

            //pop됐을때의 x좌표와 y좌표
            int curx = cur.Item1;
            int cury = cur.Item2;

            //상하좌우 체크
            for (int i = 0; i < 4; i++)
            {
                curx = cur.Item1 + dx[i];
                cury = cur.Item2 + dy[i];
                //인덱스 범위를 벗어나면 continue
                if (curx < 0 || cury < 0 || curx >= N || cury >= M)
                    continue;
                //이미 방문했거나 벽이라면 continue
                if (map[curx, cury] != 0 /*|| map[curx, cury] == -1*/)
                    continue;
                //방문하지 않은 길이라면 다음에 탐색하기 위해 큐에 넣는다. 
                //큐는 가장 이전에 입력받은 게 먼저 출력되므로 
                //탐색방식도 DFS와 달리 넓게넓게 퍼지면서 탐색할 수 있게 된다.
                queue.Enqueue((curx, cury));

                //지금 탐색한 위치는 이전 위치의 거리값에 +1한 값이다
                map[curx, cury] = map[cur.Item1, cur.Item2] + 1;
            }
        }

    }
    static void Main()
    {
        //빠른 입출력
        var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //M, N 입력
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        M = arr[0];
        N = arr[1];
        map = new int[N, M];

        //map 입력, 0, 1, -1
        for (int i = 0; i < N; i++)
        {
            //입력은 어차피 정수만 받을테니 아싸리 형변환 해준다
            int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < M; j++)
            {
                map[i, j] = input[j];
                //익은 토마토라면 큐에 넣어준다
                if (map[i, j] == 1) queue.Enqueue((i, j));
            }
        }

        //방문 배열은 테스트 케이스 하나만 쓰니까 초기화 필요없음

        //토마토 익기 시작
        BFS();

        //출력을 위한 예외처리
        int ans = 1; //정답
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                //안 익은 토마토가 남아있다면 -1
                if (map[i, j] == 0)
                {
                    sw.WriteLine("-1");
	        sr.Close();
                    sw.Flush();
                    sw.Close();
                    return;
                }
                //더 큰 값 초기화
                ans = Math.Max(ans, map[i, j]);
            }
        }

        //정답, 1부터 시작했기에 하루 빼야 함
        sw.WriteLine(ans-1);
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}