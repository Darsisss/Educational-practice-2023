using BildingTime.Model.Database;
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

namespace BildingTime.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            btnSingIn.Content = "Подождите...";

            using (var db = new TradeEntities())
            {
                

                var CurrentUser = db.User.FirstOrDefault(u => u.UserLogin == txtBoxLogin.Text &&
                            u.UserPassword == pswrdBoxPassword.Password && u.UserRoleId == 3);
                var CurrentManager = db.User.FirstOrDefault(u => u.UserLogin == txtBoxLogin.Text 
                            && u.UserPassword == pswrdBoxPassword.Password && u.UserRoleId == 2);
                var CurrentAdmin = db.User.FirstOrDefault(u => u.UserLogin == txtBoxLogin.Text && 
                            u.UserPassword == pswrdBoxPassword.Password && u.UserRoleId == 1);

                if (CurrentUser != null)
                {

                    ClientWindow ClientWindow = new ClientWindow();
                    ClientWindow.Show();
                    this.Hide();
                }
                else if (CurrentManager != null)
                {
                    ManagerWindow managerWindow = new ManagerWindow();
                    managerWindow.Show();
                    this.Hide();
                }
                else if (CurrentAdmin != null)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", 
                        "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                
            }

            btnSingIn.Content = "Войти";
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow ClientWindow = new ClientWindow();
            ClientWindow.Show();
            this.Hide();
        }
    }
}
