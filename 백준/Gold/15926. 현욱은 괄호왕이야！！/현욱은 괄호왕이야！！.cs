using System;
using System.Collections.Generic; //Stack<T> 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 15926 /g3 /현욱은 괄호왕이야!! /231226
		//중간중간 틀린 괄호열이 낄 수 있다는 것은 
		//맞는 괄호열이 나왔다면 그 괄호열의 길이를 알아낼 게 필요함
		//그래서 처음에 스택에 -1을 미리 넣고 -> (인덱스가 0부터 시작해서
		//"()"가 입력됐다면 닫혔을 때 1 - (-1) = 2가 될 수 있다.)
		//'('가 들어오면 현재 괄호의 위치인 i를 스택에 넣고
		//')'가 들어오면 일단 Pop하고
		//스택이 안 비었으면 현재 가장 긴 VPS의 길이와 
		//(현재 위치(i) - stack의 수중 가장 큰 수)를 비교해 
		//둘 중 가장 큰 수가 지금 가장 긴 VPS의 길이가 된다. 
		//위에 저렇게 빼는 이유는 맞는 괄호열의 길이를 알기 위해서다 
		//만약 Pop으로 인해 스택이 비게 됐다면 그건 
		//틀린 괄호열이란 뜻이므로 스택에 현재 위치를 넣어준다. 
		//반드시 복습할 것!
		
		//선언
		int n = int.Parse(Console.ReadLine()); //입력받을 길이 입력 
		string str = Console.ReadLine(); //괄호열 입력
		Stack<int> stk = new Stack<int>(); //괄호를 받을 스택
		int count = 0; //vps중 가장 높은 길이를 가질 카운트
		
		stk.Push(-1); //맨 앞에 -1을 넣는다. 
		//연산
		for(int i = 0; i < n; i++){ //n번 반복
			if(str[i] == '('){ //push
				stk.Push(i); //위치값을 넣는다.
			}
			else{ //pop
				stk.Pop(); //먼저 값을 빼주고
				if(stk.Count > 0){ //스택이 안 비어 있다면
					//현재 카운트와 현재위치 - 스택의 맨 윗값중 더 큰 값을 카운트에
					if(count < i - stk.Peek()) count = i - stk.Peek();
				}
				else{ //스택이 비어있다면
					//틀린 괄호열이므로 스택에 위치를 넣는다. 
					stk.Push(i);
				}
			}
		}
		
		Console.WriteLine(count); //정답 출력
	}
}