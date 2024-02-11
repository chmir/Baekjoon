using System;
using System.Collections;
class HelloWorld {
  static void Main() {
      int n = int.Parse(Console.ReadLine()); //카드 수 입력
      Queue card = new Queue(n); //큐 생성
      //카드 수 만큼 순서대로 놓아준다
      for(int i = 0; i < n; i++) card.Enqueue(i+1);
      while(card.Count != 1){ //카드가 빌 때 까지 실행
          Console.Write(card.Dequeue() + " "); //맨 위의 카드를 빼고
          card.Enqueue(card.Dequeue());//맨 밑으로 카드를 넣어준다
      }
      //while문 안에서는 두번 빼니까 나머지 하나는 지금 빼줌
      Console.Write(card.Dequeue()); 
  }
}