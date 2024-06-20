using System;
using System.Collections.Generic;

class Program
{
    //bj1043 /g4 /거짓말 / 240503
    //처음 풀어보는 Union Find (또는 Disjoint-Set) 문제
    //이걸 왜 쓰지? -> 지하철 노선도를 예시로,
    //시작역과 종착역의 호선이 다를 때, 내가 갈 역이랑 이어져 있는지 알아야 할 때 쓸 수 있다. 
    //예시로 이와 같은 집합이 있다 가정하자. (1,2), (2,3), (3,4), (5,6) 
    //1~4는 서로 연결돼 있으며 5,6은 별개의 집합이라고 할 수 있다. 
    //만약 내 시작역이 1인데 종착역이 6이라면 갈 수 없는 역이 될것이다. 
    //이를 단순히 bfs로 구해야 한다면 모든 연결된 요소를 방문해야하므로 
    //최악의 경우에 모든 요소를 한번씩 방문해야 한다. 따라서 시간 복잡도는 O(v+e)가 된다. (v:정점, e:간선)
    //유니온 파인드로 풀어낸다면 각 연결된 집합을 트리의 형태로 합치는 연산을 수행한다.
    //이 경우 모든 연결된 간선에 대해 유니온 연산을 수행한다. 
    //따라서 시간 복잡도는 O(e)가 된다.

    //union: 서로 다른 두 개의 집합을 하나의 집합으로 병합하는 연산
    //find: 하나의 원소가 어떤 집합에 속했는지를 판단하는 연산

    //각 집합(정점)의 부모를 저장하는 배열 
    //부모를 저장함으로써 트리 구조를 유지하며 각 집합을 표현
    static int FindP(int[] parent, int x)
    {
        //경로 압축 기법을 사용하여 Find 연산을 최적화한다. 
        //경로 압축: 부모를 찾을 때마다 부모를 최상위 부모로 설정하여 트리의 높이를 줄이는 방법
        if (x != parent[x])
            return parent[x] = FindP(parent, parent[x]); //경로 압축을 통해 부모를 최상위 부모로 설정
        else
            return parent[x]; //이미 최상위 부모일 경우 그대로 리턴
    }

    //두 집합을 합치는 연산
    static void Merge(int[] parent, int x, int y)
    {
        //각 원소의 부모 루트를 찾는다. 
        int px = FindP(parent, x);
        int py = FindP(parent, y);

        if (px != py)
        {
            //두 루트가 다르면 합집합을 수행합니다.
            //작은 번호의 집합을 큰 번호의 집합에 합칩니다.
            if (px < py)
                parent[py] = px;
            else
                parent[px] = py;
        }
    }

    static void Main(string[] args)
    {
        // 초기 입력 처리: 사람 수(n)과 파티 수(m)
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]); // 사람 수
        int m = int.Parse(input[1]); // 파티 수

        // 각 사람을 자기 자신을 대표자로 초기화
        int[] parent = new int[n + 1];
        for (int i = 0; i <= n; i++) parent[i] = i;

        // 진실을 아는 사람 수와 명단 입력 받기
        input = Console.ReadLine().Split();
        int knowTru = int.Parse(input[0]); // 진실을 아는 사람 수
        // 진실을 아는 사람들을 0번 집합에 포함시키기
        for (int i = 1; i <= knowTru; i++)
        {
            int temp = int.Parse(input[i]);
            parent[temp] = 0; // 0번 집합으로 분류
        }

        // 각 파티별 참석자 정보 저장
        List<List<int>> parties = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            input = Console.ReadLine().Split();
            int pNum = int.Parse(input[0]); // 파티에 오는 사람 수
            List<int> party = new List<int>();

            for (int j = 1; j <= pNum; j++)
            {
                int person = int.Parse(input[j]);
                party.Add(person); // 파티 참석자 명단에 추가
            }

            parties.Add(party); // 파티 리스트에 파티 추가
            for (int j = 1; j < pNum; j++)
            {
                Merge(parent, party[0], party[j]); // 파티 참석자들을 같은 그룹으로 합치기
            }
        }

        int answer = m; // 거짓말이 가능한 최대 파티수를 임시로 할당함

        // 진실을 아는 사람이 있는 파티는 거짓말을 할 수 없음
        foreach (var party in parties)
        {
            foreach (int person in party)
            {
                if (FindP(parent, person) == 0)
                {
                    answer--; // 진실을 아는 사람과 연결된 파티는 거짓말 할 수 없으므로 1 감소
                    break;
                }
            }
        }

        Console.WriteLine(answer); // 결과 출력
    }
}