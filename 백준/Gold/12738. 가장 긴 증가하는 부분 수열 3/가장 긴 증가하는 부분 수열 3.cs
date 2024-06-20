using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 문제: bj12738 /g2 /가장 긴 증가하는 부분 수열 3 /240505
        //12015보다는 받는 수가 더 커졌지만 int를 넘지는 않았다.
        //11053에서 풀었던 방식을 그대로 써도 맞지 않을까?

        int n = int.Parse(Console.ReadLine());  // 수열의 크기 입력 받기
        //List<int> vt =
        //[
        //    int.MinValue,  // 매우 작은 값으로 초기화하여 이분탐색에서 범위를 확장
        //];
        // 수열의 요소를 저장하는 리스트
        List<int> vt = new List<int>();
        vt.Add(int.MinValue);  // 매우 작은 값으로 초기화하여 이분탐색에서 범위를 확장

        // 두 번째 줄에 수열 입력 받기
        string[] inputs = Console.ReadLine().Split(' ');

        // 가장 긴 증가하는 부분 수열의 길이
        int ans = 0;

        // 수열의 각 요소를 확인하며 이분탐색으로 가장 긴 증가하는 부분 수열을 찾음
        for (int i = 0; i < n; i++)
        {
            int x = int.Parse(inputs[i]);  // 수열의 각 요소

            // 현재 요소가 수열의 마지막 요소보다 큰 경우
            if (vt[vt.Count - 1] < x)
            {
                vt.Add(x);  // 수열에 추가하고
                ans++;      // 부분 수열의 길이 증가
            }
            else //크지 않다면
            {
                // 이진 탐색을 사용하여 적절한 위치를 찾고 값을 업데이트
                int index = vt.BinarySearch(x); // 해당 값의 인덱스 위치를 반환해줌
                //Console.WriteLine($"1:{index}/{x}");
                // BinarySearch는 찾지 못했을 때 음수 값(~index)을 반환
                if (index < 0) index = ~index;
                //Console.WriteLine($"2:{index}/{x}");
                vt[index] = x;  // 해당 위치에 값을 업데이트하여 가장 긴 증가하는 부분 수열을 구성
            }
        }

        // vt 리스트의 첫번째 요소로 int.MinValue를 넣었기에 -1을 해줘야 함
        Console.WriteLine(vt.Count - 1);
        //foreach(int i in vt) { Console.WriteLine(i); }
    }
}
//10, 20, 10, 30, 20, 50인 경우
//1. 리스트를 생성할 때, int에서 담을 수 있는 가장 작은 값을 넣는다.
//vt[int.MinValue]
//2. 첫번째 값 10은 비교할 값이 없으므로 10을 넣는다.
//vt[int.MinValue,10]
//3. 두번째 값 20은 리스트의 마지막 값인 10보다 크므로 그냥 추가되고, ans++ 
//vt[int.MinValue,10,20]
//4. 세번째 값 10은 20보다 작으니까 리스트 안에서 적절한 위치를 찾아 그 위치에 값을 업뎃
//vt[int.MinValue,10,20]
//5. 그 뒤도 이전의 방식대로 수행하여 리스트에는 최종적으로 아래의 값이 남는다. 
//vt[int.MinValue,10,20,30,50]
//살짝 이해가 안됐던 부분은 1,5,6,3,7의 수열의 LIS가 1,3,6,7 이 된다는 점이다. 
//물론 길이상으로 1 5 6 7도 맞을 것이다. 하지만 실제 주어진 수열에서 순서가 어떻게 되는 상관이 없다는 점이
//가장 이해할 수 없는 문제였다. 오른쪽으로 쭉 올라가는 게 맞지 않나? 음... 뭐 나중에 다시 생각해보자. 