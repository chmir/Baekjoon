using System;
using System.Collections.Generic; //LinkedList<T> 사용
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 28279 /s4 /덱2 /231224
		//덱(10866)과 달리 숫자로 입력받음. 
		//근데 숫자를 char로 저장하는 편이 공간 절약에서 좋지 않을까 
		//바보야 한자리만 저장하는 게 아니라 1<=X<=100,000이잖아... 
		
		//덱으로 위장한 연결리스트 생성
		LinkedList<int> dq = new LinkedList<int>(); 
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		//입력, 출력용 객체 생성
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		int n = int.Parse(sr.ReadLine()); //입력받을 개수 입력 
			
		for(int i = 0; i < n; i++){ //n만큼 반복
			//입력 공백으로 나누기
			string[] str = sr.ReadLine().Split();
			//따로 구별 안하면 Null 오류 뜸
			int x = 0; //1, 2 일 때 사용
			switch (int.Parse(str[0])){ //첫번째 입력이 뭐인지? 
				case 1: //덱 앞에 값을 넣는다(push_front)
					x = int.Parse(str[1]);
					dq.AddFirst(x); 
					break;
				case 2: //덱 뒤에 값을 넣는다(push_back) 
					x = int.Parse(str[1]);
					dq.AddLast(x); 
					break;	
				case 3: //가장 앞의 수를 빼고 출력(pop_front)
					if(dq.Count == 0) sb.AppendLine("-1");
					else{
						sb.AppendLine(dq.First.Value.ToString());
						dq.RemoveFirst();
					}
					break;
				case 4: //가장 뒤의 수를 빼고 출력(pop_back)
					if(dq.Count == 0) sb.AppendLine("-1");
					else{
						sb.AppendLine(dq.Last.Value.ToString());
						dq.RemoveLast(); 
					}
					break;
				case 5: //몇개의 수가 들어있는지 출력(size)
					sb.AppendLine(dq.Count.ToString()); 
					break;
				case 6: //큐가 비어있으면 1, 아니면 0을 출력(empty)
					sb.AppendLine(dq.Count == 0 ? "1" : "0");
					break;
				case 7: //큐의 가장 앞의 정수를 출력(front)
					sb.AppendLine(dq.Count == 0 ? "-1" : dq.First.Value.ToString());
					break;
				case 8: //큐의 가장 뒤의 정수를 출력(back)
					sb.AppendLine(dq.Count == 0 ? "-1" : dq.Last.Value.ToString());
					break;
				//예외처리를 할 필요가 없기에 디폴트는 생략함. 
			}
		}
		//결과 출력, 입력을 다 받고 출력인가봄
		sw.Write(sb.ToString());
		sr.Close(); //객체 종료?
		sw.Close(); //객체 종료?
	}
}