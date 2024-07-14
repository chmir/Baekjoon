class Program
{
    static void Main(string[] args)
    {
        //bj1789 /s5 /수들의 합 /240715
        /* 
         * 최대한 많은 자연수를 더하려면 1부터 더하면 됨
         * 1+2+3+...n+m > S 가 되는 순간, 마지막에 더한 수였던 m을 빼고
         * 그 이전에 더한 n을 딱 S가 되도록 숫자를 변경하면 그게 정답이므로
         * S를 넘을때까지 1부터 하나씩 증감하여 더하다가, 
         * S를 넘는 순간 지금까지 더한 횟수에 -1을 하면 그게 정답
         */
        //초기값
        long sum = 0; // 현재까지의 합계를 저장하는 변수
        int cnt = 1;  // 더한 횟수 및 현재 더하려는 숫자를 나타내는 변수
        //입력
        long S = long.Parse(Console.ReadLine());
        //연산시작
        for (; ; cnt++) 
        {
            // sum에 cnt를 더한 수가 S보다 큰지 검사
            if ((sum += cnt) > S)  
            {
                //출력
                Console.WriteLine(cnt-1); 
                break; //종료
            }
        }
    }
}