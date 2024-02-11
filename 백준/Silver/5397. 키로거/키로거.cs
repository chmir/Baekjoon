using System;
using System.Collections.Generic; //Stack<T> 사용
using System.IO; //StreamWriter/Reader 사용
using System.Text; //StringBuilder 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 5397 /s2 /키로거 /231229
		//<, >이게 좀 쉽지않네 
		//그리고 입력받은걸 다시 출력하는 거도 좀 쉽지않네 
		//스택이 두개가 필요한 문제인건가? 
		
		
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//가변 문자열 생성
		StringBuilder sb = new StringBuilder();
		Stack<char> stk1 = new Stack<char>(); //문자 스택 1
		Stack<char> stk2 = new Stack<char>(); //문자 스택 2
		int n = int.Parse(sr.ReadLine()); //개수입력
		string input; //매 회 입력받을 변수
		
		//연산
		for(int i = 0; i < n; i++){ //n회 입력 
			input = sr.ReadLine();
			for(int j = 0; j < input.Length; j++){ //문자열 길이만큼 반복
				//백스페이스
				if(input[j] == '-' ){ //뺄 게 없다면 그대로
					if(stk1.Count > 0) stk1.Pop();	
				}
				//커서를 왼쪽으로
				else if(input[j] == '<'){ //더 왼쪽이 없다면 그대로
					if(stk1.Count > 0){
						stk2.Push(stk1.Peek());
						stk1.Pop();
					}
				}
				//커서를 오른쪽으로
				else if(input[j] == '>'){ //더 오른쪽이 없다면 그대로
					if(stk2.Count > 0){
						stk1.Push(stk2.Peek());
						stk2.Pop();
					}
				}
				//그 외에 문자
				else stk1.Push(input[j]);
			}
			//커서가 문자 끝이 아닌 중간에 있을 수 있으며, 
			//stk1에 담긴 문자는 반전이기 때문에? 
			//stk1에 있는 값을 전부 stk2로 옮기고 
			//stk2를 출력해주면 정상출력이 된다. 
			while(stk1.Count > 0){
				stk2.Push(stk1.Peek());
				stk1.Pop();
			}
			//출력할 문자열을 담아두고
			while(stk2.Count > 0){
				sb.Append(stk2.Peek());
				stk2.Pop();
			}
			sb.AppendLine(); //개행
		}
		
		//출력
		sw.Write(sb.ToString());
		sr.Close(); 
		sw.Close();
	}
}