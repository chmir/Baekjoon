using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static decimal Solve(List<(long x, long y)> points)
    {
        decimal area = 0;
        int n = points.Count;
        for (int i = 0; i < n; i++)
        {
            int j = (i + 1) % n;
            area += (points[i].x * points[j].y) - (points[j].x * points[i].y);
        }
        return Math.Abs(area) / 2;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var points = new List<(long x, long y)>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            points.Add((input[0], input[1]));
        }

        decimal answer = Solve(points);
        Console.WriteLine($"{answer:F1}");
    }
}