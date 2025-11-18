namespace EscapeRoomTrain
{
    internal class PinCode : Item
    {
        public bool hasPin = false;
        public string pin = "2087";
        public PinCode()
        {
            name = "PinCode";
        }

        public override void Info()
        {   //8 - III, 2 - I, 7 - IV, 0 - II
            Console.Write($"\nПластикова картка з шифром на звороті: 8 - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("III");
            Console.ResetColor();
            Console.Write(", 2 - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("I");
            Console.ResetColor();
            Console.Write(", 7 - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("IV");
            Console.ResetColor();
            Console.Write(", 0 - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("II");
            Console.ResetColor();
            Console.WriteLine(".");
            Console.WriteLine();
        }
    }
}
