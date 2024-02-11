using System;
//shift + f5 = 코드 실행
class Program {	
	static long GCD(long a, long b){ //최대공약수를 구하는 함수
		long r = b % a; //r에 b%a를 넣는다. 
		if(r == 0) return a; //나머지가 없다면 GCD
		return GCD(r, a); //다음 재귀에서 a가 b가되고 a%b가 a가 됨.
	}
    static void Main(string[] args) {      	   
		//bj2609 /s5 /최소공배수 /240104
		//유클리드 호제법으로 GCD(최대공약수), LCM(최소공배수)을 구할 수 있다. 
		//r = a%b 라고 하였을 때, r의 나머지가 0이 될 때 까지 나눠주는 함수인
		//GCD(a,b);를 만들면 결과적으로 GCD가 나온다. 
		//그리고 a*b/GCD가 곧 LCM이다. -> 6*8/2 = 24
		
		//입력및 출력
		long[] n = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse); 
		long gcd = GCD(n[0],n[1]);
		long lcm = n[0] * n[1] / gcd;
		Console.WriteLine(lcm); //최소공배수
	}
}