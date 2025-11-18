namespace EscapeRoomTrain
{
    internal class Cabinet : Object
    {
        private bool _isOpened = false;
        public string status = "невідомо";
        public bool playerIsNear = false;
        public Cabinet()
        {
            name = "Cabinet";
        }

        public override string GetStatus()
        {
            return status;
        }

        public override void Inspect()
        {
            Console.WriteLine($"\n*Ви підійшли до тумби*.");
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Console.WriteLine($"\nНевелика тумба. Нічим не закрита.");
        }
        public override void Open()
        {
            if (_isOpened)
            {
                Console.WriteLine("\nТумба вже відкрита.");
                return;
            }
            if (!(Room.currectInspect == this))
            {
                playerIsNear = false;
            }
            if (!playerIsNear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВи не підійшли до чогось що можна відкрити!");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("\n*Ви відкриваєте тумбу*");
            _isOpened = true;
            status = "відкрито";

            Crowbar crowbar = Room.items.OfType<Crowbar>().FirstOrDefault();
            crowbar.hasCrowbar = true;
            PinCode pin = Room.items.OfType<PinCode>().FirstOrDefault();
            pin.hasPin = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВи знайшли ломик (Crowbar) та пінкод (PinCode)!");
            Console.ResetColor();
        }
    }
}
