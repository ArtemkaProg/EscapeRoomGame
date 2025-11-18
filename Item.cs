namespace EscapeRoomTrain
{
    internal class Item
    {
        public string name;
        private bool _isUsed = false;

        public virtual void Info()
        {
            Console.WriteLine("Цей предмет щось може.");
        }

        public virtual void Open(MainDoor mainDoor)
        {
            Console.WriteLine("Ви використали предмет");
            _isUsed = true;
        }
        public virtual void Open(Safe safe)
        {
            Console.WriteLine("Ви використали предмет");
            _isUsed = true;
        }
    }
}
