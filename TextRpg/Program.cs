/*
gpt 활용:
- List 사용법
- 속성 지정을 위한 enum 관련 개념
- skills나 inventory에 Add한 예제들 만들어달라고 함
- 줄바꿈 깔끔하게끔 수정
*/

enum Element
{
    None, Fire, Water, Wind, Light, Ice, Rock, Dark
}

// 플레이어와 적이 함께 사용하는 상태와 행동 정의하는 Character 클래스
class Character
{
    public string Name;
    public int Hp; // 현재 체력
    public int AttackPower;
    public int MagicPower;
    public Element Element;
    public int MaxHp; // 포션으로 회복 가능한 최대 체력 (태초 체력)
    public int MaxMagicPower; // 포션으로 회복 가능한 최대 마력 (태초 마력)
    public bool IsDefending; // 방어 적용되고 있는지

    public Character(string name, int hp, int attackPower, int magicPower, Element element)
    {
        Name = name;
        Hp = hp;
        AttackPower = attackPower;
        MagicPower = magicPower;
        Element = element;
        MaxHp = hp;
        MaxMagicPower = magicPower;
    }

    // 상대방 target을 공격시키기
    public void Attack(Character target)
    {
        Console.WriteLine(this.Name + "의 공격!");
        target.TakeDamage(this.AttackPower);

    }

    // 공격 때문에 damage 받기
    public void TakeDamage(int damage)
    {
        if (IsDefending)
        {
            damage = Math.Max(1, damage / 2);
            IsDefending = false;
            Console.WriteLine("방어로 피해를 절반으로 줄였습니다!");
        }

        Hp = Math.Max(0, Hp - damage);
        Console.WriteLine(Name + "에게 " + damage + "의 데미지!");
        Console.WriteLine(Name + " HP : " + Hp + "/" + MaxHp);
    }

    // 이름, HP, 공격력, 마력, 속성 출력하기
    public void ShowStatus()
    {
        Console.WriteLine(this.Name + " HP : " + this.Hp + "/" + MaxHp);
        Console.WriteLine(this.Name + " 공격력 : " + this.AttackPower);
        Console.WriteLine(this.Name + " MP : " + this.MagicPower + "/" + MaxMagicPower);
        Console.WriteLine(this.Name + " 속성 : " + this.Element);
    }
}

// Character을 상속받는 Player 클래스
// Skills, Inventory를 가짐
class Player : Character
{
    public List<Skill> Skills = new List<Skill>();
    public List<Item> Inventory = new List<Item>();

    public Player(string name, int hp, int attackPower, int magicPower, Element element)
        : base(name, hp, attackPower, magicPower, element)
    {
        Skills.Add(new Skill("강한 일격", 30, 30, Element.None));
        Skills.Add(new Skill("화염구", 15, 18, Element.Fire));
        Skills.Add(new Skill("물줄기", 15, 18, Element.Water));
        Skills.Add(new Skill("돌 던지기", 15, 18, Element.Rock));
        Skills.Add(new Skill("빛의 화살", 15, 18, Element.Light));
        Skills.Add(new Skill("마력 방어", 5, 0, Element.None, true));

        // 일단 회복 포션들만 구현함
        Inventory.Add(new Item("하급 체력 포션", 30, false, 3));
        Inventory.Add(new Item("중급 체력 포션", 60, false, 2));
        Inventory.Add(new Item("상급 체력 포션", 100, false, 1));
        Inventory.Add(new Item("하급 마력 포션", 30, true, 3));
        Inventory.Add(new Item("중급 마력 포션", 60, true, 2));
        Inventory.Add(new Item("상급 마력 포션", 150, true, 1));
    }
}

// Player의 Skills에 들어간 Skill 클래스
class Skill
{
    public string Name;
    public int MpCost;
    public int Power;
    public Element Element;
    public bool IsDefense; // 방어 Skill 인지

    public Skill(string name, int mpCost, int power, Element element, bool isDefense = false)
    {
        Name = name;
        MpCost = mpCost;
        Power = power;
        Element = element;
        IsDefense = isDefense;
    }

    // 실제 사용에 성공했을 때만 true를 반환해 턴을 소비하게끔 함
    public bool Use(Player player, Enemy enemy)
    {
        if (player.MagicPower < MpCost)
        {
            Console.WriteLine("MP가 부족합니다.");
            return false;
        }

        player.MagicPower -= MpCost;
        Console.WriteLine(player.Name + "의 " + Name + "!");
        if (IsDefense)
        {
            player.IsDefending = true;
            Console.WriteLine("다음 공격의 피해를 절반으로 줄입니다.");
        }
        else
        {
            double multiplier = GetMultiplier(Element, enemy.Element);
            if (multiplier > 1) 
                Console.WriteLine("효과가 굉장합니다!");
            else if (multiplier < 1) 
                Console.WriteLine("효과가 별로입니다...");
                
            enemy.TakeDamage((int)(Power * multiplier));
        }

        return true;
    }

    // 불 > 얼음 > 바람 > 바위 > 물 > 불, 빛과 어둠은 서로에게 강하게 설정함
    public static double GetMultiplier(Element attack, Element target)
    {
        if (attack == Element.None || target == Element.None) 
            return 1;
        if (IsStrong(attack, target)) 
            return 2;
        if (attack == target || IsStrong(target, attack)) 
            return 0.5;

        return 1;
    }

    static bool IsStrong(Element attack, Element target)
    {
        return (attack == Element.Fire && target == Element.Ice)
            || (attack == Element.Ice && target == Element.Wind)
            || (attack == Element.Wind && target == Element.Rock)
            || (attack == Element.Rock && target == Element.Water)
            || (attack == Element.Water && target == Element.Fire)
            || (attack == Element.Light && target == Element.Dark)
            || (attack == Element.Dark && target == Element.Light);
    }
}

// Player의 Inventory에 들어갈 Item 클래스
class Item
{
    public string Name;
    public int Recovery;
    public bool RestoresMp;
    public int Count;

    public Item(string name, int recovery, bool restoresMp, int count)
    {
        Name = name;
        Recovery = recovery;
        RestoresMp = restoresMp;
        Count = count;
    }

    public bool Use(Player player)
    {
        if (Count <= 0)
        {
            Console.WriteLine("남은 포션이 없습니다.");
            return false;
        }

        int current = RestoresMp ? player.MagicPower : player.Hp;
        int maximum = RestoresMp ? player.MaxMagicPower : player.MaxHp;
        if (current >= maximum)
        {
            Console.WriteLine("이미 가득 차 있습니다.");
            return false;
        }

        int recovered = Math.Min(Recovery, maximum - current);
        if (RestoresMp) 
            player.MagicPower += recovered;
        else player.Hp += recovered;
        Count--;
        
        Console.WriteLine(Name + " 사용! " + (RestoresMp ? "MP" : "HP") + " " + recovered + " 회복!");
        
        return true;
    }
}
// Character을 상속받는 Enemy 클래스
class Enemy : Character
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public Enemy(string name, int hp, int attackPower, int magicPower, Element element)
        : base(name, hp, attackPower, magicPower, element)
    {
        Enemies.Add(this);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Text RPG ===");
        Console.Write("플레이어 이름을 입력하세요: ");
        string name = Console.ReadLine()!;

        Player player = new Player(name, 100, 10, 150, Element.Fire); // 초기 능력과 속성 고정

        // 적들 생성 -> 랜덤으로 적 선택되도록 구현함
        Enemy slime = new Enemy("Slime", 40, 8, 30, Element.Water);
        Enemy devil = new Enemy("Devil", 60, 10, 30, Element.Dark);
        Enemy professor = new Enemy("Professor", 80, 20, 40, Element.Ice);

        Random random = new Random();
        bool perfectWin = false;

        while (player.Hp > 0 && !perfectWin)
        {
            int idx = random.Next(Enemy.Enemies.Count);

            if (Enemy.Enemies[idx].Hp > 0)
            {
                if (!Battle(player, Enemy.Enemies[idx]))
                {
                    Console.WriteLine("안전하게 모험을 마칩니다.");
                    return;
                }
            }

            perfectWin = true;
            foreach (Enemy e in Enemy.Enemies)
            {
                if (e.Hp > 0)
                {
                    perfectWin = false;
                    break;
                }
            }
        }

        Console.WriteLine();
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
        Console.WriteLine();
        Console.WriteLine("── 행동 선택 ──");
        Console.WriteLine("1. 싸우다");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상태 확인");
        Console.WriteLine("4. 도망치다");
        Console.WriteLine();

        Console.Write("선택: ");
    }

    // player와 enemy 인스턴스끼리 싸움 붙이기
    // false는 도망 성공 또는 입력 종료를 뜻함
    static bool Battle(Player player, Enemy enemy)
    {   
        Console.WriteLine();
        Console.WriteLine("=== 야생의 " + enemy.Name + "이 나타났습니다! ===");
        enemy.ShowStatus();

        while (player.Hp > 0 && enemy.Hp > 0)
        {
            ShowMenu();

            string? input = Console.ReadLine();
            Console.WriteLine();
            if (input == null) return false;

            if (!int.TryParse(input, out int op))
            {
                Console.WriteLine("숫자를 입력해주세요.");
                continue;
            }

            if (op != 1 && op != 2 && op != 3 && op != 4)
            {
                Console.WriteLine("1 ~ 4 사이의 숫자를 입력해주세요.");
                continue;
            }

            if (op == 1)
            {
                if (!Fight(player, enemy)) continue;
            }
            else if (op == 2)
            {
                if (!OpenInventory(player)) continue;
            }
            else if (op == 3)
            {
                Console.WriteLine("── 플레이어 상태 ──");
                player.ShowStatus();
                continue;
            }
            else if (op == 4)
            {
                if (Random.Shared.Next(100) < 50)
                {
                    Console.WriteLine("도망치는 데 성공했습니다!");
                    return false;
                }
                Console.WriteLine("도망에 실패했습니다!");
            }

            if (enemy.Hp > 0)
            {
                Console.WriteLine();
                Console.WriteLine("── 적의 턴 ──");
                enemy.Attack(player);
            }
        }

        Console.WriteLine();
        if (player.Hp <= 0)
        {
            Console.WriteLine(player.Name + "님이 패배했습니다.");
        }
        else
        {
            Console.WriteLine(enemy.Name + "을(를) 쓰러뜨렸습니다!");
        }

        return true;
    }

    static bool Fight(Player player, Enemy enemy)
    {
        Console.WriteLine("── 스킬 선택 ──");
        Console.WriteLine("현재 MP: " + player.MagicPower);
        Console.WriteLine();
        Console.WriteLine("0. 돌아가기");
        Console.WriteLine("1. 그냥 때리기 (MP 0)");
        for (int i = 0; i < player.Skills.Count; i++)
        {
            Skill skill = player.Skills[i];
            Console.WriteLine((i + 2) + ". " + skill.Name + " (MP " + skill.MpCost + ", 위력 " + skill.Power + ", 속성 " + skill.Element + ")");
        }
        Console.WriteLine();
        Console.Write("선택: ");

        string? input = Console.ReadLine();
        Console.WriteLine();
        if (!int.TryParse(input, out int choice)
            || choice < 0 || choice > player.Skills.Count + 1)
        {
            Console.WriteLine("메뉴에 있는 숫자를 입력해주세요.");
            return false;
        }

        if (choice == 0) 
            return false;
        if (choice == 1)
        {
            player.Attack(enemy);
            return true;
        }

        return player.Skills[choice - 2].Use(player, enemy);
    }

    static bool OpenInventory(Player player)
    {
        Console.WriteLine("── 인벤토리 ──");
        Console.WriteLine("0. 돌아가기");
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Item item = player.Inventory[i];
            Console.WriteLine((i + 1) + ". " + item.Name + " (" + (item.RestoresMp ? "MP" : "HP") + " " + item.Recovery + " 회복, " + item.Count + "개)");
        }
        Console.WriteLine();
        Console.Write("선택: ");

        string? input = Console.ReadLine();
        Console.WriteLine();
        if (!int.TryParse(input, out int choice) || choice < 0 || choice > player.Inventory.Count)
        {
            Console.WriteLine("메뉴에 있는 숫자를 입력해주세요.");
            return false;
        }

        if (choice == 0) 
            return false;
        
        return player.Inventory[choice - 1].Use(player);
    }
}
