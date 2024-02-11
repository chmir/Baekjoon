using System;
using System.Collections.Generic; //List<T> 사용
using System.Linq; //Enumerable.Range() 사용, 배열에 연속된 값을 채울 때 씀
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj ?/s4 /덱 /231219
		//입출력 할 게 적어서 스트링빌더, 스트림리더/라이터 안써도 될듯
		//연결리스트에 자바같은 IndexOf()가 안보여서 많이 헤맨 문제
		//그냥 리스트를 쓰자. 
		
		//[0]=N, [1]=M //빼낼크기<=큐의크기<=50
		int[] N = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
		//빼낼 요소 배열
		int[] seq = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
		//리스트 생성
		List<int> dq = Enumerable.Range(1, N[0]).ToList();//1~N
		int count = 0; //2, 3번 연산 횟수
		
		//연산
		for(int i = 0; i < N[1]; i++){
			int target = dq.IndexOf(seq[i]); //지금 뽑을 값의 인덱스 위치탐색
			//짝수냐 홀수냐에 따라 중간값이 살짝 달라진다. 
			//5/2 -> 2(3), 4/2 -> 2(3) 
			//하지만 별로 상관은 없는게 2번 연산은 중간값보다 작아야 연산하기에 
			//1~5에서 3을 찾아야 한다? 어차피 2번하나 3번하나 똑같고
			//1~4에서 2를 찾는다면 2번, 3을 찾는다면 3번 연산을 수행하게 됨 
			//이해하기 쉽게 1~5로 나열했을 뿐, 어떻게 뒤섞여있든 똑같을듯
			if(target <= dq.Count/2){ 	
				for(int j = 0; j < target; j++){ //2번 연산
					int temp = dq[0]; //값 임시저장
					dq.RemoveAt(0); //맨 앞, 왼쪽(front) 제거
   					dq.Add(temp); //오른쪽으로 이동
					count++;
				}
			}
			else{ //찾는 요소가 중간보다 뒤에 있는 경우 3번 연산
				for(int j = 0; j < dq.Count - target; j++){
					//^ = 컬렉션의 마지막부터 역순으로 인덱스를 지정하는 연산자
					//근데 왜 ^ 안되냐?...
					int temp = dq[dq.Count-1]; //^1 = 맨 뒤의 인덱스, Length - 1 과 같음
					dq.RemoveAt(dq.Count - 1); //맨 뒤, 오른쪽(rear)의 값 제거
					dq.Insert(0, temp); //왼쪽으로 이동	
					count++;
				}
			}
			dq.RemoveAt(0); //2,3번이 끝나고 1번 연산 시행
		}
		//결과 출력
		Console.WriteLine(count);
	}
}