using System;
using System.Collections.Generic; //Stack<T> 사용
using System.Text; //StringBuilder 사용
//using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 17298 /g4 /오큰수 /240115
		//수열과 스택을 사용, 값이 입력된 모든 수열을 탐색한다
		//스택에는 수열의 인덱스를 저장하면서 비교를 해줬다
		
		//선언 
		var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		int n = int.Parse(sr.ReadLine()); //개수입력
		//값을 비교할 수열
		int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse); 
		Stack<int> s = new Stack<int>(); //대소 비교할 스택
		
		//연산
		for(int i = 0; i < n; i++){ //수열의 모든 값을 다 돌아본다.
			//스택에 값이 있으며 수열[i]가 수열[s.Peek()] 값보다 크면 
			//스택 맨 위의 인덱스의 값을 수열[i]의 값으로 바꾸는걸 반복.
			//그리고 사용한 스택의 값은 더는 비교할 필요 없어서 Pop해줌
			while(s.Count > 0 && arr[s.Peek()] < arr[i]) {
				arr[s.Pop()] = arr[i]; //오 나의 오큰수시여
			}
			//위의 반복이 끝났거나, 조건에 맞지 않은 경우 인덱스만 넣고 끝
			s.Push(i);
		}
		//위의 반복이 끝나면 스택의 모든 값을 Pop하면서 -1로 초기화
		//말 그대로 오큰수를 찾지 못한 인덱스의 값들을 -1로 바꾸는 것
		while(s.Count > 0) arr[s.Pop()] = -1;
		
		//출력
		for(int i = 0; i < n; i++) sb.Append(arr[i]).Append(' ');
		sw.Write(sb);
		sr.Close();
		sw.Flush();
		sw.Close();
	}
}