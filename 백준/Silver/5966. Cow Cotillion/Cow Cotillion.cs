//bj5966 /s4 /Cow Cotillion /240721
//음머~ 들은 항상 >< 이렇게 마주보며 인사해야한다
//마주보며 인사하는 소를 c라고 한다면 >c< 이 역시 마주보며 인사하는 거로 간주
//이런 문제를 많이 봤다면 예제 입출력만 봐도 대강 뭔지 알 거 같은 유형

//빠른입출력
StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
//횟수 입력
int N = int.Parse(sr.ReadLine());
while (N-- > 0)
{
    //음머
    Stack<bool> cows = new Stack<bool>();
    //0번 인덱스에 소들의 개수를 입력받았지만 쓸 필요가 없음
    foreach (char c in sr.ReadLine().Split(' ')[1])
    { 
        //열린경우
        if(c=='>') cows.Push(true);
        //닫힌경우
        if (c == '<')
        {
            //닫을 게 있는지 확인
            if(cows.Count > 0) cows.Pop();
            else
            {
                //닫을 게 없다면 틀림
                cows.Push(false); //임의의 값을 넣고 
                break; //반복 종료
            }
        }
    }
    //잔여 스택 확인
    sw.WriteLine(cows.Count == 0 ? "legal" : "illegal");
}
sw.Flush();
sw.Close();
sr.Close();