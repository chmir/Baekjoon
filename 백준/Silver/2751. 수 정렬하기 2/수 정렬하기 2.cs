using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 2751 /s5 /수 정렬하기2 /231227
		//수 정렬 방법에 대해선 다음에 차차 복습하도록 하고... 
		//정렬은 따로 Array.Sort(); 를 써줬고,
		//입출력이 많으므로 스트림 사용, 스트링빌더는 필요 없을듯
		//string.Join을 사용하여 정수배열을 쉽게 문자열로 변환함
        //Array.Sort();의 시간 복잡도는 O(nlogn) 이라는데, 좀 더 찾아보자.
		
		//선언	
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		//개수 입력
		int n = int.Parse(sr.ReadLine());
		int[] arr = new int[n]; //배열 생성
		for(int i = 0; i < n; i++){
			arr[i] = int.Parse(sr.ReadLine());
		}
		//정렬
		Array.Sort(arr);
		//정렬한 값을 엔터로 나눠서 
		//출력
		sw.Write(string.Join("\n", arr));
		sr.Close(); 
		sw.Close();
	}
}