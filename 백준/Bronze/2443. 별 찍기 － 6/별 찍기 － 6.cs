class Program
{
    static void Main()
    {
        //bj2443 /b3 /별찍기-6 /240702
        int num = int.Parse(Console.ReadLine());
        for(int i = num; i >= 1; i--)
        {
            //Console.Write(i);
            for(int j = num; j > i; j--) Console.Write(" ");
            for(int k =i*2; k > 1; k--) Console.Write("*");
            Console.WriteLine();
        }
    }
}