using System;

class Except
{
    public static void Run()
    {
       Console.Write("나눌 숫자를 입력하세요: ");
       int num = int.Parse(Console.ReadLine()!); // !는 nul 용서 연산자로, 경고를 없앨 수 있다.
        // Console.WriteLine(10/num); // 오류 발생 가능

       try
        {
            Console.WriteLine(10/num);
        }
        catch (Exception e)
        {
            // Console.WriteLine("0으로 나눌 수 없습니다.");
            Console.WriteLine("예외: " + e.Message);
        }

        /*
        아래 방식으로 숫자 입력 관리하는 게 가장 안전하다.
        string input = Console.ReadLine();

        // 변환에 성공하면 num에 숫자가 들어가고 true 반환, 실패하면 false 반환
        if (int.TryParse(input, out int num))
        {
            Console.WriteLine("변환된 숫자: " + num);
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }

        혹은, try-catch문을 활용한 더 꼼꼼한 에러 처리 방법은 아래와 같다.
        string input = Console.ReadLine();

        try
        {
            // 컴파일러 경고(CS8604)를 끄기 위해 !를 붙여줍니다. 
            // (try-catch는 실행 중(런타임) 에러를 잡는 것이라, 코드 작성 시점의 노란줄 경고를 알아서 없애주지는 않습니다.)
            int num = int.Parse(input!); 
            
            Console.WriteLine("변환된 숫자: " + num);
        }
        catch (ArgumentNullException)
        {
            // input이 null일 때 발생하는 에러
            Console.WriteLine("입력값이 없습니다 (null).");
        }
        catch (FormatException)
        {
            // "안녕", "abc" 등 숫자로 바꿀 수 없는 문자일 때 발생하는 에러
            Console.WriteLine("숫자 형태가 아닙니다.");
        }
        catch (OverflowException)
        {
            // int가 담을 수 있는 범위를 넘어선 너무 크거나 작은 숫자일 때 발생하는 에러
            Console.WriteLine("숫자의 범위가 너무 큽니다.");
        }
        catch (Exception ex)
        {
            // 그 외 예상치 못한 모든 에러
            Console.WriteLine("알 수 없는 오류가 발생했습니다: " + ex.Message);
        }
        */
    }
}