namespace ConsoleApp1
{
    //bj11724 /s2 /연결 요소의 개수 / 240220
    //bfs나 dfs를 돌려서, 방문하지 않은 정점이 없을 때 까지 반복하고 
    //마지막으로 그래프탐색을 돌린 횟수를 출력하면 된다. 
    class Program
    {
        //생각해보니 그래프를 구현하는 것 자체는 어려운 게 아닌 거 같음
        static bool[] visited; //방문여부
        static List<int>[] graph; //그래프 인접리스트 구현
        public static void dfs(int now) //그래프탐색
        {//재귀를 이용한 dfs이다
            //지금 정점을 탐색 완료한다
            visited[now] = true;
            //now번 그래프와 인접한 정점을 전부 탐색한다
            //next는 now정점과 인접한 모든 정점의 값이 하나씩 할당된다. 
            foreach (int next in graph[now])
            {
                //탐색이 된 정점은 건너뛴다
                if (visited[next])
                    continue;
                //탐색이 안 된 정점은 재귀함
                dfs(next);
            }
        }
        public static void Main()
        {
            int count = 0; //탐색횟수
            //N, M입력
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0]; //정점의 개수 -> 인접 리스트의 크기
            int M = input[1]; //간선의 개수 -> 입력받을 개수
            graph = new List<int>[N + 1]; //정점이 1부터 시작하기에 +1
            visited = new bool[N + 1]; //위와 같은 이유로
            
            //인접리스트 초기화
            for (int i = 1; i <= N; i++) graph[i] = new List<int>();

            //간선 입력
            for (int i = 0; i < M; i++)
            {
                int[] edge = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int u = edge[0];
                int v = edge[1];
                //무향 그래프이므로 둘 다 연결함
                graph[u].Add(v);
                graph[v].Add(u);
            }
            //탐색이 되는지 안되는지만 알면 돼서 
            //리스트 안의 인접 정점들을 정렬 할 필요는 없음
            //리스트 1부터 n까지 전부 탐색
            for (int i = 1; i <= N; i++)
            {
                //이미 탐색된 정점들이라면 카운트되지 않음
                if (!visited[i])
                {
                    //탐색하지 않은 정점이 있다면
                    //카운트를 올려주고 dfs 실행
                    count++;
                    dfs(i);
                }
            }

            //정답
            Console.Write(count);
        }
    }
}