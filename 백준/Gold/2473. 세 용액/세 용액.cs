//bj2473 /g3 /세 용액 /240917
//2467번, 2470번을 먼저 풀어봐야 조금 이해가 되는듯

class SAINT_PEPSI__ENJOY_YOURSELF
{
    static void Main()
    {
        // N 입력 받기
        int N = int.Parse(Console.ReadLine());

        // 용액의 특성값을 입력 받고 정수 배열로 변환
        string[] input = Console.ReadLine().Split();
        long[] numbers = new long[N];
        for (int i = 0; i < N; i++)
        {
            numbers[i] = long.Parse(input[i]);
        }

        // 용액의 특성값을 오름차순으로 정렬
        Array.Sort(numbers);

        // 결과를 저장할 변수 초기화
        long minAbsSum = long.MaxValue; // 최소 합의 절댓값을 저장
        long resultA = 0, resultB = 0, resultC = 0; // 결과 용액의 특성값

        // 배열을 순회하며 첫 번째 용액 고정
        for (int i = 0; i < N - 2; i++)
        {
            int left = i + 1;      // 두 번째 용액의 인덱스
            int right = N - 1;     // 세 번째 용액의 인덱스

            while (left < right)
            {
                // 세 용액의 합 계산
                // 용액의 값이 최대 10억까지여서 int(≈21억)로하면 범위 초과 될 수 있어 long사용
                long sum = numbers[i] + numbers[left] + numbers[right];

                // 합의 절댓값이 최소값보다 작으면 결과 업데이트
                if (Math.Abs(sum) < minAbsSum)
                {
                    minAbsSum = Math.Abs(sum);
                    resultA = numbers[i];
                    resultB = numbers[left];
                    resultC = numbers[right];

                    // 합이 0이면 최적의 해이므로 종료
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
                else if (sum > 0)
                {
                    right--;
                }
                else
                {
                    // sum == 0인 경우 이미 처리했으므로 break
                    break;
                }
            }

            // 합이 0이면 더 이상 탐색할 필요 없음
            if (minAbsSum == 0)
            {
                break;
            }
        }

        // 결과를 오름차순으로 정렬하여 출력
        long[] results = new long[] { resultA, resultB, resultC };
        Array.Sort(results);

        Console.WriteLine($"{results[0]} {results[1]} {results[2]}");
    }
}
