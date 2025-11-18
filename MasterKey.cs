namespace EscapeRoomTrain
{
    internal class MasterKey : Item
    {
        public bool hasKey = false;
        public MasterKey() => name = "MasterKey";

        public override void Info()
        {
            Console.WriteLine();
            Visual.DrawDivider();
            Console.ForegroundColor = ConsoleColor.Red;
            Visual.TypeWrite("МАЙСТЕР-КЛЮЧ", 50);
            Console.ResetColor();
            Console.WriteLine();
            Visual.TypeWrite("Червоний зубчатий ключ, можливо він від чогось важливого...");
            Console.WriteLine("\n");
            Visual.DrawDivider();
        }
    }
}