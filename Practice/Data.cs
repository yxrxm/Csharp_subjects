using System;

class Data
{
    public static void Run()
    {
        int num = 0;
        Console.WriteLine(num++);
        Console.WriteLine(num);
        Console.WriteLine(--num);
        Console.WriteLine(num);

        bool result;
        int num1 = 3, num2 = 5;

        result = num1 > num2;
        Console.WriteLine(result); // F

        result = num1 < num2;
        Console.WriteLine(result); // T

        bool A = true, B = false;
        Console.WriteLine(A && A); // T
        Console.WriteLine(A && B); // F

        Console.WriteLine(A || A); // T
        Console.WriteLine(A || B); // T

        Console.WriteLine(!A); // F
        Console.WriteLine(!B); // T
    }
}