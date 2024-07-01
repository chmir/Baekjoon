using System;

class Program
{
    static int count = 0;
    static int n;
    static int[] board = new int[15];

    // 유망한지 판단하는 함수
    static bool Promising(int cdx)
    {
        // 같은 열이면 안 되고, 대각선상에 있어서도 안 된다.
        for (int i = 0; i < cdx; i++)
        {
            if (board[cdx] == board[i] || Math.Abs(cdx - i) == Math.Abs(board[cdx] - board[i]))
            {
                return false;
            }
        }
        return true;
    }

    // nqueen 알고리즘 수행
    static void NQueen(int cdx)
    {
        // cdx가 마지막 행까지 수행하고 여기까지 오면, 찾기 완료
        if (cdx == n)
        {
            count++;
            return;
        }

        for (int i = 0; i < n; i++)
        {
            board[cdx] = i; // cdx번째 행, i번째 열에 queen을 놓아본다.
            // 이후 그 행에 둔 것에 대한 유망성을 판단한다.
            if (Promising(cdx)) // 그 자리에 두어도 괜찮았다면,
            {
                NQueen(cdx + 1); // 그 다음 행에 대해 퀸을 놓는 것을 해 본다.
            }
        }
    }

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        NQueen(0);
        Console.WriteLine(count);
    }
}
