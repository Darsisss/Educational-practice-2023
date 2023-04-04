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
                var CurrentUser = AppData.db.User.FirstOrDefault(u => u.UserLogin == TbLogin.Text && u.UserPassword == TbPasswd.Text);
                if (CurrentUser != null)
                {
                    DataWindow NewWindow = new DataWindow();

                    NewWindow.Show();

                    this.Close();
                }
                else
                {
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
