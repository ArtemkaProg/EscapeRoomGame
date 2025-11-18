namespace EscapeRoomTrain
{
    internal class Safe : Object
    {
        private bool _isOpened = false;
        public string status = "невідомо";
        public bool playerIsNear = false;
        public Safe() => name = "Safe";

        public override string GetStatus() => status;

        public override void Inspect()
        {
            Console.WriteLine();
            Visual.TypeWrite("*Ви підійшли до сейфу*", 40);
            Console.WriteLine("\n");
            Visual.DrawSafe();
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Visual.TypeWrite("Металевий сейф. Можливо його можна взламати чимось міцним...");
            Console.WriteLine();
        }

        public override void Open(Crowbar crowbar)
        {
            if (_isOpened)
            {
                Console.WriteLine("\nСейф вже відкритий.");
                return;
            }

            if (!(Room.currectInspect == this)) playerIsNear = false;

            if (!playerIsNear && !crowbar.hasCrowbar)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nНемає що взламувати та немає чим!");
                Console.ResetColor();
                return;
            }

            if (!playerIsNear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВи ні до чого не підійшли!");
                Console.ResetColor();
                return;
            }

            if (!crowbar.hasCrowbar)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nУ вас немає чим взламувати!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine();
            Visual.TypeWrite("*Удар ломиком*", 80);
            Console.WriteLine();
            Visual.TypeWrite("*ТРІСК*", 100);
            Console.WriteLine();
            Visual.TypeWrite("*Сейф відкривається*", 80);
            Console.WriteLine("\n");

            _isOpened = true;
            status = "відкрито";
            MasterKey masterKey = Room.items.OfType<MasterKey>().FirstOrDefault();
            masterKey.hasKey = true;

            Visual.ShowSuccess();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Ви знайшли МАЙСТЕР-КЛЮЧ!");
            Room.inventory.Add(masterKey);
            Console.ResetColor();
        }
    }
}
