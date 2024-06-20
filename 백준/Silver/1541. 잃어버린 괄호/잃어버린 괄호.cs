//bj1541 /s2 /잃어버린 괄호 /240222
//그리디, 문자열 문제
//-를 기준으로 입력받은 식을 나눠서 따로 전부 더해두고, 
//더한 값들을 다시 하나하나 빼면 이 식의 값은 최소가 된다. 
//5+10-2+5 라면 -> 15 - 7이 최소의 값이다.

//입력받은 식을 -기준으로 나눈 덧셈식
string[] plusarr = Console.ReadLine().Split('-');
//나눠질 값의 합들을 저장할 정수 배열
int[] sumarr = new int[plusarr.Length]; 
//-로 나눠진 만큼 반복
for (int i = 0; i<plusarr.Length; i++)
{
    int sum = 0; //합을 저장 할 변수
                    //하나하나 더하기 위해 한번 더 +를 기준으로 나눈다
    var nums = plusarr[i].Split('+');
    //더할 수가 2개 이상이면 하나하나 더해준다
    if (nums.Length > 1)
        for (int j = 0; j<nums.Length; j++)
            sum += int.Parse(nums[j]);
    else //더할 수가 하나 뿐이라면 그 수가 합이다
        sum = int.Parse(plusarr[i]);
    //지금 더해진 값을 나중에 빼기 위해 다시 저장한다.
    sumarr[i] = sum;
}
//첫번째 합을 기준으로
int result = sumarr[0];
//-로 나눠져있던 모든 합을 하나씩 빼준다
for (int i = 1; i < sumarr.Length; i++)
    result -= sumarr[i];
//그러면 그 값이 이 식에서 가장 최솟값이다. 
Console.WriteLine(result);