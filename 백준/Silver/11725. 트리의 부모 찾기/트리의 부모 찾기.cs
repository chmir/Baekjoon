using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // 각 노드의 연결 상태를 나타내는 인접 리스트
    static List<int>[] tree;
    // 각 노드의 부모 노드 정보를 저장하는 배열
    static int[] ParentNode;
    // 노드의 방문 여부를 체크하는 배열
    static bool[] isVisited;
    //부모노드를 찾는 dfs 재귀함수
    static void DFS(int _currentNode, int _parentNode)
    {
        isVisited[_currentNode] = true;  // 현재 노드를 방문 처리
        ParentNode[_currentNode] = _parentNode;  // 현재 노드의 부모 노드를 저장

        foreach (int connected in tree[_currentNode])  // 연결된 노드들을 순회
        {
            // 방문하지 않았다면 DFS 재귀 호출
            if (!isVisited[connected]) DFS(connected, _currentNode);
        }
    }
    static void Main()
    {
        //bj11725 /s2 /트리의 부모 찾기 /240503
        //그렇게 어려운 발상이 아닌데, 생각보다 머리가 돌아가지 않았다. 
        //그래프 관련 문제들을 풀었던 것들을 다시 돌아볼 필요가 보인다. 
        //복습을 생활화하자, 구현을 까먹은 부분을 다시 봐야할듯, 너무 성급했나 봐

        //빠른 입출력
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int N = int.Parse(sr.ReadLine());  // 노드의 개수 N을 입력받음
        tree = new List<int>[N + 1];  // 노드의 수 +1만큼 리스트 배열 생성
        ParentNode = new int[N + 1];  // 부모 정보를 저장할 배열 초기화
        isVisited = new bool[N + 1];  // 방문 정보를 저장할 배열 초기화
        int[] inputs;  // 입력 값을 임시로 저장할 배열
        //리스트 초기화
        for (int i = 0; i <= N; i++) tree[i] = new List<int>();
        //입력 및 간선 연결
        for (int i = 1; i < N; i++)
        {
            inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);  // 공백을 기준으로 입력받아 정수 배열로 변환
            tree[inputs[0]].Add(inputs[1]);  // 무방향 그래프이므로 양방향으로 연결
            tree[inputs[1]].Add(inputs[0]);  // 무방향 그래프이므로 양방향으로 연결
        }
        // 1번 노드를 루트로 가정하고 DFS 실행, 부모 노드를 0으로 설정
        DFS(1, 0);  
        // 결과 출력
        for (int i = 2; i <= N; i++) sw.WriteLine(ParentNode[i]); 
        //자원 해제
        sw.Close();
        sr.Close();
    }
}