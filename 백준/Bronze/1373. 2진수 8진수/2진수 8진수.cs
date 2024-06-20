using System;
using System.Text; //StringBuilder 사용
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//bj1373 /b1 /2진수 8진수 /240126
			//2진수를 8진수로 변환하기 위해선 2진수를 세자리씩 끊어서 조립하면 된다. 
			//2진수의 앞에서부터 3개씩 나누면서 연산한다. 
			//단, 3개씩 나눠야하니까, 길이가 3의 배수가 아니면 임의로 앞에 0을 추가
			//8진수의 경우 문자열 연산이 필요해 가변문자열을 씀
			
			//선언 및 입력
			StringBuilder base8 = new StringBuilder(); //8진수
			string s = Console.ReadLine(); //2진수
			int length = s.Length%3; //문자길이가 3의 배수인지
			//3의 배수가 아닌 경우는 1과 2 두 가지 밖에 없음. 
			if(length == 2) s = "0" + s; //0이 한 개 부족한 경우
			if(length == 1) s = "00" + s; //0이 두 개 부족한 경우
			//연산
			for(int i = 0; i < s.Length; i += 3){ //3개씩 나누어 보므로 +=3
				//남은 문자의 수에 따라 예외처리
				//2^2 + 2^1 + 2^0
				int n = (s[i]-'0')*4 + (s[i+1]-'0')*2 + (s[i+2]-'0'); 
				base8.Append(n); //숫자 -> 문자 할당연산, 자료형 변환 필요 없나봐
			}
			//출력
			Console.Write(base8);
		}
    }
}
