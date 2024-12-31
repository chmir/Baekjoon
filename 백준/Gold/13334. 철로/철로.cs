//bj13334 /g2 /철로 /240908
class Night_Tempo__Destiny
{
    static void Main()
    {
        // 사람 수 입력 받기
        int people_num = int.Parse(Console.ReadLine());
        // 좌표를 저장할 리스트
        var arr = new List<(int first, int second)>();

        // 사람들의 좌표 입력 및 처리
        for (int i = 0; i < people_num; ++i)
        {
            var input = Console.ReadLine().Split();
            int fr = int.Parse(input[0]);
            int se = int.Parse(input[1]);

            // 항상 첫 번째 값이 더 작도록 설정
            if (fr > se)
                (fr, se) = (se, fr);

            arr.Add((fr, se));
        }

        // 좌표를 끝점을 기준으로 정렬 (끝점이 같으면 시작점 기준으로 정렬)
        arr.Sort((a, b) =>
        {
            if (a.second == b.second)
                return a.first.CompareTo(b.first);
            return a.second.CompareTo(b.second);
        });

        // 철도의 길이를 입력 받음
        int rail_len = int.Parse(Console.ReadLine());

        // 최소 힙을 구현한 PriorityQueue (작은 값부터 우선순위)
        var min_pq = new PriorityQueue<int, int>();

        int max_result = 0;
        int include_cnt = 0;

        // 선분들을 순회하며 처리
        foreach (var person in arr)
        {
            int end = person.second;
            int start = end - rail_len;

            // 우선순위 큐에서 시작점이 철도의 범위를 벗어나면 제거
            while (min_pq.Count > 0 && min_pq.Peek() < start)
            {
                min_pq.Dequeue();
                --include_cnt;
            }

            // 철도의 범위 내에 속하는 시작점 추가
            if (person.first >= start)
            {
                min_pq.Enqueue(person.first, person.first); // 시작점을 우선순위 큐에 추가
                ++include_cnt;
                max_result = Math.Max(max_result, include_cnt);
            }
        }
        // 결과 출력
        Console.WriteLine(max_result);
    }
}