namespace EscapeRoomTrain
{
    internal class Cabinet : Object
    {
        private bool _isOpened = false;
        public string status = "невідомо";
        public bool playerIsNear = false;
        public Cabinet() => name = "Cabinet";

        public override string GetStatus() => status;

        public override void Inspect()
        {
            Console.WriteLine();
            Visual.TypeWrite("*Ви підійшли до тумби*", 40);
            Console.WriteLine("\n");
            Visual.DrawCabinet();
            playerIsNear = true;
            Room.currectInspect = this;
            status = "закрито";
            Visual.TypeWrite("Невелика дерев'яна тумба. Нічим не закрита.");
            Console.WriteLine();
        }

        public override void Open()
        {
            if (_isOpened)
            {
                Console.WriteLine("\nТумба вже відкрита.");
                return;
            }

            if (!(Room.currectInspect == this)) playerIsNear = false;

            if (!playerIsNear)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВи не підійшли до чогось що можна відкрити!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine();
            Visual.TypeWrite("*Ви відкриваєте тумбу*", 60);
            Console.WriteLine("\n");

            _isOpened = true;
            status = "відкрито";
            Crowbar crowbar = Room.items.OfType<Crowbar>().FirstOrDefault();
            crowbar.hasCrowbar = true;
            PinCode pin = Room.items.OfType<PinCode>().FirstOrDefault();
            pin.hasPin = true;

            Visual.ShowSuccess();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВи знайшли ЛОМИК (Crowbar) та ПІН-КОД (PinCode)!");
            Room.inventory.Add(crowbar);
            Room.inventory.Add(pin);
            Console.ResetColor();
        }
    }
}
