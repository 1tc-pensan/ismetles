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
            if (dgUsers.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Biztosan törlöd a {selectedUser.Name} felhasználót?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (userService.DeleteUserById(selectedUser.Id))
                    {
                        users.Remove(selectedUser);
                    }
                    else
                    {
                        MessageBox.Show("A felhasználó törlése sikertelen.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Config.UserFilePath;
            char separator = Config.CsvSeparator;
            userService.SaveToFile(path, separator);
            MessageBox.Show("Felhasználók mentve.", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
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