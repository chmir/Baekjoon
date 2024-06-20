using System;
using System.Collections.Generic; //Stack<T> 사용
using System.Text; //StringBuilder 사용
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //bj1918 /g2 /후위 표기식 /240222
            //후위표기식의 장점은 중위표기식과 다르게 괄호 없이 우선순위를 표현할 수 있다. 
            //)가 나올 때 까지 (와 사칙연산은 전부 Push, 문자열은 그냥 출력
            //)가 나왔다면 (가 빠질 때 까지 모든 사칙연산을 Pop하면서 출력한다
            //그리고 마지막으로 괄호가 없는 곳의 사칙연산도 털어준다
            //또한 + -보다 * /가 우선순위가 높다, 괄호가 없는 경우도 있으니까 
            //A+B*C 라면 이건 A+(B*C)인 셈이다
            //*, /가 나오면 스택의 top이 *, /면 전부 pop해서 출력해준다.
            // ㄴ 먼저들어온 *,/이므로 후위표기식에서 먼저 출력해야 하기에 
            //+, -가 나오면 *, /보다 우선순위가 낮으므로 (가 나올 때 까지 전부 출력한다
            //아마도 틀린 수식은 T에 없을테니 걍 예외처리 ㄴㄴ해

            //선언 및 입력
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder(); //스트링빌더 생성
            Stack<char> stk = new Stack<char>(); //스택
            string str = sr.ReadLine();
            for(int i = 0; i < str.Length; i++)
            {
                //A~Z면 출력
                if ('A' <= str[i] && str[i] <= 'Z')
                {
                    sb.Append(str[i]);
                }
                //그 외에
                else
                {
                    //여는 괄호면 push
                    if (str[i] == '(') stk.Push(str[i]);
                    //곱셈이거나 나눗셈이면
                    else if (str[i] == '*' || str[i] == '/')
                    {
                        //스택에 값이 있으면서 스택 맨 위에 곱셈 나눗셈이 있다면
                        while (stk.Count > 0 && (stk.Peek() == '*' || stk.Peek() == '/'))
                        {//값을 빼고 출력한다
                            sb.Append(stk.Pop());
                        }
                        stk.Push(str[i]); //그러고 나서 지금 값 push
                    }
                    //덧셈이거나 뺄셈이면
                    else if (str[i] == '+' || str[i] == '-')
                    {
                        //스택에 값이 있으면서 (가 나올 때 까지 
                        while(stk.Count > 0 && stk.Peek() != '(')
                        {//값을 빼고 출력한다
                            sb.Append(stk.Pop());
                        }
                        stk.Push(str[i]); //그러고 나서 지금 값 push
                    }
                    //닫는 괄호가 나오면 여는 괄호 나올 때 까지 pop하고 출력
                    else if (str[i] == ')')
                    {
                        while (stk.Count > 0)
                        {
                            var s = stk.Pop(); //빼고
                            if (s == '(') break; //(면 그만
                            sb.Append(s); //출력
                        }
                    }
                }
            }
            //마지막으로 괄호 밖의 문자열을 털어준다
            while (stk.Count > 0)
            {
                sb.Append(stk.Pop());
            }
            //출력
            sw.Write(sb);
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}