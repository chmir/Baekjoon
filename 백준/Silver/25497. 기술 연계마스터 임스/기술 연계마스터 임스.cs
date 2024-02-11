using System;
using System.Collections.Generic; //Stack <T> 사용
using System.IO; //StreamWriter/Reader 사용
using System.Linq; //Reverse() 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 25497 /s5 /기술 연계마스터 임스 /231212
		//lskr은 되지만 lkr, srk 같은건 안되는듯
		//그냥 쉽게말해서 lr, sk를 따로 보고, 사전기술 없이 나오면 땡처리 ㄱ
		//1~9는 예외처리 없이 해도 될듯
		
		//변수 생성
		int n = Int32.Parse(Console.ReadLine()); //기술 사용 개수
		string str = Console.ReadLine(); //전체 문자열입력	
		Stack<int> sk = new Stack<int>(); //sk 연계스택
		Stack<int> lr = new Stack<int>(); //lr 연계스택
		int count = 0; //기술 성공 횟수
		
		//연산
		for(int i = 0; i < n; i++){
			if(str[i] == 'S') sk.Push(1); //구분용 임의의 숫자
			else if(str[i] == 'K'){
				if(sk.Count == 0) break; //잘못된 사용
				else count += sk.Pop(); //잘 된 경우
			}
			else if(str[i] == 'L') lr.Push(1); //구분용 임의의 숫자
			else if(str[i] == 'R'){
				if(lr.Count == 0) break; //잘못된 사용
				else count += lr.Pop(); //잘 된 경우
			}
			else count++; //1~9
		}	
		//출력
		Console.Write(count); 
	}
}