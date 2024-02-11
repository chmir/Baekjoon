using System;
//using System.Collections.Generic; //Stack <T> 사용
using System.Text; //StringBuilder 사용
//using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {		
    static void Main(string[] args) {      	   
		//bj 9012 /s4 /괄호 /231209
		//스택을 쓰지 않는 방법으로 접근해보자.
		//스트림 리더/라이터를 안쓰면 어떨까?
				
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성		
		int n = int.Parse(Console.ReadLine()); //입력받을 개수 입력
		for(int i = 0; i < n; i++){
			string str = Console.ReadLine(); //입력
			int count = 0; //얘가 0으로 끝나야 함
			for(int j = 0; j < str.Length; j++){			
				if(str[j] == '(') count++; //push
				if(str[j] == ')'){ //pop
					if(count == 0){//더 뺄 게 없으면?
						count++; //구분을 위해 임의로 push하고
						break; //j 반복문을 나간다.
					}
					else count--; //더 뺄 게 있다면 뺀다. 
				}
			}
			//반복문을 나왔는데 여전히 요소가 남아있다면? 
			if(count > 0) sb.AppendLine("NO");
			else sb.AppendLine("YES"); //요소가 없다면 정답.
		}
		//답 출력
		Console.Write(sb.ToString());
	}
}