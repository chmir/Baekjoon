//bj28066 /s2 /타노스는 요세푸스가 밉다 /240722
//람쥐썬더
class Program
{
    static void Main()
    {
        // 입력을 읽어옵니다.
        string[] inputs = Console.ReadLine().Split(); // 한 줄의 입력을 공백으로 나누어 배열에 저장합니다.
        int N = int.Parse(inputs[0]); // 첫 번째 값 N을 정수로 변환합니다.
        int K = int.Parse(inputs[1]); // 두 번째 값 K를 정수로 변환합니다.

        // 큐를 초기화합니다.
        Queue<int> q = new Queue<int>(); // 정수를 저장할 큐를 생성합니다.
        for (int i = 1; i <= N; i++) q.Enqueue(i); // 1~N

        // 연산 시작
        while (q.Count > 1) //람쥐가 단 한마리만 남을 때 까지
        {
            int kp = q.Peek(); // 큐의 맨 앞 요소를 확인합니다. (이게 중요한듯)
            int itercnt = Math.Min(K, q.Count); // K와 현재 큐의 크기 중 작은 값을 선택합니다.
            // 남아있는 청설모가 K마리보다 적으면
            // 첫번째 청설모를 제외한 모든 청설모가 하늘나라로 갑니다. 
            for (int i = 0; i < itercnt; i++) q.Dequeue();
            q.Enqueue(kp); // 확인했던 맨 앞 요소를 큐의 뒤에 추가합니다.
        }

        // 마지막 남은 다람이
        Console.WriteLine(q.Peek());
    }
}