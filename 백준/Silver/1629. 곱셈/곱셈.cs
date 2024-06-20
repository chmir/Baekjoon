class Program
{
    //bj1629 /s1 /곱셈 /240503
    //A^B%C 이게 답이지만, 전부 곱한다음 나누면 느리고 크기가 너무 커져요
    //분할정복을 통해서 시간복잡도가 결과적으로 O{B)에서 O(log B)로 떨어집니다. 
    //
    static long Remains(int A, int B, int C)
    {
        // 기저 조건: B가 1이면 A^1 % C는 A % C와 동일
        if (B == 1) return A % C;

        // 재귀적으로 문제를 반으로 줄여나감
        long temp = Remains(A, B / 2, C);

        // B가 짝수일 때
        if (B % 2 == 0)
        {
            // 결과를 제곱하고, C로 나눈 나머지 반환
            return (temp * temp) % C;
        }
        else // B가 홀수일 때
        {
            // 결과를 제곱하고 A를 곱한 후, C로 나눈 나머지 반환
            return ((temp * temp) % C * A) % C;
        }
    }
    static void Main()
    {
        //입력
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        //출력
        Console.WriteLine(Remains(input[0], input[1], input[2])) ;
    }
}