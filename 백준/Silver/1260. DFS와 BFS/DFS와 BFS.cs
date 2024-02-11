using System;
//그래프 공부중... 240228~
//bj1260 /s2 /DFS와 BFS /240209
namespace ConsoleApp1
{
    class Program
    {
        //입출력 함수
        static System.IO.StreamReader sr = new System.IO.StreamReader(Console.OpenStandardInput());
        static System.IO.StreamWriter sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //위에 정적으로 두니까 DFS, BFS에서 인자를 추가로 가져갈 필요가 없구나
        static bool[] visited;//정점의 방문여부, 한번 탐색한 정점은 또 탐색 할 필요 X
        static List<int>[] graph;//그래프를 표현하기 위한 2차원 인접리스트
        //1~N까지의 정점이 1차원 리스트에 저장, 각 정점과 연결된 정점의 정보가 2차원 리스트에 저장된다

        //DFS 알고리즘, 스택 혹은 재귀로 구현한다
        public static void DFS(int now) //재귀구현 DFS
        {
            sw.Write(now + " "); //시작점 출력
            visited[now] = true; //시작점 탐색 완료
            //다음으로 탐색할 정점을 계속해서 탐색
            foreach (int next in graph[now])
            {
                if (visited[next]) //이미 탐색한 곳이라면
                    continue; //다음 정점으로 넘어간다
                DFS(next); //탐색되지 않았다면 다시 탐색
            }
        } //다음에는 스택으로 구현하는 DFS도 해볼것
        
        //BFS 알고리즘, 큐로 구현한다
        public static void BFS(int start) //큐 구현 BFS
        {
            Queue<int> queue = new Queue<int>(); //큐 생성
            queue.Enqueue(start); //큐에 시작점을 저장한다
            visited[start] = true; //시작점은 탐색을 완료했음
            while (queue.Count > 0) //큐가 빌 때까지
            {
                int now = queue.Dequeue(); //탐색할 정점을 빼면서 임시저장
                sw.Write(now + " "); //탐색된 정점 출력
                //now정점과 연결된 정점을 탐색한다
                foreach (int next in graph[now])
                {
                    if (!visited[next]) //현재 정점이 다 탐색될 때 까지 
                    {
                        queue.Enqueue(next); //큐에 넣고
                        visited[next] = true; //탐색했음을 저장
                    }
                }
                //더이상 탐색할 게 남아있지 않다면 큐는 비게되고 BFS는 끝난다
            }

        }
        public static void Main()
        {
            //공백으로 나눠 여러개의 정수를 입력받는다
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = input[0]; //정점
            int M = input[1]; //간선
            int V = input[2]; //탐색을 시작할 정점의 번호
            //그래프 초기화, 각 정점에 대한 빈리스트 생성
            graph = new List<int>[N + 1]; //0이 아닌 1부터 시작하기 위해 +1
            for (int i = 1; i <= N; i++) //1~N
            {
                graph[i] = new List<int>();
            }
            //간선 정보 입력
            for (int i = 0; i < M; i++)
            {
                int[] edge = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int u = edge[0];
                int v = edge[1];

                graph[u].Add(v);
                graph[v].Add(u); //양방향 간선이라 반대방향도 추가해준다 
            }
            for (int i = 1; i <= N; i++)
            {
                graph[i].Sort(); //오름차순 정렬
            }

            visited = new bool[N + 1]; //방문여부 초기화 
            DFS(V); //DFS 실행
            sw.WriteLine(); //개행
            visited = new bool[N + 1]; //방문여부 초기화 
            BFS(V); //BFS 실행
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}