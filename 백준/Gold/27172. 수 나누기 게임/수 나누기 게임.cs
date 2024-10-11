using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 플레이어 수 입력
        int N = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        int[] scores = new int[1000006];
        int[] cards = new int[1000006];

        // 두 번째 줄에서 한 줄에 공백으로 구분된 카드 넘버 입력
        string[] input = Console.ReadLine().Split();

        for (int i = 0; i < N; i++)
        {
            int temp = int.Parse(input[i]);

            numbers.Add(temp); // 각 플레이어의 카드 넘버 저장
            cards[temp] = 1; // 특정 플레이어가 해당 카드 넘버를 가지고 있는지 체크
        }

        // 에라토스테네스의 체 응용
        // 각 플레이어의 카드 넘버의 배수를 각각 체크하면서 해당 카드가 있다면, 결투
        for (int i = 0; i < N; i++)
        {
            // 해당 카드 넘버의 배수마다 탐색
            for (int j = numbers[i] * 2; j < 1000001; j += numbers[i])
            {
                // 해당 카드 넘버의 배수의 카드가 존재하면 결투
                if (cards[j] == 1)
                {
                    scores[numbers[i]]++;
                    scores[j]--;
                }
            }
        }

        // 각 플레이어의 점수 출력
        for (int i = 0; i < N; i++)
        {
            Console.Write(scores[numbers[i]] + " ");
        }
    }
}
