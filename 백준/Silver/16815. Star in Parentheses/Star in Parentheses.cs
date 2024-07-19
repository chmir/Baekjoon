//bj16815 /s5 /Star in Parentheses /240720
//소괄호로 이루어진 올바른 괄호들 사이에 * 하나가 위치한다
//그 별은 몇개의 괄호로 감싸져 있는가? 를 구하면 되는 듯
//음.. 스택을 쓰지 않아도 되겠지만 그래도 스택문제니까

//단순히 열고 닫혔는지만 확인하면 돼서 대충 크기가 작은 bool을 썼는데, 의미는 없음
Stack<bool> stk = new Stack<bool> ();
//입력받은 문자열 탐색
foreach(char c in Console.ReadLine())
{
    //별이 나온 순간, 몇개의 괄호가 열려있는지 출력하면 그게 정답임
    if (c == '*') { Console.WriteLine(stk.Count); return; }
    else if (c == '(') stk.Push(true); // 열리면 넣고
    else stk.Pop(); // ')' 닫히면 빼고
}