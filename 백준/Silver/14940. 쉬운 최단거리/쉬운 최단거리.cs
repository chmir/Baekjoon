using System;
using System.Collections.Generic;
//bj14940 /s1 /쉬운 최단거리 /240222
//시작지점은 2, 도달 할 수 없다면 -1
class Program
{
    static int sx, sy; //시작지점
    static int N, M; //가로 세로 길이
    //맵
    static int[,] map = new int[1000, 1000]; //0~1000
    static bool[,] visited = new bool[1000, 1000]; //방문 확인
    static int[,] disMap = new int[1000, 1000]; //시작점부터의 거리
    //BFS용 큐 인접행렬 방식이니 x, y 좌표 저장
    static Queue<(int, int)> queue = new Queue<(int, int)>();
    //상하좌우 확인용 좌표
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    static void Reset() //방문배열 초기화
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                visited[i, j] = false;
            }
        }
    }
    static void BFS(int x, int y)
    {
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
                //상하좌우 중 하나
                curx = cur.Item1 + dx[i];
                cury = cur.Item2 + dy[i];
                //인덱스 범위를 벗어나면 continue
                if (curx < 0 || cury < 0 || curx > N || cury > M)
                    continue;
                //이미 방문했거나 해당 집이 0이면 continue
                if (visited[curx, cury] == true || map[curx, cury] == 0)
                    continue;
                //방문하지 않은 길이라면
                visited[curx, cury] = true; //방문 체크
                queue.Enqueue((curx, cury)); //다음을 위해 큐에 넣어줌
                //cur의 상하좌우는 cur 좌표에 있는 거리값에 +1을 한 값이다 
                disMap[curx, cury] += (disMap[cur.Item1, cur.Item2] + 1);
            }
        }

    }
    static void Main()
    {
        //더 빠른 입출력
        var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //N, M
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        N = arr[0];
        M = arr[1];

        //map배열 초기화
        for (int i = 0; i < N; i++)
        {
            //공백을 기준으로 나누고
            string[] input = sr.ReadLine().Split(' ');
            for (int j = 0; j < M; j++)
            {
                //맵 초기화
                map[i, j] = Convert.ToInt32(input[j]);
                //출발지 저장함
                if (map[i, j] == 2)
                {
                    sx = i;
                    sy = j;
                }
            }
        }
        //방문 배열 초기화
        Reset();
        //탐색시작
        BFS(sx, sy);
        //출력 및 -1 예외처리
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                //탐색되지 않았지만 길이 있었다면 -1
                //그외에는 그 좌표를 출력한다
                sw.Write((disMap[i, j] == 0 && map[i, j] == 1) ? "-1 " : $"{disMap[i, j]} ");
            }
            sw.WriteLine(); //개행
        }
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}