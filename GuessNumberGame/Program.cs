using System;

/*
gpt 활용 부분: 
1. ReadLine 입력 관련 질문, 난수 생성 관련 질문 (강의에 안 나옴)
2. 입력 검증 구조 참고
*/
class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();

        // 올바른 메뉴를 입력할 때까지 반복하기 (입력 검증 추가)
        while (true)
        {
            Console.WriteLine("=== Number Guessing Game ===");
            Console.WriteLine("1. 게임 시작");
            Console.WriteLine("2. 종료");
            Console.WriteLine();

            string? input = Console.ReadLine();

            if (input == null)
                return;

            if (!int.TryParse(input, out int menu))
            {
                Console.WriteLine("숫자를 입력해 주세요.");
                continue;
            }

            if (menu == 1)
                break;

            if (menu == 2)
            {
                Console.WriteLine("프로그램을 종료합니다.");
                return;
            }

            Console.WriteLine("1 또는 2를 입력해 주세요.");
        }

        // 게임 한 판씩 반복하기
        while (true)
        {
            int answer = random.Next(1, 101);
            int count = 0;

            // 정답을 맞힐 때까지 반복하기 (입력 검증 추가)
            while (true)
            {
                Console.Write("숫자를 입력하세요: ");
                string? input = Console.ReadLine();

                if (input == null)
                    return;

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("정수를 입력해 주세요.");
                    continue;
                }

                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine("1~100 사이의 숫자를 입력해 주세요.");
                    continue;
                }

                // 올바른 범위의 정수만 시도 횟수에 포함하기
                count++;

                if (guess == answer)
                {
                    Console.WriteLine($"정답입니다! 시도 횟수: {count}회");
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

            // 올바른 재시작 응답을 입력할 때까지 반복하기 (입력 검증 추가)
            while (true)
            {
                Console.Write("다시 하시겠습니까? (Y/N): ");
                string? input = Console.ReadLine();

                if (input == null)
                    return;

                string choice = input.Trim().ToUpperInvariant();

                if (choice == "Y")
                {
                    Console.WriteLine("게임을 다시 시작합니다.");
                    Console.WriteLine();

                    break;
                }

                if (choice == "N")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    return;
                }

                Console.WriteLine("Y 또는 N을 입력해 주세요.");
            }
        }
    }
}