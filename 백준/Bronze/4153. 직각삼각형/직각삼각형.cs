using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 4153 /b3 /직각삼각형 /231231
		//가장 긴 변의 제곱은 나머지 두 변의 제곱의 합과 같다
		
		//선언	
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//입력용 변수
		int[] arr = new int[3];
		int n1, n2, n3; 
		//연산
		while(true){ 
			//3개 입력
			arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
			if(arr[0]+arr[1]+arr[2] == 0) break; //셋 다 0이면 종료
			//제곱 연산
			n1 = arr[0] * arr[0];
			n2 = arr[1] * arr[1];
			n3 = arr[2] * arr[2];
			//가장 긴 변의 제곱 = 나머지 두 변의 제곱의 합
			if(n1+n2==n3||n1+n3==n2||n2+n3==n1) sw.WriteLine("right");
			else sw.WriteLine("wrong");
		}
		sr.Close(); 
		sw.Close();
	}
}