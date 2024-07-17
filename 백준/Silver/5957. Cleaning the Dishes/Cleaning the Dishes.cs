using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 문제: 5957 / 난이도: S5 / 제목: Cleaning the Dishes / 날짜: 240718
        // 설명: Bessie와 Canmuu가 접시를 설거지하고, 말려야 합니다.
        // 접시는 세 가지 상태가 있습니다: 씻기지 않은 상태, 씻어서 젖은 상태, 완전히 말린 상태
        // 첫 줄에는 세척하고 건조해야 할 전체 접시의 개수 N이 주어집니다 (1 <= N <= 10,000).
        // 그 다음 줄부터는 명령어와 처리할 접시 수가 주어집니다.
        // 명령어 1 D는 Bessie가 접시 D개를 세척하는 것을 의미합니다.
        // 명령어 2 D는 Canmuu가 접시 D개를 건조하는 것을 의미합니다.

        // 입력 처리
        // 첫 번째 줄에서 N 값을 읽습니다.
        int N = int.Parse(Console.ReadLine());
        
        // 명령어를 저장할 리스트를 생성합니다.
        List<(int command, int count)> commands = new List<(int, int)>();

        // 입력을 한 줄씩 읽어가며 명령어와 접시 개수를 리스트에 추가합니다.
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            string[] parts = line.Split();
            int command = int.Parse(parts[0]);
            int count = int.Parse(parts[1]);
            commands.Add((command, count));
        }

        // 스택 생성
        // 더러운 접시를 저장할 스택입니다.
        Stack<int> dirtyStack = new Stack<int>();
        // 세척된 접시를 저장할 스택입니다.
        Stack<int> washedStack = new Stack<int>();
        // 건조된 접시를 저장할 스택입니다.
        Stack<int> driedStack = new Stack<int>();

        // 더러운 접시 스택을 초기화합니다 (N번 접시가 맨 아래, 1번 접시가 맨 위).
        for (int i = N; i >= 1; i--)
        {
            dirtyStack.Push(i);
        }

        // 명령어 처리
        foreach (var command in commands)
        {
            if (command.command == 1) // 세척 명령어인 경우
            {
                // 지정된 수만큼 접시를 세척합니다.
                for (int i = 0; i < command.count; i++)
                {
                    if (dirtyStack.Count > 0)
                    {
                        // 더러운 접시 스택에서 꺼내 세척된 접시 스택에 추가합니다.
                        washedStack.Push(dirtyStack.Pop());
                    }
                }
            }
            else if (command.command == 2) // 건조 명령어인 경우
            {
                // 지정된 수만큼 접시를 건조합니다.
                for (int i = 0; i < command.count; i++)
                {
                    if (washedStack.Count > 0)
                    {
                        // 세척된 접시 스택에서 꺼내 건조된 접시 스택에 추가합니다.
                        driedStack.Push(washedStack.Pop());
                    }
                }
            }
        }

        // 결과 출력
        // 건조된 접시 스택에서 접시를 하나씩 꺼내어 출력합니다.
        while (driedStack.Count > 0)
        {
            Console.WriteLine(driedStack.Pop());
        }
    }
}
