using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //bj12851 /g4 /숨바꼭질 2 /240628
        //1697번에서 추가로 가짓수를 구해야 하는 문제 
        //경우의수를 구하는 방법은, 그 위치에 똑같은 최단거리로 오는 경우가 있을 시
        //카운트 배열에 더하는 것이다. 당연히 그냥 더하면 안되고, 이전의 경우의수를 이어받아야겠지
        //만약 처음 온 좌표라면 당연히 최단거리일테니 이전의 경우의수를 이어받으면 된다.
        //생각해내는대에 어려운 건 아니지만 재밌는 매커니즘같다, 언젠간 써먹을 거 같으니 기억해두자.

        // 거리를 저장할 배열과 경우의 수를 저장할 배열을 선언합니다.
        int[] dist = new int[100002];
        int[] cnt = new int[100002];
        Queue<int> q = new Queue<int>();

        // 입력을 받습니다.
        string[] s = Console.ReadLine().Split(' ');
        int n = int.Parse(s[0]);
        int k = int.Parse(s[1]);

        // 출발점과 도착점이 같은 경우
        if (n == k)
        {
            Console.WriteLine(0);
            Console.WriteLine(1);
            return;
        }

        // 거리 배열을 -1로 초기화합니다. (방문하지 않았음을 뜻함)
        Array.Fill(dist, -1);

        // 출발점의 초기값을 설정합니다.
        dist[n] = 0;
        cnt[n] = 1;
        q.Enqueue(n); //술래의 위치를 넣고

        // BFS 탐색을 시작합니다.
        while (q.Count > 0) //큐가 다 빠질때까지
        {
            int cur = q.Dequeue(); //지금 위치를 빼서 변수에 저장하고
            //이동가능한 3가지 경우를 전부 탐색한다
            foreach (int nx in new int[] { cur + 1, cur - 1, cur * 2 })
            {
                // 유효한 범위를 벗어난 경우는 무시합니다.
                if (nx < 0 || nx > 100000) continue;

                if (dist[nx] != -1) // 이미 방문한 경우
                {
                    //cur에서 nx로 이동할 때의 거리는 dist[cur] + 1이다. 
                    //dist[nx]는 nx에 도달할 수 있는 최단거리이므로 
                    //최단거리로 올 수 있는 경우의수가 하나 더 늘었다는 뜻이된다.
                    //최단거리 계산은 처음 방문하는 경우에서 처리한다.
                    if (dist[cur] + 1 == dist[nx]) // 최단 거리가 같은 경우
                        cnt[nx] += cnt[cur]; // 경우의 수를 추가합니다.
                }
                else // 처음 방문하는 경우
                {
                    //bfs특성상, 처음 방문하는 곳이 최단거리가 될 것이다.
                    dist[nx] = dist[cur] + 1; // 최단 거리를 갱신합니다.
                    cnt[nx] = cnt[cur]; // 경우의 수를 설정합니다.
                    q.Enqueue(nx); // 다음 위치를 큐에 추가합니다.
                }
            }
        }

        // 결과를 출력합니다.
        Console.WriteLine(dist[k]);
        Console.WriteLine(cnt[k]);
    }
}