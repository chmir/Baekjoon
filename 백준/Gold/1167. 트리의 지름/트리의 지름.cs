using System;
using System.Collections.Generic;
using System.IO;

class MainClass
{
    static List<(int e, int cost)>[] list; // 튜플을 사용한 인접 리스트, 정점번호와 가중치를 저장함
    static bool[] visited; // DFS 중 방문한 노드를 추적하는 배열
    static int max = 0; // 가장 긴 거리 (트리의 지름)
    static int node; // 가장 먼 노드를 저장

    public static void Main(string[] args)
    {
        //bj1167 /g2 /트리의 지름 /240627
        /*
         * 트리의 지름 -> 트리에서 임의의 두 점 중 가장 긴 경로의 길이를 구해야한다.
         * 1. 트리의 각 노드와 간선을 입력받아 튜플 리스트 형태로 저장
         * 2. dfs를 두번 수행함.
         * 2-1. 임의의노드(1,0)에서 시작하여 가장 먼 노드를 찾는다
         * 2-2. 첫번째 dfs에서 찾은 노드에서 시작하여 다시 가장 먼 노드를 찾는다
         * 3. 두번째 dfs로 결과로 얻는 최대 거리가 트리의 지름
         * 왜 그래야 하는지는 자세히 설명할 레벨이 안되지만... 얘는 외워두면 언젠간 써먹을 일도 있을 거 같다. 
         * 그래프에 가중치가 있어서 단순히 첫번째 노드에서 제일 멀다고 가장 긴 경로라고 할 수 없게 되는듯
         * 하지만 처음 dfs를 했을 때 가장 긴 경로의 어딘가에 한번은 걸치겠지(아마도)
         * 솔브닥에 북마크 해두고 두고두고보자~ 
        */
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine()); // 노드의 수를 입력받음
        list = new List<(int e, int cost)>[n + 1]; // 노드 번호가 1부터 시작하므로 n+1 크기로 리스트 초기화
        for (int i = 1; i <= n; i++)
        {
            list[i] = new List<(int e, int cost)>(); // 각 노드에 대한 리스트 초기화
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
                list[s].Add((e, cost)); // 인접 리스트에 간선 정보 추가
                index += 2; // 다음 연결된 노드와 비용으로 이동
            }
        }

        // 임의의 노드 (1)에서 가장 먼 노드를 찾기 위해 DFS 수행
        visited = new bool[n + 1]; //방문한 경로 초기화
        dfs(1, 0);

        // 찾은 노드에서부터 가장 먼 노드까지의 거리를 구하기 위해 다시 DFS 수행
        visited = new bool[n + 1]; //방문한 경로 초기화
        dfs(node, 0);

        // 트리의 지름을 출력
        sw.WriteLine(max);
        sw.Flush();
        sw.Close();
        sr.Close();
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

        foreach (var (e, cost) in list[x])
        {
            if (!visited[e])
            {
                dfs(e, cost + len); // 연결된 노드로 DFS 수행 (누적 거리 갱신)
                visited[e] = true; // 연결된 노드 방문 처리
            }
        }
    }
}