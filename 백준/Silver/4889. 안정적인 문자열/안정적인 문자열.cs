class Program
{
    static void Main()
    {
        //bj4889 /s1 /안정적인 문자열 /240716
        //그냥 카운트 변수만 써도 되지 않을까? -> 모르겠다 스택쓰자, 스택 문젠데 성의는 보여야제
        //괄호가 열릴때마다 push
        //괄호가 닫혔는데 스택이 비었어 cnt++ 하고 열린거로 바꿔서 push해
        //괄호가 잘 닫히면 pop
        //연산을 마치고 스택에 남은 요소개수 / 2를 cnt에 더함
        //짝수개만 입력 받으니까 나눌 때 요소 개수가 홀수인지 고민 안해도 됨

        //Stack<bool> stk; //괄호가 하나만 있어서 그냥 bool씀
        //입력 시작
        string T = "";
        //매번 입력을 받고'-'면 종료
        for (int i = 1; (T = Console.ReadLine())[0]!='-'; i++) //i는 테스트케이스 번호
        {
            int cnt = 0; //변경할 괄호 수
            var stk = new Stack<bool>(); //귀요미 스택 등장
            //입력받은 괄호 탐색
            foreach (char c in T)
            {
                if (c == '{') { stk.Push(true); } //열리면 넣어
                else if (stk.Count == 0) { stk.Push(true); cnt++; } //안닫히면 cnt++ 하고 괄호 바꿔 넣어
                else { stk.Pop(); } //잘 닫히면 빼
            }
            Console.WriteLine($"{i}. {cnt + stk.Count / 2}"); //정답
        }
    }
}