using ism_core;
using System.ComponentModel.DataAnnotations;

namespace ism_console
{
    internal class Program
    {
        public static List<User> users = new List<User>();
        public static UserService userService = new UserService(users);
        public static char separator = Config.CsvSeparator;
        public static void CreateUser(UserService service)
        {
            Console.Write("Írjál egy nevet: ");
            string name = Console.ReadLine();
            Console.Write("Írjál egy jelszót: ");
            string password = Console.ReadLine();
            Console.Write("Írjál egy emailt: ");
            string email = Console.ReadLine();
            Console.Write("Írjál egy regisztrációs dátumot (yyyy-MM-dd): ");
            string regiDate = Console.ReadLine();
            Console.Write("Írjál egy szintet (1-10): ");
            string level = Console.ReadLine();
            try
            {
                User user = service.CreateUser(name, password, email, regiDate, level);
                Console.WriteLine(user);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hiba:{ex.Message}");
            }
        }


        static void Main(string[] args)
        {

            /*string csv = "2;patrik;jelszo123;patrik@gmail.com;2025-09-12;1";
            try
            {
                User user = UserService.ParseFromCsv(csv, separator);
                users.Add(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"hiba: {ex.Message}");
                Environment.Exit(1);
            }
            */

            /*
            User user = new User();
            try
            {
                User user1 = new User(1, "asf", "vlamiu@gmail.com", "mnemutdom", "2004-11-4", 3);
                Console.WriteLine(user1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hiba {ex.Message}");
                Environment.Exit(1);
            }

            try
            {
                user.Name = "Tibi";
                user.Password = "asd";
                user.Email = "tibi@moriczref.hu";
                user.RegiDate = DateTime.Parse("2025-09-08");
                user.Level = 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hiba {ex.Message}");
                Environment.Exit(1);
            }
            Console.WriteLine();
            Console.WriteLine(user);
        */
            CreateUser(userService);
            Console.ReadKey();
        }
    }
}
