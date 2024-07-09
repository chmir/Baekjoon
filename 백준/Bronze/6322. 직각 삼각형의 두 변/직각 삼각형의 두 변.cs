using System;

public class MainClass
{
    public static void Main(string[] args)
    {
        // 직각 삼각형의 두 변을 계산하는 프로그램
        // 무한루프
        for (int i = 1; ; i++)
        {
            // 입력된 한 줄을 공백으로 구분하여 토큰화
            var line = Console.ReadLine().Split();

            // 입력 값을 정수로 변환
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);

            // 0 0 0 입력 시 무한루프 종료
            if (a == 0 && b == 0 && c == 0)
                break;
            //연산
            string ans = "Impossible.";
            // 변 a의 값이 -1인 경우
            if (a == -1)
            {
                // 주어진 변 c가 변 b보다 작거나 같으면 삼각형이 성립하지 않음
                if (c > b)
                {
                    ans = "a = " + Math.Sqrt((c * c) - (b * b)).ToString("F3");
                }
            }
            // 변 b의 값이 -1인 경우
            else if (b == -1)
            {
                // 주어진 변 c가 변 a보다 작거나 같으면 삼각형이 성립하지 않음
                if (c > a)
                {
                    ans = "b = " + Math.Sqrt((c * c) - (a * a)).ToString("F3");
                }
            }
            // 변 c의 값이 -1인 경우
            else if (c == -1)
            {
                ans = "c = " + Math.Sqrt((a * a) + (b * b)).ToString("F3");
            }
            //출력
            Console.WriteLine($"Triangle #{i}\n{ans}\n");
        }
    }
}
