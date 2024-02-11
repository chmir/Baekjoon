using System;
using System.Linq; //Enumerable.Range(1,n); 사용
using System.Collections.Generic; //Queue<T> 사용
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {      	   
		//bj 12873 /s4 /기념품 /240114
		//1~N까지의 참가자가 원으로 둘러 앉아서
		//각 단계를 t라고 했을 때, 한명씩 시계방향으로 t^3까지 외치고
		//단계마다 마지막 번호를 부른 사람을 제외시켜가며 
		//마지막까지 남은 사람에게 기념품을 주는 문제 
		//n의 세제곱은 125,000,000,000 천억단위이므로 카운트는 long으로 사용
		//시간초과가 뜨는 이유를 생각해보자, 천억단위를 일일이 돌필요가 있나? 
		//나머지 연산을 통해서, 실질적으로 움직여야 될 만큼만 움직여보자. 
		//6명이 있을 때 10번 돌아가야 한다면, 4번을 돌아도 같다는 소리다. 
		
		//입력 및 선언
		int n = int.Parse(Console.ReadLine());
		//정수형 큐 선언, 1~n까지 값 넣음
		Queue<int> q = new Queue<int>(Enumerable.Range(1, n)); 
		
		//연산
		for(int i = 1; i < n; i++){ //마지막 단계에는 한 사람만 남기에
			//i의 세제곱이 마지막으로 부를 번호
			//그리고 남은 인원수로 나눈 나머지 만큼만 돌아도 된다.
			//이 값은 아무리 커져도 최대 인원수인 5000을 넘지 못한다.
			//주의할 점은 마지막 번호를 남겨야 하기에 -1을 해둔다.
			int t = (int)((Math.Pow(i, 3) - 1) % q.Count); 
			//1부터 마지막 번호 직전까지만 부른다
			for(int c = 0; c < t; c++){ 
				q.Enqueue(q.Dequeue()); //다음 차례로 넘김
			}
			//마지막 번호가 오면 탈락자를 제외한다.
			q.Dequeue(); //제외
		}
		//출력
		Console.Write(q.Dequeue()); //마지막 남은 한 사람
	}
} //근데 일일이 돌리는 것 보다 그냥 리스트에 지울 인덱스로 바로 가는 게 더 빠른듯