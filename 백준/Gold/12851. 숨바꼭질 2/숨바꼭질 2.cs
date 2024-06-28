using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
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

        // 거리 배열을 -1로 초기화합니다.
        Array.Fill(dist, -1);

        // 출발점의 초기값을 설정합니다.
        dist[n] = 0;
        cnt[n] = 1;
        q.Enqueue(n);

        // BFS 탐색을 시작합니다.
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            foreach (int nx in new int[] { cur + 1, cur - 1, cur * 2 })
            {
                // 유효한 범위를 벗어난 경우는 무시합니다.
                if (nx < 0 || nx > 100000) continue;

                if (dist[nx] != -1) // 이미 방문한 경우
                {
                    if (dist[cur] + 1 == dist[nx]) // 최단 거리가 같은 경우
                        cnt[nx] += cnt[cur]; // 경우의 수를 추가합니다.
                }
                else // 처음 방문하는 경우
                {
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
