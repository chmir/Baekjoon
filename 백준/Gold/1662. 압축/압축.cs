using System;
using System.Collections.Generic; //Stack<T> 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj1662 /g5 /압축 /240107
		//살짝 깔끔해진 버전, 일부러 변수도 많이 씀 그냥
		
		//선언
		string str = Console.ReadLine(); //문자열
		Stack<int> stk = new Stack<int>(); //문자열을 받을 스택
		int ans = 0; //정답
		int count = 0; //k, '(', ')' 를 제외한 문자열 개수
		int k = 0; int sum = 0; //임시 곱, 합 변수
		
		for (int i = 0; i < str.Length; i++) {
			switch(str[i]){
				case '(':
					//문자열 개수를 저장한다, 없으면 저장하지 않는다.
					if(count > 0){
						stk.Push(count-1); //k는 문자열이 아니므로 -1
						count = 0; //카운트 초기화
					}
					stk.Push(str[i-1]-'0'); //k를 별도 저장한다
					stk.Push(-1); //( 괄호 대신에 구분을 위해 넣는다. 
				break;
				case ')':
					//문자열 개수를 저장한다, 없으면 저장하지 않는다.
					if(count > 0){
						stk.Push(count); 
						count = 0; //카운트 초기화
					}
					sum = 0; //임시 합변수
					//'(' 괄호 나올 때 까지 스택 안의 카운트를 전부 합함
					while(stk.Peek() != -1) sum += stk.Pop(); 
					stk.Pop(); // ( 제거 (-1이 Pop됨)
					k = stk.Pop(); // k 저장
					//k, 합이 0이면 곱할 필요도, 추가할 필요도 없다.
					if(k > 0 || sum > 0) { 
						stk.Push(k * sum); 
					} 
				break;
				default:
					count++; //그 외에 그냥 문자열인 경우
				break;
			}
		}
		//전부 합한 뒤
		while(stk.Count > 0) ans += stk.Pop(); 
		Console.WriteLine(ans+count); //출력
	}
}