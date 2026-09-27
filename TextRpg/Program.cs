// 플레이어와 적이 함께 사용하는 상태와 행동 정의하는 Character 클래스
class Character
{
    public string Name;
    public int Hp;
    public int AttackPower;

    public Character(string name, int hp, int attackPower)
    {
        Name = name;
        Hp = hp;
        AttackPower = attackPower;
    }

    // 상대방 target을 공격시키기
    public void Attack(Character target)
    {
        target.Hp -= this.AttackPower;
        Console.WriteLine(this.Name + "의 공격!");
        Console.WriteLine(target.Name + "에게 " + this.AttackPower + "의 데미지!\n");

        Console.WriteLine(target.Name + " HP : " + target.Hp);
        Console.WriteLine();
    }

    // 이름, HP, 공격력 출력하기
    public void ShowStatus()
    {
        Console.WriteLine(this.Name + " HP : " + this.Hp);
        Console.WriteLine(this.Name + " 공격력 : " + this.AttackPower);
        Console.WriteLine();
    }
}

// Character을 상속받는 Player 클래스
class Player : Character
{
    public Player(string name, int hp, int attackPower)
        : base(name, hp, attackPower)
    {
    }
}

// Character을 상속받는 Enemy 클래스
class Enemy : Character
{
    public Enemy(string name, int hp, int attackPower)
        : base(name, hp, attackPower)
    {
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // 예제 조건 충족만 하게끔 우선 구현
        Console.WriteLine("=== Text RPG ===");

        Console.Write("플레이어 이름을 입력하세요: ");
        string name = Console.ReadLine()!;

        Player player1 = new Player(name, 100, 10); // 우선 초기 능력 100, 10로 고정
        Enemy slime = new Enemy("Slime", 40, 8); // 우선 초기 능력 40, 8로 고정
        Battle(player1, slime);
    }

    static void ShowMenu()
    {
        // TODO: 공격 / 상태 확인 메뉴 출력하기
        Console.WriteLine("1. 공격");
        Console.WriteLine("2. 상태확인\n");

        Console.Write("선택: ");
    }

    // player와 enemy 인스턴스끼리 싸움 붙이기
    static void Battle(Player player, Enemy enemy)
    {
        Console.WriteLine("야생의 " + enemy.Name + "이 나타났습니다!\n");

        while (player.Hp > 0 && enemy.Hp > 0)
        {
            ShowMenu();
            int op = int.Parse(Console.ReadLine()!);

            if (op == 1)
            {
                player.Attack(enemy);
            }
            else if (op == 2)
            {
                player.ShowStatus();
                continue;
            }
            else
            {
                continue;
            }

            if (enemy.Hp > 0)
            {
                enemy.Attack(player);
            }
        }

        if (player.Hp > enemy.Hp)
        {
            Console.WriteLine(player.Name + "님이 승리하셨습니다!");
        }
        else
        {
            Console.WriteLine(enemy.Name + "님이 승리하셨습니다!");
            Console.WriteLine("다시 도전해보세요.");
        }
    }
}
