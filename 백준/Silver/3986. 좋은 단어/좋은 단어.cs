using System;
using System.Collections.Generic; //Stack<> 사용
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {
		//bj3986 /s4 /좋은 단어 /231213
		//문자는 가장 안에 있는 게 먼저 닫혀야 한다. 
		//지금 입력받는 문자값이 top과 다르면 push
		//지금 입력받는 문자값이 top과 같으면 pop, 
		//스택 카운트가 3이 넘어가면 좋은문자가 아닐테니 
		//예외처리를 해줄가 했는데, 그냥 맘편히 다 넣고 보기로 했다.
		
		//변수선언
		int n = Int32.Parse(Console.ReadLine()); //개수		
		int count = 0; //카운트
		//연산
		while(n-- > 0){ //n~1
			Stack<char> s = new Stack<char>(); //알파벳스택
			string str = Console.ReadLine(); //입력
			for(int i = 0; i < str.Length; i++){
				//스택이 비지 않았고, top == i 라면
				if(s.Count > 0 && str[i] == s.Peek()) s.Pop();
				else s.Push(str[i]);
				
				//if(s.Count > 2) break;
			}
			//예외처리
			if(s.Count == 0) count++;
		}
		//출력
		Console.Write(count);
    }
}