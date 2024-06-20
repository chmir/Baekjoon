using System;
using System.Linq; //string.Reverse(); 함수 사용
//shift + f5 = 코드 실행
public class main {
	public static void Main() {		
		//bj 1259
		string ans = ""; //정답
		
		while(true)
		{
			string input = Console.ReadLine(); //입력
			if(input == "0") break; //종료
			string t1 = ""; //앞 수
			string t2 = ""; //뒷 수
			
			//앞수를 자른다.
			t1 = input.Substring(0, input.Length / 2);		
			if((input.Length % 2) == 0) //길이가 짝수라면
				t2 = input.Substring(input.Length / 2, input.Length / 2);		
			else //홀수라면 //0.5는 int로 강제형변환시 사라져서, t1에 하나는 올림 하나는 내림
				t2 = input.Substring((input.Length / 2) + 1, input.Length / 2);
			
			t2 = new string(t2.Reverse().ToArray()); //반전
			if(t1 == t2) //앞과 뒤의 반전이 같다면?
				ans += "yes\n"; //yes 저장
			else //다르다면? 
				ans += "no\n"; //no 저장
		}
		Console.WriteLine(ans); //출력
	}
}