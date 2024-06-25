using System;
using System.Collections.Generic;

public class Program
{
    const int REAL_BLANK = 3; // 외부 공기를 나타내는 상수
    const int CHEESE = 1;     // 치즈를 나타내는 상수
    const int BLANK = 0;      // 빈 공간을 나타내는 상수
    const int MELT = 2;       // 녹는 치즈를 나타내는 상수

    // 상하좌우 방향을 나타내는 배열
    static int[] dy = { -1, 1, 0, 0 };
    static int[] dx = { 0, 0, -1, 1 };
    static int N, M, time; // 행, 열 크기 및 경과 시간

    static int[,] arr;    // 치즈 상태를 저장하는 배열
    static bool[,] visit; // 방문 여부를 저장하는 배열

    // 외부 공기를 채우는 함수
    static void FillBlank()
    {
        // 방문 배열 초기화
        Array.Clear(visit, 0, visit.Length);

        // BFS를 위한 큐 초기화
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));
        visit[0, 0] = true;

        while (q.Count > 0)
        {
            var (y, x) = q.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int ty = y + dy[i];
                int tx = x + dx[i];
                // 배열 경계 내에 있고, 아직 방문하지 않았으며 치즈가 아닌 경우
                if (ty >= 0 && tx >= 0 && ty < N && tx < M && !visit[ty, tx] && arr[ty, tx] != CHEESE)
                {
                    visit[ty, tx] = true;
                    arr[ty, tx] = REAL_BLANK; // 외부 공기로 변경
                    q.Enqueue((ty, tx));
                }
            }
        }
    }

    // 시뮬레이션을 수행하는 함수
    static void Simulation()
    {
        bool cheeseExists;
        while (true)
        {
            FillBlank(); // 외부 공기를 채움

            cheeseExists = false;
            // 치즈가 녹을 수 있는지 확인
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == CHEESE)
                    {
                        int cnt = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            int ty = i + dy[k];
                            int tx = j + dx[k];
                            // 상하좌우 방향으로 외부 공기와 접촉하는지 확인
                            if (ty >= 0 && tx >= 0 && ty < N && tx < M && arr[ty, tx] == REAL_BLANK)
                            {
                                cnt++;
                            }
                        }
                        if (cnt >= 2) // 최소 2면이 외부 공기와 접촉하는 경우
                        {
                            arr[i, j] = MELT; // 녹는 치즈로 표기
                            cheeseExists = true;
                        }
                    }
                }
            }

            if (!cheeseExists) break; // 더 이상 녹을 치즈가 없는 경우 종료

            // 녹는 치즈를 빈 공간으로 변경
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == MELT)
                    {
                        arr[i, j] = BLANK;
                    }
                }
            }

            time++; // 시간 증가
        }
    }

    public static void Main()
    {
        // 입력 값 읽기
        var Line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        N = Line[0];
        M = Line[1];

        arr = new int[N, M];    // 치즈 상태 배열 초기화
        visit = new bool[N, M]; // 방문 배열 초기화

        // 치즈 상태 배열 채우기
        for (int i = 0; i < N; i++)
        {
            Line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 0; j < M; j++)
            {
                arr[i, j] = Line[j];
            }
        }

        Simulation(); // 시뮬레이션 실행
        Console.WriteLine(time); // 결과 출력
    }
}
