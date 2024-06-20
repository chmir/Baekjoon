using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj9020 /s2 /골드바흐의 추측 /240103
		//2보다 큰 모든 짝수는 두 소수의 합으로 나타낼 수 있다는 추측
		//4<=n<=10,000 사이의 짝수가 들어 왔을 때, 
		//서로 가장 차이가 작은 두 소수의 합으로 출력해라. 
		//2~10,000 까지 에라토스테네스의 체를 사용하여 미리 구해놓고, 
		//n의 절반값 부터 시작하여 1씩 내려간 수가 소수가 맞는지를 보고
		//구해낸 소수로 n을 뺐을 때, 나머지 수도 소수인지를 판별하고 출력. 
		//참고로 1만 까지는 골드바흐 파티션(두 소수의 합이 되는 짝수)
		//이 있기 때문에 무조건 정답이 나와야 한다. 
		
		//입력 및 선언
		//입출력용 스트림
		StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		int even; //짝수를 담을 변수
		int t1; //골드바흐 파티션 확인용 변수
		int t2; //위와 같음
		int T = int.Parse(sr.ReadLine()); //테스트 개수
        
        /*에라토스테네스의 체*/
		//소수를 담을 배열 생성
		//int배열은 할당하지 않으면 0으로 초기화 된다.
		int[] arr = new int[10001]; //0이 소수, 1이 합성수가 됨
		//소수를 출력하는 문제가 아니기에, 0과 1로 소수를 구분한다.
		//2부터 시작하여 소수가 아닌 수에 1를 저장한다.
		//선택된 수는 지우지 않고, 이미 지워진 수는 넘어간다. 
		for(int i = 2; i < 10001; i++){
			if(arr[i] == 1) continue; //지워진 수 건너띄기
			//지워진 수가 아니라면 i의 배수부터 출발하여 모든 배수를 지움
			for(int j = i*2; j < 10001; j += i) arr[j] = 1;
		}
		/*골드바흐 추측 연산*/
		//연산, 출력
		for(int i = 0; i < T; i++){
			even = int.Parse(sr.ReadLine());
			//짝수의 절반값 부터 -- 감소하여 탐색
			for(int j = even/2; j > 1; j--){ //2까지 탐색
				t1 = j; //소수일까?
				t2 = even - j; //두번째 값도? 
				if(arr[t1] == 0 && arr[t2] == 0){ //소수라면?
					sw.WriteLine($"{t1} {t2}"); //출력하고
					break; //나간다. 
				}
			}
		}
		
		sr.Close();
		sw.Flush();
		sw.Close();
	}
}