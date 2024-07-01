/*
 * bj16953 /s2 /A → B /240701
 * 생각보다 어렵네... 1을 추가한다는 조건 때문에 이거는 
 * B에서부터 하나씩 변환해가는 게 더 빠르다고 판닪ㅁ
*/

class Program
{
    static void Main()
    {
        // 한 줄에 두 개의 정수를 입력받아 각각 a와 b에 저장
        var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int a = line[0];
        int b = line[1];

        // 결과 값을 저장할 변수 초기화 (초기 값은 1)
        int result = 1;

        // b가 a보다 클 때까지 반복 + b는 a보다 작을 수 없음
        while (b > a) 
        {
            // b가 2로 나누어 떨어지면 b를 2로 나누기
            if (b % 2 == 0)
            {
                b /= 2;
            }
            // b의 마지막 자리가 1이면, b에서 1을 빼고 10으로 나누기
            else if (b % 10 == 1)
            {
                b = (b - 1) / 10;
            }
            // 위 두 조건이 모두 해당되지 않으면 변환 불가로 결과를 -1로 설정하고 루프 종료
            else
            {
                result = -1;
                break;
            }
            // 변환 성공 시마다 결과 값을 1 증가
            result++;
        }
        // 결과 값을 콘솔에 출력 (b와 a가 같지 않다면 -1)
        Console.WriteLine(b != a ? -1 : result);
    }
}