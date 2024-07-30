using System;
using System.Collections.Generic;

class SegmentTree
{
    const int MAXN = 100000;
    static int[] arr = new int[MAXN + 1];
    // (최소값, 최대값) 쌍을 저장하는 하나의 세그먼트 트리
    static List<(int min, int max)> tree;

    static void Init(int node, int start, int end)
    {
        if (start == end)
        {
            tree[node] = (arr[start], arr[start]);
            return;
        }
        
        int mid = (start + end) / 2;
        Init(node * 2, start, mid);
        Init(node * 2 + 1, mid + 1, end);
        
        tree[node] = (Math.Min(tree[node * 2].min, tree[node * 2 + 1].min),
                      Math.Max(tree[node * 2].max, tree[node * 2 + 1].max));
    }

    static (int min, int max) FindMinMax(int node, int start, int end, int left, int right)
    {
        if (left > end || right < start)
        {
            return (int.MaxValue, int.MinValue);
        }
        
        if (left <= start && end <= right)
        {
            return tree[node];
        }
        
        int mid = (start + end) / 2;
        var leftResult = FindMinMax(node * 2, start, mid, left, right);
        var rightResult = FindMinMax(node * 2 + 1, mid + 1, end, left, right);
        
        return (Math.Min(leftResult.min, rightResult.min),
                Math.Max(leftResult.max, rightResult.max));
    }

    static void Main(string[] args)
    {
        using (StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())))
        using (StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
        {
            var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = input[0];
            int M = input[1];

            int h = (int)Math.Ceiling(Math.Log(N, 2));
            int treeSize = 1 << (h + 1);
            tree = new List<(int, int)>(new (int, int)[treeSize]);

            for (int i = 1; i <= N; i++)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }

            Init(1, 1, N);

            for (int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int left = input[0];
                int right = input[1];

                var result = FindMinMax(1, 1, N, left, right);
                sw.WriteLine($"{result.min} {result.max}");
            }

            sw.Flush();
        }
    }
}