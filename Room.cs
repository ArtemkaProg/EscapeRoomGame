namespace EscapeRoomTrain
{
    internal static class Room
    {
        public static List<Item> items = new List<Item>
        {
            new MasterKey(),
            new Crowbar(),
            new PinCode()
        };

        public static List<Object> objects = new List<Object>
        {
            new MainDoor(),
            new Cabinet(),
            new Safe()
        };
        public static List<Item> inventory = new List<Item>();

        public static Object currectInspect;
    }
}
