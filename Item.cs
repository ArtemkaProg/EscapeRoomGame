namespace EscapeRoomTrain
{
    internal class Item
    {
        public string name;
        public virtual void Info() => Console.WriteLine("Цей предмет щось може.");
    }
}
