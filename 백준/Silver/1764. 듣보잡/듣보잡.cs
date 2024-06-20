//bj1764 /s4 /듣보잡 /240302
//듣도 못한 사람, 보도 못한 사람 두 집합을 입력받고 
//듣도 보도 못한 사람의 명수와 이름을 사전순으로 출력한다. 
//각 집합은 중복된 키를 받지 않으나, 두 집합은 중복될 수 있다. 
//두개의 연관배열을 만들고 키를 비교하여 같은 사람을 리스트에 넣자. 
//처음엔 딕셔너리를 사용했는데, Value가 쓸 데 없는 점, 그리고 두번째 입력부터 
//바로 연산을 해도 되는 점을 생각하여 해시셋과 리스트를 사용해보기로 했다.
//메모리가 확 줄긴 했는데 속도는 의외로 비슷한듯? 
class Program
{
    static void Main()
    {
        //빠른 입출력
        var sr = new System.IO.StreamReader(Console.OpenStandardInput());
        var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
        //초기값 입력
        var nm = Array.ConvertAll(sr.ReadLine().Split(' ').ToArray(), int.Parse);
        int n = nm[0];  //듣도 못한 사람 수 
        int m = nm[1];  //보도 못한 사람 수
        //듣도 못한 사람을 담아낼 해시셋
        HashSet<string> Data = new HashSet<string>(n);
        //듣도 보도 못한 사람을 담아낼 리스트
        List<string> list = new List<string>(m);

        //듣도 못한 사람 입력
        while (n-- > 0) Data.Add(sr.ReadLine());
        //보도 못한 사람 입력
        while (m-- > 0)
        {
            //듣도 못한 사람과 같다면 리스트에 넣어준다
            string str = sr.ReadLine();
            if (Data.Contains(str)) list.Add(str);
        }
        
        //리스트를 사전순으로 정렬한다
        list.Sort();
        //리스트 안에 넣어진 듣도 보도 못한 사람의 명수 출력
        sw.WriteLine(list.Count);
        //그리고 그 명단을 출력한다
        foreach (var name in list) sw.WriteLine(name);
        sr.Close();
        sw.Flush();
        sw.Close();
    }
}