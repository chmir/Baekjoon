using System;
//shift + f5 = 코드 실행
public class main {
	static int N = 0; //반복 횟수
	static string under = "____"; //언더바
	static void underbar(int n){ //언더바 반복 함수
		for(int i = 0; i<n; i++) Console.Write(under);
	}
	
	static void recu(int n){ //n은 반복 횟수
		underbar(n); //언더바 개수
		Console.WriteLine("\"재귀함수가 뭔가요?\"");		
		if(n == N){ //마지막 재귀라면 답변을 한다. 
			underbar(n); 
			Console.WriteLine("\"재귀함수는 자기 자신을 호출하는 함수라네\"");
			underbar(n); 
			Console.WriteLine("라고 답변하였지.");
			//return;
		} 
		else { //마지막 재귀가 아니라면 이야기를 마저 잇는다. 
			underbar(n); 
			Console.WriteLine("\"잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
			underbar(n); 
			Console.WriteLine("마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
			underbar(n); 
			Console.WriteLine("그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");
			recu(n+1); //마지막 재귀가 아니면 한번 더 함수 실행
			//위의 재귀를 전부 마쳤으면 이제 아래 말만 하다가 끝나게 됨. 
			underbar(n); 
			Console.WriteLine("라고 답변하였지.");
		} 	
	}
	public static void Main() {	
		//bj17478 /s5 /재귀함수가 뭔가요?
		//반복할 부분, 종료 조건, 반복 중에 바뀔 부분
		//첫 입력 N수는 고정수로 둬야겠지?...
		
		//재귀횟수 입력
		N = Int32.Parse(Console.ReadLine());
		//실행
		Console.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
		recu(0);
	}
}