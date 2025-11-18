namespace EscapeRoomTrain
{
    internal class MainDoor : Object
    {
        public string status = "невідомо";
        public bool playerIsNear = false;

        public MainDoor()
        {
            name = "MainDoor";
        }

        public override string GetStatus()
        {
            return status;
        }

        public override void Inspect()
        {
            Console.WriteLine($"\n*Ви підійшли до дверей*.");
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Console.WriteLine($"\nЗачинено. Потрібен ключ та пінкод щоб відкрити.");
        }
        public override void Open(MasterKey masterKey, PinCode pinCode)
        {
            if (!(Room.currectInspect == this))
            {
                playerIsNear = false;
            }
            if (!playerIsNear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВи ні до чого не підійшли щоб відкривати!\n");
                Console.ResetColor();
                return;
            }
            if (!playerIsNear && !masterKey.hasKey)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВи ні до чого не підійшли щоб відкривати та немає чим відкривати!\n");
                Console.ResetColor();
                return;
            }
            if (!masterKey.hasKey)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nНемає чим відкривати двері!\n");
                Console.ResetColor();
                return;
            }
            Console.Write("Для введення пінкоду - нажміть 'P': ");
            if (Console.ReadLine() == pinCode.pin)
            {
                Console.WriteLine("\n*Ви відкриваєте двері*");
                status = "відкрито";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ви знайшли вихід!");
                Console.ResetColor();
                Game.game = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНевірний пінкод!\n");
                Console.ResetColor();
            }
        }
    }
}
