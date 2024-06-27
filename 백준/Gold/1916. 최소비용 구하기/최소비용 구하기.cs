using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    static void Main(string[] args)
    {
        // 입력받기: 노드 수 n과 간선 수 m
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        // 그래프 초기화: 노드 번호가 1부터 시작하므로 n+1 크기로 배열 생성
        List<(int, int)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        // 간선 정보 입력받기
        for (int i = 0; i < m; i++)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            graph[arr[0]].Add((arr[1], arr[2])); // (도착지, 가중치)
        }

        // 출발점과 도착점 입력받기
        int[] togo = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int start = togo[0];
        int end = togo[1];

        // 방문 여부 배열과 거리 배열 초기화
        bool[] visited = new bool[n + 1];
        int[] distance = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        distance[start] = 0;

        // 우선순위 큐 초기화 (PriorityQueue는 C# 7.0 이후부터 지원)
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);

        // 다익스트라 알고리즘 수행
        while (pq.Count > 0)
        {
            // 현재까지의 최단 거리가 가장 짧은 노드를 꺼낸다.
            int current = pq.Dequeue();
            if (visited[current]) continue; // 이미 방문한 노드는 무시
            visited[current] = true;

            // 인접 노드들을 확인
            foreach (var (next, weight) in graph[current])
            {
                // 새로운 경로의 거리가 더 짧은 경우
                if (distance[next] > distance[current] + weight)
                {
                    distance[next] = distance[current] + weight;
                    pq.Enqueue(next, distance[next]); // 갱신된 거리와 함께 큐에 넣는다.
                }
            }
        }

        // 도착점까지의 최단 거리 출력
        Console.WriteLine(distance[end]);
    }
}
