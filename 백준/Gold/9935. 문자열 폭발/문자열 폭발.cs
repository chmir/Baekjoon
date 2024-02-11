using System;
using System.Collections.Generic; //Stack <T> 사용
using System.IO; //StreamWriter/Reader 사용
using System.Linq; //Reverse() 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 9935 /g4 /문자열 폭발 /231211
		//맨 처음 문자열을 입력받고... 
		
		//변수 생성		
		string str = Console.ReadLine(); //전체 문자열입력
		string c4 = Console.ReadLine(); //폭발 문자열입력
		char last = c4[c4.Length - 1]; //폭발 문자열의 마지막 문자 저장
		Stack<char> s1 = new Stack<char>(); //문자를 받는 스택 
		Stack<char> s2 = new Stack<char>(); //폭발 의심 문자열을 받는 스택
		
		//연산
		for(int i = 0; i < str.Length; i++){
			s1.Push(str[i]); //값을 담다가
			//스택의 값이 폭발물 글자보다 크다는 가정 하에?
			//폭발 의심물자 발견
			if(s1.Count >= c4.Length && str[i] == last){ 
				//의심물자를 담아줍니다. 
				for(int j = 0; j < c4.Length; j++){ 
					s2.Push(s1.Pop()); //값을 일단 넣어줘요 
				}
				//아니라면 다시 넣어줍니다. 
				if(c4 != string.Join("",s2.ToArray())){ 
					while(s2.Count != 0) s1.Push(s2.Pop());
				}
				else s2.Clear(); //폭발물이 맞다면 제거합니다. 
			}
		}
		//출력
		//함수 간단 설명: string.Join() <- 문자배열을 문자열로 변환
		//arr.Reverse() <-- 배열의 구조를 반전함, 스택이라서 필요했음
		//스택이름.ToArray() <-- 리스트나 스택등을 배열로 변환함
		Console.Write(s1.Count == 0 ? "FRULA" : string.Join("",s1.Reverse().ToArray())); 
	}
}