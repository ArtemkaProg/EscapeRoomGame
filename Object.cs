using System.Reflection.PortableExecutable;

namespace EscapeRoomTrain
{
    internal class Object
    {
        public string name;

        public virtual string GetStatus()
        {
            return "";
        }
        public virtual void Inspect()
        {
            Console.WriteLine("Якийсь об'єкт.");
        }

        public virtual void Open()
        {
            Console.WriteLine("Ви завзаємодіяли з об'єктом");
        }
        public virtual void Open(Crowbar corbar)
        {
            Console.WriteLine("Ви завзаємодіяли з об'єктом");
        }
        public virtual void Open(MasterKey masterKey, PinCode pin)
        {
            Console.WriteLine("Ви завзаємодіяли з об'єктом");
        }
    }
}
