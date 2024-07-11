#include <iostream>
using namespace std;

//bj15687 /s5 /직사각형 /240709
//클래스 만들기 놀이, 이클립스ide로 java로 풀면 뚝딱이것는디
/*클래스명: Rectangle
생성자: width, height를 입력받음 
멤버변수: int width, height
getset: 위에 저 두개, set에는 범위 예외처리 필요
메서드들-
int area(): 직사각형 넓이 리턴
int perimeter(): 직사각형의 둘레 리턴
bool is_square(): 정사각형 여부 리턴
*/

class Rectangle
{
private:
    //멤버변수
    int width, height;

public:
    //생성자
    Rectangle(int width, int height)
    {
        this->width = width;
        this->height = height;
    }

    //게터 세터
    int get_width() const { return width; }
    int get_height() const { return height; }

    void set_width(int width)
    {
        if (0 < width && width <= 1000)
            this->width = width;
    }

    void set_height(int height)
    {
        if (0 < height && height <= 2000)
            this->height = height;
    }

    //메서드, const는 이 함수가 객체의 멤버변수를 수정하지 않는다고 보장하는 것
    int area() const { return width * height; }
    int perimeter() const { return (width + height) * 2; }
    bool is_square() const { return width == height; }
};