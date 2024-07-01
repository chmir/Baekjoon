using System;
using System.IO;

class Program
{
    const int MAX = 9;
    static int N, M; // 두 입력값, N(수열의 범위), M(수열의 크기)
    static int[] sequence = new int[MAX]; // 생성된 수열을 저장할 배열
    static bool[] visited = new bool[MAX]; // dfs를 위한 방문 여부 배열

    static void Main()
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 입력값 읽기
        string[] inputs = sr.ReadLine().Split();
        N = int.Parse(inputs[0]);
        M = int.Parse(inputs[1]);

        // DFS 호출
        dfs(0, sw);

        // 스트림 정리
        sw.Flush();
        sw.Close();
        sr.Close();
    }

    static void dfs(int cnt, StreamWriter sw)
    {
        if (cnt == M)  // 배열 크기가 최대 크기에 도달했을 때
        {
            for (int index = 0; index < M; index++)
                sw.Write(sequence[index] + " ");
            sw.WriteLine();
            return;
        }
        else
        {
            for (int index = 1; index <= N; index++)
            {
                if (!visited[index])
                {
                    visited[index] = true;
                    sequence[cnt] = index;
                    dfs(cnt + 1, sw);
                    visited[index] = false;
                }
            }
        }
    }
}