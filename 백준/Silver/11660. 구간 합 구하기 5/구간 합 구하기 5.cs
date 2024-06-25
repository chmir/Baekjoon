using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //좌에서 우로 누적되어야 하고, 상에서 하로 누적되어야 한다. 
        //올바르게 누적되기 위해선 이미 더한 대각선위치의 합을 빼야했다. 
        //그러기 위해선 합배열의 왼쪽라인, 윗쪽라인에 0
        //예를들어 1 2 3 / 4 5 6 / 7 8 9 가 있다고 치자. 이를 합배열로 하려면...
        // 위에는 1 3 6이 될 것이고 
        // 아래를 계산할 때, 첫번째는 5, 두번째가 12인데 12를 어떻게 셈하느냐
        //1 + 2 + 4 + 5 = 12가 나와야하는데 
        //
        //

        //입출력용 스트림
        using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 2차원 구간 합 배열을 선언합니다. 배열의 크기는 최대 1025 x 1025입니다.
        int[,] p_sum = new int[1025, 1025];

        // 첫 번째 입력 줄을 읽어 N과 M을 추출합니다.
        var firstLine = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int N = firstLine[0]; // N은 행렬의 크기입니다.
        int M = firstLine[1]; // M은 구간 합을 구해야 하는 횟수입니다.

        // 행렬을 읽고, 2차원 구간 합 배열을 계산합니다.
        for (int i = 1; i <= N; i++)
        {
            // 행렬의 각 행을 읽습니다.
            var line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 1; j <= N; j++)
            {
                // 구간 합 배열을 계산합니다.
                //p_sum[i - 1, j]: 바로 위쪽 행까지의 합
                //p_sum[i, j - 1]: 바로 왼쪽 열까지의 합
                //p_sum[i - 1, j - 1]: 중복으로 더해진 (i-1, j-1) 대각선 위치까지의 합을 빼주어야 합니다.
                //line[j - 1]: 현재 행의 j번째 원소
                p_sum[i, j] = p_sum[i - 1, j] + p_sum[i, j - 1] - p_sum[i - 1, j - 1] + line[j - 1];
            }
        }

        // 각 구간 합을 계산할 쿼리를 읽고 처리합니다.
        for (int i = 0; i < M; i++)
        {
            // 각 쿼리를 읽습니다.
            var query = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int y1 = query[0], x1 = query[1], y2 = query[2], x2 = query[3];

            // 구간 합을 계산합니다.
            int result = p_sum[y2, x2] - p_sum[y1 - 1, x2] - p_sum[y2, x1 - 1] + p_sum[y1 - 1, x1 - 1];
            // 결과를 출력합니다.
            sw.WriteLine(result);
        }
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}
