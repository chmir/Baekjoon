//bj1644 /g3 /소수의 연속합 /240917

class コンピュータサイバー魂﻿PC86__OPEN_UP_YOUR_HEART
{
    static void Main()
    {
        // N 입력 받기
        int N = int.Parse(Console.ReadLine());

        // N 이하의 모든 소수를 구함
        List<int> primes = GetPrimesUpToN(N);

        // 경우의 수를 저장할 변수
        int count = 0;

        // 투 포인터를 위한 변수 초기화
        int start = 0, end = 0, sum = 0;

        // 투 포인터 알고리즘 시작
        while (true)
        {
            // 현재 부분 합이 N과 같거나 크면
            if (sum >= N)
            {
                // N과 같으면 경우의 수 증가
                if (sum == N)
                {
                    count++;
                }
                // sum에서 primes[start]를 빼고 start를 증가시켜 부분 합을 줄임
                sum -= primes[start];
                start++;
            }
            // end가 리스트 범위를 넘어가면 종료
            else if (end == primes.Count)
            {
                break;
            }
            // 현재 부분 합이 N보다 작으면
            else
            {
                // sum에 primes[end]를 더하고 end를 증가시켜 부분 합을 키움
                sum += primes[end];
                end++;
            }
        }

        // 결과 출력
        Console.WriteLine(count);
    }

    // 에라토스테네스의 체를 사용하여 N 이하의 소수를 구하는 함수
    static List<int> GetPrimesUpToN(int N)
    {
        // 인덱스가 숫자, 값이 해당 숫자가 소수인지 여부를 나타내는 배열
        bool[] isPrime = new bool[N + 1];

        // 처음에 모든 수를 소수로 가정하고 true로 설정
        for (int i = 2; i <= N; i++)
        {
            isPrime[i] = true;
        }

        // 2부터 시작하여 소수 판별
        for (int i = 2; i * i <= N; i++)
        {
            if (isPrime[i])
            {
                // i의 배수들을 소수가 아니라고 표시
                for (int j = i * i; j <= N; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        // 소수만을 저장할 리스트 생성
        List<int> primes = new List<int>();
        for (int i = 2; i <= N; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }
}
