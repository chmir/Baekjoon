using System;

class MainClass
{
    public static void Main(string[] args)
    {
        //bj31403 /b4 /A + B - C /240627
        //입력
        var lines = new string[3];
        for (int i = 0; i < 3; i++) lines[i] = Console.ReadLine();
        var arr = Array.ConvertAll(lines, int.Parse);
        //출력
        Console.Write(
            (arr[0] + arr[1] - arr[2]) //숫자의 경우
            + "\n" +
            (int.Parse(lines[0] + lines[1]) - arr[2]) //(문자+문자) - 숫자의 경우
        );
    }
}
