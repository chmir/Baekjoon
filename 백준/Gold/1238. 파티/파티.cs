using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // bj1238 /g3 /파티 /240714
    /*
    이 문제는 다익스트라 알고리즘을 사용하여 그래프에서 최단 경로를 찾는 문제입니다.
    먼저 각 정점에서 파티가 열리는 정점까지의 최단 경로를 구하고,
    그 후 파티가 열리는 정점에서 각 정점으로 돌아오는 최단 경로를 구합니다.
    각 정점의 왕복 최단 경로를 계산하여 그 중 가장 큰 값을 출력합니다.
    */

    const int INF = 98765432; // 무한대를 나타내는 값
    const int MAX = 1002; // 최대 정점 수

    static void Main()
    {
        // 빠른 입출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 첫 번째 줄 입력: 정점 수, 간선 수, 파티가 열리는 정점
        var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int N = inputs[0];
        int M = inputs[1];
        int X = inputs[2] - 1;

        // 인접 리스트 초기화 (정방향, 역방향)
        List<(int, int)>[] forwardGraph = new List<(int, int)>[N];
        List<(int, int)>[] reverseGraph = new List<(int, int)>[N];
        for (int i = 0; i < N; i++)
        {
            forwardGraph[i] = new List<(int, int)>();
            reverseGraph[i] = new List<(int, int)>();
        }

        // 간선 정보 입력
        for (int i = 0; i < M; i++)
        {
            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int u = inputs[0] - 1;
            int v = inputs[1] - 1;
            int t = inputs[2];
            forwardGraph[u].Add((v, t)); // 정방향 간선
            reverseGraph[v].Add((u, t)); // 역방향 간선
        }

        // 다익스트라 알고리즘 함수
        int[] Dijkstra(int start, List<(int, int)>[] graph)
        {
            int[] Dist = new int[N];
            Array.Fill(Dist, INF);
            var PQ = new PriorityQueue<(int, int), int>();
            PQ.Enqueue((start, 0), 0);
            Dist[start] = 0;

            while (PQ.Count > 0)
            {
                var current = PQ.Dequeue();
                int cur = current.Item1;
                int cost = current.Item2;

                if (cost > Dist[cur]) continue;

                foreach (var (next, nCost) in graph[cur])
                {
                    int ndst = nCost + cost;
                    if (Dist[next] > ndst)
                    {
                        Dist[next] = ndst;
                        PQ.Enqueue((next, ndst), ndst);
                    }
                }
            }

            return Dist;
        }

        // X에서 정점들로 가는 최단 거리
        int[] distFromX = Dijkstra(X, forwardGraph);

        // 정점들에서 X로 가는 최단 거리
        int[] distToX = Dijkstra(X, reverseGraph);

        // 왕복 거리의 최대값 계산
        int maxDist = 0;
        for (int i = 0; i < N; i++)
        {
            int totalDist = distFromX[i] + distToX[i];
            if (totalDist > maxDist)
            {
                maxDist = totalDist;
            }
        }

        // 결과 출력
        sw.WriteLine(maxDist);
        sr.Close();
        sw.Close();
    }
}
