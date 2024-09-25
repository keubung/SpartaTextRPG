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

    // �÷��̾� ���¸� �����ִ� �޼ҵ�
    public void ShowStatus()
    {
        bool inShowStatus = true;
        while (inShowStatus)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("���� ����");
            Console.ResetColor();
            Console.WriteLine("ĳ������ ������ ǥ�õ˴ϴ�.");

            Console.WriteLine($"\nLv. {Level}\n�̸�: {Name}\n����: {Job}\n���ݷ�: {Attack} +{PlusAttack}\n����: {Defense} +{PlusDefense}\nü��: {Health}\n���: {Gold} G\n");

            Console.WriteLine("0. ������");

            Console.WriteLine("\n���Ͻô� �ൿ�� �Է����ּ���.");
            Console.Write(">> ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                Console.Clear();
                inShowStatus = false;
            }
            else
            {
                Console.WriteLine("�߸��� �����Դϴ�. �ٽ� �õ��ϼ���.");
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
            Console.WriteLine($"{item.Name}��(��) �����߽��ϴ�!");
        }
        else
        {
            Console.WriteLine("��尡 �����մϴ�.");
        }
    }

    // ������ ���� �� ����
    public void EquipItem(string itemName)
    {
        Item finditem = Inventory.Find(item => item.Name == itemName);
        if (finditem != null)
        {
            if (finditem.IsEquipped)
            {
                // �̹� �����Ǿ� �ִ� ��� ����
                finditem.IsEquipped = false;
                TotalAttack -= finditem.Attack;
                TotalDefense -= finditem.Defense;
                Console.WriteLine($"{finditem.Name}��(��) �����߽��ϴ�.");
            }
            else
            {
                // ����
                finditem.IsEquipped = true;
                TotalAttack += finditem.Attack;
                TotalDefense += finditem.Defense;
                Console.WriteLine($"{finditem.Name}��(��) �����߽��ϴ�.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("�ش� �������� �κ��丮�� �����ϴ�.");
        }
    }

    // �κ��丮 ���
    public void ShowInventory()
    {
        bool inInventory = true;
        while (inInventory)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("�κ��丮");
            Console.ResetColor();
            if (Inventory.Count == 0)
            {
                Console.WriteLine("�κ��丮�� ��� �ֽ��ϴ�.");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    if (item.Description == "���ݷ�")
                    {
                        Console.WriteLine($"- {item.Name} (���ݷ� + {item.Attack})\n");
                    }
                    else if (item.Description == "����")
                    {
                        Console.WriteLine($"- {item.Name} (���� + {item.Defense})\n");
                    }
                }
            }
            Console.WriteLine("\n1. ���� ����");
            Console.WriteLine("0. ������");

            Console.WriteLine("\n���Ͻô� �ൿ�� �Է����ּ���.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.Clear();
                inInventory = false;
            }
            if (input == "1")
            {
                Console.WriteLine("�����Ͻ� ������ �̸��� �Է��� �ּ���.");
                Console.WriteLine(">> ");
                string equippedItem = Console.ReadLine();
                EquipItem(input);
            }
            else
            {
                Console.WriteLine("�߸��� �����Դϴ�. �ٽ� �õ��ϼ���.");
            }
        }
    }
}