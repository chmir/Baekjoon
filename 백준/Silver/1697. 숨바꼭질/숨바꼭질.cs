//bj1697 /s1 /숨바꼭질 /240224
//이미 탐색한 곳은 탐색하지 않는다
class Program
{
    static int start, end; //시작, 끝
    static bool[] visited = new bool[100001]; //방문여부
    //bool배열은 생성해주면 알아서 false로 초기화 돼있더라
    
    static void bfs(int n) //bfs
    {
        //위치와 거리를 담는 큐 생성
        Queue<(int, int)> q = new Queue<(int, int)>(); 
        q.Enqueue((n, 0)); //시작점과 거리를 저장
        visited[n] = true; //방문했음
        //전부 탐색 될 때 까지만 반복
        //물론 T에서 정답이 안나오는 경우는 없기에 큐가 다 비기전에 끝날듯
        while (q.Count != 0) 
        {
            var v = q.Dequeue(); //위치, 거리
            int idx = v.Item1; //위치
            int dis = v.Item2; //거리
            //이 위치가 끝이다
            if (idx == end)
            {
                Console.Write(dis); //출력하고
                return; //종료
            }
            //지금 위치에서 *2로 갈 수 있는 경우
            if (2 * idx <= 100000 && visited[2 * idx] == false)
            {
                visited[2 * idx] = true; //탐색 됨
                q.Enqueue(( 2 * idx, dis + 1 )); //탐색한 위치에 거리 + 1 해서 저장
            }
            //지금 위치에서 +1로 갈 수 있는 경우
            if (idx + 1 <= 100000 && visited[idx + 1] == false)
            {
                visited[idx + 1] = true; //탐색 됨
                q.Enqueue(( idx + 1, dis + 1 )); //탐색한 위치에 거리 + 1 해서 저장
            }
            //지금 위치에서 -1로 갈 수 있는 경우
            if (idx - 1 >= 0 && visited[idx - 1] == false)
            {
                visited[idx - 1] = true; //탐색 됨
                q.Enqueue(( idx - 1, dis + 1 )); //탐색한 위치에 거리 + 1 해서 저장
            }
        }
    }

    static void Main()
    {
        //입력
        string[] s = Console.ReadLine().Split(' ');
        start = int.Parse(s[0]);
        end = int.Parse(s[1]);
        //출력
        bfs(start);
    }
}