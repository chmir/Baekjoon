using System;
using System.Collections.Generic; //Queue <T> 사용
using System.Text; //StringBuilder 사용
using System.Linq; //Queue.Last; 사용(큐의 맨 뒤의 요소를 알려줌)
//shift + f5 = 코드 실행
class Program {		
    static void Main(string[] args) {      	   
		//bj 10845 /s4 /큐 /231209
		//10828 스택 문제가 생각나는 문제, 혹시 몰라서 스트링 버퍼 사용

		Queue<int> q = new Queue<int>(); //정수형 큐 생성	
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		int n = int.Parse(Console.ReadLine()); //입력받을 개수 입력
		
		for(int i = 0; i < n; i++){ //n만큼 반복
			//입력 공백으로 나누기
			string[] sarr = Console.ReadLine().Split(' '); 
			switch (sarr[0]){ //첫번째 입력이 뭐인지?
				case "push": //값을 넣을것(출력없음)
					q.Enqueue(int.Parse(sarr[1]));
					break;
				case "pop":	//비어있으면 -1, 값이 있으면 빼고 출력할 것	
					//AppendLine() 에 정수가 들어가면 말을 안들어서 +""로 강제 형변환 함
					sb.AppendLine(q.Count == 0 ? "-1" : q.Dequeue()+"");
					break;
				case "size": //몇개의 수가 들어있는지 출력할 것
					sb.AppendLine(q.Count+""); 
					break;
				case "empty": //큐가 비어있으면 1, 아니면 0을 출력할 것
					sb.AppendLine(q.Count == 0 ? "1" : "0");
					break;
				case "front": //큐의 가장 앞의 정수를 출력, 없으면 -1을 출력할 것
					//값이 빠진다는 차원에서 스택의 top과 큐의 front는 같다.
					sb.AppendLine(q.Count == 0 ? "-1" : q.Peek()+"");
					break;
				case "back": //큐의 가장 뒤의 정수를 출력, 없으면 -1을 출력할 것
					//방금 넣은 큐의 값을 구해야하나? 명령어가 없어서 linq사용
					sb.AppendLine(q.Count == 0 ? "-1" : q.Last()+"");
					break;
				//예외처리를 할 필요가 없기에 디폴트는 생략함. 
			}			
		}
		//결과 출력, 입력을 다 받고 출력인가봄
		Console.Write(sb.ToString());
	}
}