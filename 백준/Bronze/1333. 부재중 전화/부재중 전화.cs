using System;
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {
        //bj 1333 /b2 /부재중 전화 /231127
		//N, L, D 곡 개수, 노래 길이, 전화벨 간격
		
		//입력 N=0, L=1, D=2 
		int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); 
		int l = n[1]+5; //노래길이랑 5초 지난거 까지 셈
		int d = n[2]; //전화벨 간격
		for(int i = 0; i < n[0]; i++){//노래를 반복한다. 
			//노래가 흐른 시간보다 전화벨 시간이 작은지? 확인
			while(n[1] > n[2]) n[2] += d; //작다면 벨 시간을 올린다. 			
			//위의 반복문을 벗어났다면 n[1] <= n[2] 이 됐을거고, 
			//n[1] <= n[2] < n[1] + 5 라면 빠져나온다. 			
			//벨소리가 노래가 다시 시작되기 전에 울렸다면?
			//시작되고 나서는 울려도 안들림
			if(n[2] < n[1] + 5) break; //반복문 종료
			
			n[1] += l; //5초의 대기시간과 노래가 흐른 시간
		}
		//노래가 안들리는 시간이 왔다면
		Console.WriteLine(n[2]); //이제야 벨이 울림
	}
}