using System;

class Class
{
    static void Main(string[] args)
    {
        //bj29751 /b5 /삼각형 /240704
        //w*h/2 = area
        string[] line = Console.ReadLine().Split(" ");
        double area = double.Parse(line[0]) * double.Parse(line[1]) / 2;
        Console.WriteLine(area.ToString("0.0"));
        //Console.WriteLine(String.Format("{0:0.0}", area));
        //Console.WriteLine(Math.Round(area, 1)); //얘는 딱 맞아 떨어지면 .0이 안나와서 안됨
    }
}