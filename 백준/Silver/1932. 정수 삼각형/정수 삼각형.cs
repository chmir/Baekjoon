using System;
using System.Text;
using System.IO;
 
class Program
{
    static int[,] triangle;
 
    static void Cal(int n)
    {
        
        for (int i = 1; i < n; i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if (j == 0)
                {
                    triangle[i, j] = triangle[i - 1, j] + triangle[i, j];
                }
                else if (j == i)
                {
                    triangle[i, j] = triangle[i - 1, j-1] + triangle[i, j];
                }
                else
                {
                    triangle[i, j] = Math.Max(triangle[i - 1, j - 1], triangle[i - 1, j]) + triangle[i, j];
                }
                    
            }
        }
        
        
    }
 
    static int max(int n)
    {
        int max_score = 0;
        for(int i = 0; i < n; i++)
        {
            max_score = Math.Max(triangle[n-1, i], max_score);
        }
        return max_score;
    }
 
    static void Main()
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder sb = new StringBuilder();
        int n = int.Parse(sr.ReadLine());
        triangle = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            var num = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for(int j = 0; j < num.Length; j++)
            {
                triangle[i, j] = num[j];
            }
        }
        Cal(n);
        sw.WriteLine(max(n));
        sr.Close();
        sw.Close(); 
    } 
}
