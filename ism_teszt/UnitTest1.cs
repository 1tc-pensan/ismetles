using ism_core;
namespace ism_teszt
{
    public class UnitTest1
    {
        [Fact]
        public void CreateUser_ShouldAddUserToList()
        {
            var users = new List<User>();
            UserService service=new UserService(users);
            var user = service.CreateUser("Teszt Elek", "jelszo123","teszt@example.com",DateTime.Now.ToString(),"3");
            Assert.Equal("Teszt Elek", user.Name);
        }
    }
}