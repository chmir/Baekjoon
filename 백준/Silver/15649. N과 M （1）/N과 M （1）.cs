/*
 * bj15649 /s3 /N과 M (1) /240701
 * 백트래킹을 사용하여 가능한 모든 수열을 생성..
 * 입력으로 N, M을 입력받고, N은 수열의 범위, M은 수열의 크기가 됨
 * 방문여부를 판단하기 위해 visited배열을 사용, 생성된 수열은 sequence에 저장
 * 이미 사용된 숫자는 재사용하지 않도록 한다. (유망성 검사)
*/

class Program
{
    const int MAX = 9; // 수열의 최대 크기
    static int N, M; // 두 입력값, N(수열의 범위), M(수열의 크기)
    static int[] sequence = new int[MAX]; // 생성된 수열을 저장할 배열
    static bool[] visited = new bool[MAX]; // dfs를 위한 방문 여부 배열

    static void Main()
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 입력값 읽기
        string[] inputs = sr.ReadLine().Split(); // 입력값을 공백으로 분리하여 배열에 저장
        N = int.Parse(inputs[0]); // 첫 번째 값을 N으로 변환하여 저장
        M = int.Parse(inputs[1]); // 두 번째 값을 M으로 변환하여 저장

        // DFS 호출
        dfs(0, sw); // DFS 함수 호출, 초기 cnt 값은 0

        // 스트림 정리
        sw.Flush(); // 출력 버퍼를 비우고 내용을 출력
        sw.Close(); // StreamWriter 닫기
        sr.Close(); // StreamReader 닫기
    }

    static void dfs(int cnt, StreamWriter sw)
    {
        if (cnt == M)  // 배열 크기가 최대 크기에 도달했을 때
        {
            for (int index = 0; index < M; index++)
                sw.Write(sequence[index] + " "); // 생성된 수열을 출력
            sw.WriteLine(); // 줄 바꿈
            return; // 함수 종료
        }
        else
        {
            for (int index = 1; index <= N; index++)
            {
                if (!visited[index]) // 현재 숫자가 방문되지 않았을 때 유망성 검사
                {
                    visited[index] = true; // 방문 표시 (이러면 다음 숫자는 겹치지 않음)
                    sequence[cnt] = index; // 현재 위치에 숫자 저장
                    dfs(cnt + 1, sw); // 재귀 호출, 다음 위치로 이동 
                    visited[index] = false; // 방문 표시 해제 (표시 해제해야 다음에 또 쓰겠지)
                }
            }
        }
    }
}