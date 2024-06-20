using System;
using System.Collections.Generic;
using System.Linq;
//bj2667 /s1 /단지번호붙이기 /240222
//아직 2차원 맵배열에서 탐색하는 게 좀 약한 거 같다. 
//자존심을 내려놓고 다른 분들의 풀이법을 참고하면서 흡수하자. 
//이 문제도 그렇고, 미로탐색(2178) 문제도 계속 복습하자. 
namespace Programs
{
    class Program
    {
        private static int[,] array; //2차원 맵배열
        private static bool[,] visit; //탐색한 곳인지 여부
        private static int count; //단지 수
        private static int house; //단지 번호
        private static List<int> houseNum = new List<int>(); //단지 내 집의 수
        //상하좌우 탐색에 쓰일 읽기전용 dx, dy배열 
        //const와 다른 점은 런타임 상에서 (1회)초기화가 가능하다는 것. 
        private static readonly int[] dx = { 0, 0, -1, 1 };
        private static readonly int[] dy = { 1, -1, 0, 0 };

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            array = new int[N, N]; //N*N
            visit = new bool[N, N];
            //맵배열 입력
            for (int i = 0; i < N; ++i)
            {
                var lint = Console.ReadLine();
                for (int j = 0; j < lint.Length; ++j)
                {
                    array[i, j] = int.Parse(lint[j].ToString());
                }
            }
            //탐색되지 않은 모든 맵 배열을 탐색
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (array[i, j] == 1 && !visit[i, j])
                    {
                        Dfs(i, j); //dfs 돌리고
                        houseNum.Add(house); //단지 내 집의 수
                        count++; //탐색 될 때마다 총 단지수가 오름
                        house = 0; //단지수는 다시 쓸 수 있으니 초기화
                    }
                }
            }
            houseNum.Sort(); //오름차순 정렬

            Console.WriteLine(count); //총 단지 수
            //단지 내 집의 수 오름차순으로 출력
            foreach (var num in houseNum) Console.WriteLine(num.ToString());
        }
        //재귀함수로 구현한 dfs
        private static void Dfs(int i, int j)
        {
            visit[i, j] = true; //이 좌표는 탐색됨
            house++; //집의 수 + 
            //상하좌우 탐색할 거니까 0~3
            for (int k = 0; k < 4; ++k)
            {
                int nextX = i + dx[k];
                int nextY = j + dy[k];

                if (IsCheck(nextX, nextY))
                {//내가 탐색하지 않은 집이라면
                    if (array[nextX, nextY] == 1 && !visit[nextX, nextY])
                    {
                        Dfs(nextX, nextY); //재귀
                    }
                }
            }
        }
        //제대로 된 집주소인지 더블체크
        private static bool IsCheck(int x, int y)
        {
            return (x >= 0 && x < array.GetLength(0) &&
                    y >= 0 && y < array.GetLength(1));
        }
    }
}