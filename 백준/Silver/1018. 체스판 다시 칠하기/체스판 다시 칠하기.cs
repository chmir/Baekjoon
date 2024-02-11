using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//bj1018 /s4 /체스판 다시 칠하기 /240119
			//체스판은 B부터 시작하는 경우, W부터 시작하는 경우 두가지 
			//문제의 요지는 m*n 안에 8*8보드를 넣어서 연산하는 것.
			//아무렇게나 칠해진 m*n 보드에서 8*8로 봤을 때 
			//가장 덜 칠해도 될 곳을 출력하면 된다.
			
			//선언
			var sr = new System.IO.StreamReader(Console.OpenStandardInput());
			var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
			int min = 64; //가장 적게 칠할 수 있는 개수, 8*8이라 64가 최대치임
			//입력
			int[] arr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse); 
			int n = arr[0]; int m = arr[1]; 
			string[] board = new string[n];
			for(int i = 0; i < n; i++){
				board[i] = sr.ReadLine();
			}
			
			//연산
			//다시 바꿔 칠할 체스보드는 8*8이기 때문에 범위는 -7로 빼준다. 
			//왜냐면 8*8보드판이 전체 보드판의 인덱스를 초과해선 안되기 때문이다. 
			//만약 전체 보드판도 8*8이라면 전체보드를 한번만 확인하고 끝나는 방식. 
			for(int i = 0; i < n-7; i++){
				for(int j = 0; j < m-7; j++){
					//칠할 색의 개수, 무슨 색부터 시작할지 몰라 2개를 초기화
					int t1 = 0; int t2 = 0; 
					//i or j를 8*8로 전부 탐색한다. 
					for(int k = i; k < i+8; k++){
						for(int l = j; l < j+8; l++){
							//k+l로 홀수짝수 구분
							if((k+l)%2 == 0){ //0을 포함한 짝수인 경우
								//t1은 백부터 시작하는 경우
								if(board[k][l] != 'W') t1++;
								else t2++;
							}
							else{ //홀수인 경우
								//짝수일 때랑은 반대로 생각하면 됨
								if(board[k][l] != 'B') t1++;
								else t2++;
							}
						}
					}
					//8*8보드 탐색이 끝났으면, 칠할색이 가장 적게나왔는지 비교
					min = Math.Min(min, Math.Min(t1, t2));
				}
			}
			//출력
			sw.Write(min);
			sr.Close();
			sw.Flush();
			sw.Close();
		}
    }
}
