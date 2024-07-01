//bj13549 /g5 /숨바꼭질 3 /240701
//이미 탐색한 곳은 탐색하지 않는다
//이거 그냥 1697에서 순간이동만 시간을 안재면 되는 거 아니야?
//아.. bfs는 간선의 가중치가 모두 같아야만 최단경로를 찾는다고 한다.
//이런 경우엔 다익스트라를 사용해야한다.

class Program
{
    static int start, end; // 시작, 끝
    static int[] dist = new int[100001]; // 거리를 저장하는 배열
    static bool[] visited = new bool[100001]; // 방문 여부

    static void Dijkstra(int n) // 다익스트라 알고리즘
    {
        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
        for (int i = 0; i <= 100000; i++)
        {
            dist[i] = int.MaxValue; // 거리를 무한대로 초기화
        }

        dist[n] = 0; // 시작점의 거리는 0
        pq.Enqueue((n, 0), 0); // 시작점과 거리를 큐에 저장

        while (pq.Count != 0)
        {
            var v = pq.Dequeue(); // 현재 위치와 거리를 큐에서 꺼냄
            int idx = v.Item1; // 현재 위치
            int dis = v.Item2; // 현재 거리

            if (visited[idx]) // 이미 방문한 곳은 다시 방문하지 않음
                continue;
            visited[idx] = true;

            // 현재 위치가 끝이라면 종료
            if (idx == end)
            {
                Console.Write(dis); // 최단 거리 출력
                return; // 종료
            }

            // *2로 순간 이동하는 경우
            if (2 * idx <= 100000 && !visited[2 * idx] && dist[2 * idx] > dis)
            {
                dist[2 * idx] = dis;
                pq.Enqueue((2 * idx, dis), dist[2 * idx]);
            }

            // +1로 이동하는 경우
            if (idx + 1 <= 100000 && !visited[idx + 1] && dist[idx + 1] > dis + 1)
            {
                dist[idx + 1] = dis + 1;
                pq.Enqueue((idx + 1, dis + 1), dist[idx + 1]);
            }

            // -1로 이동하는 경우
            if (idx - 1 >= 0 && !visited[idx - 1] && dist[idx - 1] > dis + 1)
            {
                dist[idx - 1] = dis + 1;
                pq.Enqueue((idx - 1, dis + 1), dist[idx - 1]);
            }
        }
    }

    static void Main()
    {
        // 입력
        string[] s = Console.ReadLine().Split(' ');
        start = int.Parse(s[0]);
        end = int.Parse(s[1]);
        // 다익스트라 알고리즘 호출
        Dijkstra(start);
    }
}