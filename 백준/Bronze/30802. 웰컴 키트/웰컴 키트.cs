using System;
using System.IO;
using System.Linq;

public class Program {
    public static void Main(string[] args) {
        // bj30802 /b3 /웰컴 키트 /240712
        // 문제 설명: 주어진 크기 배열(sizeArr)과 특정 값 T를 사용해 최소 묶음 수를 계산하고, 
        // 총 수량(N)을 특정 값 P로 나눈 몫과 나머지를 계산합니다.

        var br = new StreamReader(Console.OpenStandardInput());
        var bw = new StreamWriter(Console.OpenStandardOutput());

        // 첫 번째 줄 입력 받기 (N)
        int N = int.Parse(br.ReadLine());
        
        // 두 번째 줄 입력 받기 (sizeArr)
        var sizeArr = Array.ConvertAll(br.ReadLine().Split(), int.Parse);
        
        // 세 번째 줄 입력 받기 (T와 P)
        var arr = Array.ConvertAll(br.ReadLine().Split(), int.Parse);
        int T = arr[0];
        int P = arr[1];

        int cnt = 0;
        // sizeArr 배열을 순회하며 최소 묶음 수 계산
        for (int i = 0; i < 6; i++) {
            // 각 요소를 T로 나누어 몫을 cnt에 더함
            cnt += sizeArr[i] / T;
            // 나머지가 있으면 추가 묶음 필요
            cnt = sizeArr[i] % T > 0 ? cnt + 1 : cnt;
        }

        // 계산된 묶음 수 출력
        bw.WriteLine(cnt);
        // N을 P로 나눈 몫과 나머지 출력
        bw.WriteLine(N / P + " " + N % P);

        // StreamReader와 StreamWriter 객체 닫기
        br.Close();
        bw.Flush();
        bw.Close();
    }
}