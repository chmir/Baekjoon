using System;
using System.Reflection.Metadata;
//shift + f5 = 코드 실행
class Program
{
    static void Main(string[] args)
    {
        //bj 12789 /s3 /도키도키 간식드리미 /240218
        //처음 입력을 큐, 중간 대기열을 스택으로, 
        //순서대로 빠져나갔다면 Nice, 아니면 Sad
        //순서대로 들어갔는지 체크할 변수 필요

        int check = 1; //간식 순서
        Queue<int> q = new Queue<int>();
        Stack<int> s = new Stack<int>();
        //대기 개수 N 
        int N = int.Parse(Console.ReadLine());
        //대기자 수열
        int[] seq = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        for(int i = 0; i < N; i++) q.Enqueue(seq[i]);

        //반복문 시작
        //큐 대기열에 학생이 다 없어질 때까지
        while (q.Count > 0)
        {
            if (q.Peek() == check) //간식먹는 순서라면
            {   
                q.Dequeue();
                check++; //다음 순번으로
            }
            else if (s.Count > 0 && s.Peek() == check)
            {   //스택또한 순서를 계산한다
                s.Pop();
                check++;
            }
            else
            {
                //큐도 스택도 순서가 안맞다면
                s.Push(q.Dequeue()); // 큐에서 빼서 스택에 집어넣는다.
            }
        }
        while (s.Count > 0)
        {   // 스택에 학생 남아있다면 간식 순서로 나오는지 확인
            if (s.Peek() == check)
            {   //순서 맞으면 스택을 빼주고
                s.Pop();
                check++;
            }
            else
            {   //아니라면 틀림
                Console.WriteLine("Sad");
                return;
            }
        }
        //큐와 스택을 전부 털어냈다면 순서가 맞았다는 뜻
        Console.WriteLine("Nice");
    }
}