namespace EscapeRoomTrain
{
    internal class PinCode : Item
    {
        public bool hasPin = false;
        public string pin = "2087";
        public PinCode() => name = "PinCode";

        public override void Info()
        {
            Console.WriteLine();
            Visual.DrawDivider();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Visual.TypeWrite("ПІН-КОД", 50);
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Пластикова картка з шифром: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("8-III, 2-I, 7-IV, 0-II");
            Console.ResetColor();
            Console.WriteLine("\n");
            Visual.DrawDivider();
        }
    }
}
