using System;

class Class
{
    static void Main(string[] args)
    {
        // bj9366 /b3 /삼각형 분류 /240708
        // 예외: 가장 큰 변의 길이는 나머지 두변의 길이의 합보다 작다
        // 정삼각형: a == b == c
        // 이등변 삼각형: a == b or a == c or b == c
        // 부등변 삼각형: a != b != c

        // 테스트케이스 입력
        int t = int.Parse(Console.ReadLine());
        // 그만큼 반복
        for (int i = 1; i <= t; i++)
        {
            string ans = "invalid!"; //삼각형 여부
            //3개의 변 입력
            var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int c = line[2];

            // 삼각형이 될 수 있는지 확인
            if (a + b > c && a + c > b && b + c > a)
            {
                // 정삼각형인지 확인
                if (a == b && b == c)
                    ans = "equilateral";
                // 이등변 삼각형인지 확인
                else if (a == b || a == c || b == c)
                    ans = "isosceles";
                // 부등변 삼각형인지 확인
                else
                    ans = "scalene";
            }
            //정답
            Console.WriteLine($"Case #{i}: {ans}");
        }
    }
}