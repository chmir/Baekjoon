//bj9730 /s1 /Sequence Merging /240722
//주어진 수열을 하나의 원소로 줄이기 위한 최소비용을 구해야함

class Program
{
    static void Main(string[] args)
    {
        // 테스트 케이스 개수 입력
        int T = int.Parse(Console.ReadLine());
        for (int t = 1; t <= T; t++)
        {
            // 각 테스트 케이스의 수열 길이 입력 (필요없음)
            //int N = int.Parse(Console.ReadLine());
            Console.ReadLine();
            // 수열 입력
            int[] sequence = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            // 최소 비용 계산
            int result = CalculateMinCost(sequence);
            // 결과 출력
            Console.WriteLine($"Case #{t}: {result}");
        }
    }

    // 최소 비용 계산 함수
    static int CalculateMinCost(int[] sequence)
    {
        Stack<int> stack = new Stack<int>();
        int cost = 0; //최소비용

        // 첫 번째 원소를 스택에 추가
        stack.Push(sequence[0]);
        // 연산 시작
        for (int i = 1; i < sequence.Length; i++)
        {
            // 현재 원소를 스택의 top과 비교하여 더 큰 값을 top으로 설정
            while (stack.Count > 0 && stack.Peek() <= sequence[i])
            {
                int top = stack.Pop(); 
                if (stack.Count > 0)
                {
                    cost += Math.Min(stack.Peek(), sequence[i]);
                }
                else
                {
                    cost += sequence[i];
                }
            }
            stack.Push(sequence[i]);
        }

        // 스택에 남은 원소들에 대해 비용 계산
        while (stack.Count > 1)
        {
            int top = stack.Pop();
            cost += stack.Peek();
        }

        return cost;
    }
}
