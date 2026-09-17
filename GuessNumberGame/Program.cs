using System;

/*
gpt 활용 부분: ReadLine 입력 관련 질문, 난수 생성 관련 질문
*/
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Number Guessing Game ===");
        Console.WriteLine("1. 게임 시작");
        Console.WriteLine("2. 종료");
        Console.WriteLine();

        int number = int.Parse(Console.ReadLine()!); // ! 는 null 관련 경고를 억제한다.

        if (number == 1)
        {
            while (true)
            {
                Random random = new Random();
                int answer = random.Next(1,101);
                int count = 0, guess;

                while (true)
                {
                    Console.Write("숫자를 입력하세요: ");
                    guess = int.Parse(Console.ReadLine()!);
                    count++;

                    if (guess == answer)
                    {
                        Console.WriteLine("정답입니다!");
                        Console.Write("시도 횟수: ");
                        Console.Write(count);
                        Console.WriteLine("회");
                        Console.WriteLine();
                        break;
                    }
                    else if (guess > answer)
                    {
                        Console.WriteLine("DOWN!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("UP!");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("다시 하시겠습니까? (Y/N)");
                string? chance = Console.ReadLine();
                
                if (chance == "Y" || chance == "y")
                {
                    Console.WriteLine("게임을 다시 시작합니다.");
                }
                else if (chance == "N" || chance == "n")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
                }
            }
        }
        else if (number == 2)
        {
            Console.WriteLine("프로그램을 종료합니다.");
            return;
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            return;
        }
    }
}