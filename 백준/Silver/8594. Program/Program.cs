//bj8694 //s3 //Program //240722
//문제의 언어는.. 폴란드어 인 거 같네요. 
//3개의 괄호가 올바르게 중첩되어 있는지를 계속 확인해줘야하고
//정답이면 괄호들의 최대 깊이(가장 많이 중첩된 괄호의 깊이)를 출력해주고 
//아니면 NIE, 올바른 괄호인지 아닌지는 구분하기 쉬우니 설명 생략

class Program
{
    static void Main()
    {
        // 입력을 받습니다.
        //int n = int.Parse(Console.ReadLine());//괄호 길이(필요없음)
        Console.ReadLine();//괄호 길이(필요없음)
        string sequence = Console.ReadLine();//괄호들

        // 결과를 계산하고 출력합니다.
        string result = MaxDepth(sequence);
        Console.WriteLine(result);
    }

    static string MaxDepth(string sequence)
    {
        // 스택을 초기화합니다.
        Stack<char> stack = new Stack<char>();
        int maxDepth = 0;
        int currentDepth = 0;

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
                //스택에 추가하고 현재 깊이를 증가시킵니다.
                stack.Push(ch);
                currentDepth++;
                // 최대 깊이를 갱신합니다.
                if (currentDepth > maxDepth) maxDepth = currentDepth;
            }
            else if (ch == ')' || ch == ']' || ch == '}') //닫는 괄호
            {
                if (stack.Count > 0 && stack.Peek() == matchingBracket[ch])
                {
                    // 스택의 최상단이 매칭되는 여는 괄호라면 팝하고 현재 깊이를 감소시킵니다.
                    stack.Pop();
                    currentDepth--;
                }
                else
                {
                    // 매칭되지 않거나 스택이 비어있으면 "NIE"를 반환합니다.
                    return "NIE";
                }
            }
        } //foreach end
        // 검사를 마치고 괄호가 남아있지 않다면 정답
        return stack.Count > 0 ? "NIE" : maxDepth.ToString();
    }
}