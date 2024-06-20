using System;
//shift + f5 = 코드 실행
public class main {
	public static void Main() {		
		//bj 1032 / 23년 11월 4일
		//여러번의 입력이어도, 어차피 위에서 틀리면 
		//쭉~? 니까 첫입력이 도중에 ?로 변경되어도 괜찮을듯?
		int n = int.Parse(Console.ReadLine());
		//첫입력을 문자 배열로 변환
		char[] ans = Console.ReadLine().ToCharArray(); 
		
		for(int i = 1; i < n; i++){
			char[] temp = Console.ReadLine().ToCharArray(); 
			for(int j = 0; j < temp.Length; j++)
			{
				if(ans[j] != temp[j]) //서로 다르다면
					ans[j] = '?'; //값을 ?로
			}
		}
		string s = new string(ans); //답이에요
		Console.WriteLine(s); //출력		
	}
}