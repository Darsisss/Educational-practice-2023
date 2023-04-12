using BildingTime.Model.Database;
using BildingTime.ViewModel;
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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            var category = AppData.db.ProductСategory.ToList();
            var product = AppData.db.Product.ToList();
            ProductName.ItemsSource = productname;
            Category.ItemsSource = category;
            Product.ItemsSource = product;
        }
    }
}
