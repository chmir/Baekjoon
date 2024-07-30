using System;

class SegmentTree
{
    //bj2042 /g1 /구간 합 구하기 /240730
    //어느 구간의 범위를 구해야 하는데 값이 계속해서 변하는 경우에 세그먼트트리를 사용
    //단순히 시작지점부터 끝까지 더하는 방식으로는 시간복잡도가 O(N) 이라서 느리다.
    //그렇다고 미리 더해놓고 쓰는 방식도, 값이 수시로 바뀌니 할 수가 없다.
    //입력한 수열의 크기가 N이라고 하면, 세그먼트 트리는 4*N의 크기를 가진다
    //더 자세히 구하는 방식이 있지만 굳이 일일이 연산하는 것 보다 저렇게 어림하여 셈하는 게 더 빠름
    //예를들어 숫자 1 2 3 4가 있다고 가정하면, 1 2를 더한 3, 3 4를 더한 7, 그리고 3 7을 더한 10 이렇게 저장해놓고
    //1이 5로 바뀐 경우에, 단순히 누적합을 배열에 일일이 저장하는 방식을 사용했다면 전부다 초기화해야했지만
    //이 경우 1과 2를 더한 3만 변경하여 7로 바꾸고, 3과 7을 더했던 10만 변경하여 7+7  = 14로 변경한다
    //예시가 단순히 4개일 뿐인지라 별 차이가 없어보이지만, 세그먼트트리의 시간복잡도는 O(logN) 으로
    //수열의 길이가 커질수록 더 효율적으로 사용이 가능함을 알 수 있다. 
    //세그먼트 트리는 포화이진트리의 형태를 가진다. 무조건 자식노드가 2개, 0개인 경우밖에 없다. 
    //부모노드부터 보았을 때, 범위를 계속 반절씩 나눠서 값을 저장하기 때문이다. 
    //대략적인구현 방법은 아래의 코드를 참고

    //기본적으로 필요한 배열 두가지
    static long[] num;   // 원래 숫자들을 저장할 배열
    static long[] seg_tree;  // 세그먼트 트리를 저장할 배열

    // 세그먼트 트리 만들기
    //인덱스는 0이 아니라 1부터 시작, 자식노드 계산을 편하게 하기 위해서
    //메서드 시작은 부모부터 시작하지만, 값이 할당되는 건 자식노드부터 위로 올라가는 느낌
    //메서드의 작동 원리가 stack과 유사하니 그걸 생각하면서 머릿속에 그리면 될듯
    //입력받은 num 수열의 인덱스는 0부터 시작함을 유의
    static long BuildTree(int idx, int left, int right) //시작은 1, 0, n-1
    {
        // 리프 노드인 경우 (더이상 자식노드가 나눠떨어지지 않는 경우)
        if (left == right)
        {
            seg_tree[idx] = num[left];
            return seg_tree[idx];
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        long left_value = BuildTree(2 * idx, left, mid);  // 왼쪽 서브트리 생성
        long right_value = BuildTree(2 * idx + 1, mid + 1, right);  // 오른쪽 서브트리 생성
        seg_tree[idx] = left_value + right_value;  // 현재 노드는 왼쪽과 오른쪽 서브트리의 합
        return seg_tree[idx];
    }

    // 세그먼트 트리로 구간 합 구하기
    // 만약 num이 0~7까지의 수열, 다시말해 8개의 숫자의 범위를 입력받아 세그트리를 생성했을 때...
    // num[2] ~ num[5]의 합을 구하려면 어떻게 해야 할까?
    // 부분적으로 겹치기 때문에 좌우 자식으로 재귀를 호출하여 연산하게 된다
    // 0~3 부터 나눠서 봄 -> 부분적으로 겹치니까 0~1과 2~3으로 나눠서 보기
    // 0~1은 2~5와 겹치지 않으니 패스
    // 2~3 전체가 2~5에 포함되므로 2~3의 합을 반환함 (왼쪽 서브트리의 합)
    // 다시 돌아와서 4~7은 부분적으로 겹치므로 4~5, 6~7로 나눠서 확인
    // 4~5 전체가 2~5에 포함되므로 4~5의 합을 반환함 (오른쪽 서브트리의 합)
    // 6~7은 아예 겹치지 않기 때문에 0 반환
    // 결과적으로 2~3과 4~5의 합을 더하여 2~5의 합을 구해낼 수 있게 됨
    static long FindTree(int start, int end, int idx, int left, int right) //b~c 구하려는 범위
    {
        // 범위 밖인 경우
        if (end < left || right < start)
        {
            return 0; //더하지 않는다
        }
        // 완전히 범위 안인 경우
        if (start <= left && right <= end)
        {
            return seg_tree[idx]; //그 합을 반환함
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        long left_value = FindTree(start, end, idx * 2, left, mid);  // 왼쪽 서브트리에서 구간 합 계산
        long right_value = FindTree(start, end, idx * 2 + 1, mid + 1, right);  // 오른쪽 서브트리에서 구간 합 계산
        return left_value + right_value;  // 두 서브트리의 합 반환
    }

    // 세그먼트 트리 값 업데이트
    // nodeIndex = 현재 세그먼트 트리 노드의 인덱스, 1부터 시작함
    // left, right = 현재 노드가 담당하는 배열 범위의 시작과 끝 인덱스
    // updateIndex = 업데이트할 배열 요소의 인덱스
    // newValue = updateIndex 위치에 새로 설정할 값
    // 대략적인 작동 방식은 FindTree와 비슷함
    // 부모노드부터 내려가면서... 
    // 리프노드면서 그 값이 updateIndex라면 해당 노드값을 새로 업데이트함
    // 업데이트 된 이후로는 다시 변경된 부분의 범위만 새로 값이 업데이트 될거임
    // 업데이트할 인덱스가 포함되지 않은 범위는 연산하지 않음으로써 최적화할 수 있다.
    // 예를들어 0~3의 범위가 있고 1번 인덱스를 변경한다면, 2~3의 범위는 연산하지 않는다. 
    static void UpdateTree(int nodeIndex, int left, int right, int updateIndex, long newValue)
    {
        // 리프 노드인 경우
        if (left == right && left == updateIndex)
        {
            seg_tree[nodeIndex] = newValue;
            return;
        }
        // 범위 밖인 경우
        if (updateIndex < left || right < updateIndex)
        {
            return;
        }
        int mid = (left + right) / 2;  // 중간 인덱스 계산
        UpdateTree(nodeIndex * 2, left, mid, updateIndex, newValue);  // 왼쪽 서브트리 업데이트
        UpdateTree(nodeIndex * 2 + 1, mid + 1, right, updateIndex, newValue);  // 오른쪽 서브트리 업데이트
        // 현재 노드는 왼쪽과 오른쪽 서브트리의 합
        seg_tree[nodeIndex] = seg_tree[nodeIndex * 2] + seg_tree[nodeIndex * 2 + 1];  
    }

    static void Main(string[] args)
    {
        // 입력과 출력을 위한 StreamReader와 StreamWriter 설정
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        // 첫 번째 줄 입력 받기
        var input = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        int n, m, k;  // n: 숫자의 개수, m: 수의 변경 횟수, k: 구간 합을 구하는 횟수
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
            //int a = (int)query[0];
            int b = (int)query[1];
            long c = query[2];
            if (query[0] == 1) //a == 1
            {
                UpdateTree(1, 0, n - 1, b - 1, c);  // 숫자 변경
            }
            else //a == 2
            {
                long s = FindTree(b - 1, (int)c - 1, 1, 0, n - 1);  // 구간 합 구하기
                sw.WriteLine(s);  // 결과 출력
            }
        }
        //출력 종료
        sw.Flush();
        sw.Close();
        sr.Close();
    }
}