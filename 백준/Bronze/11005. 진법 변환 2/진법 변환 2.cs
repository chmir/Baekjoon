using System;
using System.Collections.Generic; //Stack<T> 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj11005 /b1 /진법 변환 2 /240109
		//진법 변환문제, % 연산 사용
		//문자를 하나씩 스택에 담아서 출력하는 건 어떨까?
		
		//n, b 입력
		int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
		Stack<char> stk = new Stack<char>(); //문자로 한 자 씩 출력함
		//연산
		while(n[0] > 0){ //n이 다 나눠질 때 까지
			int temp = n[0] % n[1]; //n에 b를 나눈 나머지
			n[0] /= n[1]; //실제로 나눠야 다음 연산이 가능
			if(temp > 9){ //16진수여서 10~16인 경우
				stk.Push((char)(temp + 55)); //65(A) ~ 70(F) 
			}
			else stk.Push((char)(temp + 48)); //0~9
		}
		//출력
		while(stk.Count > 0) Console.Write(stk.Pop());
	}
}