namespace EscapeRoomTrain
{
    internal class MasterKey : Item
    {
        public bool hasKey = false;
        public MasterKey()
        {
            name = "MasterKey";
        }

        public override void Info()
        {
            Console.WriteLine($"\nЧервоний зубчатий ключ, можливо він від чогось важливого, наприклад дверей.\n");
        }
    }
}