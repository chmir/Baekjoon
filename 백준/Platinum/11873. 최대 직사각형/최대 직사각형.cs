using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n, m;
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
            if (n == 0 && m == 0) break;

            int result = 0;
            int[] heights = new int[m + 1]; // 높이 배열의 크기를 m + 1로 설정

            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    int x = int.Parse(row[j]);
                    heights[j] = (x == 1) ? heights[j] + 1 : 0;
                }

                Stack<int> stack = new Stack<int>();
                for (int j = 0; j <= m; j++) // 여기서 m까지 반복하여 마지막 높이를 처리
                {
                    while (stack.Count > 0 && heights[stack.Peek()] > heights[j])
                    {
                        int height = heights[stack.Pop()];
                        int width = (stack.Count == 0) ? j : j - stack.Peek() - 1;
                        result = Math.Max(result, height * width);
                    }
                    stack.Push(j);
                }
            }
            Console.WriteLine(result);
        }
    }
}
