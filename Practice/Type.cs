using System;
using System.Globalization;

class Type
{
    public static void Run()
    {
        // sbyte num = 128; // 오류 -> 컴파일러가 알아채준다
        sbyte num1= 64;
        sbyte num2 = 64;
        
        // sbyte value = num1 + num2; // 더했을 때 범위를 넘어서면 자동으로 형 변환되기에 int형이 된다
        int value = num1 + num2; // 저장하려면 자료형을 int로 고쳐줘야한다.
        // int value = (int)num1 + num2; // 혹은 명시적 형 변환을 활용할 수도 있다
        
        Console.WriteLine(value); // int형을 
    }
}