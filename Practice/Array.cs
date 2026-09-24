using System;

class Array
{
    public static void Run()
    {
        int[] array1 = new int[3];
        array1[0] = 10;
        array1[1] = 20;
        array1[2] = 30;

        int[] array2 = new int[3] {10,20,30};

        int[] array3 = {10,20,30};

        Console.WriteLine(array1[0]);
        Console.WriteLine(array1[1]);
        Console.WriteLine(array1[2]);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine(array2[i]);
        }

        Console.WriteLine(array3.Length);
        for (int i = 0; i < array3.Length; ++i)
        {
            Console.WriteLine(array3[i]);
        }

        // foreach-in문은 index로 접근하는 게 아닌, 아이템으로 접근한다!
        foreach (int i in array3)
        {
            Console.WriteLine(i);
        }
    }
}