using System;
//bj2812 /g3 /크게 만들기 /240209
//스택, 그리디문제
//그냥, 입력받은 수 중에 맨 앞의 수가 가장 크면 가장 큰 수가 되니까? 
//"14892" 라면 2개를 빼야한다 했을 때, 당연히 "892"가 나오는 것 처럼
//"29382" 인데 3개를 빼야한다면 "98"이 나와야겠지? 좋아 렛츠고
namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            //입출력 함수
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            //N, K
            int[] nk = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int N = nk[0]; int K = nk[1];
            string s = sr.ReadLine(); //숫자, 자릿수가 커서 문자열이 편함
            Stack<char> stk = new Stack<char>(); //정수형 스택

            //연산
            for (int i = 0; i < N; i++) //모든 문자열을 반복하고
            {
                //스택에 값이 있으면서
                //이전의 수가 지금 수 보다 작다면 (뺄 카운트가 있을 시)
                while (stk.Count > 0 && stk.Peek() < s[i] && K > 0)
                {
                    stk.Pop(); //스택의 값을 빼주고 
                    K--; //카운트를 빼준다.
                }
                stk.Push(s[i]); //그 다음 수를 저장한다
            }
            //"321" 같은 경우 Pop이 일어나지 않으니 한번 더 빼줘야 함
            //K가 N보다 클리는 없으니 스택 예외처리는 하지 않았음
            while (K > 0)
            {
                K--; //카운트 빼주고
                stk.Pop(); //맨 뒤의 수가 제일 작겠지
            }
            //출력, 스택 두개 만들어서 반전보다 이게 더 빠르지 않을까
            char[] arr = stk.ToArray();
            Array.Reverse(arr);
            //출력
            sw.Write(string.Join("", arr)); //스택출력
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}