using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // bj1753 /g4 /최단경로 /240714
    // 이 프로그램은 다익스트라 알고리즘을 사용하여 그래프에서 최단 경로를 찾습니다.

    const int MAX = 20010; // 최대 정점 수
    const int INF = int.MaxValue; // 무한대를 나타내는 값으로 int의 최대값 사용

    static void Main()
    {
        // 빠른 입출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 첫 줄 입력: 정점 수, 간선 수
        var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int V = arr[0];
        int E = arr[1];
        int Start = int.Parse(sr.ReadLine()); // 시작 정점

        // 최단 거리를 저장하는 배열과 인접 리스트를 나타내는 배열 초기화
        int[] Dist = new int[MAX];
        List<(int, int)>[] Vertex = new List<(int, int)>[MAX];

        for (int i = 1; i <= V; i++)
        {
            Vertex[i] = new List<(int, int)>();
            Dist[i] = INF; // 모든 거리를 무한대로 초기화
        }

        // 간선 정보 입력
        for (int i = 0; i < E; i++)
        {
            var edge = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            Vertex[u].Add((v, w)); // 인접 리스트에 간선 추가
        }

        // 우선순위 큐 생성 (거리, 정점)
        var PQ = new PriorityQueue<(int, int), int>();

        PQ.Enqueue((Start, 0), 0); // 시작 정점을 큐에 추가
        Dist[Start] = 0; // 시작 정점의 거리를 0으로 설정

        while (PQ.Count > 0)
        {
            var current = PQ.Dequeue(); // 큐에서 가장 작은 값을 추출
            int cur = current.Item1; // 추출한 정점
            int cost = current.Item2; // 추출한 정점까지의 비용

            if (cost > Dist[cur]) continue; // 이미 처리된 경우 건너뜀

            foreach (var (next, nCost) in Vertex[cur])
            {
                if (Dist[next] > cost + nCost)
                {
                    Dist[next] = cost + nCost; // 더 짧은 경로 발견 시 업데이트
                    PQ.Enqueue((next, Dist[next]), Dist[next]); // 큐에 추가
                }
            }
        }

        // 결과 출력
        for (int i = 1; i <= V; i++)
        {
            if (Dist[i] == INF) sw.WriteLine("INF"); // 도달할 수 없는 경우 INF 출력
            else sw.WriteLine(Dist[i]); // 최단 거리 출력
        }

        // StreamWriter 닫기
        sw.Close();
    }
}
