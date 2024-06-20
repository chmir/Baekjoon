using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //bj18186 /d4 /라면 사기 (Large) /240502
        //240429의 응용문제, 달라진 건 거의 없고, 추가로 구매할 때 드는 비용만 생각하면 끝
        //1000000

        //n은 공장의 수, b는 한 개를 구매할 때의 가격, c는 추가 구매할 때의 가격
        int n, b, c;
        //answer는 최소 비용을 계산하여 저장
        long answer = 0;

        //입력: 첫 줄에는 공장의 수 n과 가격 b, c를 입력받는다. 
        var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        n = inputs[0]; //공장의 개수
        b = inputs[1]; //개별가
        c = inputs[2]; //추가가격
        //ㄴ라면을 살 수 있는 공장의 개수가 (1 < n)이라면 라면의 개가격은 개별가+추가가격*(n-1)이다.
        //공장의 개수, 아래 연산에서 +2까지 접근하고, 인덱스 1부터 시작하기에 +3
        var v = new long[n + 3];

        //입력: 두 번째 줄에서 각 공장별 라면의 수를 입력받아 배열에 저장한다. 
        var ramens = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int i = 0; i < n; i++) v[i + 1] = ramens[i];

        //연산
        //c가 b보다 작지 않다면 모든 라면을 개별적으로 구매하는 게 더 유리하다.
        if (b <= c)
        {
            for (int i = 1; i <= n; i++) answer += v[i] * b;
            Console.WriteLine(answer); //정답 출력 후
            return; // 프로그램을 조기 종료합니다.
        }
        //그렇지 않다면, 패키지 구매를 최대한 활용해야 유리하다. (낱개로 사지 않고 묶음으로 사기)
        for (int i = 1; i <= n; i++)
        {
            //만약 살 수 있는 라면이 없다면 Min연산에 의해 0을 곱하기 때문에 신경쓰지 않아도 됨 
            //2개 패키지가 3개 패키지보다 많은 라면을 필요로 할 때
            if (v[i + 1] > v[i + 2])
            {
                //2개 패키지 구매를 먼저 계산
                long count = Math.Min(v[i], v[i + 1] - v[i + 2]); //살 수 있는 개수
                answer += (b + c) * count; //2개 패키지 비용을 적용한다
                v[i] -= count;
                v[i + 1] -= count;

                //이후 3개 패키지 구매를 계산
                count = Math.Min(v[i], Math.Min(v[i + 1], v[i + 2]));
                answer += (b + 2 * c) * count; //3개 패키지 비용을 적용한다
                v[i] -= count;
                v[i + 1] -= count;
                v[i + 2] -= count;
            }
            else //반대의 경우
            {
                //3개 패키지 구매가 우선적으로 가능
                long count = Math.Min(v[i], Math.Min(v[i + 1], v[i + 2]));
                answer += (b + 2 * c) * count;
                v[i] -= count;
                v[i + 1] -= count;
                v[i + 2] -= count;

                //남은 라면은 2개 패키지로 구매
                count = Math.Min(v[i], v[i + 1]);
                answer += (b + c) * count;
                v[i] -= count;
                v[i + 1] -= count;
            }
            //마지막으로 남은 라면은 개별적으로 구매
            answer += b * v[i];
        }
        //최종 계산된 최소 비용을 출력
        Console.WriteLine(answer);
    }
}