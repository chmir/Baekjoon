using System;
using System.Collections.Generic; //Stack<T> 사용
namespace ConsoleApp1{
	class Program{  
		static void Main(string[] args){
			//bj1725 /p5 /히스토그램 /240131
			//먼저 예외처리를 위해서 입력받은 히스토그램의 양 끝에 0이 있다 가정한다. 
			//그래서 스택에는 인덱스 0(값도 0)을 넣고 시작하고 
			//1~N까지의 값을 입력받으며 연산을 한다. 
			//입력받은 i번째 값이 스택의 맨 위보다 작다면 
			//스택의 맨 위의 값을 빼고 임시 저장 후
			//빼진 값 * (현재 인덱스 - 스택 맨위 인덱스 - 1)로 연산하고 
			//그 값을 지금까지의 가장 큰 넓이와 비교하여 삽입을 반복한다. 
			//살짝 아쉬운 점은 똑같은 값은 연속해서 받을 필요가 없지 않을까?
			
			//선언 및 입력
			var sr = new System.IO.StreamReader(Console.OpenStandardInput());
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
			Stack<int> stk = new Stack<int>(); //히스토그램 스택
			int N = int.Parse(sr.ReadLine()); //수열의 길이
			//히스토그램의 양 끝단을 0으로 두고 풀이한다. 
			//인덱스가 1부터 시작, N+1까지 있어야 하기에 N+2
			//입력받지 않은 경우 알아서 0으로 할당된다. 
			int[] arr = new int[N+2]; //최대 100002
			int max = 0; //가장 큰 넓이
			stk.Push(0); //예외처리를 위한 0 추가
			//연산
			for(int i = 1; i <= N; i++){
				arr[i] = int.Parse(sr.ReadLine()); //입력
				//입력받은 히스토그램의 값이 현재 입력된 스택의 맨 위 보다 작다면
				while(arr[stk.Peek()] > arr[i]){
					int temp = stk.Pop(); //빼면서 연산을 위해 값을 임시저장
					//연산된 넓이가 지금까지 가장 큰 넓이보다 큰지 비교 후 삽입
					max = Math.Max(max, arr[temp]*(i - stk.Peek() - 1)); 
				}
				stk.Push(i);//현재의 인덱스를 넣는다. 
			}
			//입력따로, 연산따로하면 느리지 않을까 싶어서 마지막에 털어주는걸 하나 더 만듬
			while(arr[stk.Peek()] > arr[N+1]){
				int temp = stk.Pop(); //빼면서 연산을 위해 값을 임시저장
				//연산된 넓이가 지금까지 가장 큰 넓이보다 큰지 비교 후 삽입
				max = Math.Max(max, arr[temp] * (N - stk.Peek()));
			}
			//출력
			sw.Write(max);
			sr.Close();
			sw.Flush();
			sw.Close();
		}
	}
}