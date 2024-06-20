using System;

class Program
{
    static void Main()
    {
        //bj18185 /d5 /라면 사기 (Small) /240429
        //가능한 한번에 3개를 사도록 해야하고, 2개를 사는 경우와 1개를 사는 경우를 생각해야 함

        //공장의 수 입력 및 공장 배열 생성
        int n = int.Parse(Console.ReadLine()); //공장의 수 n
        int[] v = new int[n + 3]; //공장 위치, 배열 인덱스를 1부터 시작하기 위해 n+3으로 설정 (v[n+1], v[n+2]에 대한 접근 예외처리)
        //공장마다 라면수 입력
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 공장별 라면 수 입력 받기
        for (int i = 0; i < n; i++) v[i + 1] = input[i]; //인덱스 시작점 차이에 유의
        //연산시작
        int ans = 0; // 최소 비용을 저장할 변수
        int ramen = 0; // 구매 가능한 라면 갯수, 일일이 생성할 필요 없어보여서
        for (int i = 1; i <= n; i++)
        {
            if (v[i] == 0) continue; //0인 경우 다음으로 넘긴다
            //가능한 많은 라면을 구매해야 하기에, 2개나 3개를 구매할 상황을 먼저 가정함
            //1개인 경우의 예외가 없지 않나요? -> 셋중에 하나가 0이라면 Min()함수로 인해 0이되고,
            //어차피 0에 뭘 곱하든 0이기에 상관 없음
            //2개 패키지가 3개 패키지보다 많은 라면을 필요로 할 때
            if (v[i + 1] > v[i + 2])
            {
                //2개 패키지로 구매 가능한 최대 라면 수 (3개 패키지를 사야 할 수를 고려하고 셈한다)
                ramen = Math.Min(v[i], v[i + 1] - v[i + 2]);
                ans += 5 * ramen; // 2개 패키지 비용 적용
                v[i] -= ramen; //산 만큼 빼는 과정
                v[i + 1] -= ramen;
                //3개 패키지로 구매 가능한 최대 라면 수
                ramen = Math.Min(v[i], Math.Min(v[i + 1], v[i + 2]));
                ans += 7 * ramen; // 3개 패키지 비용 적용
                v[i] -= ramen; //산 만큼 빼는 과정
                v[i + 1] -= ramen;
                v[i + 2] -= ramen;
            }
            //3개 패키지가 2개 패키지보다 많은 라면을 필요로 할 때
            else
            {
                //3개 패키지로 구매 가능한 최대 라면 수 
                //ex: 0 2 2 2 0 이렇게 되어있다면 3개 패키지를 한번에 2개 사니까 ans = 7*2 = 14
                //그 후엔 0 0 0 0 0이 되므로 아래의 2개 패키지는 실행되지 않습니다.
                ramen = Math.Min(v[i], Math.Min(v[i + 1], v[i + 2]));
                ans += 7 * ramen; // 3개 패키지 비용 적용
                v[i] -= ramen;
                v[i + 1] -= ramen;
                v[i + 2] -= ramen;
                //2개 패키지로 구매 가능한 최대 라면 수
                ramen = Math.Min(v[i], v[i + 1]);
                ans += 5 * ramen; // 2개 패키지 비용 적용
                v[i] -= ramen;
                v[i + 1] -= ramen;
            }
            //남은 라면은 1개 패키지로 구매
            ans += 3 * v[i]; // 1개 패키지 비용 적용, 갯수를 굳이 뺄 필요는 없다
        }//for end
        Console.WriteLine(ans); // 최소 비용 출력
    }
}