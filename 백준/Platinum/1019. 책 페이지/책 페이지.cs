//bj1019 /p5 /책 페이지 /240917
//

class kissmenerdygirl__Hypnotic_Eyes
{
    static int[] counts = new int[10]; // 각 숫자(0~9)의 등장 횟수를 저장할 배열

    static void Main()
    {
        // N 입력 받기
        int N = int.Parse(Console.ReadLine());

        // 페이지 번호 범위 설정
        int start = 1;
        int end = N;
        int digit = 1; // 현재 자리수 (일의 자리부터 시작)

        while (start <= end)
        {
            // start의 일의 자리가 0이 될 때까지 처리
            while (start % 10 != 0 && start <= end)
            {
                CountDigits(start, digit);
                start++;
            }

            // end의 일의 자리가 9가 될 때까지 처리
            if (start > end)
                break;

            while (end % 10 != 9 && start <= end)
            {
                CountDigits(end, digit);
                end--;
            }

            // 10의 배수 구간에서 각 숫자의 등장 횟수 누적
            int count = (end / 10 - start / 10 + 1);
            for (int i = 0; i < 10; i++)
            {
                counts[i] += count * digit;
            }

            // 다음 자리수로 이동
            start /= 10;
            end /= 10;
            digit *= 10;
        }

        // 결과 출력
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{counts[i]} ");
        }
    }

    // 주어진 숫자 num에서 각 자리수의 등장 횟수를 counts 배열에 누적
    static void CountDigits(int num, int digit)
    {
        while (num > 0)
        {
            int d = (int)(num % 10);
            counts[d] += digit;
            num /= 10;
        }
    }
}
