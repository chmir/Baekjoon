using System;
using System.Collections.Generic; //Stack <T> 사용
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
class Program
{
    static void Main(string[] args)
    {	
		//bj 2493 /g5 /탑 /231218
		//매 반복마다 타워를 좌에서 우로 하나씩 입력받는다. 
		//입력받은 탑이 이전의 탑보다 크다면 
		//이전의 탑은 입력받을 필요가 없으니 스택에서 빼준다. 
		//입력받은 탑이 이전의 탑보다 작다면 
		//그 이전의 탑이 수신받을 탑이며, 일단 이번 입력은 스택에 넣어준다. 
		//스택이 비었을 땐 0을, 있다면 가장 우측의 탑 인덱스를 출력해준다. 
		
		//가변 문자열 생성
		StringBuilder sb = new StringBuilder();
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//타워를 입력받을 스택 생성
		//(,) 사용법... 값을 두개 다 넣을때는 Push((x,y));
		Stack<(int,int)> stk = new ();
		int n = int.Parse(sr.ReadLine()); //탑 개수
		//높이를 입력받은 정수형 배열
		int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse); 
		int height; //입력에 사용
		//연산
		for (int i = 1; i <= n; i++) //1~n 까지
		{
			height = arr[i-1]; //비교 할 탑 입력
			//int index = i;
			//스택에 탑이 있고, 지금 입력받은 게 기존 탑보다 크다면
			while (stk.Count > 0 && height > stk.Peek().Item1){
				stk.Pop(); //기존의 탑을 지운다.
			}	
			if (stk.Count == 0){ //탑이 비었다면?
				sb.Append("0 "); //0을 출력하고		
			}
			else{//탑이 비지 않았을 때 
				//지금 가장 높은 탑의 인덱스를 출력한다. 
				sb.Append(stk.Peek().Item2 + " ");
			}
			stk.Push((height,i)); //입력한 탑을 넣는다.
		}
		//출력
		sw.Write(sb.ToString());
		sr.Close(); //객체 종료?
		sw.Close(); //객체 종료?
    }
}