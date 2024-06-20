using System.Text;

namespace ConsoleApp1
{
    //bj4963 /s2 /섬의 개수 /240224
    //1012번 유기농배추를 조금 응용하면 되지 않을까? 
    //살짝 달라진 점은 대각선까지 봐야한다. 그러므로... 
    //상하좌우 확인용 배열을 확장하면 된다. 
    //원래는 상하좌우만 봤으니까, 좌상(-1,-1), 좌하(1,-1), 우상(-1,1), 우하(1,1)까지 본다
    //너비와 높이를 입력받으며, 0 0이면 종료
    //문제에서 정사각형이라 했던 거 같은데, 아무튼 너비가 2차원, 높이가 1차원 인덱스 크기 같다 
    class Program
    {
        //너비, 높이
        static int W, H;
        //맵 저장 행렬
        static int[,] map = new int[51, 51];
        //방문 확인 행렬
        static bool[,] visited = new bool[51, 51];
        //상하좌우 확인용 배열
        static int[] dx = { -1, 1, 0, 0, -1, 1, -1, 1 };
        static int[] dy = { 0, 0, -1, 1, -1, -1, 1, 1 };
        //각 테스트케이스에 대한 섬의 개수
        static int count;

        static void Reset() //섬의 수, 맵, 방문여부 초기화
        {
            count = 0; //섬개수
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    visited[i, j] = false; //방문여부
                    //map[i, j] = 0; //어차피 다시 입력받으니까
                }
            }
        }
        //재귀함수로 구현한 dfs
        static void DFS(int x, int y)
        {
            visited[x, y] = true; //이 좌표는 탐색됨
            //상하좌우 + 대각선 탐색할 거니까 0~7
            for (int k = 0; k < 8; ++k)
            {
                int nextX = x + dx[k]; //탐색 할 x좌표 (상하)
                int nextY = y + dy[k]; //탐색 할 y좌표 (좌우)

                //인덱스 범위를 벗어나면 continue
                if (nextX < 0 || nextY < 0 || nextX > H || nextY > W)
                    continue;
                //방문을 안했고, 배추가 있는 곳이라면
                if (map[nextX, nextY] == 1 && !visited[nextX, nextY])
                {
                    DFS(nextX, nextY); //재귀
                }
            }
        }
        static void Main(string[] args)
        {
            //더 빠른 입출력
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder(); //스트링빌더 생성
            //0 0 입력 받을 때 까지 반복
            while(true)
            {
                int[] inputdata = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

                W = inputdata[0]; //너비
                H = inputdata[1]; //높이
                if (W == 0 && H == 0) break;
                //K = inputdata[2]; //섬의 개수

                //방문,맵 배열 및 count초기화
                Reset();

                //지도 입력
                for (int i = 0; i < H; i++)
                {
                    int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                    for(int j = 0; j < W; j++)
                    {
                        map[i, j] = input[j];
                    }
                }

                //map배열을 순회하면서 섬 찾기
                for (int j = 0; j < H; j++)
                {
                    for (int k = 0; k < W; k++)
                    {
                        if (map[j, k] == 1 && visited[j, k] == false)
                        {
                            DFS(j, k); //탐색 안된 섬이면 탐색 시작
                            count++; //섬 개수 추가용
                        }
                    }
                }
                sb.AppendLine(count.ToString()); //각 T별로 저장
            }
            //출력
            sw.Write(sb);
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}