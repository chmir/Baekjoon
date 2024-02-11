using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//bj 11650 /s5 /좌표정렬하기 /240118
			//x, y를 하나의 튜플로 보고 정렬 함수를 쓰면 됨 
			//근데 만들어진 함수를 쓰는것과 별개로, 
			//각 방식에 대한 구현방법도 조금씩 배워야 할듯
			//구름ide는 왜 밸류튜플 안되는거야 ㅡㅡ

			//선언
			var sr = new System.IO.StreamReader(Console.OpenStandardInput());
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
			int n = int.Parse(sr.ReadLine());
			//튜플 배열
			//ValueTuple<int, int>[] t = new ValueTuple<int, int>[n];
			(int x, int y)[] t = new (int x, int y)[n];

			//입력
			for (int i = 0; i < n; i++)
			{
				string[] s = sr.ReadLine().Split(); //입력값 두개를 나누고
				t[i].x = int.Parse(s[0]);
				t[i].y = int.Parse(s[1]);
			}
			Array.Sort(t); //정렬
			//출력
			for (int i = 0; i < n; i++)
			{
				sw.WriteLine($"{t[i].x} {t[i].y}");
			}
			sr.Close();
			sw.Flush();
			sw.Close();
		}
    }
}
