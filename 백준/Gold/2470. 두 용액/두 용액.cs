//bj2467 /g5 /용액 /240917
//2467번과 다른 점은 용액의 값들이 정렬되어있지 않다는 것

class Tim_Legend__soda_city_funk
{
    static void Main()
    {
        // N 입력 받기
        int N = int.Parse(Console.ReadLine());

        // 용액의 특성값을 입력 받고 정수 배열로 변환
        string[] input = Console.ReadLine().Split();
        int[] numbers = new int[N];
        for (int i = 0; i < N; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        // 용액의 특성값을 오름차순으로 정렬
        Array.Sort(numbers);

        // 투 포인터 및 결과를 저장할 변수 초기화
        int left = 0;                  // 시작 인덱스
        int right = N - 1;             // 끝 인덱스
        int minAbsSum = int.MaxValue;  // 최소 합의 절댓값을 저장
        int resultLeft = 0;            // 결과 용액의 첫 번째 값
        int resultRight = 0;           // 결과 용액의 두 번째 값

        // 투 포인터 알고리즘 시작
        while (left < right)
        {
            int sum = numbers[left] + numbers[right]; // 현재 두 용액의 합
            int absSum = Math.Abs(sum);               // 합의 절댓값

            // 최소 합의 절댓값을 갱신하는 부분
            if (absSum < minAbsSum)
            {
                minAbsSum = absSum;
                resultLeft = numbers[left];
                resultRight = numbers[right];

                // 합이 0이면 최적이므로 반복 종료
                if (sum == 0)
                {
                    break;
                }
            }

            // 합이 0보다 작으면 left를 증가시켜 합을 증가시킴
            if (sum < 0)
            {
                left++;
            }
            // 합이 0보다 크면 right를 감소시켜 합을 감소시킴
            else
            {
                right--;
            }
        }

        // 결과 출력 (오름차순으로 출력)
        if (resultLeft < resultRight)
        {
            Console.WriteLine($"{resultLeft} {resultRight}");
        }
        else
        {
            Console.WriteLine($"{resultRight} {resultLeft}");
        }
    }
}
