using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ism_core
{
    public class UserService
    {
        //Controller metódusok
        private List<User> users;
        public UserService(List<User> u)
        {
            this.users = u;
        }
        public static User ParseFromCsv(string csv, char separator)
        {
            string[] parts = csv.Split(separator);
            if (parts.Length != 6)
            {
                throw new ArgumentException("Hibas csv sor");
            }
            int id = int.Parse(parts[0]);
            string name = parts[1];
            string password = parts[2];
            string email = parts[3];
            string regiDate = parts[4];
            int level = int.Parse(parts[5]);
            User user = new User(id, name, email, password, regiDate, level);
            return user;

        }
        public User CreateUser(string name, string password, string email, string regiDate, string level)
        {
            int id = User.UserCount + 1;
            int levl;
            try
            {
                levl = int.Parse(level);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Szint számnak kell lenni");
            }
            User user = new User(id, name, email, password, regiDate, levl);
            users.Add(user);
            return user;
        }
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
        public bool UpdateUserName(int id, string newName)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                user.Name = newName;
                return true;
            }
            return false;
        }
        public bool DeleteUserById(int id)
        {
            User user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }
        public void LoadFromFile(string filePath, char separator)
        {
            users.Clear();
            try
            {
                using (StreamReader sr=new StreamReader(filePath))
                {
                    string line;
                    while ((line=sr.ReadLine()) !=null)
                    {
                        if ((string.IsNullOrWhiteSpace(line)) || (line.StartsWith("#")))
                        {
                            continue;
                        }
                        try
                        {
                            User user = ParseFromCsv(line, separator);
                            users.Add(user);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hiba sor kihagyva:" +ex.Message);   
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Hiba {ioEx.Message}");
                System.Diagnostics.Debug.WriteLine($"Hiba {ioEx.Message}");
            }
        }
        public List<User> GetAllUsers()
        {
            return users;
        }
        
    }
}
