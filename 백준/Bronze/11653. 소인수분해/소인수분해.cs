using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 11653 /b1 /소인수분해 /240101
		//소수: 1보다 큰 자연수 중 1과 자기자신만을 약수로 가지는 수 
		//약수: 어떤수를 나눠 떨어지게 하는 수를 뜻함 n%약수 = 0
		//인수: 곰셈식에서 곱해지는 일련의 수들
		//소인수분해: 1보다 큰 자연수를 소인수(소수인 약수)들의 곱으로 분해 
		
		//선언	
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//소인수분해 할 1~천만 사이의 자연수
		int n = int.Parse(sr.ReadLine());
		int i = 2; //나눌 수, 1로는 나누지 않기에 2부터 
		//연산
		while(i <= n){
			if(n % i == 0){ //n이 i로 딱 나눠지면
				sw.WriteLine(i); //나눌 수를 출력하고
				n /= i; //n의 값을 i로 나눈다.
			}
			else i++; //안 나눠지면 다음 수로 넘어간다
		}
		
		sr.Close(); 
		sw.Close();
	}
}