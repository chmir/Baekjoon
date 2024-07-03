class Program
{
    static void Main()
    {
        //bj3009 /b3 /네 번째 점 /240703
        //축에 평행한 직사각형을 만족하는 네번째 좌표를 구해라
        //세개의 축이 주어진다면, 그 셋중 둘은 x가 같을 것이며, 
        //하나만 다른 x축이 네번째 축의 x가 될 것이다.
        //y도 마찬가지로 볼 수 있다. 두개의 입력 중 어느게 x고 y인지는 중요한 건 아닌듯

        //선언
        int[] x = new int[4]; //3번 인덱스를 정답으로 간주함
        int[] y = new int[4];
        //입력
        for(int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            x[i] = int.Parse(input[0]);
            y[i] = int.Parse(input[1]);
        }
        //연산
        if (x[0] == x[1]) x[3] = x[2]; //2번 인덱스가 다르므로 정답
        else if (x[0] == x[2]) x[3] = x[1]; //1번 인덱스가 다르므로 정답
        else x[3] = x[0]; //둘 다 아니면 0번 인덱스만 다른것
        //y도 똑같이 연산
        if (y[0] == y[1]) y[3] = y[2]; 
        else if (y[0] == y[2]) y[3] = y[1]; 
        else y[3] = y[0];
        //출력
        Console.WriteLine($"{x[3]} {y[3]}");
    }
}