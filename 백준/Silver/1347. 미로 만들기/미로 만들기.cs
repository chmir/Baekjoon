using System;
using System.Text;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string S = Console.ReadLine();

        // If +1 : Turn Right, -1 : Turn Left
        int[] Dy = { -1, 0, 1, 0 };
        int[] Dx = { 0, 1, 0, -1 };
        char[,] V = new char[101, 101];
        for (int i = 0; i < 101; i++)
        {
            for (int j = 0; j < 101; j++)
            {
                V[i, j] = '#';
            }
        }

        int y = 50, x = 50, D = 2;
        int ey = 50, ex = 50, sy = 50, sx = 50;
        V[y, x] = '.';

        foreach (char ch in S)
        {
            if (ch == 'L')
            {
                D = (D + 3) % 4;
            }
            else if (ch == 'R')
            {
                D = (D + 1) % 4;
            }
            else
            {
                y += Dy[D];
                x += Dx[D];
                V[y, x] = '.';
                sy = Math.Min(sy, y);
                ey = Math.Max(ey, y);
                sx = Math.Min(sx, x);
                ex = Math.Max(ex, x);
            }
        }

        StringBuilder output = new StringBuilder();
        for (int i = sy; i <= ey; i++)
        {
            for (int j = sx; j <= ex; j++)
            {
                output.Append(V[i, j]);
            }
            output.AppendLine();
        }

        Console.Write(output.ToString());
    }
}