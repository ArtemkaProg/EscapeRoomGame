namespace EscapeRoomTrain
{
    internal class Game
    {
        public static bool game = true;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Begin();

            while (game)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\n> ");
                Console.ResetColor();
                string input = Console.ReadLine()?.ToLower().Trim();

                if (input == "search")
                {
                    Console.WriteLine();
                    Visual.PrintBox("ОГЛЯД КІМНАТИ", ConsoleColor.Cyan);
                    Console.WriteLine("\nНавколо вас є:\n");

                    foreach (Object obj in Room.objects)
                    {
                        ConsoleColor color = obj.GetStatus() switch
                        {
                            "невідомо" => ConsoleColor.Yellow,
                            "закрито" => ConsoleColor.Red,
                            _ => ConsoleColor.Green
                        };

                        Console.Write("    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(obj.name);
                        Console.ForegroundColor = color;
                        Console.WriteLine($" ({obj.GetStatus()})");
                        Console.ResetColor();
                    }
                    Pass();
                }
                else if (input?.StartsWith("inspect ") == true)
                {
                    string target = input.Substring(8).Trim();
                    var obj = Room.objects.FirstOrDefault(o => o.name.Equals(target, StringComparison.OrdinalIgnoreCase));

                    if (obj != null)
                        obj.Inspect();
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  Невідомий об'єкт!");
                        Console.ResetColor();
                    }
                    Pass();
                }
                else if (input == "open maindoor")
                {
                    MainDoor door = (MainDoor)Room.objects[0];
                    MasterKey key = (MasterKey)Room.items[0];
                    PinCode pin = (PinCode)Room.items[2];
                    door.Open(key, pin);
                    Pass();
                }
                else if (input == "open cabinet")
                {
                    Cabinet cab = (Cabinet)Room.objects[1];
                    cab.Open();
                    Pass();
                }
                else if (input == "open safe")
                {
                    Safe safe = (Safe)Room.objects[2];
                    Crowbar crowbar = (Crowbar)Room.items[1];
                    safe.Open(crowbar);
                    Pass();
                }
                else if (input == "inventory")
                {
                    Console.WriteLine();
                    Visual.PrintBox("ІНВЕНТАР", ConsoleColor.Magenta);
                    Console.WriteLine();
                    if (Room.inventory.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("  Ваш інвентар порожній.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        foreach (Item item in Room.inventory)
                        {
                            Console.Write("  - ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(item.name);
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    Pass();
                }
                else if (input?.StartsWith("info ") == true)
                {
                    string target = input.Substring(5).Trim();

                    if (target.Equals("MasterKey", StringComparison.OrdinalIgnoreCase))
                    {
                        MasterKey masterKey = Room.items.OfType<MasterKey>().FirstOrDefault();
                        if (masterKey.hasKey)
                            Room.items[0].Info();
                        else
                            ShowNoItem();
                    }
                    else if (target.Equals("Crowbar", StringComparison.OrdinalIgnoreCase))
                    {
                        Crowbar crowbar = Room.items.OfType<Crowbar>().FirstOrDefault();
                        if (crowbar.hasCrowbar)
                            Room.items[1].Info();
                        else
                            ShowNoItem();
                    }
                    else if (target.Equals("PinCode", StringComparison.OrdinalIgnoreCase))
                    {
                        PinCode pin = Room.items.OfType<PinCode>().FirstOrDefault();
                        if (pin.hasPin)
                            Room.items[2].Info();
                        else
                            ShowNoItem();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  Невідомий предмет!");
                        Console.ResetColor();
                    }
                    Pass();
                }
                else if (input == "help" || input == "?")
                {
                    ShowHelp();
                    Pass();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Невірна команда! Введіть 'help' для допомоги.");
                    Console.ResetColor();
                    Pass();
                }
            }

            Console.WriteLine("\n");
            Visual.PrintBox("ДЯКУЄМО ЗА ГРУ!", ConsoleColor.Green);
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        static void ShowNoItem()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  У вас немає такого предмету.\n");
            Console.ResetColor();
        }

        static void Pass()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n[Натисніть будь-яку клавішу...]");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowHelp()
        {
            Console.WriteLine();
            Visual.PrintBox("ДОВІДКА", ConsoleColor.Blue);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ДОСТУПНІ КОМАНДИ:");
            Console.ResetColor();
            Console.WriteLine("  search           - Подивитись навколо себе");
            Console.WriteLine("  inspect [назва]  - Підійти до об'єкта");
            Console.WriteLine("  open [назва]     - Відкрити об'єкт");
            Console.WriteLine("  info [назва]     - Інформація про предмет");
            Console.WriteLine("  inventory        - Показати інвентарь");
            Console.WriteLine("  help / ?         - Показати цю довідку");
            Console.WriteLine();
        }

        static void Begin()
        {
            Console.Clear();
            Visual.ShowLogo();
            Console.WriteLine();
            Visual.PrintBox("Ласкаво просимо до ESCAPE ROOM!", ConsoleColor.Yellow);
            Console.WriteLine();

            Console.WriteLine("1 - Почати гру");
            Console.WriteLine("2 - Інструкція");
            Console.WriteLine();
            Console.Write("Ваш вибір: ");

            var key = Console.ReadKey().Key;
            Console.Clear();

            if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Visual.PrintBox("ІНСТРУКЦІЯ", ConsoleColor.Blue);
                Console.WriteLine();
                Visual.TypeWrite("Ви закриті в кімнаті. Ваша ціль - знайти вихід!", 30);
                Console.WriteLine("\n");

                ShowHelp();

                Console.WriteLine("Натисніть будь-яку клавішу щоб почати...");
                Console.ReadKey();
                Console.Clear();
            }

            Visual.PrintBox("ГРА ПОЧАЛАСЬ!", ConsoleColor.Green);
            Console.WriteLine();
            Visual.TypeWrite("Ви прокидаєтесь в незнайомій кімнаті...", 40);
            Console.WriteLine();
            Visual.TypeWrite("Двері зачинені. Потрібно знайти вихід!", 40);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Порада: почніть з команди 'search'");
            Console.ResetColor();
        }
    }
}
