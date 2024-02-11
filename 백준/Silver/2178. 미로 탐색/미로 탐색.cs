using System;
using System.Collections.Generic;
//bj2178 / 미로 탐색 / 240211
class Program
{
    //항상 이동할 수 있는 경우만 입력받기에 예외처리 안해도 되고
    //음... 배열을 3개나 써야할까? 하나로 줄일 수는 없나?
    static int N, M;
    //맵
    static int[,] map = new int[101, 101]; //1~100 * 1~100
    static bool[,] visited = new bool[101, 101]; //방문 확인
    static int[,] disMap = new int[101, 101]; //시작점부터의 거리
    //BFS용 큐 인접행렬 방식이니 x, y 좌표 저장
    static Queue<(int, int)> queue = new Queue<(int, int)>();

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
                curx = cur.Item1 + dx[i];
                cury = cur.Item2 + dy[i];
                //인덱스 범위를 벗어나면 continue
                if (curx < 0 || cury < 0 || curx > N || cury > M)
                    continue;
                //이미 방문했거나 해당 집이 0이면 continue
                if (visited[curx, cury] == true || map[curx, cury] == 0)
                    continue;
                visited[curx, cury] = true;
                queue.Enqueue((curx, cury));

                //아까 Pop했던 정보를 기억해두고 거리 맵 배열에 += 해줌
                disMap[curx, cury] += disMap[cur.Item1, cur.Item2];
            }
        }

    }
    static void Main()
    {
        //N, M
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        N = arr[0];
        M = arr[1];

        //map배열 초기화
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                map[i, j] = Convert.ToInt32((input[j].ToString()));
                disMap[i, j] = Convert.ToInt32((input[j].ToString()));
            }
        }

        //방문 배열 초기화
        Reset();
        //시작
        BFS(0, 0);

        Console.WriteLine(disMap[N - 1, M - 1]);
    }
}