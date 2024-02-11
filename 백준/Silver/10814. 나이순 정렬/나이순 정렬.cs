using System;
using System.Text; //StringBuilder 사용
using System.IO; //StreamWriter/Reader 사용
using System.Collections.Generic; //List<,> 사용

//shift + f5 = 코드 실행
class Program {
    static void Main(string[] args) {
		StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
		StreamReader reader = new StreamReader(Console.OpenStandardInput());
		
		int n = int.Parse(reader.ReadLine());
		// data라는 List 변수를 선언
		List<(int, string)> data = new List<(int, string)>();
		
		for (int i = 0; i < n; i++)
		{
		string[] value = reader.ReadLine().Split();
		// 튜플을 사용하여 나이와 이름을 저장하였습니다.
		data.Add((int.Parse(value[0]), value[1]));
		}
		
		// C# 문법 LINQ(OrderBy)로 정렬
		var sortList = data.OrderBy(x => x.Item1).ToList();
		
		for (int i = 0; i < n; i++)
		writer.WriteLine($"{sortList[i].Item1} {sortList[i].Item2}");
		
		writer.Close();
		reader.Close();
    }
}