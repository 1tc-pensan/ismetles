using ism_core;
using System.ComponentModel.DataAnnotations;

namespace ism_console
{
    internal class Program
    {
        public static List<User> users = new List<User>();
        public static UserService userService = new UserService(users);
        public static char separator = Config.CsvSeparator;
        static void ShowMenu()
        {
            Console.WriteLine("USER MENU");
            Console.WriteLine("1.Új felhasznalo");
            Console.WriteLine("2.felhasznalo keresés index");
            Console.WriteLine("3.felhasznalo név friss index");
            Console.WriteLine("4.felhasznalo törlés index alap");
            Console.WriteLine("5.felhasznalo listzázása");
            Console.WriteLine("6. felhasznalo fajlba iras");
            Console.WriteLine("0.3exit");

        }
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
        public static void ReadUser(UserService service)
        {
            Console.WriteLine("ID:");
            int id = int.Parse(Console.ReadLine());
            User user = service.GetUserById(id);
            Console.WriteLine(user != null ? user : "nincs ilyen");
        }

        static void UpdateUser(UserService service)
        {
            Console.WriteLine("Módosítandó user ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Új név: ");
            string newName = Console.ReadLine();
            bool updated = service.UpdateUserName(id, newName);
            Console.WriteLine(updated ? "nev friss" : "nincs ilyen nev");
        }
        static void DeleteUser (UserService service)
        {
            Console.WriteLine("Törlendő felhasználó Id:");
            int id=int.Parse(Console.ReadLine());
            bool deleted = service.DeleteUserById(id);
            Console.WriteLine(deleted? "Felhasznalo torolve": "nincs ilyen id-jű felhasznalo");
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
            while (true)
            {
                ShowMenu();
                Console.Write("Szám: \n");
                string choice = Console.ReadKey().KeyChar.ToString();
                switch (choice)
                {
                    case "1":
                        CreateUser(userService);
                        break;
                    case "2":
                        ReadUser(userService);
                        break;
                    case "3":
                        UpdateUser(userService);
                        break;
                    case "4":
                        DeleteUser(userService);
                        break;

                    case "0":
                        Console.WriteLine("Kilépés...");
                        return; // vagy break, ha nem akarod kiléptetni a ciklusból

                    default:
                        Console.WriteLine("Érvénytelen választás, próbáld újra.");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
