public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Price { get; set; }
    public string Info { get; set; }
    public bool IsEquipped { get; set; }    // ���� ���� Ȯ��

    public Item(string name, string description, int attack, int defense, int price, string info)
    {
        Name = name;
        Description = description;
        Attack = attack;
        Defense = defense;
        Price = price;
        Info = info;
        IsEquipped = false; // �⺻��: ���� �ȵ�
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"���ݷ� +{Attack} | ���� +{Defense} | ����: {Price} Gold");
        Console.WriteLine($"- {Info}\n");
    }
}