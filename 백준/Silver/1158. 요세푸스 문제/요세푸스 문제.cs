using System;
using System.Linq; //Enumerable.Range(1,n); 사용
using System.Collections.Generic; //Queue 큐 사용
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {      	   
		//bj 11866 /s5 /요세푸스 문제 0 /231207
		//조금 최적화한 버전, 1158도 풀림
		
		//n, k 입력	   
		int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
		//정수형 큐 선언, Enumerable.Range(1,n) -> 1~n까지 큐에 삽입
		Queue<int> q = new Queue<int>(Enumerable.Range(1, n[0])); 
		int[] ans = new int[n[0]]; //정답이 넣어질 변수
		
		//n만큼 반복해주고. 
		for(int i = 0; i < n[0]; i++)
		{
			//0~k-1 까지 반복 후 k번째는 빼는걸 반복하자. 
			for(int j = 0; j < n[1] - 1; j++){
				q.Enqueue(q.Dequeue());
			}
			ans[i] = q.Dequeue(); //제외된 값을 하나씩 넣어준다. 
		}
		//출력
		Console.Write($"<{String.Join(", ", ans)}>");	
	}
}