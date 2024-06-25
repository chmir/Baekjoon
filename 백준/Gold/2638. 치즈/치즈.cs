using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    const int REAL_BLANK = 3;
    const int CHEESE = 1;
    const int BLANK = 0;
    const int MELT = 5;

    static int[] dy = { -1, 1, 0, 0 };
    static int[] dx = { 0, 0, -1, 1 };
    static int N, M, time;

    static int[,] arr = new int[101, 101];
    static int[,] visit = new int[101, 101];

    // 치즈 내, 외부 구분하는 함수
    static void FillBlank()
    {
        // visit 초기화
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                visit[i, j] = 0;
            }
        }

        Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
        q.Enqueue(Tuple.Create(0, 0));
        visit[0, 0] = 1;

        while (q.Count > 0)
        {
            var (y, x) = q.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int ty = y + dy[i];
                int tx = x + dx[i];
                if (ty >= 0 && tx >= 0 && ty < N && tx < M && visit[ty, tx] == 0 && arr[ty, tx] != CHEESE)
                {
                    visit[ty, tx] = 1;
                    arr[ty, tx] = REAL_BLANK;
                    q.Enqueue(Tuple.Create(ty, tx));
                }
            }
        }
    }

    static void Simulation()
    {
        bool flag = false;
        // 모든 칸을 다 살펴본다.
        while (true)
        {
            // (1) 치즈 내, 외부 구분시키기
            FillBlank();

            // (2) 모든 치즈 칸들을 대상으로 녹을 수 있는지 확인하기
            flag = false;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    // 해당 칸이 치즈일 경우
                    if (arr[i, j] == CHEESE)
                    {
                        int cnt = 0;
                        // 그 칸의 상,하,좌,우를 살펴보고 최소 2칸이 REAL_BLANK인지 확인
                        for (int k = 0; k < 4; k++)
                        {
                            int ty = i + dy[k];
                            int tx = j + dx[k];
                            if (ty >= 0 && tx >= 0 && ty < N && tx < M && arr[ty, tx] == REAL_BLANK)
                            {
                                flag = true;
                                cnt++;
                            }
                        }
                        if (cnt >= 2) arr[i, j] = MELT; // 녹는 대상으로 표기
                    }
                }
            }

            // (3) 녹는 대상으로 표기된 적이 있을 경우 외부 공기로 바꾸기
            if (flag)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (arr[i, j] == MELT)
                        {
                            arr[i, j] = REAL_BLANK;
                        }
                    }
                }
            }
            time++;

            flag = false;
            // 치즈가 남아있는지 재검사
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] == CHEESE)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag) break;
        }
    }

    public static void Main()
    {
        using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        var Line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        N = Line[0];
        M = Line[1];

        for (int i = 0; i < N; i++)
        {
            Line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < M; j++)
            {
                arr[i, j] = Line[j];
            }
        }

        Simulation();
        sw.WriteLine(time);

        sr.Close();
        sw.Flush();
        sw.Close();
    }
}
