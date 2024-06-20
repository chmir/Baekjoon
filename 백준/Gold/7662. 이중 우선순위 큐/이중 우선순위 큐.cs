using System.Text;
//bj7662 /g4 /이중 우선순위 큐 /240308
//문제의 뼈대를 챗지피티에게 부탁해봤는데, 결국 다듬는 건 내가 직접 해야하는듯
//처음에는 단순히 최대힙을 만들고
//size-- 연산을 하는 최소값 삭제 함수를 만들면 그만 아니야? 했는데
//최대힙은 최대값을 정확히 반환해줄 뿐, 뒤쪽의 최소값들은 순서대로 놓여있는 게 아니다. 
//최소힙도 똑같다, 아무튼 그렇게 쉽게 될리가 없으니 최소 최대힙 두개를 만들어 관리함.
//*이 문제 복습 꼭 필요하다, 다음에 좀 더 정리하자.

namespace BOJ
{
    // 최소 최대힙의 중복 멤버 최소화
    public class BasicHeap
    {
        protected int[] heap = new int[1000001]; // 힙을 저장할 배열, 인덱스 1부터 시작
        protected int size = 0;

        // 힙 크기 반환
        public int Count()
        {
            return size; // 힙의 크기 반환
        }

        // 우선순위 값 반환
        public int Peek()
        {
            if (size == 0) return 0; // 힙이 비어있으면 0 반환
            return heap[1]; // 힙의 첫 번째 요소(최솟값) 반환
        }
    }

    public class MinHeap : BasicHeap
    {
        // 값 삽입
        public void Push(int item)
        {
            int i = ++size; // 추가된 요소의 인덱스
            // 힙 속성을 유지하면서 새 요소를 올바른 위치로 이동
            while (i > 1)
            {
                int parent = i / 2; // 부모 노드의 인덱스
                if (heap[parent] <= item) break; // 힙 속성 만족 시 중단
                heap[i] = heap[parent]; // 부모 노드 값을 자식 노드로 이동
                i = parent; // 인덱스를 부모 노드로 업데이트
            }
            heap[i] = item; // 최종 위치에 새 요소 배치
        }

        // 값 제거
        public int Pop()
        {
            if (size == 0) return 0; // 힙이 비어있으면 0 반환
            int frontItem = heap[1]; // 힙의 첫 번째 요소(최솟값) 저장
            int temp = heap[size]; // 배열의 마지막 요소 저장
            heap[size--] = int.MaxValue; // 마지막 요소 제거

            int parent = 1; // 시작 위치는 루트 노드
            // 힙 속성을 유지하면서 재구성
            while (true)
            {
                int leftChild = parent * 2; // 왼쪽 자식 노드의 인덱스
                if (leftChild > size) break; // 자식 노드가 없으면 중단
                int rightChild = leftChild + 1; // 오른쪽 자식 노드의 인덱스
                int minChild = leftChild; // 최소 자식 노드의 인덱스를 왼쪽 자식으로 초기화
                // 오른쪽 자식이 존재하고 더 작으면 최소 자식을 오른쪽 자식으로 변경
                if (rightChild <= size && heap[rightChild] < heap[leftChild])
                {
                    minChild = rightChild;
                }

                if (heap[minChild] >= temp) break; // 힙 속성 만족 시 중단

                heap[parent] = heap[minChild]; // 최소 자식 노드 값을 부모 노드로 이동
                parent = minChild; // 인덱스를 최소 자식 노드로 업데이트
            }
            heap[parent] = temp; // 마지막 요소를 새 위치에 배치
            return frontItem; // 최솟값 반환
        }
    }

    public class MaxHeap : BasicHeap
    {
        // 값 삽입
        public void Push(int item)
        {
            int i = ++size; // 추가된 요소의 인덱스
            // 힙 속성을 유지하면서 새 요소를 올바른 위치로 이동
            while (i > 1)
            {
                int parent = i / 2; // 부모 노드의 인덱스
                if (heap[parent] >= item) break; // 힙 속성 만족 시 중단
                heap[i] = heap[parent]; // 부모 노드 값을 자식 노드로 이동
                i = parent; // 인덱스를 부모 노드로 업데이트
            }
            heap[i] = item; // 최종 위치에 새 요소 배치
        }

        // 값 제거
        public int Pop()
        {
            if (size == 0) return 0; // 힙이 비어있으면 0 반환
            int frontItem = heap[1]; // 힙의 첫 번째 요소(최댓값) 저장
            int temp = heap[size--]; // 배열의 마지막 요소 저장
            heap[size + 1] = int.MinValue; // 마지막 요소 제거

            int parent = 1; // 시작 위치는 루트 노드
            // 힙 속성을 유지하면서 재구성
            while (true)
            {
                int leftChild = parent * 2; // 왼쪽 자식 노드의 인덱스
                if (leftChild > size) break; // 자식 노드가 없으면 중단
                int rightChild = leftChild + 1; // 오른쪽 자식 노드의 인덱스
                int maxChild = leftChild; // 최대 자식 노드의 인덱스를 왼쪽 자식으로 초기화
                // 오른쪽 자식이 존재하고 더 크면 최대 자식을 오른쪽 자식으로 변경
                if (rightChild <= size && heap[rightChild] > heap[leftChild])
                {
                    maxChild = rightChild;
                }

                if (heap[maxChild] <= temp) break; // 힙 속성 만족 시 중단

                heap[parent] = heap[maxChild]; // 최대 자식 노드 값을 부모 노드로 이동
                parent = maxChild; // 인덱스를 최대 자식 노드로 업데이트
            }
            heap[parent] = temp; // 마지막 요소를 새 위치에 배치
            return frontItem; // 최댓값 반환
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 빠른 입출력을 위한 StreamReader와 StreamWriter 설정
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder(); // 결과를 저장할 StringBuilder
            int T = int.Parse(sr.ReadLine()); // 테스트 케이스 개수 읽기

            MinHeap minHeap = new MinHeap(); // 최소힙 생성
            MaxHeap maxHeap = new MaxHeap(); // 최대힙 생성

            // 테스트 케이스별로 반복 처리
            for (int t = 0; t < T; t++)
            {
                Dictionary<int, int> countMap = new Dictionary<int, int>(); // 삽입된 각 요소의 개수를 추적

                // 해당 케이스의 입력 개수 읽기
                int N = int.Parse(sr.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    // I ..., D ... 명령어 읽기
                    string[] tokens = sr.ReadLine().Split(' ');
                    string command = tokens[0];
                    int number = int.Parse(tokens[1]);
                    // I 명령어 처리: 요소 삽입
                    if (command == "I")
                    {
                        minHeap.Push(number);
                        maxHeap.Push(number);
                        if (countMap.ContainsKey(number)) countMap[number]++;
                        else countMap[number] = 1;
                    }
                    // D 명령어 처리: 요소 삭제
                    else if (command == "D")
                    {
                        if (number == 1) // 최댓값 삭제
                        {
                            // 유효한 최댓값을 찾을 때까지 반복
                            while (maxHeap.Count() > 0 && (!countMap.ContainsKey(maxHeap.Peek()) || countMap[maxHeap.Peek()] == 0))
                            {
                                maxHeap.Pop();
                            }
                            // 유효한 최댓값 삭제
                            if (maxHeap.Count() > 0)
                            {
                                int max = maxHeap.Pop();
                                countMap[max]--;
                            }
                        }
                        else if (number == -1) // 최솟값 삭제
                        {
                            // 유효한 최솟값을 찾을 때까지 반복
                            while (minHeap.Count() > 0 && (!countMap.ContainsKey(minHeap.Peek()) || countMap[minHeap.Peek()] == 0))
                            {
                                minHeap.Pop();
                            }
                            // 유효한 최솟값 삭제
                            if (minHeap.Count() > 0)
                            {
                                int min = minHeap.Pop();
                                countMap[min]--;
                            }
                        }
                    }
                }
                // 모든 명령 처리 후 유효한 최솟값과 최댓값 출력
                //최소힙에 남아있는 요소가 더는 없을 때 까지 반복한다. 
                //ㄴ 추가로 현재 최소힙의 최솟값이 countMap에 없거나 개수가 0이라면 이 요소는 유효하지 않으므로 무시한다.
                //이걸 굳이 하는 이유는? 최솟값과 최대값을 둘 다 같이 빼주면서 생기는 문제가 있기 때문....
                while (minHeap.Count() > 0 && (!countMap.ContainsKey(minHeap.Peek()) || countMap[minHeap.Peek()] == 0))
                {
                    minHeap.Pop();
                }
                while (maxHeap.Count() > 0 && (!countMap.ContainsKey(maxHeap.Peek()) || countMap[maxHeap.Peek()] == 0))
                {
                    maxHeap.Pop();
                }
                // 결과 문자열 생성
                if (minHeap.Count() == 0 || maxHeap.Count() == 0) sb.AppendLine("EMPTY");
                else sb.AppendLine($"{maxHeap.Peek()} {minHeap.Peek()}");
                // 사용된 힙 초기화
                minHeap = new MinHeap();
                maxHeap = new MaxHeap();
            }
            sw.WriteLine(sb.ToString());
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}