using System;
using System.Linq; //Enumerable.Range(1,n); 사용
using System.Collections.Generic; //Queue<T> 사용
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {      	   
		//bj 2164 /s4 /카드2 /240110
		//맨 위의 카드 버리고, 두번째 카드는 아래로 반복
		//deq, enq(deq) -> 마지막?
		//큐는 가장 먼저 들어온 애가 나중에 나가니까 가능한 문제
		
		//n 입력	   
		int n = int.Parse(Console.ReadLine());
		//정수형 큐 선언, Enumerable.Range(1,n) -> 1~n까지 큐에 삽입
		Queue<int> q = new Queue<int>(Enumerable.Range(1, n)); 
		//연산
		while(q.Count > 1){ //마지막 카드 하나가 남을 때 까지 반복
			q.Dequeue(); //맨 위의 카드를 버린다
			q.Enqueue(q.Dequeue()); //그다음 맨 위의 카드는 아래에 놓는다
		}
		//출력
		Console.Write(q.Dequeue()); //그럼 마지막 한장은?
	}
}