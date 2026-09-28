/*
gpt 활용: List 사용법
*/

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

        if (target.Hp > 0)
        {
            Console.WriteLine(target.Name + " HP : " + target.Hp);
            Console.WriteLine();
        }
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
        enemies.Add(this);
    }

    // 여러 Enemy들을 저장하는 List
    public static List<Enemy> enemies = new List<Enemy>();
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Text RPG ===");

        Console.Write("플레이어 이름을 입력하세요: ");
        string name = Console.ReadLine()!;

        Player player = new Player(name, 100, 10); // 우선 player 초기 능력 100, 10로 고정

        // 적들 생성 -> 랜덤으로 적 선택되도록 구현
        Enemy slime = new Enemy("Slime", 40, 8);
        Enemy devil = new Enemy("Devil", 60, 10);
        Enemy professor = new Enemy("Professor", 80, 20);

        Random random = new Random();
        bool perfectWin = false;

        while (player.Hp > 0 && !perfectWin)
        {
            int idx = random.Next(Enemy.enemies.Count);

            if (Enemy.enemies[idx].Hp > 0)
            {
                Battle(player, Enemy.enemies[idx]);
            }

            perfectWin = true;
            foreach (Enemy e in Enemy.enemies)
            {
                if (e.Hp > 0)
                {
                    perfectWin = false;
                    break;
                }
            }
        }

        if (player.Hp <= 0)
        {
            Console.WriteLine("게임 오버! 다시 도전해보세요.");
        }
        else if (perfectWin)
        {
            Console.WriteLine("모든 적을 쓰러뜨렸습니다! 축하합니다!");
        }
    }

    static void ShowMenu()
    {
        // 공격 / 상태 확인 메뉴 출력하기
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
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int op))
            {
                Console.WriteLine("숫자를 입력해주세요.");
                continue;
            }

            if (op != 1 && op != 2)
            {
                Console.WriteLine("1 또는 2를 입력해주세요.");
                continue;
            }

            if (op == 1)
            {
                player.Attack(enemy);
            }
            else if (op == 2)
            {
                player.ShowStatus();
                continue;
            }

            if (enemy.Hp > 0)
            {
                enemy.Attack(player);
            }
        }

        if (player.Hp <= 0)
        {
            Console.WriteLine(player.Name + "님이 패배했습니다.");
        }
        else
        {
            Console.WriteLine(enemy.Name + "을(를) 쓰러뜨렸습니다!");
        }
    }
}
