using System;
//shift + f5 = 코드 실행
public class main {
	public static void Main() {		
		//0~99
		//변경될 변수
	    int n = int.Parse(Console.ReadLine());
		//정답 변수
		int answer = n;
		int count = 0; //카운트

		do //일단 실행
		{
			int a = n / 10; //10의자리
			int b = n % 10; //1의자리
			//값 다음으로 넘어주고
			n = (b * 10) + (a + b) % 10;
			count++; //카운트업
		} while (n != answer); //같을때까지 못나옴
		Console.WriteLine(count); //다 됐으면 출력
	}
}