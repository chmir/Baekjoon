using System;
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
using System.Collections.Generic; //Stack <T> 사용
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {      	   
		//bj 24448 /s4 /도서관2 /240111
		//일본어 문제, 소문자 영어가 제목인 책을 한 곳에 쌓아서
		//"READ"가 올 때 마다 맨 위에 놓인 책을 읽고 
		//읽은책을 읽은 순서에 저장
		//모든 행동을 다 했을 때, 읽었던 책의 제목을 순서대로 나열한다. 
		//행동개수인 Q가 꽤 크기 때문에 가변문자열과 스트림입출력 사용 필요
		
		//선언
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		Stack<string> book = new Stack<string>(); //책
		int q = int.Parse(sr.ReadLine()); //입력개수
		
		//연산
		for(int i = 0; i < q; i++){
			string s = sr.ReadLine(); //READ or book
			if(s == "READ"){ //맨 위에 쌓인 책을 읽다
				sb.AppendLine(book.Pop()); //읽은 책 저장
			}
			else{ //도서관에서 책을 가져오다 
				book.Push(s);
			}
		}
		//출력
		sw.Write(sb);
		sw.Flush();
		sw.Close();
		sr.Close();
	}
}