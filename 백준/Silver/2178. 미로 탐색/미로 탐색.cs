//bj2178 / 미로 탐색 / 240211
class Program
{
    //항상 이동할 수 있는 경우만 입력받기에 예외처리 안해도 되고
    //이 문제의 경우 disMap을 쓰지 않아도 될 거 같다. 함 해보자
    static int N, M;
    //맵
    static int[,] map = new int[101, 101]; //1~100 * 1~100
    static bool[,] visited = new bool[101, 101]; //방문 확인 
    //BFS용 큐 인접행렬 방식이니 x, y 좌표 저장
    static Queue<(int, int)> queue = new Queue<(int, int)>();
    //상하좌우 탐색용 좌표배열
    static readonly int[] dx = { -1, 1, 0, 0 };
    static readonly int[] dy = { 0, 0, -1, 1 };

    static void BFS(int x, int y)
    {
        //map[x, y] = 0; //첫 시작점의 거리를 1로할지 0으로 할지?
        queue.Enqueue((x, y)); //첫 시작점을 넣고
        visited[x, y] = true; //방문 완료

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
                if (curx < 0 || cury < 0 || curx > N || cury > M)
                    continue;
                //이미 방문했거나 벽이라면 continue
                if (visited[curx, cury] == true || map[curx, cury] == 0)
                    continue;
                //방문하지 않은 길이라면 방문 표시를 남기고
                visited[curx, cury] = true;
                //다음에 탐색하도록 큐에 넣어준다. 
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
        //N, M 입력
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        N = arr[0];
        M = arr[1];

        //map 입력
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < M; j++) map[i, j] = input[j] - '0';
        }

        //방문 배열은 어차피 테스트 케이스 하나만 쓰니까 초기화 필요없음

        //시작
        BFS(0, 0);
        //정답
        Console.WriteLine(map[N - 1, M - 1]);
    }
}