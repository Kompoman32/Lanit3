using Lanit3.Model;

namespace Lanit3.Models
{
    public static class DataBase
    {
        public static void Init()
        {
            ModelContainer = new dbModelContainer();
        }

        public static dbModelContainer ModelContainer { get; set; }
    }
}