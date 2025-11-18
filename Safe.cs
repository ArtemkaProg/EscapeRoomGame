namespace EscapeRoomTrain
{
    internal class Safe : Object
    {
        private bool _isOpened = false;
        public string status = "невідомо";
        public bool playerIsNear = false;
        public Safe()
        {
            name = "Safe";
        }

        public override string GetStatus()
        {
            return status;
        }

        public override void Inspect()
        {
            Console.WriteLine($"\n*Ви підійшли до сейфу*.");
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Console.WriteLine($"\nМеталевий сейф. Можливо його можна взламати чимось.");
        }
        public override void Open(Crowbar crowbar)
        {
            if (_isOpened)
            {
                Console.WriteLine("\nСейф вже відкритий.");
                return;
            }
            if (!(Room.currectInspect == this))
            {
                playerIsNear = false;
            }
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
                Console.WriteLine("\nВи ні до чого не підійшли щоб відкривати!");
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
            Console.WriteLine("\n*Ви взламуєте сейф*");
            _isOpened = true;
            status = "відкрито";

            MasterKey masterKey = Room.items.OfType<MasterKey>().FirstOrDefault();
            masterKey.hasKey = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВи знайшли ключ (MasterKey)!");
            Console.ResetColor();
        }
    }
}
