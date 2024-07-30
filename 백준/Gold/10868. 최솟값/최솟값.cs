using System;
using System.Collections.Generic;
using System.IO;

class SegmentTree
{
    //bj10868 /g1 /최솟값 /240731
    //2357번 문제에서 단순히 최솟값만 출력하는 문제라서 조금 더 바꿔서 풀었음
    //2042처럼 단순히 구간합을 구하는 것 뿐만 아니라 
    //각 구간별로 최솟값이나 최댓값을 구해가면서 셈하는 방식도 가능하다
    //저번엔 배열로 세그먼트 트리를 구현했는데 트리로도 가능함. 
    //복습 필요, 많이 많이 필요

    // MAXN은 배열 arr의 최대 크기를 나타내며 100,000으로 설정
    const int MAXN = 100000;
    // 입력 배열을 저장하는 arr
    static int[] arr = new int[MAXN + 1];
    // 최솟값을 저장하는 세그먼트 트리
    static List<int> tree;

    // 세그먼트 트리 초기화 함수
    static void Init(int node, int start, int end)
    {
        // 리프 노드인 경우 배열의 해당 값을 세그먼트 트리에 저장
        if (start == end)
        {
            tree[node] = arr[start];
            return;
        }

        // 내부 노드인 경우 자식 노드들 초기화
        int mid = (start + end) / 2;
        Init(node * 2, start, mid);
        Init(node * 2 + 1, mid + 1, end);

        // 현재 노드의 값을 자식 노드들의 최소값으로 설정
        tree[node] = Math.Min(tree[node * 2], tree[node * 2 + 1]);
    }

    // 구간 [left, right]에서의 최소값을 찾는 함수
    static int FindMin(int node, int start, int end, int left, int right)
    {
        // 현재 노드의 구간이 [left, right]와 겹치지 않는 경우
        if (left > end || right < start)
        {
            // 영향을 주지 않도록 무한대를 반환
            return int.MaxValue;
        }

        // 현재 노드의 구간이 [left, right]에 완전히 포함되는 경우
        if (left <= start && end <= right)
        {
            return tree[node]; //그게 정답이거나, 정답의 일부분이다. 결국엔 좌 우의 정답을 구하게 된다.
        }

        // 현재 노드의 구간이 [left, right]와 일부만 겹치는 경우
        //좌우로 범위를 나눠서 다시 연산 (어차피 포함되지 않는 범위가 생긴다면 int.MaxValue가 반환되니 ㄱㅊ)
        int mid = (start + end) / 2;
        int leftResult = FindMin(node * 2, start, mid, left, right);
        int rightResult = FindMin(node * 2 + 1, mid + 1, end, left, right);

        // 자식 노드들의 결과를 병합하여 반환
        return Math.Min(leftResult, rightResult);
    }

    static void Main(string[] args)
    {
        // 입력과 출력을 위한 스트림 리더와 라이터를 사용
        using (StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput())))
        using (StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
        {
            // 첫 번째 줄에서 N (배열 크기)과 M (질의 수)를 읽음
            var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = input[0];
            int M = input[1];

            // 세그먼트 트리의 크기 계산 (2^h보다 큰 가장 작은 2의 제곱수)
            // 근데 굳이 이렇게는 잘 안하고 4*N하지 그냥
            //int h = (int)Math.Ceiling(Math.Log(N, 2));
            //int treeSize = 1 << (h + 1);
            //tree = new List<int>(new int[treeSize]);
            tree = new List<int>(new int[4*N]);

            // 배열의 값을 입력받아 저장
            for (int i = 1; i <= N; i++)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }

            // 세그먼트 트리 초기화
            Init(1, 1, N);

            // M개의 질의에 대해 최소값을 찾아 출력
            for (int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int left = input[0];
                int right = input[1];

                int result = FindMin(1, 1, N, left, right);
                sw.WriteLine(result);
            }

            // 출력 버퍼를 비움
            sw.Flush();
        }
    }
}