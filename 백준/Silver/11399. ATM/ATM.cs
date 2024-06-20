using System;
using System.Collections.Generic;
using System.Linq;
//bj11399 /s4 /ATM /240223
//내림차순 정렬 후, 가장 인출이 빠른 사람이 먼저 인출해야 함
//그래서 입력받은 수를 정렬하여 걸리는 시간을 전부 합하고 출력
namespace Programs
{
    class Program
    {
        public static void Main(string[] args)
        {
            //빠른 입출력
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine()); //사람
            int[] P = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); 
            int[] sumP = new int[N]; // 누적 시간 
            Array.Sort(P); // 내림차순 정렬
            int sum = 0; //합
            for (int i = 0; i < N; i++)
            {
                sum += P[i];
                sumP[i] = sum; //돈 인출 시 걸리는 시간 저장
            }

            sw.Write(sumP.Sum()); // 합의 최솟값
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}