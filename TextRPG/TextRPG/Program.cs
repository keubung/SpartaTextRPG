using static TextRPG.Program;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerjob = "";
            int attack = 0;
            int defense = 0;
            Nullable<int> plusattack = null;
            Nullable<int> plusdefense = null;
            
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");        // 플레이어 이름 입력
            Console.Write(">> ");
            string playerName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 직업을 선택해주세요.\n");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 궁수");
            Console.WriteLine("3. 마법사");
            Console.Write(">> ");
            string jobchoice = Console.ReadLine();

            switch (jobchoice)
            {
                case "1":
                    playerjob = "전사";
                    attack = 30;
                    defense = 70;
                    break;
                case "2":
                    playerjob = "궁수";
                    attack = 50;
                    defense = 50;
                    break;
                case "3":
                    playerjob = "마법사";
                    attack = 70;
                    defense = 30;
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                    break;
            }

            // 플레이어 생성
            Player player = new Player(1, playerName, playerjob, attack, 0, defense, 0);

            Console.Clear();

            // 메뉴 화면 표시
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("스파르타 던전");
                Console.ResetColor();
                Console.WriteLine($"{player.Name}님 환영합니다! 이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine("\n==== 메뉴 ====");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 상점");
                Console.WriteLine("3. 인벤토리");
                Console.WriteLine("4. 게임 종료");
                Console.Write("메뉴를 선택하세요: ");

                string choice = Console.ReadLine();

                // 선택지에 따른 동작 수행
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        player.ShowStatus();
                        break;
                    case "2":
                        Console.Clear();
                        EnterShop(player);
                        break;
                    case "3":
                        Console.Clear();
                        player.ShowInventory();
                        break;
                    case "4":
                        Console.WriteLine("게임을 종료합니다.");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                        break;
                }
            }
        }

        // 상점 기능
        public static void EnterShop(Player player)
        {
            List<Item> shopItems = new List<Item>
            {
                new Item("수련자 갑옷", "방어력", 0, 5, 1000, "수련에 도움을 주는 갑옷입니다."),
                new Item("무쇠 갑옷", "방어력", 0, 9, 2000, "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Item("스파르타의 갑옷", "방어력", 0, 15, 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."),
                new Item("낡은 검", "공격력", 2, 0, 600, "쉽게 볼 수 있는 낡은 검입니다."),
                new Item("청동 도끼", "공격력", 5, 0, 1500, "어디선가 사용됐던 것 같은 도끼입니다."),
                new Item("스파르타의 창", "공격력", 7, 0, 2300, "스파르타의 전사들이 사용했다는 전설의 창입니다.")
            };
            Console.Clear();
            bool inShopMenu = true;
            while (inShopMenu)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("상점");
                Console.ResetColor();
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

                Console.WriteLine("\n[보유골드]");
                Console.WriteLine($"{player.Gold} G");
                if (shopItems.Count == 0)
                {
                    Console.WriteLine("상점에 남은 아이템이 없습니다.");
                }
                else
                {
                    Console.WriteLine("\n[아이템 목록]");
                    for (int i = 0; i < shopItems.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        shopItems[i].ShowInfo();
                    }
                    
                }
                Console.WriteLine("아이템을 선택해 구매하세요 (번호 입력).");
                Console.WriteLine("0. 메인 메뉴로 돌아가기");
                
                string input = Console.ReadLine();

                if (input == "0")
                {
                    inShopMenu = false;  // 메인 메뉴로 돌아가기
                }
                else
                {
                    if (int.TryParse(input, out int selectedItem) && selectedItem > 0 && selectedItem <= shopItems.Count)
                    {
                        Console.Clear();
                        player.BuyItem(shopItems[selectedItem - 1], shopItems);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                    }
                }
            }
        }
    }
}
