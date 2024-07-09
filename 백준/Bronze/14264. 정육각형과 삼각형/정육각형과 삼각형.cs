using System;

public class MainClass
{
    public static void Main(string[] args)
    {
        //bj14264 /b3 /정육각형과 삼각형 /240709
        //정육각형에 세 개의 겹치지 않는 대각선을 그린다면... 
        //정육각형의 각 꼭짓점 3개에 걸쳐서 정육각형 안에 있을 수 있는
        //가장 커다래보이는 삼각형이 그려진다. (가장 큰지는 정확히 모르겠지만 아마 가장 클듯)
        //커다란 삼각형 옆에 쪼끄미 삼각형 3개가 생기는데...
        //이 삼각형의 내각의 각도는 30 30 120
        //가장 긴 변의 길이를 구하려면 (0.5) * L * L * sin(120도)
        //sin(120)은 2분의 3루트가 된다. 
        //0.5 * L * L * 루트3 / 2
        //L * L * 루트3 /4 
        //어지럽넹... 맞겠지? 아님말고 

        // 입력 값 L을 읽습니다.
        double L = double.Parse(Console.ReadLine());

        // 주어진 공식을 사용하여 결과를 계산합니다.
        double result = L * L * Math.Sqrt(3) / 4;

        // 결과를 소수점 10자리까지 출력합니다. <- 근데 아마 없어도 되지 않을까
        Console.WriteLine(result.ToString("F10"));
    }
}
