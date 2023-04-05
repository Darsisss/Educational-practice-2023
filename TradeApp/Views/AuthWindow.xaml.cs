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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradeApp.Models;

namespace TradeApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButnSignIn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                btn.Content = "Подождите...";
                var CurrentUser = AppData.db.User.FirstOrDefault(u => u.UserLogin == TbLogin.Text && u.UserPassword == TbPasswd.Password);
                if (CurrentUser != null)
                {
                    if (CurrentUser.UserRoleId == 1)
                    {
                        Hide();
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                    }
                    else if (CurrentUser.UserRoleId == 2)
                    {
                        Hide();
                        Manager manager = new Manager();
                        manager.Show();
                    }

                }
                else
                {
                    btn.Content = "Sign in2";
                    MessageBox.Show("Wrong Login or Password");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Critical App Malfunction");
            }
        }
    }
}
