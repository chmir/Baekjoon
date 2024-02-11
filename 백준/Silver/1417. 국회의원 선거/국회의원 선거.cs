using System;
class HelloWorld {
  static void Main() {
      int n = int.Parse(Console.ReadLine()); //후보자 수 입력
      int my = int.Parse(Console.ReadLine()); //내 투표 수 입력
      int min = 0;//매수자 최솟값
      int[] map = new int[n-1]; //타 후보자들의 투표 수 저장
      if(n == 1){ //후보가 나 혼자면
              Console.Write(0);
              return; //프로그램 종료
      }
      //타 후보자 투표수 입력
      for(int i=0; i<n-1; i++) map[i] = int.Parse(Console.ReadLine()); 
      while(true){//나를 제한 타 후보자 투표수로 연산 시작
          Array.Sort(map); //타 후보자 투표수 오름차순 정렬
          if(my <= map[map.Length-1]){ //가장 높은 득표가 내가 아닌경우
              my++; //내 득표를 올리고
              min++; //매수자 수를 올리고
              map[map.Length-1]--; //매수한 후보의 투표수를 내린다.
          }
          else break; //가장 높은 득표가 나라면 종료
      }//bool변수를 사용하면 반복 한번을 줄일 수 있겠지만 굳이?
      Console.Write(min); //내가 매수할 사람의 수
  }
}