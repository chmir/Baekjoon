

class SUI_UZI__LISA
{
    //bj2309 /b1 /일곱난쟁이 /240813
    //7개의 수를 일일이 더해보며 알아내는 것 보다 
    //9개의 합을 미리 구해놓고,
    //그 중에서 2개의 수를 뺐을 때
    //100이 되는 걸 찾는 게 빠르지 않을까

    static void Main(string[] args)
    {
        int totalSum = 0; //아홉 난쟁이의 키
        int targetSum = 0; //제외될 두명의 난쟁이의 키
        int[] arr = new int[9];
        for (int i = 0; i < arr.Length; i++)
            totalSum += arr[i] = int.Parse(Console.ReadLine());
        //Console.WriteLine(totalSum);
        targetSum = totalSum - 100;
        //Console.WriteLine(targetSum);

        //마지막 인덱스는 j의 영역이므로 제외한다
        for(int i = 0; i < arr.Length - 1; i++)
        {
            //i, 그리고 i이전의 인덱스는 이미 셈했으므로 제외한다
            for(int j = i+1; j < arr.Length; j++)
            {
                //두 난쟁이의 키 합이 빼야할 키라면
                if (targetSum == (arr[i] + arr[j]))
                {
                    //나머지 일곱난쟁이를 출력한다
                    int[] result = new int[7];
                    int index = 0;

                    // 제외될 두 인덱스를 제외한 값을 result 배열에 저장
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            result[index++] = arr[k];
                        }
                    }

                    // 오름차순으로 정렬
                    Array.Sort(result);

                    // 정렬된 결과 출력
                    foreach (var value in result)
                    {
                        Console.WriteLine(value);
                    }

                    return; // 원하는 결과를 찾았으므로 프로그램 종료
                }
            }
        }
        
    }
}
