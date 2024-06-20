using System.Text;
//bj17219 /s4 /비밀번호 찾기 /240301
//빠른입출력이 필요하고, 배열의 0 1 2 3... 같은 인덱스 번호를 대신해서 
//Key를 인덱스 대신 사용하고 Value를 같이 쓰는 방식을 연관 배열이라 한다. 
//C#에선 Dictionary로 연관배열을 사용할 수 있다. 
//*단 중복된 키값을 사용할 수 없으니 주의
namespace Programs
{
    class Program
    {
        public static void Main(string[] args)
        {
            //빠른 입출력 및 정답을 저장할 가변문자열 생성
            var sb = new StringBuilder();
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var sr = new StreamReader(Console.OpenStandardInput());
            //연관 배열 생성
            //Dictionary<Key자료형, Value자료형> 변수명 = new Dictionary<Key자료형, Value자료형>();
            var map = new Dictionary<string, string>();
            string site; //비밀번호를 찾기 위해 입력받을 사이트 변수
            //입력
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]); // 저장된 사이트의 주소
            int m = int.Parse(input[1]); // 비밀번호를 찾으려는 사이트 주소의 수
            //저장된 사이트 및 비밀번호 입력
            for (int i = 0; i < n; i++)
            {
                input = sr.ReadLine().Split();
                map.Add(input[0], input[1]);
            }
            //비밀번호를 찾으려는 사이트 주소를 입력하고
            //이메일 주소를 입력받는다
            for (int j = 0; j < m; j++)
            {
                site = sr.ReadLine();
                sb.Append($"{map[site]}\n");
            }
            //정답 출력
            sw.WriteLine(sb);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}