using System;
using System.Collections.Generic;

class SegmentTree
{
    // N: 수열의 길이, M: 쿼리의 개수
    static int N, M;
    // MAXN: 수열의 최대 길이
    const int MAXN = 100000;
    // arr: 입력받은 수열을 저장하는 배열
    static int[] arr = new int[MAXN + 1];
    // minTree, maxTree: 각각 최소값과 최대값을 저장하는 세그먼트 트리
    static List<int> minTree, maxTree;

    // 세그먼트 트리 초기화 함수
    // node: 현재 노드 번호
    // start, end: 현재 노드가 담당하는 구간의 시작과 끝
    static void Init(int node, int start, int end)
    {
        // 리프 노드인 경우 (구간의 길이가 1인 경우)
        if (start == end)
        {
            // 해당 위치의 값을 최소값과 최대값으로 설정
            minTree[node] = maxTree[node] = arr[start];
            return;
        }
        else
        {
            int mid = (start + end) / 2;
            // 왼쪽 자식 노드 초기화 (node * 2)
            Init(node * 2, start, mid);
            // 오른쪽 자식 노드 초기화 (node * 2 + 1)
            Init(node * 2 + 1, mid + 1, end);
            // 현재 노드의 최소값과 최대값을 자식 노드들의 값을 이용해 계산
            minTree[node] = Math.Min(minTree[node * 2], minTree[node * 2 + 1]);
            maxTree[node] = Math.Max(maxTree[node * 2], maxTree[node * 2 + 1]);
        }
    }

    // 주어진 범위의 최소값과 최대값을 찾는 함수
    // node: 현재 노드 번호
    // start, end: 현재 노드가 담당하는 구간의 시작과 끝
    // left, right: 쿼리로 주어진 구간의 시작과 끝
    static (int, int) FindMinMax(int node, int start, int end, int left, int right)
    {
        // 범위를 완전히 벗어난 경우
        if (left > end || right < start)
        {
            // 최소값으로는 가능한 최대값을, 최대값으로는 가능한 최소값을 반환
            return (int.MaxValue, 0);
        }
        // 범위에 완전히 포함된 경우
        else if (left <= start && end <= right)
        {
            // 현재 노드의 최소값과 최대값을 반환
            return (minTree[node], maxTree[node]);
        }
        // 범위가 일부만 겹치는 경우
        else
        {
            int mid = (start + end) / 2;
            // 왼쪽 자식 노드에서 값을 찾음
            var leftResult = FindMinMax(node * 2, start, mid, left, right);
            // 오른쪽 자식 노드에서 값을 찾음
            var rightResult = FindMinMax(node * 2 + 1, mid + 1, end, left, right);
            // 왼쪽과 오른쪽 결과 중 최소값과 최대값을 선택하여 반환
            return (Math.Min(leftResult.Item1, rightResult.Item1),
                    Math.Max(leftResult.Item2, rightResult.Item2));
        }
    }

    static void Main(string[] args)
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        // 이는 입출력 속도를 향상시키기 위한 방법입니다.
        using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
        using (StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()))
        {
            // 첫 번째 줄 입력 처리
            var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            N = input[0]; // 수열의 크기
            M = input[1]; // 쿼리의 개수

            // 세그먼트 트리의 크기 계산
            // h: 트리의 높이, treeSize: 트리의 노드 개수
            int h = (int)Math.Ceiling(Math.Log(N, 2));
            int treeSize = 1 << (h + 1);
            // 최소값과 최대값을 저장할 세그먼트 트리 초기화
            minTree = new List<int>(new int[treeSize]);
            maxTree = new List<int>(new int[treeSize]);

            // 수열 입력 받기
            for (int i = 1; i <= N; i++)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }

            // 세그먼트 트리 초기화
            // 1번 노드부터 시작하여 전체 구간 [1, N]에 대해 초기화
            Init(1, 1, N);

            // 쿼리 처리
            for (int i = 0; i < M; i++)
            {
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int left = input[0];  // 쿼리 구간의 시작
                int right = input[1]; // 쿼리 구간의 끝

                // 최소값과 최대값 찾기
                // 1번 노드부터 시작하여 전체 구간 [1, N]에서 [left, right] 구간의 값을 찾음
                var result = FindMinMax(1, 1, N, left, right);
                // 결과 출력 (최소값, 최대값)
                sw.WriteLine($"{result.Item1} {result.Item2}");
            }

            // 버퍼에 남아있는 데이터를 모두 출력
            sw.Flush();
        }
    }
}