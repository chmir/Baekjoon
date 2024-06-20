using System;
using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program
{
    static void Main(string[] args)
    {
        //bj6588 /s1 /골드바흐의 추측 /240524
        //2보다 큰 모든 짝수는 두 소수의 합으로 나타낼 수 있다는 추측
        //이전에 9020으로 비슷한 문제를 풀었어서 조금만 달리하면 될듯
        //에라토스테네스의 체로 소수를 미리 구해놓고
        //n이 입력될 때마다 연산해주면 되지 않을까?
        //연산 방법은 n의 절반값부터 시작해서 1씩 내려간 수가 소수라면 
        //n에서 그 소수를 뺐을 때, 나머지 수도 소수인지를 판별하고 맞다면 출력한다.

        //입력 및 선언
        //입출력용 스트림
        using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n; //짝수가 입력될 변수
        bool found = false; //소수 찾았는지
        int t1; //골드바흐 파티션 확인용 변수
        int t2; //위와 같음

        /*에라토스테네스의 체*/
        //소수를 담을 배열 생성
        //int배열은 할당하지 않으면 0으로 초기화 된다.
        int[] arr = new int[1000001]; //0이 소수, 1이 합성수가 됨
        //소수를 출력하는 문제가 아니기에, 0과 1로 소수를 구분한다.
        //2부터 시작하여 소수가 아닌 수에 1를 저장한다.
        //선택된 수는 지우지 않고, 이미 지워진 수는 넘어간다. 
        for (int i = 2; i < 1000001; i++)
        {
            if (arr[i] == 1) continue; //지워진 수 건너띄기
                                       //지워진 수가 아니라면 i의 배수부터 출발하여 모든 배수를 지움
            for (int j = i * 2; j < 1000001; j += i) arr[j] = 1;
        }
        /*골드바흐 추측 연산*/
        //연산, 출력
        while(true)
        {
            //n입력, 0이라면 반복 종료
            if ((n = int.Parse(sr.ReadLine())) == 0) break;
            found = false; //아직 소수를 찾지 못했다 가정
            //절반값 부터 -- 감소하여 탐색.. 하려했는데 테스트 케이스를 보니까 뭔가 이상하다
            //2부터 절반값까지 올라가야 할 거 같다. 아니 굳이 절반값을 구할 필요도 없을거다.
            //그리고 두 소수의 합으로 n이 나오지 않는 경우도 추가해야 한다. (근데 정말 틀린 게 있을까?)
            for (int j = 2; j < n; j++)
            { //2까지 탐색
                t1 = j; //소수일까?
                t2 = n - j; //두번째 값도? 
                if (arr[t1] == 0 && arr[t2] == 0)
                { //소수라면?
                    found = true; //찾았다~
                    sw.WriteLine($"{n} = {t1} + {t2}"); //출력하고
                    break; //나간다. 
                }
            }
            if(!found) sw.WriteLine("Goldbach's conjecture is wrong.");
            /*
            //9020에서 푼 방식
            for (int j = n / 2; j > 1; j--)
            { //2까지 탐색
                t1 = j; //소수일까?
                t2 = n - j; //두번째 값도? 
                if (arr[t1] == 0 && arr[t2] == 0)
                { //소수라면?
                    sw.WriteLine($"{n} = {t1} + {t2}"); //출력하고
                    break; //나간다. 
                }
            }
            */
        }
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}