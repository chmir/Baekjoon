using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 1929 /s3 /소수 구하기 /240101
		//2581과 달리, 이 문제에서는 에라토스테네스의 채를 써야 함
		
		//입력 및 선언
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//m~n 
		int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
		//소수를 담을 배열 생성
		int[] arr = new int[n[1]+1];
		//2~n
		for(int i = 2; i <= n[1]; i++) arr[i] = i;
		
		//2부터 시작하여 선택된 수의 배수에 해당하는 수를 전부 지운다. 
		//선택된 수는 지우지 않고, 이미 지워진 수는 넘어간다. 
		for(int i = 2; i <= n[1]; i++){
			if(arr[i] == 0) continue; //지워진 수 건너띄기
			//지워진 수가 아니라면 i의 배수부터 출발하여 모든 배수를 지움
			for(int j = i*2; j <= n[1]; j += i) arr[j] = 0;
		}
		
		//출력
		for(int i = n[0]; i <= n[1]; i++){
			if(arr[i] != 0) sw.WriteLine(arr[i]);
		}
		
		sr.Close();
		sw.Flush();
		sw.Close();
	}
}