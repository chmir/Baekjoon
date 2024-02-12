using System;
//shift + f5 = 코드 실행
class Program
{
    static void Main(string[] args)
    {
        //bj11659 /s3 /구간 합 구하기 4 /240212
        //문제의 시간 제한은 1초, 약 1억번의 연산을 할 수 있는데
        //최대 10만개의 수열에서 10만개의 합을 출력해야 하기에
        //O(MN) = 100억번 연산 이라는 시간 복잡도는 시간초과가 되므로 단순합은 X
        //2~4의 구간합은 0~4의 합에서 0~1의 합을 뺀 것과 같다. 
        //누적합 배열에서 sum[4] - sum[2-1] 과 같다.

        //첫 번째 줄 입력
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //왠진 몰라도 StreamReader를 안쓰는 게 더 빠르다.
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int N = input[0];int M = input[1];

        //두 번째 줄 입력
        int[] sum = new int[N+1];
        input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        //1~N까지의 합배열을 생성한다.
        for (int i = 0; i < N; i++) sum[i + 1] = sum[i] + input[i];
        //for (int i = 0; i < sum.Length; i++) Console.WriteLine($"sum[{i}] = {sum[i]}");

        //입력 및 연산
        while (M-- > 0) // 입력 받은 M의 횟수만큼 순회
        {
            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            sw.WriteLine(sum[input[1]] - sum[input[0] - 1]);
        }
        sw.Flush();
        sw.Close();
    }
}