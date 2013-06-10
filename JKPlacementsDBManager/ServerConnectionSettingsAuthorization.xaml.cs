using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JKPlacementsDBManager
{
    /// <summary>
    /// Interaction logic for ServerConnectionSettingsAuthorization.xaml
    /// </summary>
    public partial class ServerConnectionSettingsAuthorization : Window
    {
        public ServerConnectionSettingsAuthorization()
        {
            InitializeComponent();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordField.Password != "123placement")
                WrongPasswordLabel.Content = "Wrong Password!";
            else
            {
                this.Opacity = 0.10;
                ServerConnectionSettings serverSettingWindow = new ServerConnectionSettings();
                serverSettingWindow.ShowDialog();
                this.Close();
            }
        }
    }
}
