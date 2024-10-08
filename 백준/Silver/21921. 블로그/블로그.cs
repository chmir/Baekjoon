//bj21921 /s3 /블로그 /241008
//N개의 수 중에서 X 범위(합) 중 가장 큰 값을 찾아야함
//문제 풀이 방식이 투포인터와 달리 탐색하는 구간의 넓이가 고정되어있으며, 
//슬라이딩 윈도우 알고리즘이라고 불린다.
//가장 큰 범위가 여러개일 경우도 셈해야 하므로 카운팅 변수 추가

public class Program
{
    public static void Main()
    {
        // 첫 번째 줄을 읽어서 N과 X를 파싱합니다.
        string[] tokens = Console.ReadLine().Split(' ');
        int N = int.Parse(tokens[0]); // 전체 숫자의 개수 N
        int X = int.Parse(tokens[1]); // 슬라이딩 윈도우의 크기 X

        // 두 번째 줄을 읽어서 숫자 배열로 변환합니다.
        var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // 변수 초기화
        long curV = 0; // 현재 슬라이딩 윈도우의 합
        long maxV = 0; // 최대 합
        int maxC = 0;  // 최대 합을 가진 윈도우의 개수

        // 슬라이딩 윈도우를 사용하여 합을 계산합니다.
        for (int i = 0; i <= N - X; i++)
        {
            if (i == 0)
            {
                // 첫 번째 윈도우의 합을 계산합니다.
                for (int j = 0; j < X; j++)
                {
                    curV += arr[j];
                }
                maxV = curV; // 최대 합을 현재 합으로 초기화합니다.
                maxC = 1;    // 최대 합을 가진 윈도우의 개수를 1로 초기화합니다.
            }
            else
            {
                // 윈도우를 오른쪽으로 한 칸 이동합니다.
                // 이전 윈도우의 첫 번째 값을 빼고, 새로운 값을 더합니다.
                curV = curV - arr[i - 1] + arr[i + X - 1];

                // 현재 합이 최대 합과 같은 경우
                if (curV == maxV)
                {
                    maxC += 1; // 최대 합을 가진 윈도우의 개수를 증가시킵니다.
                }
                // 현재 합이 최대 합보다 큰 경우
                else if (curV > maxV)
                {
                    maxV = curV; // 최대 합을 현재 합으로 갱신합니다.
                    maxC = 1;    // 최대 합을 가진 윈도우의 개수를 1로 초기화합니다.
                }
            }
        }

        // 결과를 출력합니다.
        if (maxV == 0)
        {
            Console.WriteLine("SAD"); // 최대 합이 0인 경우 "SAD"를 출력합니다.
        }
        else
        {
            Console.WriteLine(maxV); // 최대 합을 출력합니다.
            Console.WriteLine(maxC); // 최대 합을 가진 윈도우의 개수를 출력합니다.
        }
    }
}