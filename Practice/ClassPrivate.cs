using System;

class Cat2
{
    private string name;

    public Cat2(string name)
    {
        this.name = name;
        Console.WriteLine("Cat2(string name) 생성자가 호출되었습니다.");
        Console.WriteLine("고양이 이름은 " + this.name + "입니다.");
    }

    // Setter
    public void SetName(string name)
    {
        this.name = name;
    }

    // Getter
    public string GetName()
    {
        return this.name;
    }
}

class ClassPrivate
{
    public static void Run()
    {
        Cat2 myCat = new Cat2("탁냥탁냥");
        // myCat.name = "탁냥"; << public 일 때는 가능하던 접근 불가능
        myCat.SetName("탁냥");
        Console.WriteLine("고양이 이름은 " + myCat.GetName() + "입니다.");

    }
}