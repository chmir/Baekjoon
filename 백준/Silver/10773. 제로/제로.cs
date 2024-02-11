using System;
using System.Collections.Generic; //Stack <T> 사용
//shift + f5 = 코드 실행
class Program {		
    static void Main(string[] args) {      	   
		//bj 10773 /s4 /제로 /231208
		//1<=K<=100,000 and 0<=N<=1,000,000 
		//여기서 0은 입력 취소. 
		//sum은 int로 하면 터짐, 천억인가? 그쯤 돼서 long으로 
		//sum에다 값을 넣는 연산을 따로 또 반복 할 필요가 있을까? 
		//둘 중에 뭐가 더 빠른지 비교해 봤는데, 
		//둘이 딱히 차이가 없는 거 같다, 몇몇은 그냥 따로 더하는 게 
		//더 빨리 나오기도 했음 복잡하게 생각말고 단순히 돌아가자. 
		
		Stack<int> stack = new Stack<int>(); //정수형 스택 생성
		int K = int.Parse(Console.ReadLine()); //입력받을 개수 입력
		long sum = 0; //값을 담을 변수
		//단순히 더하는 연산을 따로 했을 경우... 		
		for(int i = 0; i < K; i++){
			//입력
			int input = int.Parse(Console.ReadLine());
			if(input == 0) stack.Pop(); //0이면 값 빼기 
			else stack.Push(input); //아니면 값 push
		}
		while(stack.Count != 0){ //요소가 빌 때 까지 빼주고
			sum += stack.Pop(); //그값을 더해서
		}		
		//더하는 연산을 같이 했을 경우... 
		/*
		for(int i = 0; i < K; i++){
			//입력
			int input = int.Parse(Console.ReadLine());
			//0이면 값 빼면서 그 값 sum에 빼기
			if(input == 0) sum -= stack.Pop(); 
			else{ //아니면 값 push 겸 sum에도 더해준다. 
				sum += input;
				stack.Push(input); 
			} 
		}
		*/
		Console.WriteLine(sum); //출력
		
	}
}