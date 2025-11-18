namespace EscapeRoomTrain
{
    internal class Crowbar : Item
    {
        public bool hasCrowbar = false;
        public Crowbar() => name = "Crowbar";

        public override void Info()
        {
            Console.WriteLine();
            Visual.DrawDivider();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Visual.TypeWrite("ЛОМИК", 50);
            Console.ResetColor();
            Console.WriteLine();
            Visual.TypeWrite("Стальний ломик. Достатньо міцний щоб щось взламати.");
            Console.WriteLine("\n");
            Visual.DrawDivider();
        }
    }
}
