namespace ConsoleApp1
{
    //bj2606 /s3 /바이러스 / 240220
    //1번 정점에서 그래프 탐색 시작 후 
    //탐색된 곳만 바이러스++, 첫 정점은 이미 감염된거니 정답 출력에 주의
    class Program
    {
        //생각해보니 그래프를 구현하는 것 자체는 어려운 게 아닌 거 같음
        static int virus = 0; //감염된 개수
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
                virus++; //이 컴퓨터는 감염됨!
            }
        }
        public static void Main()
        {
            //N, M입력
            int N = int.Parse(Console.ReadLine()); //정점의 개수 -> 인접 리스트의 크기
            int M = int.Parse(Console.ReadLine()); //간선의 개수 -> 입력받을 개수
            graph = new List<int>[N+1]; //정점의 개수
            visited = new bool[N+1]; //탐색여부
            
            //인접리스트 초기화
            for (int i = 1; i <= N; i++) graph[i] = new List<int>();

            //간선 입력
            for (int i = 1; i <= M; i++)
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
            dfs(1);

            //정답
            Console.Write(virus);
        }
    }
}