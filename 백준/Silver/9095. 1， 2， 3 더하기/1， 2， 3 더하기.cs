//bj9095 /s3 /1, 2, 3 더하기 /240425
//먼저, 1 2 3을 미리 만들어놓고 4부터 10까지 연산
//연산 후 각 테스트케이스에 따른 정답 출력

//이 연산을 40까지 반복해놓고, 입력에 따른 값을 출력한다.
int N = int.Parse(Console.ReadLine());
int[] add = new int[11]; //1~10, 0은 안씀
//초기값 설정 
//3은 1+1+1, 1+2, 2+1, 3 -> 4
add[1] = 1; add[2] = 2; add[3] = 4;

// 4부터 10까지 각 숫자에 대해 합의 개수를 구한다.
for (int i = 4; i <= 10; i++)
{
    add[i] = add[i - 1] + add[i - 2] + add[i - 3];
}
//입력 및 출력부분
for (int k = 0; k < N; k++)
{
    int index = Convert.ToInt32(Console.ReadLine()); // 사용자로부터 숫자 입력 받음
    Console.WriteLine(add[index]); // 해당 숫자의 값 출력
}