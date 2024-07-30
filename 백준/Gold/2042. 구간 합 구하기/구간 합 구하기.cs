using System;
using System.IO;
using System.Linq;

class SegmentTree
{
    static int n, m, k;  // n: 숫자의 개수, m: 수의 변경 횟수, k: 구간 합을 구하는 횟수
    static long[] num;   // 원래 숫자들을 저장할 배열
    static long[] seg_tree;  // 세그먼트 트리를 저장할 배열

    // 세그먼트 트리 만들기
    static long BuildTree(int x, int left, int right)
    {
        // 리프 노드인 경우
        if (left == right)
        {
            seg_tree[x] = num[left];
            return seg_tree[x];
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        long left_value = BuildTree(2 * x, left, mid);  // 왼쪽 서브트리 생성
        long right_value = BuildTree(2 * x + 1, mid + 1, right);  // 오른쪽 서브트리 생성
        seg_tree[x] = left_value + right_value;  // 현재 노드는 왼쪽과 오른쪽 서브트리의 합
        return seg_tree[x];
    }

    // 세그먼트 트리로 구간 합 구하기
    static long FindTree(int b, int c, int x, int left, int right)
    {
        // 범위 밖인 경우
        if (c < left || right < b)
        {
            return 0;
        }
        // 완전히 범위 안인 경우
        if (b <= left && right <= c)
        {
            return seg_tree[x];
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        long left_value = FindTree(b, c, x * 2, left, mid);  // 왼쪽 서브트리에서 구간 합 계산
        long right_value = FindTree(b, c, x * 2 + 1, mid + 1, right);  // 오른쪽 서브트리에서 구간 합 계산
        return left_value + right_value;  // 두 서브트리의 합 반환
    }

    // 세그먼트 트리 값 업데이트
    static void UpdateTree(int x, int left, int right, int idx, long val)
    {
        // 리프 노드인 경우
        if (left == right && left == idx)
        {
            seg_tree[x] = val;
            return;
        }
        // 범위 밖인 경우
        if (idx < left || right < idx)
        {
            return;
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        UpdateTree(x * 2, left, mid, idx, val);  // 왼쪽 서브트리 업데이트
        UpdateTree(x * 2 + 1, mid + 1, right, idx, val);  // 오른쪽 서브트리 업데이트
        seg_tree[x] = seg_tree[x * 2] + seg_tree[x * 2 + 1];  // 현재 노드는 왼쪽과 오른쪽 서브트리의 합
    }

    static void Main(string[] args)
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 첫 번째 줄 입력 받기
        var input = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        n = (int)input[0];  // 숫자의 개수
        m = (int)input[1];  // 수의 변경 횟수
        k = (int)input[2];  // 구간 합을 구하는 횟수

        num = new long[n];
        for (int i = 0; i < n; i++)
        {
            num[i] = long.Parse(sr.ReadLine());  // 숫자 입력 받기
        }

        seg_tree = new long[4 * n];  // 세그먼트 트리 배열 초기화
        BuildTree(1, 0, n - 1);  // 세그먼트 트리 생성

        for (int i = 0; i < m + k; i++)
        {
            var query = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);  // 쿼리 입력 받기
            int a = (int)query[0];
            int b = (int)query[1];
            long c = query[2];
            if (a == 1)
            {
                UpdateTree(1, 0, n - 1, b - 1, c);  // 숫자 변경
            }
            else
            {
                long s = FindTree(b - 1, (int)c - 1, 1, 0, n - 1);  // 구간 합 구하기
                sw.WriteLine(s);  // 결과 출력
            }
        }
        sw.Flush();  // 모든 출력을 플러시
    }
}
