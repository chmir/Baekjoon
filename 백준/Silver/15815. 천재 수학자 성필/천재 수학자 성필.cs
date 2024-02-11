using System;
using System.Collections.Generic; //Stack <T> 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 25497 /s5 /기술 연계마스터 임스 /231212
		//숫자는 넣고, 연산자 나오면 두번빼서 연산 후 다시 넣고 반복
		//잘못된 수식이 나올 경우는 없으며, 결과값은 int를 넘지 않음
		//a / b -> ab/ 니까 값을 꺼낼 때 a가 x, b가 y에 위치하도록 해야할듯
		//a/b가 되어야지 b/a가 되면 안되니까요
		//a - b와 b - a도 결과가 다르니 조심
		
		//변수 생성
		string str = Console.ReadLine(); //전체 문자열입력	
		Stack<int> s = new Stack<int>(); //연산될 수가 들어갈 스택
		
		//연산
		for(int i = 0; i < str.Length; i++){
			int x = 0; int y = 0; //임시 계산용 정수
			if(str[i] == '+'){
				x = s.Pop(); //뭘 먼저 셈해도
				y = s.Pop(); //둘의 연산값은 같다. 
				s.Push(x + y);
			}
			else if(str[i] == '*'){
				x = s.Pop(); //뭘 먼저 셈해도 
				y = s.Pop(); //둘의 연산값은 같다. 
				s.Push(x * y);
			}
			else if(str[i] == '-'){
				x = s.Pop(); //연산순서 유의
				y = s.Pop();
				s.Push(y - x);
			}
			else if(str[i] == '/'){
				x = s.Pop(); //연산순서 유의
				y = s.Pop(); 
				s.Push(y / x);
			}
			else{ //수식인 경우
				s.Push(str[i] - '0');
			}
		}
		//마지막은 결국 하나의 숫자가 남는다. 
		Console.Write(s.Pop()); 
	}
}