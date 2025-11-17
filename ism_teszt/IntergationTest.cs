using ism_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ism_teszt
{
    public class IntergationTest: IDisposable
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
        [Fact]
        public void UpdateUserName_IntegrationTest()
        {
            var user=service.CreateUser("Teszt Elek","pass123","tesztelek@gmail.com", DateTime.Now.ToString(), "3");
            bool updateresult= service.UpdateUserName(user.Id, "UjNev");
            Assert.True(updateresult);
            Assert.Equal("UjNev", user.Name);
        }
        [Fact]
        public void DeleteUserById_IntegrationTest()
        {
            //új user létrehozása a users Listához
            var user = service.CreateUser("Teszt Elek", "pass123", "tesztelek@gmail.com", DateTime.Now.ToString(), "3");
            //függvény meghívása a user törlésére
            bool deleteResult = service.DeleteUserById(user.Id);
            //ellenőrzés,hogy a törlés sikeres volt-e
            Assert.True(deleteResult);
            //ellenerzés,hogy a users lista a törölt usert
            Assert.Empty(users);
        }
        [Fact]
        public void ExportUserToCsv_IntegrationTest()
        {
            //új user létrehozása a users Listához
            var user = service.CreateUser("Teszt Elek", "pass123", "tesztelek@gmail.com", DateTime.Now.ToString(), "3");
            //users lista kiírása CSV fájlba (tempFilePath-re)
            service.SaveToFile(tempFilePath, separator);
            //Fájl létezésének ellenőrzése
            Assert.True(File.Exists(tempFilePath));
            //Fájl tartalmának beolvasása egy string tömbe
            string[] lines = File.ReadAllLines(tempFilePath);
            //Ellenőrzés,hogy a fájl tartalma egy sor-e
            Assert.Single(lines);
            //Ellenőrzés,hogy a sorban van e "A létrehozott user neve" string
            Assert.Contains("Teszt Elek", lines[0]);
        }
        [Fact]
        public void LoadUsersFromCsv_IntegrationTest()
        {
            //csv sor létrehozása
            string csvLine = $"1{separator}Teszt Elek{separator}pass123{separator}tesztelek@gmail.com{separator}{DateTime.Now:yyyy-MM-dd}{separator}3";
            //csv sor fájlba írása
            File.WriteAllText(tempFilePath, csvLine);
            //users lista betöltése a fájlból
            service.LoadFromFile(tempFilePath, separator);
            //ellenőrzés,hogy a users listában van e egy user
            Assert.Single(users);
            //ellenőrzés,hogy a user neve megegyezik e a csv sorban lévő névvel
            Assert.Equal("Teszt Elek", users[0].Name);
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
