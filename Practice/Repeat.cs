using System;

class Repeat
{
    public static void Run()
    {
        for (int i = 0; i < 11; ++i)
        {
            Console.WriteLine(i);
        }

        for (int i = 10; i > 0; --i)
        {
            Console.WriteLine(i);
        }

        int j = 0;
        while (j < 11)
        {
            Console.WriteLine(j);
            j++;
        }

        j = 10;
        while (j >= 0)
        {
            Console.WriteLine(j);
            j--;

            if (j == 6)
                break;
        }
    }
}