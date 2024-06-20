using System.Text;
//bj11286 /s1 /절댓값 힙 /240308
//힙 자료구조는 우선순위 큐 라고도 부른다, 
//어느 자료를 받고 가장 우선순위가 높은 자료를 순서대로 pop해준다. 
//힙은 트리의 구조를 가지며, 완전 이진트리를 만족하고 때에따라 포화 이진트리가 된다. 
//각 노드의 배열 인덱스상 위치는 자식노드의 위치 / 2 = 부모노드 
//부모노드의 위치 * 2 = 왼쪽 자식, 부모노드의 위치 * 2 + 1 = 오른쪽 자식노드이다. 
//최대힙 = max heap , 최소힙 = min heap 
//이거 걍 넣거나 뺄 때 마다 절대값 비교 하면 되는 거 아닌교?
//아니 -1 > 1 음수가 더 우선순위인거는 내가 어캐알아 ;;; 
//ㅇㅎ 걍 음수 양수를 둘 다 받는구나
//이제 골치아프게 직접 구현 말고, C#에 구현돼 있는 힙을 써보자. 

namespace Programs
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stb = new StringBuilder(); //가변문자열
            int n = int.Parse(Console.ReadLine()); //입력 개수
            //우선순위큐는 기본적으로 최소힙의 형태를 가진다.
            //<int, int>로 받는 이유는 하나는 요소, 하나는 우선순위를 받아서 다르게 처리하기 위함
            //최대힙을 구현한다면 요소, -(요소) 를 입력받으면 된다. 
            //그러면 우선순위는 (1, -1) < (2, -2) < (3, -3)가 될 것이다...
            //또는 아래와 같은 옵션이 있다. 
            //var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            //양수
            PriorityQueue<int, int> plus = new PriorityQueue<int, int>();
            //음수
            PriorityQueue<int, int> minus = new PriorityQueue<int, int>();

            //n회 반복
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                //입력이 0이면 삭제
                if (num == 0)
                {
                    //양수와 음수가 힙 모두에 값이 있는 경우
                    if (minus.Count > 0 && plus.Count > 0)
                    {
                        //같은 절대값이면 음수가 우선이므로 (-1 > 1) 
                        //음수의 절댓값이 더 크면 양수꺼 출력
                        stb.Append(Math.Abs(minus.Peek()) > Math.Abs(plus.Peek()) ? plus.Dequeue() : minus.Dequeue()).Append("\n");
                    }
                    //음수만 값이 있으면 음수 힙 출력
                    else if (minus.Count > 0) stb.Append(minus.Dequeue()).Append("\n");
                    //양수만 값이 있으면 양수 힙 출력
                    else if (plus.Count > 0) stb.Append(plus.Dequeue()).Append("\n");
                    //둘다 없으면 0 출력
                    else stb.AppendLine("0");
                }
                //0 이외의 입력은 삽입임
                else 
                {
                    //양수면 양수에, 음수면 음수에 넣기
                    if (num > 0) plus.Enqueue(num, num);
                    else minus.Enqueue(num, Math.Abs(num));
                }
            }
            //정답
            Console.WriteLine(stb);
        }
    }
}