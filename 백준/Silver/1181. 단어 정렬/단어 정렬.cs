using System;
using System.Collections.Generic; //List<T> 사용
using System.Linq; //List.OrderBy 사용
namespace ConsoleApp1
{
    class Program
    {
    	static void Main(string[] args)
    	{
			//bj1181 /s5 /단어 정렬 /240129
			//정렬문제, OrderBy 함수 복습필요
			
			//선언
			var sr = new System.IO.StreamReader(Console.OpenStandardInput());
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
			int n = int.Parse(sr.ReadLine());
			List<string> s = new List<string>();
			//입력
			for (int i = 0; i < n; i++) s.Add(sr.ReadLine());
			//연산
			s = s.Distinct().ToList(); //중복된 단어 제거
			s.Sort(); //알파벳 순서로 정렬
			s = s.OrderBy(x => x.Length).ToList(); //길이 오름차순 정렬
			//출력
			foreach (string ans in s) sw.WriteLine(ans);
			sr.Close();
			sw.Flush();
			sw.Close();
		}
    }
}
