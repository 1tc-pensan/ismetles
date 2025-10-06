using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_core
{

        public class User
        {
            //osztálysintű
            public static int UserCount;
            //példányszintű
            private int id;
            private string name;
            private string email;
            private string password;
            private DateTime regiDate;
            private int level;
            public User(int id, string name, string email, string password, string regiDate, int level)
            {
                Id = id;
                Name = name;
                Email = email;
                Password = password;
                RegiDate = DateTime.Parse(regiDate);
                Level = level;
                UserCount++;
            }
            public User()
            {

            }
            //Tulajdonság
            public int Id { get; set; }
            public string Name
            {
                get => name;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("név nem lehet ures vagy valami");
                    }
                    name = value;
                }
            }
            public string Password
            {
                get => password;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("jelszo nem lehet ures vagy valami");
                    }
                    password = value;
                }
            }
            public string Email
            {
                get => email;
                set
                {
                    if (!value.Contains('@'))
                    {
                        throw new ArgumentException("nem jo more");
                    }
                    email = value;
                }
            }
            //public DateTime RegistrationDate => RegistrationDate;

            public DateTime RegiDate
            {
                get => regiDate;
                set
                {
                    if (value > DateTime.Now)
                    {
                        throw new ArgumentException("Valmi nem jó a szülbe");
                    }
                    if (value < new DateTime(2000, 1, 1))
                    {
                        throw new ArgumentException("ne legyél fiatalabb 2000-nél");
                    }
                    regiDate = value;
                }
            }
            public int Level
            {
                get => level;
                set
                {
                    if (value < 1 || value > 10)
                    {
                        throw new ArgumentException("1 és 10 között kell lenni");
                    }
                    level = value;
                }
            }
            public override string ToString()
            {
                return $"id: {Id}\n" + 
                $"név: {Name}\n " +
                    $"jelszo :{Password}\n " +
                    $"email: {Email}\n" +
                    $"szul : {RegiDate:yyyy-MM-dd}\n" +
                    $"level: {Level}";
            }
        }
    }
