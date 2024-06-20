using System;
using System.Linq; //string.Reverse(); 함수 사용
//shift + f5 = 코드 실행
public class main {
	
	//역순화 함수(문자열)
	public static int Rev(string s){ 
		//전달받은 문자열을 반전시키고
		s = new string(s.Reverse().ToArray());
		//이를 형변환 하여 반환
		int revnum = int.Parse(s);
		return revnum;
	}
	//역순화 함수(정수) //메소드 오버로딩
	public static int Rev(int n){ 
		//전달받은 숫자를 문자열로 변환
		string s = n.ToString();
		//문자열을 반전시키고
		s = new string(s.Reverse().ToArray());
		//이를 형변환 하여 반환
		int revnum = int.Parse(s);
		return revnum;
	}
	
	public static void Main() {	
		//bj 1357 /b1
		//입력 받은 수를 역순으로 조합하여 덧셈해야 한다.
		//더해진 값 또한 역순이 되어야 함, 함수화 해야할듯
		//문자열 두개를 공백으로 띄워 입력
		string[] s = Console.ReadLine().Split(' '); 
		//함수사용하여 값을 출력한다.
		int ans = Rev(Rev(s[0]) + Rev(s[1]));
		//출력
		Console.WriteLine(ans);
	}
}