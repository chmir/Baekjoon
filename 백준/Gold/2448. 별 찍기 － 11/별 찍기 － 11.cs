//bj2448 /g4 /별 찍기 - 11 /240430
//뭔소린가 했는데 재귀를 써야했구나
//3*(2*k)만 입력되고, k는 0~10 사이의 정수
//그리고 빠른 입출력도 고려해야 함
//어차피 그릴 게 *하고 ' '중 하나니까 bool로 받았음
class Program
{
    //그려질 배열
    static bool[,] arr; //bool배열은 초기화시 기본값 false
    //삼각형을 재귀적으로 그려주는 함수, 
    static void Triangle(int len, int row, int col) //삼각형 크기, 높이, 너비
    {
        if (len == 3) //그릴 수 있는 가장 작은 삼각형을 그린다 (종료조건)
        {
            // 첫 번째 줄 (1개)
            arr[row, col] = true;
            // 두 번째 줄 (2개)
            arr[row + 1, col - 1] = arr[row + 1, col + 1] = true;
            // 세 번째 줄 (5개)
            arr[row + 2, col - 2] = arr[row + 2, col - 1] = arr[row + 2, col] =
                arr[row + 2, col + 1] = arr[row + 2, col + 2] = true;
        }
        else
        {
            //재귀적으로 삼각형을 그리도록 한다.
            //지금 그릴 삼각형의 절반 크기의 삼각형을 위, 아래의 양옆에 하나씩 그리도록 지시
            //Triangle 함수 자체가 그려주는 게 아니라,
            //각 위치에 그릴 함수 3개가 len이 3이 될 때 까지 재귀하다가 그 위치에 도달하면 그려주는 것
            //3번 재귀하기에 위, 양 옆 둘다 그릴 수 있는 거임
            Triangle(len / 2, row, col); //위에쪽 삼각형의 꼭짓점
            Triangle(len / 2, row + len / 2, col - len / 2); //왼쪽 삼각형의 꼭짓점
            Triangle(len / 2, row + len / 2, col + len / 2); //오른쪽 삼각형의 꼭짓점
        }
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine()); //크기
        //프렉탈 삼각형의 세로길이는 N이지만, 괄호길이는 2*N-1 이어야 한다. 왜냐면
        //삼각형은 중앙을 기준으로 하여 좌우대칭이기 때문
        //예를들어 6이면 삼각형의 아랫면이 5개고 중앙을 기점으로 1칸 띄워서 5개가 2개기에 11
        arr = new bool[N, 2 * N - 1]; //그릴 배열 생성
        //연산
        Triangle(N, 0, N - 1); //맨 위의 높이, 최대 너비를 보내준다. 
        //출력
        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Console.OpenStandardOutput())) //이게 더 느리네
        using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
        {
            for (int i = 0; i < N; i++) // 높이 N
            {
                for (int j = 0; j < 2 * N - 1; j++) // 너비는 2*N - 1
                {
                    sw.Write(arr[i, j] ? '*' : ' ');
                }
                sw.WriteLine();
            }
        }
    }
}