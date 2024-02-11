using System;
class HelloWorld {
  static void Main() {
      int[,] map = new int[100, 100]; //도화지
      int count = 0; //덧대어진 색종이의 넓이
      int n = int.Parse(Console.ReadLine()); //색종이 횟수
      //x y 입력 n번
      for(int i=0; i<n; i++)
      {
          string[] txt = Console.ReadLine().Split(' '); 
          int x = int.Parse(txt[0]);
          int y = int.Parse(txt[1]);
          //연산(도화지에 색종이 넣기)
          for(int j=0; j<10; j++){
              for(int k=0; k<10; k++){
                  //색종이가 도화지 밖으로 나갈일은 없으니,
                  //map배열 밖으로 나갈 예외처리는 하지 않음
                  if(map[j+x,k+y] == 0){ //그자리에 색종이가 있는지
                      map[j+x,k+y] = 1; //있으면 넣어주고
                      count++; //색종이 넓이를 더함
                  } //없는 경우는 카운트 하지 않음
              }
          }
      }
      //출력
    Console.Write(count);
  }
}