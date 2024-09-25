public class Player
{
    public int Level { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public int Attack { get; set; }
    public int PlusAttack { get; set; }
    public int Defense { get; set; }
    public int PlusDefense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    public List<Item> Inventory { get; set; }
    public int TotalAttack { get; set; }
    public int TotalDefense { get; set; }

    public Player(int level, string name, string job, int attack, int plusattack, int defense, int plusdefense)
    {
        Level = level;
        Name = name;
        Job = job;
        Attack = attack;
        PlusAttack = plusattack;
        TotalAttack = attack;
        Defense = defense;
        PlusDefense = plusdefense;
        TotalDefense = defense;
        Health = 100;
        Gold = 11500;
        Inventory = new List<Item>();
    }

    // 플레이어 상태를 보여주는 메소드
    public void ShowStatus()
    {
        bool inShowStatus = true;
        while (inShowStatus)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            Console.WriteLine($"\nLv. {Level}\n이름: {Name}\n직업: {Job}\n공격력: {Attack} +{PlusAttack}\n방어력: {Defense} +{PlusDefense}\n체력: {Health}\n골드: {Gold} G\n");

            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.Clear();
                inShowStatus = false;
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
            }
        }
    }

    public void BuyItem(Item item, List<Item> shopItems)
    {
        if (Gold >= item.Price)
        {
            Gold -= item.Price;
            PlusAttack += item.Attack;
            TotalAttack += item.Attack;
            PlusDefense += item.Defense;
            TotalDefense += item.Defense;
            shopItems.Remove(item);
            Inventory.Add(item);
            Console.WriteLine($"{item.Name}을(를) 구매했습니다!");
        }
        else
        {
            Console.WriteLine("골드가 부족합니다.");
        }
    }

    // 아이템 장착 및 해제
    public void EquipItem(string itemName)
    {
        Item finditem = Inventory.Find(item => item.Name == itemName);
        if (finditem != null)
        {
            if (finditem.IsEquipped)
            {
                // 이미 장착되어 있는 경우 해제
                finditem.IsEquipped = false;
                TotalAttack -= finditem.Attack;
                TotalDefense -= finditem.Defense;
                Console.WriteLine($"{finditem.Name}을(를) 해제했습니다.");
            }
            else
            {
                // 장착
                finditem.IsEquipped = true;
                TotalAttack += finditem.Attack;
                TotalDefense += finditem.Defense;
                Console.WriteLine($"{finditem.Name}을(를) 장착했습니다.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("해당 아이템이 인벤토리에 없습니다.");
        }
    }

    // 인벤토리 기능
    public void ShowInventory()
    {
        bool inInventory = true;
        while (inInventory)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            if (Inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    if (item.Description == "공격력")
                    {
                        Console.WriteLine($"- {item.Name} (공격력 + {item.Attack})\n");
                    }
                    else if (item.Description == "방어력")
                    {
                        Console.WriteLine($"- {item.Name} (방어력 + {item.Defense})\n");
                    }
                }
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                inInventory = false;
            }
            if (input == "1")
            {
                Console.WriteLine("장착하실 아이템 이름을 입력해 주세요.");
                Console.WriteLine(">> ");
                string equippedItem = Console.ReadLine();
                EquipItem(input);
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
            }
        }
    }
}