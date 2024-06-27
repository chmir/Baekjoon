using System;
using System.Collections.Generic;
using System.IO;

class MainClass
{
    static List<Node>[] list; // 트리를 저장할 인접 리스트
    static bool[] visited; // DFS 중 방문한 노드를 추적하는 배열
    static int max = 0; // 가장 긴 거리 (트리의 지름)
    static int node; // 가장 먼 노드를 저장

    public static void Main(string[] args)
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine()); // 노드의 수를 입력받음
        list = new List<Node>[n + 1]; // 노드 번호가 1부터 시작하므로 n+1 크기로 리스트 초기화
        for (int i = 1; i <= n; i++)
        {
            list[i] = new List<Node>(); // 각 노드에 대한 리스트 초기화
        }

        for (int i = 0; i < n; i++)
        {
            var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 입력을 공백 기준으로 분할하여 정수 배열로 변환
            int s = arr[0]; // 시작 노드
            int index = 1;
            while (true)
            {
                int e = arr[index]; // 연결된 노드
                if (e == -1) break; // -1이면 입력 종료
                int cost = arr[index + 1]; // 연결된 간선의 비용
                list[s].Add(new Node(e, cost)); // 인접 리스트에 간선 정보 추가
                index += 2; // 다음 연결된 노드와 비용으로 이동
            }
        }

        // 임의의 노드 (1)에서 가장 먼 노드를 찾기 위해 DFS 수행
        visited = new bool[n + 1];
        dfs(1, 0);

        // 찾은 노드에서부터 가장 먼 노드까지의 거리를 구하기 위해 다시 DFS 수행
        visited = new bool[n + 1];
        dfs(node, 0);

        // 트리의 지름을 출력
        sw.WriteLine(max);
        sw.Flush();
    }

    // DFS 함수: 현재 노드와 누적 거리를 인자로 받음
    public static void dfs(int x, int len)
    {
        if (len > max)
        {
            max = len; // 최대 거리 갱신
            node = x; // 가장 먼 노드 갱신
        }
        visited[x] = true; // 현재 노드 방문 처리

        foreach (var n in list[x])
        {
            if (!visited[n.e])
            {
                dfs(n.e, n.cost + len); // 연결된 노드로 DFS 수행 (누적 거리 갱신)
                visited[n.e] = true; // 연결된 노드 방문 처리
            }
        }
    }

    // Node 클래스: 연결된 노드와 그 비용을 저장
    public class Node
    {
        public int e; // 연결된 노드
        public int cost; // 연결된 간선의 비용

        public Node(int e, int cost)
        {
            this.e = e;
            this.cost = cost;
        }
    }
}
