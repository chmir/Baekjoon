using System;
//shift + f5 = 코드 실행
public class main {
	public static void Main() {		
		int T = Int32.Parse(Console.ReadLine()); //테스트 개수
		string result = ""; //출력될 결과값

		for(int i = 0; i<T; i++) //테스트케이스 만큼 반복
		{
			//숫자를 3개 입력 받는다 0=h, 1=w, 2=n
			int[] td = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
			//계산하기 용이하도록 변수를 추가로 할당한다. 
			int h = td[0]; //층 수
			//int w = td[1]; //방 수 <- 예외처리를 하지 않으므로 필요 없음
			int n = td[2]; //손님 수
			int hn = 0; //층번호 
			int wn = 0; //방번호
			
			//손님의 수를 층수로 나눈 나머지를 구하면 방번호를 알 수 있다. 
			//손님수와 층수의 배수가 같으면 나머지가 0이 나오므로 예외처리를 해야한다. 
			if((n % h) != 0) 
			{
				hn = n % h;
				wn = (n / h) + 1;
			}
			else
			{
				hn = h;
				wn = n / h;
			}
			//나중에 출력할 문자열 변수에 값을 더해준다. 
			result += (hn.ToString() + wn.ToString().PadLeft(2,'0') + "\n"); 
		}
		Console.Write(result); //값을 출력한다. 
	}
}