using System;
using System.Collections.Generic; //List<T> 사용
using System.Text; //StringBuilder 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 2346 /s3 /풍선 터뜨리기 /231226
		//런타임에러가 왜 떴는지는 모르겠지만 아무튼... 맞췄다.

		StringBuilder sb = new StringBuilder(); //스트링빌더 생성
		int n = int.Parse(Console.ReadLine()); //입력받을 개수 입력 
		List<int> dq = new List<int>(); //덱 생성
		for (int i = 1; i <= n; i++) dq.Add(i); //1~n
		//풍선 안의 번호 입력
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);	
		int num; //터트릴 풍선의 번호
		//연산	
		while(dq.Count > 1){ //풍선 마지막 하나 남을 때 까지
			sb.Append(dq[0]+" "); //지금 터트릴 풍선 출력
			num = arr[(dq[0]-1)]; //터트린 풍선의 번호
			dq.RemoveAt(0); //터진 풍선 제거
			
			//몇번이동?
			if(num > 0){ //양수인지, 양수는 1이면 그대로.
				for(int j = 1; j < num; j++){
					//전방삭제 후 후방삽입
					dq.Add(dq[0]); //앞의 값을 뒤로
					dq.RemoveAt(0); //맨 앞, 왼쪽(front) 제거
				}
			}
			else{ //음수인지 (0은 안나옴)
				for(int j = 0; j > num; j--){
					//후방삭제 후 전방삽입
					dq.Insert(0, dq[dq.Count-1]); //뒤의 값을 앞으로
					dq.RemoveAt(dq.Count - 1); //맨 뒤, 오른쪽(rear)의 값 제거
				}
			}
		}
		//결과 출력
		sb.Append(dq[0]+" "); //마지막으로 터트린 풍선 출력
		Console.Write(sb.ToString());
	}
}