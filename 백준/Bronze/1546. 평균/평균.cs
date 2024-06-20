using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        //1546
         //첫쨰 줄에 시험 본 과목의 개수
        int n = int.Parse(Console.ReadLine());
 
        //둘째 줄에 세준이의 성적이 주어진다.
        string[] inputScore = Console.ReadLine().Split(' ');
        float[] score = Array.ConvertAll(inputScore, float.Parse);
 
        //자기 점수 중 최댓값을 골라내야한다.
        float maxScore = float.MinValue;
        for (int i = 0; i < n; i++)
        {
            if (maxScore < score[i])
            {
                maxScore = score[i];
            }
        }
 
        //새로운 평균을 구해야한다.
        // - 반복문을 돌면서 원래점수를 조작한점수로 변경해야한다.
        // - 조작한 점수를 모두 더한다.
        // - 모두 더해진 점수를 나누어서 새로운 평균을 만든다.
        float sum = 0;
        for (int i = 0; i < n; i++)
        {
            score[i] = (score[i] / maxScore) * 100;
            sum += score[i];
        }
        double scoreAverage = sum / n;
 
        //첫째 줄에 새로운 평균을 출력한다.
        Console.WriteLine("{0:#0.00####}", scoreAverage);
    }
}