using System;
using System.Collections.Generic; //Stack<T> 사용
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 6198 /g5 /옥상 정원 꾸미기 /231228
		//보자마자 생각난대로 풀었는데 제발 맞았으면 좋겠다
		//2493번 탑과 비슷한 방식? 똑같은 건 아니고...
		
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		Stack<int> stk = new Stack<int>(); //정수형 스택
		int n = int.Parse(sr.ReadLine()); //개수입력
		int[] arr = new int[n]; //배열 생성
		long count = 0; //벤치마킹 가능한 빌딩의 총합
		//입력 겸 연산
		//첫번째 값은 무조건 넣음
		//arr[1] = int.Parse(sr.ReadLine()); 
		stk.Push(int.Parse(sr.ReadLine()));
		for(int i = 1; i < n; i++){
			arr[i] = int.Parse(sr.ReadLine());
			//넣을 값이 옆 건물보다 크다면 무조건 옆 건물을 빼야함
			//왜냐면 3층 빌딩 오른쪽에 7층빌딩이 들어서면
			//3층은 더이상 앞을 볼 수 없기에 제외함
			//스택이 비워질 때 까지만 빼준다!
			while(stk.Count > 0 && stk.Peek() <= arr[i]) stk.Pop();	
			count += stk.Count; //볼 수 있는 빌딩의 수
			stk.Push(arr[i]);//지금 빌딩을 넣는다.	
		}
		//출력
		sw.Write(count.ToString());
		sr.Close(); 
		sw.Close();
	}
}