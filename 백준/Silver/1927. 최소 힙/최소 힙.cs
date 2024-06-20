using System.Text;
//bj1927 /s2 /최소 힙 /240226
//힙 자료구조는 우선순위 큐 라고도 부른다, 
//어느 자료를 받고 가장 우선순위가 높은 자료를 순서대로 pop해준다. 
//힙은 트리의 구조를 가지며, 완전 이진트리를 만족하고 때에따라 포화 이진트리가 된다. 
//각 노드의 배열 인덱스상 위치는 자식노드의 위치 / 2 = 부모노드 
//부모노드의 위치 * 2 = 왼쪽 자식, 부모노드의 위치 * 2 + 1 = 오른쪽 자식노드이다. 
//최대힙 = max heap , 최소힙 = min heap 
 
//최소힙의 경우 기본으로 들어가는 값 0에대한 예외처리가 필요하다!!...
namespace Programs
{
    //최대힙 구현
    public class MaxHeap
    {
        int[] heap; //힙 구현용 배열
        public int size; //힙의 현재 크기
        //생성자
        public MaxHeap(int n)
        {
            heap = new int[n]; //인덱스가 1부터 시작함을 유의하여 생성할 것
            size = 0; //힙의 실재 크기는 아직 비어있으므로
        }
        //힙의 첫 삽입은 말단 노드에서 시작한다
        public void Push(int item)
        {
            //힙의 크기를 1 늘려 노드 위치를 바꾼다 
            //맨 처음엔 노드의 말단에서 시작한다
            int tempidx = ++size;
            //item이 부모노드보다 작다면 부모노드와 자식노드의 자리를 바꾼다.
            while (tempidx > 1 && item < heap[tempidx / 2])
            {
                heap[tempidx] = heap[tempidx / 2]; //부모노드의 값을 자식노드로 옮기고
                tempidx /= 2; //다음 연산을 위해 인덱스를 옮긴다
            }
            //정렬이 완료됐다면 삽입할 원소를 넣는다 
            heap[tempidx] = item;
        }
        //힙의 첫 삭제는 맨 첫번째 노드에서 시작한다.
        public int Pop()
        {
            int parent, child; //부모 자식노드 변수
            int temp; //값 이동간 임시변수
            parent = 1; //힙의 첫 삭제는 맨 첫번째 노드에서 시작한다
            int item = heap[parent]; //항상 맨 위의 값이 먼저 나갈 것
            heap[parent] = heap[size];//맨 뒤의 값을 맨 위로 놓고 정렬 시작
            //heap[size--] = 0; //이해는 안되지만 최소힙에서는 이 코드가 문제다
            //어차피 0으로 초기화 안해도 size 예외처리가 있으니 상관은 없지만 조금 찝찝하다...
            size--;//값이 빠졌음으로 힙의 사이즈가 1 줄었다. 

            //정렬 시작
            while (true)
            {
                if (parent * 2 > size)
                {
                    //heap[size + 1] = 0; //이전의 말단은 0으로 초기화, 굳이 안해도 되서 뺌
                    return item; //범위 예외처리
                }
                //부모노드의 자식노드 중 키 값이 더 작은 자식과 바꾼다
                child = heap[parent * 2] < heap[(parent * 2) + 1] ? parent * 2 : (parent * 2) + 1;
                //큰 자식노드의 키값과 부모노드의 키값을 비교해 
                //부모값이 자식값보다 작거나 같다면 반복 종료
                if (heap[parent] <= heap[child]) break;
                //부모값이 더 크다면 자식값과 바꾼다
                temp = heap[child]; //임시로 옮겨두고
                heap[child] = heap[parent]; //자식노드 위치에 부모노드 값을 넣고 
                heap[parent] = temp; //반대로 부모노드 위치에 자식노드 값을 넣는다.
                parent = child; //다음 노드로 이동
            }
            //정렬이 완료됐다면 값 리턴
            return item;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //빠른 입출력
            var sr = new System.IO.StreamReader(Console.OpenStandardInput());
            var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder(); //스트링빌더 생성
            MaxHeap heap = new MaxHeap(100001); //힙 생성... 100000이어도 되네? 왤까... 삽입만 하는 T가 없나?
            int n = int.Parse(sr.ReadLine()); //반복횟수
            int input; //입력
            while (n-- > 0)
            {
                input = int.Parse(sr.ReadLine());
                //삭제
                if (input == 0)
                {
                    //힙이 비면 0, 있다면 Pop
                    sb.Append(heap.size == 0 ? "0" : heap.Pop());
                    sb.AppendLine();//개행
                }
                //입력은 따로 출력 없음
                else
                {
                    heap.Push(input);
                }
            }
            //출력
            sw.Write(sb); //최대값을 순서대로
            sr.Close();
            sw.Flush();
            sw.Close();
        }
    }
}