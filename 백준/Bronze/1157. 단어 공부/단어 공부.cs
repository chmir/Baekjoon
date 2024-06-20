using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //대문자 65~90 소문자 97~122
            String s = Console.ReadLine();
            int[] count = new int[26]; //알파벳 개수 배열
            int max=0; //같은 문자가 가장 많은 인덱스 숫자
            bool overlap = false; //같은 개수가 있는지 여부
            s = s.ToUpper(); //연산의 수월함을 위해 전부 대문자로 변환
            //입력한 문자를 전부 알파벳 배열에 카운팅함
            for (int i = 0; i < s.Length; i++) count[s[i]-65]++;
            //알파벳 개수만큼 반복함
            for (int i = 1; i < 26; i++) 
            {//개수가 다른 알파벳과 중복이면 overlap true
                if (count[max] == count[i]) overlap = true;
                else if (count[max] < count[i])
                {//가장 큰 개수의 알파벳이 있다면
                    max = i; //max변수에 해당 인덱스 대입
                    overlap = false; //중복이 아님
                }
            }
            //중복이 있으면 ?, 아니면 가장 많은 개수의 알파벳 출력
            //삼항연산자 쓸까 했는데 왠지 모르게 오류가 나서 보류...
            if (overlap) Console.Write("?");
            else Console.Write((char)(max+65));
        }
    }
}
