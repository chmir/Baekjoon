using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp1
{
    class Program
    {
        public class Q //원형큐
        { //예외처리 없음
            private int[] arr;
            private int front, rear, size;

            public Q(int size){
                this.size = size;
                arr = new int[size];
                front = 0;
                rear = 0;
            }
            public void enq(int data){
                rear = (rear + 1) % size;
                arr[rear] = data;
            }
            public int deq(){
                front = (front + 1) % size;
                return arr[front];
            }
        }
        static void Main(string[] args)
        {
            //bj 24511 / queuestack / 240217
            //스택은 있으나 마나 상관없고, 
            //큐를 하나의 큐로 합치면 연산하기 편할 것 같다. 
            //큐1, 큐4 이러면 그냥 큐14로 합쳐도 똑같으니까. 

            //선언
            StringBuilder sb = new StringBuilder(); //가변문자열
            //입출력
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            
            //첫째줄 N입력
            int N = int.Parse(sr.ReadLine());
            Q q = new Q(N+1); //큐 생성

            //둘째줄 자료구조 정보 수열 / 큐0, 스택1
            int[] flag = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            //셋째줄 각 자료구조에 하나씩 들어갈 수열 / 및 큐 삽입
            int[] seq = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            //그냥 큐를 쓰면 뒤에서부터 읽어야 하네
            for (int i = N - 1; i > -1; i--)
            {
                if (flag[i] == 0) q.enq(seq[i]);
            }

            //넷째줄 삽입할 요소의 개수 
            int M = int.Parse(sr.ReadLine());

            //다섯째줄 삽입할 수열 / 및 출력
            seq = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < M; i++)
            {
                q.enq(seq[i]);
                sb.Append(q.deq() + " ");
            }
            sw.Write(sb);
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}