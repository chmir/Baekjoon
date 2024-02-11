using System;
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 10799 /s2 /쇠막대기 /231211
		//() <- 레이저 
		//( <- push, ) <- pop
		//예외처리 없어도 되고, 스택 안써도 됨
		//만약 틀린 파이프가 나올 수 있고, 
		//마지막 글자인 경우 레이저 예외처리가 필요한데, 
		//레이저를 먼저보고 파이프인지를 처리하고 싶다면
		//그건 continue;로 처리하면 됩니다. 더 좋은 방법도 있을듯
		
		//변수 생성		
		string str = Console.ReadLine(); //입력
		int stack = 0; //스택인 척 하는 카운트 변수
		int ans = 0; //정답을 넣을 개수
		
		//출력
		for(int i = 0; i < str.Length; i++){
			if(str[i] == '(' && str[i+1] == ')'){ //레이저라면? 
				ans += stack; //나눠진 막대기 개수 더하기
				i++; // )는 이미 탐색했으니까 다음으로
			}
			else if(str[i] == '('){ //막대기가 더해졌으면
				stack++; //막대기 추가요
			}
			else if(str[i] == ')'){ //막대기가 닫아졌으면
				stack--; //막대기 개수 하나 빼고
				ans++; //막대기 개수 더하기
			}
		}
		Console.Write(ans); //출력
	}
}