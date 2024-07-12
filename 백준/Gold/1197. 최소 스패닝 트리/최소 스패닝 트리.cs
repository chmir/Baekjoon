using System;
using System.Collections.Generic;

class Program
{
    static int V, E;
    static List<(int, int, int)> edges = new List<(int, int, int)>();
    static int[] parent;

    static void Main()
    {
        // 첫 번째 줄에서 정점 수 V와 간선 수 E를 입력 받음
        var input = Console.ReadLine().Split();
        V = int.Parse(input[0]); // 정점 수
        E = int.Parse(input[1]); // 간선 수

        // E개의 간선을 입력 받음
        for (int i = 0; i < E; i++)
        {
            var edgeInput = Console.ReadLine().Split();
            int A = int.Parse(edgeInput[0]); // 시작 정점
            int B = int.Parse(edgeInput[1]); // 끝 정점
            int C = int.Parse(edgeInput[2]); // 가중치
            edges.Add((A, B, C)); // 간선 리스트에 추가
        }

        // 가중치 기준으로 오름차순 정렬
        edges.Sort((x, y) => x.Item3.CompareTo(y.Item3)); // 간선의 가중치 비교

        // Union-Find 자료구조 초기화
        parent = new int[V + 1];
        for (int i = 0; i <= V; i++)
        {
            parent[i] = i; // 초기에는 자기 자신을 부모로 설정
        }

        int answer = 0;
        foreach (var edge in edges)
        {
            int a = edge.Item1;
            int b = edge.Item2;
            int cost = edge.Item3;

            // 두 정점이 같은 부모를 가지지 않을 때 (사이클이 생기지 않을 때)
            if (!SameParent(a, b))
            {
                UnionParent(a, b); // 두 정점을 하나의 집합으로 합침
                answer += cost; // 간선의 가중치를 결과에 더함
            }
        }

        // 최종 결과 출력
        Console.WriteLine(answer);
    }

    // 주어진 정점의 부모를 찾는 함수 (경로 압축 포함)
    static int GetParent(int x)
    {
        if (parent[x] == x)
        {
            return x; // 자기 자신이 부모인 경우
        }
        return parent[x] = GetParent(parent[x]); // 부모를 재귀적으로 찾고 경로 압축
    }

    // 두 정점을 하나의 집합으로 합치는 함수
    static void UnionParent(int a, int b)
    {
        a = GetParent(a); // a의 부모 찾기
        b = GetParent(b); // b의 부모 찾기

        // 작은 쪽이 부모가 되도록 설정
        if (a < b)
        {
            parent[b] = a;
        }
        else
        {
            parent[a] = b;
        }
    }

    // 두 정점이 같은 부모를 가지는지 확인하는 함수
    static bool SameParent(int a, int b)
    {
        return GetParent(a) == GetParent(b);
    }
}
