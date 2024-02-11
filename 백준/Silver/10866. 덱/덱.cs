using System;
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
	public struct Deque{
		//변수
		private int size; //덱의 최대 가용범위
		private int front, rear; //요소의 시작위치, 마지막 위치
		private int[] arr; //요소를 담을 배열
		private int count; //요소의 개수 
		//생성자
		public Deque(int size){
			this.size = size;
			front = 0;
			rear = 0;
			count = 0;
			arr = new int[size];
		}
		//함수
		public void Push_f(int item){ //전방삽입
			arr[front] = item; //먼저 추가 하고(front는 비었으니까)
			front = (front - 1 + size) % size; //뒤로 감
			count++; //요소의 개수 증가
		}
		public void Push_b(int item){ //후방삽입(큐와 동일)
			rear = (rear + 1) % size; //앞으로 가서
			arr[rear] = item; //추가 하고
			count++; //요소의 개수 증가
		}
		public int Pop_f(){ //전방삭제(큐와 동일, 맨 왼쪽의 데이터를 꺼낸다)
			if(isEmpty()) return -1; //뺄 값이 없으면 예외처리
			
			front = (front + 1) % size; //앞으로 가서 (front는 비어있는 칸이어서)
			int number = arr[front]; //삭제할 값 저장
			Array.Clear(arr, front, 1); //값 삭제 (안해도 되긴할듯)
			count--; //요소 개수 감소 
			return number; //값 출력
		} 
		public int Pop_b(){ //후방삭제
			if(isEmpty()) return -1; //뺄 값이 없으면 예외처리
			
			int number = arr[rear]; //삭제할 값 저장
			Array.Clear(arr, rear, 1); //값 삭제 (안해도 되긴할듯)
			rear = (rear - 1 + size) % size; //뒤로 감
			count--; //요소 개수 감소 
			return number; //값 출력
		} 
		public int getS(){ //걍 프로퍼티 안쓸랭
			return count;
		}
		public bool isEmpty(){ 
			return count == 0; //0이면 true, 아니면 false
		}
		public int Peek_f(){ //전방탐색, 전방삭제에서 삭제만 뺌
			if(isEmpty()) return -1; //예외처리
			return arr[(front + 1) % size]; 
		}
		public int Peek_b(){ //후방탐색, 위와 같은 원리
			if(isEmpty()) return -1; //예외처리
			return arr[rear];
		}
	}
    static void Main(string[] args) {      	   
		//bj 10866 /s4 /덱 /231219
		//구조체 사용함 // 숫자 문자 형변환은 +""도 별 다를거 없어보임
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		//입력, 출력용 객체 생성
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		int n = int.Parse(sr.ReadLine()); //입력받을 개수 
		Deque dq = new Deque(n); //수제로 만든 덱 구조체 생성
			
		for(int i = 0; i < n; i++){ //n만큼 반복
			//입력 공백으로 나누기
			string[] sarr = sr.ReadLine().Split(' ');
			switch (sarr[0]){ //첫번째 입력이 뭐인지? 
				case "push_front": //덱 앞에 값을 넣는다
					dq.Push_f(int.Parse(sarr[1]));
					break;
				case "push_back": //덱 뒤에 값을 넣는다. (큐와 같음) 
					dq.Push_b(int.Parse(sarr[1]));	
					break;	
				case "pop_front": //가장 처음에 넣었던 수 제거 (큐와 같음)
					sb.AppendLine(dq.Pop_f()+"");
					break;
				case "pop_back": //가장 마지막에 넣은 수 제거
					sb.AppendLine(dq.Pop_b()+"");
					break;
				case "size": //몇개의 수가 들어있는지 출력할 것
					sb.AppendLine(dq.getS()+""); 
					break;
				case "empty": //큐가 비어있으면 1, 아니면 0을 출력할 것
					sb.AppendLine(dq.isEmpty() ? "1" : "0");
					break;
				case "front": //큐의 가장 앞의 정수를 출력
					sb.AppendLine(dq.Peek_f()+"");
					break;
				case "back": //큐의 가장 뒤의 정수를 출력
					sb.AppendLine(dq.Peek_b()+"");
					break; 
			}
		}
		//결과 출력
		sw.Write(sb.ToString());
		sr.Close(); 
		sw.Close(); 
	}
}