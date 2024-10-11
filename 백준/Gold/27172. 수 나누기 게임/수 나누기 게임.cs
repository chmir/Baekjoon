//bj27172 /g4 /수 나누기 게임 /241011
// 각 플레이어는 숫자가 적힌 카드를 가지고 있으며, 서로 배수를 기준으로 결투를 벌인다.
// 각 플레이어의 카드 번호가 주어졌을 때, 배수 관계를 통해 이길 수 있는 플레이어를 찾고 점수를 계산함
// 주어진 카드 번호를 기준으로 해당 카드의 배수에 다른 플레이어의 카드가 있는지 확인한 후, 승패를 결정한다.
// 배수는 어디까지 확인하냐면 주어진 카드 중 가장 큰 카드 이상은 비교할 카드가 없기에 배수가 넘어가면 반복 종료
// 이 문제는 풀이 방식이 쉬워서 편한듯, 입력받는 수가 좀 많으니 빠른 입출력 코드 사용하자.
using System.Text;

class Macross_82_99__Now_And_Forever
{
    static void Main(string[] args)
    {
        //빠른 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder sb = new StringBuilder();

        // 플레이어 수 입력
        int N = int.Parse(sr.ReadLine());

        // 공백으로 구분된 카드 번호를 배열로 변환
        int[] card = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        // 가장 큰 카드 번호 찾기
        int maxCard = card.Max(); //정수 배열은 Max메서드로 

        // 카드 존재 여부를 저장하는 배열
        bool[] dict = new bool[maxCard + 1];
        for (int i = 0; i < N; i++)
            dict[card[i]] = true;

        // 각 카드 번호별 점수를 저장할 배열
        int[] score = new int[maxCard + 1];

        // 결투 로직: 배수를 찾고 점수 계산
        for (int i = 0; i < N; i++) //모든 플레이이어가 한번씩 돌아가며...
        {
            int num = card[i];

            // num의 배수에 대해 탐색
            for (int j = 2; num * j <= maxCard; j++) //num의 2배 부터, 가장 큰 카드까지 하나씩 배수를 계산
            {
                if (dict[num * j]) //num으로 나눠지는 다른 플레이어의 카드가 있다면?
                {
                    score[num]++; //승리한 플레이어
                    score[num * j]--; //패배한 플레이어
                }
            }
        }

        // 각 플레이어의 점수를 StringBuilder에 저장
        for (int i = 0; i < N; i++)
            sb.Append(score[card[i]] + " ");

        // 출력
        sw.Write(sb.ToString().Trim());
        sw.Close();
        sr.Close();
    }
}