using System;

class Person
{
    public string Name{ get; set; } = ""; // 또는 = string.Empty; <= 기본값 할당으로 해결
    // 경고가 뜨는 이유: 변수에 값이 비어있을(null) 수 있는데, 안전을 위해 어떻게 처리할지 명확히 해달라"고 요구하는 것!
    public void Eat()
    {
        Console.WriteLine(Name + "(이)가 밥을 먹습니다.");
    }
}

class Cat
{
    public string Name{ get; set; } = "";
    public int Weight;
    
    public Cat()
    {
        Console.WriteLine("Cat() 생성자가 호출되었습니다.");
    }

    public Cat(string name)
    {
        Console.WriteLine("Cat(string name) 생성자가 호출되었습니다.");
        Name = name;
        Console.WriteLine("고양이 이름은 " + Name + "입니다.");
    }

    public Cat(string name, int weight)
    {
        Console.WriteLine("Cat(string name) 생성자가 호출되었습니다.");
        Name = name;
        Weight = weight;
        Console.WriteLine("고양이 이름은 " + Name + "이고, 몸무게는 " + Weight + "kg입니다.");
    }

    // .NET이 처리해주기 때문에 우리가 만들 필요 없다.
    // ~Cat()
    // {
    //     Console.WriteLine(Name + "가 사라집니다.");
    // }
}

class Robot
{
    public virtual void Move()
    {
        Console.WriteLine("로봇이 움직입니다.");
    }
}

class CleanRobot : Robot
{
    public override void Move() // 오버라이딩 <- 상속의 개념
    {
        Console.WriteLine("청소 로봇이 움직입니다.");
    }

    public void Clean()
    {
        Console.WriteLine("로봇이 청소합니다.");
    }
}

// 부모 클래스에는 virtual을, 자식 클래스에는 ovverride를 붙여주면 C# 컴파일러가 경고를 띄우지 않는다 (의도를 파악함)
class RescueRobot : Robot 
{
    public override void Move() 
    {
        Console.WriteLine("구조 로봇이 움직입니다.");
    }
}


class ClassPrac
{
    public static void Run()
    {
        Person p1 = new Person();
        p1.Name = "김석진";
        p1.Eat();

        Cat myCat1 = new Cat();
        Cat myCat2 = new Cat("탁냥이");
        myCat2.Name = "탁냐냐냥이";
        Console.WriteLine("고양이 이름은 " + myCat2.Name + "로 바뀌었습니다");
        Cat myCat3 = new Cat("석냥이", 59);

        Robot cr1 = new Robot();
        CleanRobot cr2 = new CleanRobot();
        RescueRobot cr3 = new RescueRobot();

        cr1.Move();
        cr2.Move();
        cr2.Clean();
        cr3.Move();
    }
}