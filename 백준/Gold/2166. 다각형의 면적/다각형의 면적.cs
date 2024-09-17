//bj2166 /g5 /다각형의 면적 /240908
//어떻게 공식 이름이 신발끈 공식? 
//대충 원리는 선분이 교차하지 않는 다각형을 삼각형으로 나눠서
//그 삼각형의 넓이를 합산하면 그것이 다각형의 넓이가 된다.
//세 점씩 계산해도 되는데, 그냥 2개씩 해도 됨

class Yung_Bae__Take_My_Love
{
    // 신발끈 공식을 사용하여 다각형의 면적을 계산하는 함수
    static decimal Solve(List<(long x, long y)> points)
    {
        decimal area = 0; // 면적을 저장할 변수 초기화
        int n = points.Count; // 다각형의 점의 개수

        // 신발끈 공식을 적용하여 좌표를 사용한 면적 계산
        // Area = 1/2 * abs(Σ(x_i * y_(i+1) - x_(i+1) * y_i))
        /*for (int i = 0; i < n; i++)
        {
            // 다음 좌표 j는 i+1이지만, 마지막 점의 경우 첫 번째 점과 이어야 하므로 % n을 사용
            int j = (i + 1) % n;

            // 신발끈 공식에서 x_i * y_(i+1) 부분과 x_(i+1) * y_i 부분을 계산하여 더하고 빼기
            area += (points[i].x * points[j].y) - (points[j].x * points[i].y);
        }*/
        // i는 1부터 시작하고 j는 i-1로 설정하여 첫 번째와 마지막 점을 연결
        for (int i = 1; i < n; i++)
        {
            int j = i - 1; // 이전 좌표 j는 i-1
            area += (points[i].x * points[j].y) - (points[j].x * points[i].y);
        }
        // 마지막 점과 첫 번째 점을 연결하여 면적을 계산
        area += (points[0].x * points[n - 1].y) - (points[n - 1].x * points[0].y);

        // 계산된 값의 절댓값을 취하고 2로 나누어 최종 면적을 반환
        // 면적은 절대값을 취해야 하며, 공식에 따라 2로 나눔
        return Math.Abs(area) / 2;
    }

    static void Main(string[] args)
    {
        // 다각형의 점의 개수를 입력받음
        int n = int.Parse(Console.ReadLine());

        // 좌표를 저장할 리스트, 튜플로 (x, y) 형태로 저장
        var points = new List<(long x, long y)>();

        // n개의 좌표를 입력받아 리스트에 저장
        for (int i = 0; i < n; i++)
        {
            // 공백으로 구분된 좌표를 입력받아 각 값을 long 타입으로 변환 후 튜플로 저장
            var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            points.Add((input[0], input[1])); // (x, y) 형태로 리스트에 추가
        }

        // 신발끈 공식으로 계산한 면적을 가져옴
        decimal answer = Solve(points);

        // 소수점 첫째 자리까지 반올림하여 출력
        // $"{answer:F1}"는 소수점 첫째 자리까지 포맷팅한 문자열을 반환
        Console.WriteLine($"{answer:F1}");
    }
}