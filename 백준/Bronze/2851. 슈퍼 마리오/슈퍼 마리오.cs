using System;
//shift + f5 = 코드 실행
public class main {
	public static void Main() {		
		//bj 2851
		int[] n = new int[10]; 
		int sum = 0; //합수
		int ans = 0; //답
		//굳이 포문 두개 안써도 되긴 할거같은데 귀찮아
		for(int i = 0; i<10; i++)
			n[i] = int.Parse(Console.ReadLine());
		for(int i = 0; i<10; i++)
		{
			sum += n[i];
			//혹시모를 예외처리 다 더해도 100이 안넘어가면
			if(i == 9)
			{
				ans = sum;
				break;
			}
			//다음 값을 더했을 때 100이 넘어간다면
			if(sum + n[i+1] > 100)
			{
				//지금값 보다 다음값의 차가 적다면
				if((100-sum) > (sum + n[i+1])-100)
				{
					ans = sum + n[i+1];
				}
				//지금값이 차가 더 적다면
				else if((100-sum) < (sum + n[i+1])-100)
				{
					ans = sum;
				}
				else //둘이 같은 값이면?
				{
					ans = sum + n[i+1];
				}
				break; //무슨 연산이든 하고 빠져나오겠지
			}
		}		
		Console.WriteLine(ans); //출력
	}
}