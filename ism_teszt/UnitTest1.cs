using ism_core;
namespace ism_teszt
{
    public class UnitTest1
    {
        [Fact]
        public void CreateUser_ShouldAddUserToList()
        {
            var users = new List<User>();
            UserService service = new UserService(users);
            var user = service.CreateUser("Teszt Elek", "jelszo123", "teszt@example.com", DateTime.Now.ToString(), "3");
            Assert.Equal("Teszt Elek", user.Name);
            Assert.Equal("jelszo123", user.Password);
            Assert.Equal("teszt@example.com", user.Email);
            Assert.Equal(3, user.Level);
        }
        [Fact]
        public void GetUser_ShouldReturnCorrectUser()
        {
            //Arrange
            User user = new User(1, "Teszt Elek", "teszt@example.com", "jelszo123", DateTime.Now.ToString(), 3);
            var users = new List<User> { user };
            UserService service = new UserService(users);
            //Act
            var resultUser = service.GetUserById(1);
            //Assert
            Assert.NotNull(resultUser);
            Assert.Equal("Teszt Elek", resultUser.Name);
        }
        [Fact]

        public void UpdateUserName_ShouldChangeUserName()
        {
            //Arrange
            User user = new User(1, "Teszt Elek", "teszt@gmail.com", "jelszo123", DateTime.Now.ToString(), 3);
            var users = new List<User> { user };
            UserService service = new UserService(users);

            //act
            bool result = service.UpdateUserName(1, "Sanyi");

            //assert
            Assert.True(result);
            Assert.Equal("Sanyi", user.Name);
        }

        [Fact]
        public void UpdateUserName_ShouldReturnFalseForNonExistentUser()
        {
            //Arrange
            var users = new List<User>();
            UserService service = new UserService(users);

            //act
            bool result = service.UpdateUserName(99, "Sanyi");

            //assert
            Assert.False(result);
        }
        [Fact]
        public void DeleteUserById_WhenExists_ShouldBeRemoved()
        {
            User user = new User(1, "Teszt Elek", "teszt@gmail.com", "jelszo123", DateTime.Now.ToString(), 3);
            var users = new List<User> { user };
            UserService service = new UserService(users);

            //act
            bool result = service.DeleteUserById(1);

            //assert
            Assert.True(result);
        }
        [Fact]
        public void DeleteUserById_WhenNotExists_ShouldReturnFalse()
        {
            var users = new List<User>();
            UserService service = new UserService(users);
            //act
            bool result = service.DeleteUserById(99);
            //assert
            Assert.False(result);
        }
        /*[Fact]
        public void ParseFromCsv_ShouldReturnValidUser()
        {
            //Arrange
            string csv = /*1,"Teszt Elek","jelszo123","teszt@example.com;2025-11-10 11:24:00:03";
            //Act
            User user = UserService.ParseFromCsv(csv,';');
            //Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("Teszt Elek", user.Name);
            Assert.Equal("jelszo123", user.Password);
            Assert.Equal("teszt@example.com", user.Email);

        }*/

    }
}