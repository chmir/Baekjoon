using System;
using System.Collections.Generic; //List<T> 사용
using System.Text; //stringbuilder 사용
using System.Linq; //ToList() 사용
namespace ConsoleApp1
{
    class Program
    {
    	static void Main(string[] args)
    	{
			//bj1920 /s4 /수 찾기 /240129
			//이분탐색, 정렬문제
			//두개의 수열이 주어지고, 첫번째로 입력받은 수열 안에서 
			//두번째로 입력받은 수열의 값이 있는지 하나하나 출력하는 문제
			//정렬방식 및 이분탐색 함수 복습필요
			
			//선언 및 입력
			StringBuilder sb = new StringBuilder();
			//자연수 N
			int nl = int.Parse(Console.ReadLine());
			int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
			//자연수 M
			int ml = int.Parse(Console.ReadLine());
			int[] m = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
			
			//입력받은 문자열 순서대로 정렬하기
			//굳이 리스트로 바꾼 이유는 BinarySearch 쓰려고... 더 좋은 방법이 있을듯
			List<int> criteria = n.ToList();
			criteria.Sort();
			//연산
			for(int i=0; i<ml; i++)
			{
				int index = criteria.BinarySearch(m[i]);
				sb.AppendLine(index < 0 ? "0" : "1"); 
			}
			//출력
			Console.WriteLine(sb.ToString()); 
		}
    }
}
