//bj7585 /s4 /Brackets /240722
//(),[],{} 

class Program
{
    static void Main()
    {
        while (true) {
            string sequence = Console.ReadLine();//괄호들
            if (sequence == "#") break;

            // 결과를 계산하고 출력합니다.
            string result = MaxDepth(sequence);
            Console.WriteLine(result);
        }
    }

    static string MaxDepth(string sequence)
    {
        // 스택을 초기화합니다.
        Stack<char> stack = new Stack<char>();

        // 닫는 괄호와 여는 괄호를 매핑합니다. (안하면 if 길어지니까 이런것도 좋은듯)
        Dictionary<char, char> matchingBracket = new Dictionary<char, char>
        {
            { ')', '(' }, //소괄호
            { ']', '[' }, //대괄호
            { '}', '{' }  //중괄호
        };

        // 시퀀스를 하나씩 검사합니다.
        foreach (char ch in sequence)
        {
            if (ch == '(' || ch == '[' || ch == '{') //여는 괄호
            {
                //스택에 추가
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}') //닫는 괄호
            {
                if (stack.Count > 0 && stack.Peek() == matchingBracket[ch])
                {
                    // 스택의 최상단이 매칭되는 여는 괄호라면 팝
                    stack.Pop();
                }
                else
                {
                    // 매칭되지 않거나 스택이 비어있으면 "NIE"를 반환합니다.
                    return "Illegal";
                }
            }
        } //foreach end
        // 검사를 마치고 괄호가 남아있지 않다면 정답
        return stack.Count > 0 ? "Illegal" : "Legal";
    }
}