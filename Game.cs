namespace EscapeRoomTrain
{
    internal class Game
    {
        public static bool game = true;
        static void Main()
        {
            Begin();
            while (game)
            {
                string input = Console.ReadLine();
                if (input == "search")
                {
                    Console.WriteLine($"\nНавколо вас є:");
                    foreach (Object obj in Room.objects)
                    {
                        ConsoleColor color;

                        switch (obj.GetStatus())
                        {
                            case "невідомо":
                                color = ConsoleColor.Yellow;
                                break;
                            case "закрито":
                                color = ConsoleColor.Red;
                                break;
                            default:
                                color = ConsoleColor.Green;
                                break;
                        }

                        Console.Write($"  {obj.name}  ");
                        Console.ForegroundColor = color;
                        Console.WriteLine($"({obj.GetStatus()})");
                        Console.ResetColor();
                    }
                    Pass();
                }
                else if (input.StartsWith("inspect "))
                {
                    string target = input.Substring(8);

                    if (target == Room.objects[0].name)
                        Room.objects[0].Inspect();
                    else if (target == Room.objects[1].name)
                        Room.objects[1].Inspect();
                    else if (target == Room.objects[2].name)
                        Room.objects[2].Inspect();
                    else
                        Console.WriteLine("Була введена невірна дія.");
                    Pass();
                }
                else if (input == "open MainDoor")
                {
                    MainDoor door = (MainDoor)Room.objects[0];
                    MasterKey key = (MasterKey)Room.items[0];
                    PinCode pin = (PinCode)Room.items[2];

                    door.Open(key, pin);
                    Pass();
                }
                else if (input == "open Cabinet")
                {
                    Cabinet cab = (Cabinet)Room.objects[1];

                    cab.Open();
                    Pass();
                }
                else if (input == "open Safe")
                {
                    Safe safe = (Safe)Room.objects[2];
                    Crowbar crowbar = (Crowbar)Room.items[1];

                    safe.Open(crowbar);
                    Pass();
                }
                else if (input.StartsWith("info "))
                {
                    string target = input.Substring(5);

                    if (target == Room.items[0].name)
                    {
                        MasterKey masterKey = Room.items.OfType<MasterKey>().FirstOrDefault();
                        if (masterKey.hasKey)
                            Room.items[0].Info();
                        else
                        { 
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nУ вас немає такого предмету.\n"); 
                            Console.ResetColor();
                        }
                    }
                    else if (target == Room.items[1].name)
                    {
                        Crowbar crowbar = Room.items.OfType<Crowbar>().FirstOrDefault();
                        if (crowbar.hasCrowbar)
                            Room.items[1].Info();
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nУ вас немає такого предмету.\n");
                            Console.ResetColor();
                        }
                    }
                    else if (target == Room.items[2].name)
                    {
                        PinCode pin = Room.items.OfType<PinCode>().FirstOrDefault();
                        if (pin.hasPin)
                            Room.items[2].Info();
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nУ вас немає такого предмету.\n");
                            Console.ResetColor();
                        }
                    }
                    else
                        Console.WriteLine("Була введена невірна дія.");
                    Pass();
                }
                else
                {
                    Console.WriteLine("Була введена невірна дія.");
                    Pass();
                }
            }
        }

        static void Pass()
        {
            Console.WriteLine("Нажміть щоб продовжити...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Begin()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("1 - почати гру нажміть, 2 - переглянути інструкцію та управління.");
            if (Console.ReadKey().Key == ConsoleKey.D1)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nВи закриті в кімнаті, ваша ціль знайти вихід.\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Стандартні дії:");
                Console.ResetColor();

                Console.WriteLine("   Подивитись навколо себе - search");
                Console.WriteLine("   Підійти до *чогось* - inspect *назва*");
                Console.WriteLine("   Відкрити *щось* - open *назва*");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Дії з предметами:");
                Console.ResetColor();

                Console.WriteLine("   Дізнатися більше про предмет - info *назва*");
                Console.WriteLine("\nПочати гру?");
                Console.WriteLine("1 - так, 2 - ні.");
                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Begin();
                }
            }
        }
    }
}
