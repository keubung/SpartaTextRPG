public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Price { get; set; }
    public string Info { get; set; }
    public bool IsEquipped { get; set; }    // 장착 상태 확인

    public Item(string name, string description, int attack, int defense, int price, string info)
    {
        Name = name;
        Description = description;
        Attack = attack;
        Defense = defense;
        Price = price;
        Info = info;
        IsEquipped = false; // 기본값: 장착 안됨
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"공격력 +{Attack} | 방어력 +{Defense} | 가격: {Price} Gold");
        Console.WriteLine($"- {Info}\n");
    }
}