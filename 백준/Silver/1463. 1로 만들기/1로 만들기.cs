//bj1463 /s3 /1로 만들기 /240429
//메모이제이션, 바텀업 방식으로 풀이
//arr[1] = 0; arr[2] = arr[3] = 1;
//초기값은 굳이 연산할 필요 없으니 4부터 연산하면 되지 않을까
//입력
int n = int.Parse(Console.ReadLine());
int[] arr = new int[n + 1]; //0은 안씀, 1은 0으로 자동초기화 될거임
//2~n 연산 시작 (2, 3은 1이다)
for (int i = 2; i <= n; i++)
{
    //1을 빼는 경우를 먼저 삽입한다. 
    arr[i] = arr[i - 1] + 1;
    //2나 3으로 나누는 경우
    //단순히 1을 빼는 방법보다, 2나 3으로 나누는 게 더 빠른지 계산
    if (i % 2 == 0) arr[i] = arr[i] < arr[i / 2] + 1 ? arr[i] : arr[i / 2] + 1;
    if (i % 3 == 0) arr[i] = arr[i] < arr[i / 3] + 1 ? arr[i] : arr[i / 3] + 1;
}
//출력
Console.WriteLine(arr[n]);