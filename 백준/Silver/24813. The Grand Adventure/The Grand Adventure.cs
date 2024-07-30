//bj24813 //s3 //The Grand Adventure //240731
//$ = b / | = t / * = j
//사실상 (){}[] 3개의 괄호를 쓰는 VPS 문제와 다른 게 없음
//근데 그냥 보면 단어끼리 서로 연관이 있다고 유추하기 어려우니
//닫는쪽을 키, 여는쪽을 값으로 하는 Dictionary<TKey,TValue>를 사용했음

class Program
{
    // 닫는 괄호와 여는 괄호를 매핑합니다. (안하면 if 길어지니까 이런것도 좋은듯)
    static Dictionary<char, char> matchingBracket = new Dictionary<char, char>
    {
        //닫는쪽이 Key여야 함!
        //왜냐면 닫을 때, 열린 괄호가 바로 위에 있는지 확인하기 때문에 
        { 'b', '$' }, // 은행원, 돈
        { 't', '|' }, // 상인, 향
        { 'j', '*' }  // 보석상, 보석
    };

    static void Main()
    {
        // 입력을 받습니다.
        int n = int.Parse(Console.ReadLine());//괄호 길이
        while (n-- > 0)
        {
            // 결과를 계산하고 출력합니다.
            string result = MaxDepth(Console.ReadLine()); //모험길 입력 후 계산
            Console.WriteLine(result);
        }
    }

    static string MaxDepth(string sequence)
    {
        // 스택을 초기화합니다.
        Stack<char> stack = new Stack<char>();

        // 시퀀스를 하나씩 검사합니다.
        foreach (char ch in sequence)
        {
            //.은 그냥 무시
            if (ch == '$' || ch == '|' || ch == '*') //여는 괄호
            {
                //스택에 추가
                stack.Push(ch);
            }
            else if (ch == 'b' || ch == 't' || ch == 'j') //닫는 괄호
            {
                if (stack.Count > 0 && stack.Peek() == matchingBracket[ch])
                {
                    //정상적으로 뺄 수 있다면 빼면 된다.
                    stack.Pop();
                }
                else
                {
                    // 매칭되지 않거나 스택이 비어있으면 "NO"를 반환합니다.
                    return "NO";
                }
            }
        } //foreach end
        // 검사를 마치고 괄호가 남아있지 않다면 정답
        return stack.Count == 0 ? "YES" : "NO";
    }
}