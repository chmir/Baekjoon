using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 10989 /b1 /수 정렬하기3 /231231
		//입력 개수가 천만개 까지 되기에 일일이 입력받고 
		//따로 정렬해서 출력하는 건 비효율적이다. 
		//입력받을 때 부터 미리 만들어둔 1만개(입력이 1~1만이기에)
		//의 배열에 입력받은 값과 같은 인덱스에 1씩 더해줘서
		//0(값이 없는)을 제외하고 중복값은 중복된 만큼 더 출력해주면 끝
		
		//선언	
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//개수 입력
		int n = int.Parse(sr.ReadLine());
		int[] arr = new int[10001]; //1만 크기의 배열 생성
		//입력
		for(int i = 0; i < n; i++){
			arr[int.Parse(sr.ReadLine())]++; //1을 더한다. 
		}
		//출력
		for(int i = 1; i < 10001; i++){ //배열 탐색
			if(arr[i] == 0) continue; //0은 출력안함
			//값이 들어있으면 중복된 개수만큼 연달아 출력한다. 
			for(int j = 0; j < arr[i]; j++) sw.WriteLine(i); 
		}
		sr.Close(); 
		sw.Close();
	}
}