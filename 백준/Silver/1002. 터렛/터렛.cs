using System;

class Program
{
    static void Main()
    {
        int t, x1, y1, r1, x2, y2, r2, result;
        double distance, subtract;

        t = int.Parse(Console.ReadLine());

        while (t-- > 0)
        {
            var n = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            x1 = n[0];
            y1 = n[1];
            r1 = n[2];
            x2 = n[3];
            y2 = n[4];
            r2 = n[5];

            distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            subtract = r1 > r2 ? r1 - r2 : r2 - r1;

            if (distance == 0 && r1 == r2)
                result = -1;  // 두 원이 완전히 일치하는 경우
            else if (distance < r1 + r2 && subtract < distance)
                result = 2;  // 두 원의 교점이 2개일 경우
            else if (distance == r1 + r2 || distance == subtract)
                result = 1;  // 두 원의 교점이 1개일 경우
            else
                result = 0;  // 두 원의 교점이 없을 경우

            Console.WriteLine(result);
        }
    }
}