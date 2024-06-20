using System;
//shift + f5 = 코드 실행
public class main {
	static ulong f2 = 1; //더 이전 피보나치 수 
	static ulong f1 = 1; //이전 피보나치 수 
	static ulong f0 = 2; //현재 피보나치 수 
	
	static ulong fibo(int n){ //n은 반복 횟수
		//
		for(int i = 0; i <= n; i++){
			if(n==0) return 0; //그냥 예외처리
			else if (n <= 2) return 1; //1, 2는 1
			else if (i > 3){ //3이상의 수를 요구하면 
				f2 = f1; //하나씩 밀려나면서 
				f1 = f0; 
				f0 = f1 + f2; //다음 피보나치 수를 구함
			}
		}
		return f0; //현재 피보나치 수 리턴
	}
	public static void Main() {	
		//bj2747 //b2
        //bj2748 //b1
		//범위는 1~45의 자연수
		//f[0] = 0, f[1] = f[0]+f[1], f[2] = f[0] + f[1] 
		//f[3] = f[2] + f[1] ...
		//찾고자하는 n번째 피보나치 수
		int n = Int32.Parse(Console.ReadLine()); 
		ulong ans = fibo(n); //정답
		Console.WriteLine(ans); //출력 
		//연속으로 사용하려면 구하려는 값이 이전보다 작을 때, 
		//다시 초기화 해서 사용해야 할듯 
	}
}