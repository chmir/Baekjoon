//bj1806 /g4 /부분합 /240917
//투포인터문제

class ミカヅキBIGWAVE__Kawaii_Dreamer
{
    static void Main()
    {
        // N과 S를 입력 받음
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]); // 수열의 길이
        int S = int.Parse(input[1]); // 목표 부분합

        // 수열을 입력 받음
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 투 포인터 및 변수 초기화
        int start = 0, end = 0; // 부분합의 시작과 끝 인덱스
        int sum = 0;            // 현재 부분합
        int minLength = N + 1;  // 최소 길이 (초기값은 최대 길이보다 크게 설정)

        // 투 포인터 알고리즘 시작
        while (true)
        {
            // 현재 부분합이 S 이상인 경우
            if (sum >= S)
            {
                // 현재 구간의 길이를 계산
                int currentLength = end - start;
                // 최소 길이를 업데이트
                if (currentLength < minLength)
                {
                    minLength = currentLength;
                }
                // 시작 인덱스의 값을 부분합에서 빼고 시작 인덱스 증가
                sum -= numbers[start];
                start++;
            }
            // end가 수열의 끝에 도달한 경우 반복문 종료
            else if (end == N)
            {
                break;
            }
            // 현재 부분합이 S 미만인 경우
            else
            {
                // 끝 인덱스의 값을 부분합에 더하고 끝 인덱스 증가
                sum += numbers[end];
                end++;
            }
        }

        // 결과 출력
        if (minLength == N + 1)
        {
            // 부분합이 S 이상인 구간이 없는 경우
            Console.WriteLine(0);
        }
        else
        {
            // 최소 길이 출력
            Console.WriteLine(minLength);
        }
    }
}