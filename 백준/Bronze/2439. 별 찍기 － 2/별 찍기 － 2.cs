using System;

public class HelloWorld
{
    public static void Main(string[] args)
    { 
        int N = int.Parse(Console.ReadLine());
        for(int i=0; i<N; i++){ //열
            for(int j=i+1; j<N; j++) Console.Write(" ");
            for(int k=0; k<i+1; k++) Console.Write("*");
            Console.Write("\n");
        }
        
    }
}