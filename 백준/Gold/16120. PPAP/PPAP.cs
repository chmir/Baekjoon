using System;
using System.Collections.Generic; //Stack<T> 사용
//using System.IO; //StreamWriter/Reader 사용
//shift + f5 = 코드 실행
class Program {	
    static void Main(string[] args) {      	   
		//bj 16120 /g4 /PPAP /240117
		//P, PPAP, 혹은 PPAP문자열을 X라 했을 때 PXAP도 가능
		//PPXP는 안되나봄, 애초에 구분하기도 뭐하고 ㅇㅇ
		//처음에 딱 P 한글자만 있는건 안되는 건줄 알고 고민했는데 그냥 P도 PPAP인듯
		//앞에 p가 두개가 아닌데 a가 왔다면 그건 np로 종료 
		//p가 두개면서 a면 일단 a 넣고, a 후에 p가 오면 ppap이기에 p로 바꾸기 반복
		//p개수인 pcount를 따로 두고 관리해야 할듯... 잠깐 그러면 스택이 필요한가?
		//스택을 쓰지 않아도 될 것 같으므로 스택처럼 풀기만 하고 스택은 쓰지 않는다.
		
		//선언 
		var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
		string str = sr.ReadLine(); //입력받기
		int size = str.Length; //문자열 사이즈
		int pcnt = 0; //p가 몇개인지
		
		//연산
		for(int i = 0; i < size; i++){ //문자열 전부 탐색
			if(str[i] == 'P') pcnt++; //P라면 일단 넣음
			else{ //A인 경우
				//PP이면서 다음 문자를 탐색할 수 있으면서, 
				//다음에 P가 온다면 PPAP이므로 
				//PPAP를 P로 변환한다
				if(pcnt > 1 && i < size - 1 && str[i+1] == 'P'){
					pcnt--; //실제 들어있는건 PP뿐이기에 1만 빼면 됨
					i++; //이러면 i+1은 탐색한 거기에 넘어가준다
				}
				else{ //PA, A, AA인 경우 틀린 것
					sw.Write("NP");
					sr.Close();
					sw.Flush();
					sw.Close();
					return; //종료
				}
			}
		}
		//출력
		sw.Write(pcnt == 1 ? "PPAP":"NP"); //pcnt가 2이상이면 틀림
		sr.Close();
		sw.Flush();
		sw.Close();
	}
}