using ism_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_teszt
{
    public class IntergationTest
    {
        private readonly string tempFilePath;
        private readonly char separator = ';';
        private List<User> users;
        private UserService service;
        //Előkészítés
        public IntergationTest()
        {
            //Előkészítési műveletek
            tempFilePath = Path.Combine(Path.GetTempPath(), $"users_test_{Guid.NewGuid()}.csv");
            users = new List<User>();
            service = new UserService(users);
        }
        //Tesztek
        [Fact]
        public void CreateUser_IntergationsTest()
        {
            var user=service.CreateUser("Teszt Elek","pass123","tesztelek@gmail.com", DateTime.Now.ToString(), "3");
            Assert.Single(users);
            Assert.Equal("Teszt Elek", user.Name);
        }
        //Takarítás
        public void Dispose()
        {
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
            //Takarítási művelet
        }
    }
}
