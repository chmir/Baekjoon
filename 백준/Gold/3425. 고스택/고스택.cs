namespace bj3425
{
    //bj3425 /g4 /고스택 /240424
    //문제 이해를 못해서 고스택 클래스만 만들고 구현부에서 헤맨 문제
    //기기를 입력받는 T1의 개수는 사용자가 "QUIT"를 입력하기 전까지 개수제한이 없다고 생각하자
    //각 기기마다 수행을 입력받는 T2의 개수는 100,000개 까지, 각 스택에는 1,000개 이상의 수를 받지 않는다.
    //초기값인 숫자 T3의 개수는 10,000까지이고, 각 숫자 마다 별개의 케이스임을 감안하고 봐야합니다. 
    //예를들어 하나의 기기 안에 3개의 T3가 있고, 각자 1, 10, 50이라면 각 숫자마다의 초기값을 시작으로 
    //이번 T1안의 모든 명령을 차례대로 돌아보면서, 오류가 나지 않는다면 결과를, 오류가 났다면 ERROR하고 다음으로 넘어가기
    // 에러가 발생할 수 있는 조건들:
    // 1. 스택에 숫자가 부족하여 연산을 수행할 수 없을 때
    // 2. DIV, MOD 연산에서 0으로 나눴을 때
    // 3. 연산 결과의 절댓값이 10^9를 넘어갈 때
    // 4. 각 연산을 마친 후, 스택에 남은 숫자가 1개가 아닐 때

    public class Gostack
    {
        public Stack<int> stack;
        const int Max = 1000000000; // 최대 허용 값은 10^9
        public Gostack(int initial)
        {
            stack = new Stack<int>();
            stack.Push(initial);
        }
        //커맨드 집합
        public void ExecuteCommand(string command)
        {
            if (command.StartsWith("NUM")) //값넣기
            {
                int x = int.Parse(command.Split(' ')[1]);
                if (0 <= x && x <= Max) stack.Push(x);
                else throw new Exception(); //조건을 벗어나면 예외 발생
            }
            else if (command == "POP") //값 빼기
            {
                if (stack.Count > 0) stack.Pop();
                else throw new Exception();
            }
            else if (command == "INV") //최상위 값을 음수로
            {
                if (stack.Count > 0) stack.Push(-stack.Pop());
                else throw new Exception();
            }
            else if (command == "DUP") //최상위 값을 복사하여 push
            {
                if (stack.Count > 0) stack.Push(stack.Peek());
                else throw new Exception();
            }
            else if (command == "SWP") //최상위의 두 값을 서로 스왑
            {
                if (stack.Count >= 2)
                {
                    int first = stack.Pop();
                    int second = stack.Pop();
                    stack.Push(first);
                    stack.Push(second);
                }
                else throw new Exception();
            }
            else if (command == "ADD") //최상위의 두 값을 더함
            {
                if (stack.Count >= 2)
                {
                    int first = stack.Pop();
                    int second = stack.Pop();
                    int result = first + second;
                    if (result > Max) throw new Exception();
                    stack.Push(result);
                }
                else throw new Exception();
            }
            else if (command == "SUB") //두번째 최상위 값에서 최상위 값을 뺀다
            {
                if (stack.Count >= 2)
                {
                    int first = stack.Pop();
                    int second = stack.Pop();
                    int result = second - first;
                    if (Math.Abs(result) > Max) throw new Exception();
                    stack.Push(result);
                }
                else throw new Exception();
            }
            else if (command == "MUL") //두 값 곱하기
            {
                if (stack.Count >= 2)
                {
                    long first = stack.Pop();
                    long second = stack.Pop();
                    long result = first * second;
                    if (Math.Abs(result) > Max) throw new Exception();
                    stack.Push((int)result);
                }
                else throw new Exception();
            }
            else if (command == "DIV") //나누기
            {
                if (stack.Count >= 2)
                {
                    int first = stack.Pop();
                    int second = stack.Pop();
                    if (first == 0) throw new Exception();
                    //^ 연산자는 XOR연산자임, 둘 중 하나만 참일때만 참을 반환한다.
                    //둘 다 음수거나, 둘 다 양수면 first에 * 1을 곱한다 (양수)
                    //둘 중 하나는 음수, 하나는 양수로 나뉜다면 first에 * -1을 곱한다 (음수)
                    //우선 절댓값으로 나눈 다음에 부호를 정하는 방식으로 했습니다.
                    int result = Math.Abs(second) / Math.Abs(first) * (second < 0 ^ first < 0 ? -1 : 1);
                    stack.Push(result);
                }
                else throw new Exception();
            }
            else if (command == "MOD") //나머지
            {
                if (stack.Count >= 2)
                {
                    int first = stack.Pop();
                    int second = stack.Pop();
                    if (first == 0) throw new Exception();
                    int result = Math.Abs(second) % Math.Abs(first);
                    //나머지 부호는 나누어지는 수의 부호에 의해 결정된다.
                    if (second < 0) result = -result;
                    stack.Push(result);
                }
                else throw new Exception();
            }
        }
    }
    //명령어 입력 및 실행 클래스
    public class CommandProcessor
    {
        List<string> commands = new List<string>(); //명령 리스트
        public bool IsQuitCommand = false; //함수 종료할지 여부
        //명령 입력
        public void LoadCommands(System.IO.StreamReader sr)
        {
            commands.Clear(); //명령 초기화
            string input;
            while ((input = sr.ReadLine()) != "END" && input != "QUIT")
            {
                commands.Add(input);
            }
            IsQuitCommand = (input == "QUIT"); //프로그램 종료 조건
        }
        //각 초기값에 따른 명령 실행
        public void ProcessCommands(int initial, System.IO.StreamWriter sw)
        {
            Gostack gostack = new Gostack(initial);
            try
            {
                foreach (var command in commands)
                {
                    gostack.ExecuteCommand(command);
                }
                //스택에 남은 값이 1개가 아니면 오류
                if (gostack.stack.Count == 1) sw.WriteLine(gostack.stack.Peek());
                else sw.WriteLine("ERROR");
            }
            catch //명령어 실행중에 오류남
            {
                sw.WriteLine("ERROR");
            }
        }
    }
    //메인
    class Program
    {
        static void Main(string[] args)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {//sr과 sw를 이 중괄호 안에서 쓰겠다.
                CommandProcessor processor = new CommandProcessor(); //명령어 클래스 생성
                while (true)
                {
                    processor.LoadCommands(sr); //명령입력
                    if (processor.IsQuitCommand) break; //quit 있으면 종료
                    //숫자(초기값) 입력 부
                    int T = int.Parse(sr.ReadLine()); //개수
                    for (int i = 0; i < T; i++) { processor.ProcessCommands(int.Parse(sr.ReadLine()), sw); }
                    sw.WriteLine(); // 각 기기 테스트 케이스 후에 빈 줄 출력
                }
            }//sw,sr 해제
        }
    }
}