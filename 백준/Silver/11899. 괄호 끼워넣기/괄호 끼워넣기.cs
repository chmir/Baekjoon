using System;
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 11899 /s3 /괄호 끼워넣기 /231211
		//굳이 스택을 쓰지 않아도 될 거 같아 스택을 뺌
		//안 닫아지는 ) 만큼 ans++; 
		//남은 스택 카운트만큼 ans+=count;
		
		//변수 생성		
		string str = Console.ReadLine(); //입력
		int stack = 0; //스택인 척 하는 카운트 변수
		int ans = 0; //정답을 넣을 개수
		
		//연산
		for(int i = 0; i < str.Length; i++){
			if(str[i] == '(') stack++; //push
			else if(str[i] == ')'){
				if(stack == 0) ans++; //stack is empty
				else stack--; //pop
			} 
		}
		Console.Write(ans+stack); //출력
	}
}