/*
 * bj17286 /s5 /유미 /240703
 * 유미가 3명에게 전부 최단거리로 이어지며 안기려면... 음... 어지럽네
 * 감이 안와서 다른 풀이방식을 참고했고, 아래는 그에대한 정리 / 복습 필요
 * 
 * 문제 설명:
 * 4개의 점이 주어졌을 때, 첫 번째 점에서 출발하여 모든 점을 거쳐 다시 첫 번째 점으로 돌아오는 
 * 최소 거리를 구하는 문제입니다. 점 사이의 거리는 유클리드 거리로 계산합니다.
 * 
 * 풀이 방법:
 * 1. 4개의 점 좌표를 입력받습니다.
 * 2. 각 점 사이의 거리를 계산하여 2차원 배열에 저장합니다.
 * 3. DFS를 이용하여 모든 점을 방문하면서 최소 거리를 찾습니다. (이미 방문한 점은 다시 방문x)
 * 4. 현재 점을 방문한 상태에서 다음 점으로 이동하며 거리를 누적하고,
 *    모든 점을 방문했을 때 누적된 거리를 최소값과 비교하여 업데이트합니다.
 */

class Program
{
    static (int x, int y)[] points = new (int, int)[4]; //좌표
    static double[,] dist = new double[4, 4]; //누적거리
    static bool[] visit = new bool[4]; //방문여부
    static int ans = int.MaxValue; //최단거리, 우선 가장 큰 수로 초기화

    static void Main(string[] args)
    {
        // 1. 4개의 점 좌표를 입력받음
        for (int i = 0; i < 4; i++)
        {
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            points[i] = (x, y);
        }

        // 2. 각 점 사이의 거리를 계산하여 2차원 배열에 저장
        for (int i = 0; i < 4; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                //Euclidean distance 계산
                dist[i, j] = dist[j, i] = Math.Sqrt(Math.Pow(points[i].x - points[j].x, 2) + Math.Pow(points[i].y - points[j].y, 2));
            }
        }

        // 3. DFS를 이용하여 모든 점을 방문하면서 최소 거리를 찾음
        DFS(0, 0, 0);

        // 4. 최소 거리를 출력
        Console.WriteLine(ans);
    }

    public static void DFS(int idx, double sum, int cnt)
    {
        // 모든 점을 방문한 경우 최소 거리 갱신
        if (cnt == 4)
        {
            ans = Math.Min(ans, (int)sum);
            return;
        }

        // 이미 방문한 점이면 리턴
        if (visit[idx]) return;

        // 현재 점 방문 표시
        visit[idx] = true;

        // 다음 점으로 이동하며 거리를 누적
        for (int i = 0; i < 4; i++)
        {
            DFS(i, sum + dist[idx, i], cnt + 1);
        }

        // 백트래킹을 위해 방문 표시 해제
        visit[idx] = false;
    }
}