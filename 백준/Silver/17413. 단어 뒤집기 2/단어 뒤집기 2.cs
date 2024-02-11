using System;
using System.Collections.Generic; //Stack <T> 사용
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
	//출력 객체
	static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
	//역순 출력 함수
	static void Rev(Stack<char> s){ while(s.Count != 0) sw.Write(s.Pop()); }
	//메인함수
    static void Main(string[] args) {      	   
		//bj 17413 /s3 /단어 뒤집기 2 /231210
		//스택에 계속해서 문자를 담아뒀다가 
		//공백이 나오거나, 문자가 끝나면 한번에 뒤바꾼다. 
		
		//변수 생성		
		string str = Console.ReadLine(); //입력
		Stack<char> s = new Stack<char>(); //문자를 받는 스택 
		
		//출력
		for(int i = 0; i < str.Length; i++){
			if(str[i] == '<'){
				Rev(s); //스택을 털어주고(이전의 값을 출력해주고)
				sw.Write(str[i]); //지금 값을 출력해 준 다음!
				while(str[i] != '>'){ //다음 꺽쇠가 나올 때 까지
					sw.Write(str[++i]); //정직하게 출력해줌
				}
			}
			else if(str[i] == ' '){
				Rev(s); //스택을 털어주고
				sw.Write(str[i]); //지금 값 출력
			}
			else{ s.Push(str[i]); } //값을 스택에 쌓아둔다.
		}
		Rev(s); //마지막 단어도 털어주고 끝
		sw.Close(); //얘 안 닫으면 못씀
	}
}