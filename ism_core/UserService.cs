using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
