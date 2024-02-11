using System;
using System.Collections.Generic; //Stack <T> 사용
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {		
    static void Main(string[] args) {      	   
		//bj 4949 /s4 /균형잡힌 세상 /231209
		//9012에서 영감을 받을 수 있는 문제. 
		//모든 소괄호는 소괄호끼리, 대괄호는 대괄호 끼리 여닫혀야 한다. 
		//괄호대신 그냥 임의의 숫자로 구분하는게 편할듯
		//1( 2) 3[ 4]
		
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		//입력, 출력용 객체 생성
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		
		string input; //입력값이 넣어질 문자열
		while(true){
			//괄호가 넣어질 스택 생성
			Stack<int> s = new Stack<int>();
			input = sr.ReadLine(); //입력
			if(input == ".") break; //온점을 누르면 반복 종료
			for(int i = 0; i < input.Length; i++){
				//여는 괄호가 나왔을 때
				if(input[i] == '(') s.Push(1);
				else if(input[i] == '[') s.Push(3);
				//닫는 괄호가 나왔을 때
				if(input[i] == ')'){
					//더 뺄 값이 없다면 틀린것
					if(s.Count == 0){ 
						s.Push(0); //임의의 값을 더해주고
						break; //종료
					} //같은 괄호가 나왔으면?
					else if(s.Peek() == 1){
						s.Pop(); //여는 괄호를 빼준다. 
					}
					else //위에가 아니라면 틀린거겠지
					{
						s.Push(0); //임의의 값을 더해주고
						break; //종료
					}
					
				}
				else if(input[i] == ']'){
					//더 뺄 값이 없다면 틀린것
					if(s.Count == 0){ 
						s.Push(0); //임의의 값을 더해주고
						break; //종료
					} //같은 괄호가 나왔으면?
					else if(s.Peek() == 3){
						s.Pop(); //여는 괄호를 빼준다. 
					}
					else //위에가 아니라면 틀린거겠지
					{
						s.Push(0); //임의의 값을 더해주고
						break; //종료
					}
					
				}
			}
			if(s.Count == 0) sb.AppendLine("yes");
			else sb.AppendLine("no");
			
		}
		//답 출력
		sw.Write(sb);
		sr.Close(); //객체 종료?
		sw.Close(); //객체 종료?
	}
}