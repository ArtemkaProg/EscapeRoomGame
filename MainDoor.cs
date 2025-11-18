namespace EscapeRoomTrain
{
    internal class MainDoor : Object
    {
        public string status = "невідомо";
        public bool playerIsNear = false;
        public MainDoor() => name = "MainDoor";

        public override string GetStatus() => status;

        public override void Inspect()
        {
            Console.WriteLine();
            Visual.TypeWrite("*Ви підійшли до дверей*", 40);
            Console.WriteLine("\n");
            Visual.DrawDoor();
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Visual.TypeWrite("Масивні металеві двері. Потрібен ключ та пінкод щоб відкрити.");
            Console.WriteLine();
        }

        public override void Open(MasterKey masterKey, PinCode pinCode)
        {
            if (!(Room.currectInspect == this)) playerIsNear = false;

            if (!playerIsNear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  Ви ні до чого не підійшли!\n");
                Console.ResetColor();
                return;
            }

            if (!masterKey.hasKey)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  Немає чим відкривати двері!\n");
                Console.ResetColor();
                return;
            }

            Console.Write("\n  Введіть пінкод (або нажміть Enter щоб скасувати): ");
            string input = Console.ReadLine();

            if (input == pinCode.pin)
            {
                Console.WriteLine();
                Visual.TypeWrite("*Клацання замка*", 80);
                Console.WriteLine();
                Visual.TypeWrite("*Скрип дверей*", 80);
                Console.WriteLine("\n");
                Visual.ShowSuccess();
                status = "відкрито";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n  ВИ ЗНАЙШЛИ ВИХІД! ВИ ВІЛЬНІ!");
                Console.ResetColor();
                Game.game = false;
            }
            else if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\nСкасовано.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  НЕВІРНИЙ ПІНКОД!\n");
                Console.ResetColor();
            }
        }
    }
}
