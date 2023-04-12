using BildingTime.Model.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BildingTime.ViewModel
{
    internal class Connect : BaseModel
    {
        private string _Login;
        private string _Password;


        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Login
        {
            get => _Login;
            set
            {
                _Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public async Task<bool> ValidateUserLoginAndPassword()
        {
            try
            {
                using (var context = new TradeEntities())
                {
                    var user = await context.User.FirstOrDefaultAsync
                        (u => u.UserLogin == _Login && u.UserPassword == _Password);
                    if (user != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка соединения с базой данных!",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

        }
    }
}
