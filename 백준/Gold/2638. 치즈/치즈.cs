using System;
using System.Collections.Generic;

public class Program
{
    //bj2638 /g3 /치즈 /240625 
    //치즈외부와 내부를 구분하는 것은 BFS로한다, 마침 치즈는 가장자리엔 없기때문에 0,0부터 시작해도 됨
    //그다음 치즈 주변에 외부공기가 2칸이상 닿았는지를 확인하고 녹이고... 
    //녹인 치즈를 빈공간으로 만들고... 근데 처음부터 녹인치즈는 그냥 빈공간이라해도 되는 거 아녀?
    //아니지아니지, 그러면 안녹을수도 있던 치즈도 녹아버릴 수 있잖아용

    const int BLANK = 0;      // 빈 공간을 나타내는 상수
    const int CHEESE = 1;     // 치즈를 나타내는 상수
    const int MELT = 2;       // 녹는 치즈를 나타내는 상수
    const int REAL_BLANK = 3; // 외부 공기를 나타내는 상수

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
        q.Enqueue((0, 0)); // 시작점을 (0, 0)으로 설정
        visit[0, 0] = true; // 시작점 방문 처리

        while (q.Count > 0)
        {
            var (y, x) = q.Dequeue(); // 큐에서 좌표를 꺼냄

            // 상하좌우로 탐색
            for (int i = 0; i < 4; i++)
            {
                int ty = y + dy[i];
                int tx = x + dx[i];
                // 배열 경계 내에 있고, 아직 방문하지 않았으며 치즈가 아닌 경우
                if (ty >= 0 && tx >= 0 && ty < N && tx < M && !visit[ty, tx] && arr[ty, tx] != CHEESE)
                {
                    visit[ty, tx] = true; // 방문 처리
                    arr[ty, tx] = REAL_BLANK; // 외부 공기로 변경
                    q.Enqueue((ty, tx)); // 큐에 새 좌표 추가
                }
            }
        }
    }

    // 시뮬레이션을 수행하는 함수
    static void Simulation()
    {
        bool cheeseExists; // 치즈가 남아있는지 여부를 나타내는 변수
        while (true)
        {
            FillBlank(); // 외부 공기를 채움

            cheeseExists = false;
            // 모든 칸을 검사하여 치즈가 녹을 수 있는지 확인
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == CHEESE) // 현재 칸이 치즈인 경우
                    {
                        int cnt = 0; // 외부 공기와 접촉한 면의 개수
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
                            cheeseExists = true; // 녹을 치즈가 있음
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
                        arr[i, j] = BLANK; // 녹은 치즈를 빈 공간으로 변경
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
        N = Line[0]; // 행의 크기
        M = Line[1]; // 열의 크기

        arr = new int[N, M];    // 치즈 상태 배열 초기화
        visit = new bool[N, M]; // 방문 배열 초기화

        // 치즈 상태 배열 채우기
        for (int i = 0; i < N; i++)
        {
            //줄마다 입력
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
