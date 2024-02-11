using System;
using System.Collections.Generic; //Stack <T> 사용
using System.Text; //StringBuilder 사용
//shift + f5 = 코드 실행
class Program {		
    static void Main(string[] args) {      	   
		//bj 10828 /s4 /스택 /231208
		//Console.WriteLine(); 으로 출력하면 시간초과가 뜨는 문제.
		//더 효율적인 출력(?)을 위해 stringbuilder를 사용하자.
		//StringBuilder는 동적 문자열 처리, 문자열의 값이 자주 바뀌는 경우에 유리함
		//단 정적인 문자열은 단순히 string이 더 좋음 
		// sb.AppendLine(); == 지금 문자열에 += 괄호 안의 문자 + 개행
		// sb.Append(); == 지금 문자열에 += 괄호 안의 문자, 개행 없음
		Stack<int> stack = new Stack<int>(); //정수형 스택 생성	
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		int n = int.Parse(Console.ReadLine()); //입력받을 개수 입력
		
		for(int i = 0; i < n; i++){ //n만큼 반복
			//입력 공백으로 나누기
			string[] sarr = Console.ReadLine().Split(' '); 
			switch (sarr[0]){ //첫번째 입력이 뭐인지?
				case "push": //값을 넣을것(출력없음)
					stack.Push(int.Parse(sarr[1]));
					break;
				case "pop":	//비어있으면 -1, 값이 있으면 빼고 출력할 것	
					//AppendLine() 에 정수가 들어가면 말을 안들어서 +""로 강제 형변환 함
					sb.AppendLine(stack.Count == 0 ? "-1" : stack.Pop()+"");
					break;
				case "size": //몇개의 수가 들어있는 출력할 것
					sb.AppendLine(stack.Count+""); 
					break;
				case "empty": //스택이 비어있으면 1, 아니면 0을 출력할 것
					sb.AppendLine(stack.Count == 0 ? "1" : "0");
					break;
				case "top": //스택의 가장 위의 정수를 출력, 없으면 -1을 출력할 것
					sb.AppendLine(stack.Count == 0 ? "-1" : stack.Peek()+"");
					break;
				//예외처리를 할 필요가 없기에 디폴트는 생략함. 
			}			
		}
		//결과 출력, 입력을 다 받고 출력인가봄
		Console.Write(sb.ToString());
	}
}