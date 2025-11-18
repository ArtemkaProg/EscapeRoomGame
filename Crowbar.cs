namespace EscapeRoomTrain
{
    internal class Crowbar : Item
    {
        public bool hasCrowbar = false;
        public Crowbar()
        {
            name = "Crowbar";
        }
        public override void Info()
        {
            Console.WriteLine($"\nСтальний ломик. Достатньо міцний щоб щось взламати.\n");
        }
    }
}
