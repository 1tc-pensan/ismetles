using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ism_core;

namespace ism_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        private UserService userService;
        public MainWindow()
        {
            InitializeComponent();
            users = new ObservableCollection<User>();
            userService = new UserService(users.ToList());
            dgUsers.ItemsSource = users;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser=userService.CreateUser("Új név","jelszo","email@gmail.com", "2024-01-01", "1");
            users.Add(newUser);
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Config.UserFilePath;
            char separator = Config.CsvSeparator;
            users.Clear();
            userService.LoadFromFile(filePath, separator);
            foreach (var user  in userService.GetAllUsers())
            {
                users.Add(user);
            }
        }
    }
}