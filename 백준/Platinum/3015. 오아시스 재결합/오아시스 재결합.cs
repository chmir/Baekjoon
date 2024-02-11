using System;
using System.Collections.Generic; //Stack<T> 사용
namespace ConsoleApp1
{
    class Program
    {
		public struct N{
			public int h; //키
			public long c; //카운트
			public N(int h, long c){ //구조체
				this.h = h;
				this.c = c;
			}
		}
    	static void Main(string[] args)
    	{
			//bj3015 /p5 /오아시스 재결합 /240129
			//스택에는 항상 값이 내림차순이 되도록 유지돼야 한다. 
			//만약 앞에 나올 값이 지금까지의 값보다 크다면, 
			//왼쪽의 작은 값들은 그 앞에 가로막혀 더는 카운트 되지 않기 때문이다. 
			//그리고 똑같은 값이 들어올 때의 예외처리도 필요하다. 
			//112 순으로 들어오면 내림차 순 유지를 위해 1을 그냥 빼면 문제가 되기에
			//그 사람의 키와, 같은 키를 가진 사람의 수를 저장할 카운트를 구조체로 묶자. 
			
			//선언 및 입력
			//더 빠른 입출력
			var sr = new System.IO.StreamReader(Console.OpenStandardInput());
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
			Stack<N> stk = new Stack<N>(); //인원수를 받을 스택
			int length = int.Parse(sr.ReadLine()); //사람 수
			long cnt = 0; //카운트
			
			//연산
			for (int i = 0; i < length; i++) {
				int h = int.Parse(sr.ReadLine()); //키
				N n = new N(h, 1); //키, 카운트
				
				//지금 입력보다 이전 스택의 키가 작은경우 Pop
				while (stk.Count != 0 && stk.Peek().h <= h) {
					N pop = stk.Pop(); //값을 빼기전에 잠깐 저장
					cnt += pop.c; //뺄 값의 카운트를 더해준다 
					//입력할 값과 키가 같다면 명수 카운트
					if (pop.h == h) n.c += pop.c; 
				}
				
				if (stk.Count != 0) cnt++; //스택이 비었다면 카운트
					
				stk.Push(n); //입력한 값을 넣어준다.
			}
			//출력
			sw.Write(cnt);
			sr.Close();
			sw.Flush();
			sw.Close();
		}
    }
}
