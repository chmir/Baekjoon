using System;
using System.Text; //stringbuilder 사용
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//bj10816 /s4 /숫자 카드 2 /240129
			//이진탐색 정렬문제 같은데... 
			//수 입력 범위가 int보다 작아서 이렇게 풀어도 되나보다, 
			//이진탐색으로 푸는 방법은 해보지 않았으므로 복습이 필요하다. 
			//근데, 이런 방식도 나름 공간을 이용한 문제같아 좋은듯? 
			
			//선언 및 입력
			StringBuilder sb = new StringBuilder();
			int N = int.Parse(Console.ReadLine());
			int[] narr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
			int M = int.Parse(Console.ReadLine());
			int[] marr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
			int[] cnt = new int[20000001]; //카운트 될 배열, 음수 카드를 위해 인덱스 크기를 두배로
			//처음으로 입력받은 배열의 값들을 카운트한다.
			for(int i = 0; i < N; i++) cnt[narr[i] + 10000000]++;
			//인덱스를 직접 접근 해, 몇번 카운트 됐었는지 저장 
			for(int i = 0; i < M; i++) sb.Append(cnt[marr[i] + 10000000] + " ");
			//출력
			Console.WriteLine(sb);
        }
    }
}
