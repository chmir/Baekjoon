using System;
//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {      	   
		//bj 11047 /s4 /동전0 /240110
		//- greedy 알고리즘을 사용하는 시기 -
		//현재의 선택이 이후에 선택에 영향을 주지 않으면서,
		//매순간 최적의 해를 구하는 것이 문제 전체의 최적의 해인 경우. 
		//n은 동전의 개수, k는 동전으로 거스를 돈
		
		//n, k 입력
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
		int n = arr[0]; //동전 개수
		int k = arr[1]; //거스를 돈
		//동전 가치 입력
		int[] coin = new int[n];
		for(int i = 0; i < n; i++){
			coin[i] = int.Parse(Console.ReadLine());
		} 
		int count = 0; //몇개의 동전이 필요한지?
		//연산
		//가장 비싼 동전부터 연산해야 하니까 n-1부터 시작함
		for(int i = n - 1; i > -1; i--){
			count += k / coin[i]; //나눠진 몫은 동전의 개수
			k %= coin[i]; //만약 나눠졌다면 거스를 돈도 나눠진다 
		}
		//출력
		Console.WriteLine(count);
	}
}