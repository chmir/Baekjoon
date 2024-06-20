using System;

class Program
{
    static void Main(string[] args)
    {
        //bj11651 /s5 /좌표 정렬하기 2 /240528
        //입출력용 스트림
        using var sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        //입력
        int n = int.Parse(sr.ReadLine());
        //x, y를 튜플 리스트 형태로 받겠음
        var list = new List<(int, int)>();
        //n개의 좌표를 입력받아 리스트에 추가
        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            list.Add((input[0], input[1])); //x, y
        }

        // y 좌표로 정렬하고, x좌표로 정렬 (y좌표가 같다면 x좌표 기준으로 오름차순 정렬)
        var sortList = list.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToList();
        //정렬된 리스트 순서대로 출력하기
        for (int i = 0; i < n; i++) sw.WriteLine($"{sortList[i].Item1} {sortList[i].Item2}");

        sr.Close();
        sw.Close();
    }
}