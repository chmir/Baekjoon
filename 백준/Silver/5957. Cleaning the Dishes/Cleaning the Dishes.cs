using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //bj5957 /s5 /Cleaning the Dishes
        //영알못이라 자세한 문제 설명은 생략한다.
        //첫번째 줄은 씻을 접시 개수고, 위에서부터 아래로 접시번호 1~N 으로 쌓여짐
        //두번째 줄부터 씻기는지, 말리는지 여부(1or2) 그리고 개수를 공백으로 나눠서 입력받음
        //그래서 깨끗하고 건조한 접시가 쌓이는 최종 순서(위에서 부터)는 뭘까?
        //예시- 
        //접시 3개를 씻기면 씻긴 접시칸에 3~1(3이 맨 위)
        //접시 2개를 말리면 말린 접시칸에 2,3(2가 맨 위)
        //접시 2개를 씻기면 씬긴 접시칸에 5,4,1
        //접시 3개를 말리면 말린 접시칸에 1,4,5,2,3(1이 맨 위)
        //말린 접시칸은 스택이 아니라 뭐 문자로 담았다가 거꾸로 하든 상관없겠지만
        //그냥 스택 3개를 쓰는 게 가장 명시적이어서 이렇게 짰습니다. 
        //그리고 아마도 문제에서는 일부러 틀린 케이스가 나오지 않는다고 가정하는 거 같다.
        //그래서 스택이 비어있는지 예외처리를 하지 않았습니다.

        //빠른입출력
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        // 스택 생성
        Stack<int> s1 = new Stack<int>(); //안씻긴 거
        Stack<int> s2 = new Stack<int>(); //씻기고, 안말린거
        Stack<int> s3 = new Stack<int>(); //씻기고, 말린거 

        // 첫 줄에서 N 값을 읽음
        int N = int.Parse(sr.ReadLine());

        // 더러운 접시 스택 초기화
        for (int i = N; i >= 1; i--)
        {
            s1.Push(i); //맨 위에는 1이 있게 된다.
        }

        //두번째 줄부터 명령어 입력 및 처리
        //명령어 종료 조건은 모든 접시가 세척이 되었을 때 이다.
        //s3의 카운트가 N이 될때 까지 반복하거나, 수행개수의 합이 N*2인 경우까지 반복하거나
        //아니면 더이상의 입력이 없을 때나 (되긴함)
        //수행 개수의 합이 N*2일 때 까지 반복하는 것은, 
        //모든 입력에 실수가 없어야 가능함을 알아두자.
        for(int sum = 0; sum < N*2;)
        {
            string[] parts = sr.ReadLine().Split();
            int x = int.Parse(parts[0]); //명령어
            int y = int.Parse(parts[1]); //수행 개수
            sum += y;
            if (x == 1) // 세척 명령어
            {
                while (y-- > 0)
                {
                    s2.Push(s1.Pop()); 
                }
            }
            else if (x == 2) // 건조 명령어
            {
                while (y-- > 0)
                {
                    s3.Push(s2.Pop());
                }
            }

            // 모든 접시가 건조된 경우 루프 종료
            if (s3.Count == N)
            {
                break;
            }
        }

        // 결과 출력
        while (s3.Count > 0)
        {
           sw.WriteLine(s3.Pop());
        }
        sw.Flush();
        sw.Close();
        sr.Close();
    }
}