using System.Windows;
using System.Windows.Controls;

namespace BookManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
              ((dynamic)this.DataContext).UserLogin.Model.PassWord = ((PasswordBox)sender).Password;
            }
        }
    }
}
