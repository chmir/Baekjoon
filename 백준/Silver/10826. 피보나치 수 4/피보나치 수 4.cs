using System;
using System.Numerics; //BigInteger 변수 사용
//shift + f5 = 코드 실행
public class main {
	//0:더 이전, 1: 이전, 2: 현재 피보나치 수
	static BigInteger[] f = {1, 1, 2}; //Memoization
	
	static BigInteger fibo(int n){ //n은 반복 횟수
		for(int i = 0; i <= n; i++){
			if(n==0) return 0; //예외처리
			else if (n <= 2) return 1; //1, 2는 1
			else if (i > 3){ //3이상의 수를 요구하면 
				f[0] = f[1]; //하나씩 밀려나면서 
				f[1] = f[2]; 
				f[2] = f[1] + f[0]; //다음 피보나치 수를 구함
			}
		}
		return f[2]; //현재 피보나치 수 리턴
	}
	public static void Main() {	
		//bj10870 //b2 / 0<=n<=20
		//bj2747 //b2 / 1<=n<=45 <-자연수 라는 설명 때문에, 0일수도 있음
		//bj2748 //b1 / 1<=n<=90
		//위에 까지는 ulong 자료형 써서 해결함, 2748은 long으로 하면 터짐
		//bj10826 //s5 / 0<=n<=10000 <- 얘는 큰 수 계산 필요
		
		//찾고자하는 n번째 피보나치 수
		int n = Int32.Parse(Console.ReadLine()); 
		Console.WriteLine(fibo(n)); //출력 
	}
}