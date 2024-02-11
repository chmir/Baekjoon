using System;
using System.Collections.Generic; //Stack<T> 사용
using System.IO; //StreamWriter/Reader 사용
using System.Text; //StringBuilder 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 1406 /s2 /에디터 /231230
		//5397 키로거와 상당히 비슷한 문제. 
		//스택을 두개 쓰고, 예외처리에 유의할 것
		//스택을 이용했기에 마지막으로 결과출력 전에 
		//스택1의 값을 스택2의 값으로 부어내자. 
		
		//입력 및 선언
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//가변 문자열 생성
		StringBuilder sb = new StringBuilder();
		Stack<char> stk1 = new Stack<char>(); //왼쪽 문자열
		Stack<char> stk2 = new Stack<char>(); //오른쪽 문자열
		
		string input = sr.ReadLine(); //첫 입력
		for(int i = 0; i < input.Length; i++){
			stk1.Push(input[i]); //하나씩 입력받음
		}
		int n = int.Parse(sr.ReadLine()); //개수입력
		
		//연산
		for(int i = 0; i < n; i++){ //n회 입력 
			//입력, 문자니까 굳이 Split(' ') 하지말고 인덱스로 접근
			input = sr.ReadLine(); //i번째 입력
			switch(input[0]){
				case 'L': //커서 왼쪽으로
					if(stk1.Count != 0){ //예외처리
						stk2.Push(stk1.Peek());
						stk1.Pop();
				}
				break;
				case 'D': //커서 오른쪽으로
					if(stk2.Count != 0){ //예외처리
						stk1.Push(stk2.Peek());
						stk2.Pop();
				}
				break;
				case 'B': //Pop
					if(stk1.Count != 0) stk1.Pop(); //예외처리
				break;
				default: //"P $"
					stk1.Push(input[2]); //문자열이 아닌 문자만 입력받음
				break;
			}
		}
		//커서가 문자 끝이 아닌 중간에 있을 수 있다는 점, 
		//stk1을 출력하려면 반전을 해야하기에 stk2로 옮겨 출력함
		while(stk1.Count > 0){
			stk2.Push(stk1.Peek());
			stk1.Pop();
		}
		//출력할 문자열을 담아두고
		while(stk2.Count > 0){
			sb.Append(stk2.Peek());
			stk2.Pop();
		}
		
		//출력
		sw.Write(sb);
		sb.Clear();
		sr.Close();
		sw.Flush();
		sw.Close();
	}
}