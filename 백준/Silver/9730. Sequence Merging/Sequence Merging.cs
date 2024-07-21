//bj9730 /s1 /Sequence Merging /240722
//stack, greedy
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
        // 스택을 사용하여 수열의 원소를 저장
        Stack<int> stack = new Stack<int>();
        // 최소 비용을 저장할 변수
        int cost = 0;

        // 첫 번째 원소를 스택에 추가
        stack.Push(sequence[0]);

        // 두 번째 원소부터 수열의 끝까지 처리
        for (int i = 1; i < sequence.Length; i++)
        {
            // 스택이 비어있지 않고, 현재 원소보다 다음에 넣을 원소가 크거나 같다면...
            while (stack.Count > 0 && stack.Peek() <= sequence[i])
            {
                // 스택의 top 원소를 꺼냄 (결과를 사용하지 않으므로 버림)
                stack.Pop();
                // 스택이 비어있지 않다면, 스택의 새 top 원소와 현재 원소 중 작은 값을 비용에 더함
                if (stack.Count > 0)
                {
                    cost += Math.Min(stack.Peek(), sequence[i]);
                }
                // 스택이 비어있다면, 현재 원소를 비용에 더함
                else
                {
                    cost += sequence[i];
                }
            }
            // 현재 원소를 스택에 추가
            stack.Push(sequence[i]);
        }

        // 스택에 남아 있는 원소들에 대해 비용을 계산
        while (stack.Count > 1)
        {
            // 스택의 top 원소를 꺼냄 (결과를 사용하지 않으므로 버림)
            stack.Pop();
            // 남아 있는 스택의 원소를 비용에 더함
            cost += stack.Peek();
        }

        // 총 비용을 반환
        return cost;
    }
}