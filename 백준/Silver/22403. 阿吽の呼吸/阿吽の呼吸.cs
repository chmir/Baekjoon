using System;
using System.Collections.Generic;
//bj22403 /s5 /阿吽の呼吸 /240514
byte n = byte.Parse(Console.ReadLine()); //n
byte s = 0; //스택
while(n-- > 0){ //n회 반복
    //A or Un 입력
    if(Console.ReadLine()[0] == 'A') s++; //A 입력시 push
    else{ //Un 입력시? 
        if(s == 0){ //A가 없다면 틀림
            Console.WriteLine("NO");
            return;
        }
        else{ //A가 있으면 빼기
            s--; //빼기
        }
    }
}//end while
//다 끝나고 나서 전부 답해줬는지 확인
if(s == 0) Console.WriteLine("YES");
else Console.WriteLine("NO");