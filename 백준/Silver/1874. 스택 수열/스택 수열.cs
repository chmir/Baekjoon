using System;
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
using System.Collections.Generic; //Stack<> 사용

//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {
		//bj 1874 /s2 /스택 수열 /231213
		//수열의 값을 탐색할 index 정수와 값을 1~N까지 넣을 반복문용 정수가 
		//따로따로 쓰여야 보기가 편할 것 같다.
		//그리고 굳이 for문에 집착 할 필요는 없는 문제다. 
		//다음 pop을 할 때 다음 인덱스로 넘어가면 되고, 
		//push를 할 때 다음 오름차 순의 숫자로 넘어가면 된다. 
		
		//선언
		StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
		StreamReader reader = new StreamReader(Console.OpenStandardInput());
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		Stack<int> stack = new Stack<int>(); //정수형 스택
		int n = int.Parse(reader.ReadLine()); //입력개수
		int[] seq = new int[n]; //입력할 수열
		int num = 1; //1~n까지 순서대로 넣어질 수
		
		//입력
		for (int i = 0; i < n; i++) seq[i] = int.Parse(reader.ReadLine());
			
		//연산
		//수열을 넣은 배열 탐색은 0~n-1 이지만, 
		//값을 넣는 순서는 1~n이기에 이를 유의할것
		for(int i = 0; i < n; i++){ //index = 0~(n-1)
			while(num <= seq[i]){ //다음값 나올 때 까지 push
				stack.Push(num++); //push하고 다음 수로 넘어감
				sb.AppendLine("+"); 
			}
			if(stack.Peek() == seq[i]){ //pop할 수 있다면
				stack.Pop(); //빼주고 다음을 기다린다.
				sb.AppendLine("-"); //인덱스는 다음으로 넘어감
			}
			else { //pop할 수 없다면 틀린 수열
				writer.Write("NO"); //NO출력 후 
				writer.Close();
				reader.Close();
				return; //종료(sb.clear() 쓰면 break해도 됨)
			}
		}	
		//출력
		writer.Write(sb.ToString());
		//close함수를 호출하여 모든 입, 출력이 정상처리되도록 함.
		writer.Close();
		reader.Close();
    }
}