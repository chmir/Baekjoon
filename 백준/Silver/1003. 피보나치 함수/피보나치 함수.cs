
//bj1003 /s3 /피보나치 함수 /240425
//0과 1이 몇번 출력되는지 구하라
//메모이제이션? 써서 미리 구해놓고, 입력받은 거에 따라 답변해주면 되겠다.
//그러면 이제 배열로 접근해서 2부터 40까지 하나하나 셈해보는거야. 
//2는 fibo[2-1] + fibo[2-2]를 호출한다. 즉 0과 1을 두번씩 호출한다.
//3운 fibo[3-1] + fibo[3-2]를 호출한다. 즉 fibo[2]와 fibo[1] 안의 값을 호출하여 0은 1번, 1은 2번 호출한다.
//4는 fibo[4-1] + fibo[4-2]를 호출한다. 즉 fibo[3]과 fibo[2] 안의 값을 호출하여 0은 2번, 1은 3번 호출한다.
//이 연산을 40까지 반복해놓고, 입력에 따른 값을 출력한다.
int N = int.Parse(Console.ReadLine());
(int zero, int one)[] fibo = new (int zero, int one)[41]; // 튜플 배열 초기화
                                                          // 초기 피보나치 호출 횟수 설정
fibo[0] = (1, 0); // fibonacci(0)은 0을 1번, 1을 0번 호출
fibo[1] = (0, 1); // fibonacci(1)은 0을 0번, 1을 1번 호출

// 2부터 40까지 각 숫자에 대해 피보나치 함수에서 0과 1이 호출되는 횟수 계산
for (int i = 2; i <= 40; i++)
{
    fibo[i] = (fibo[i - 1].zero + fibo[i - 2].zero, fibo[i - 1].one + fibo[i - 2].one);
}
//입력 및 출력부분
for (int k = 0; k < N; k++)
{
    int index = Convert.ToInt32(Console.ReadLine()); // 사용자로부터 숫자 입력 받음
    Console.WriteLine($"{fibo[index].zero} {fibo[index].one}"); // 해당 숫자의 0과 1 호출 횟수 출력
}