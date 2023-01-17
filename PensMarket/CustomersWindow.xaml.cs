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

namespace PensMarket
{
    /// <summary>
    /// Логика взаимодействия для CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        public CustomersWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
        public void Refresh()
        {
            ListCustomers.ItemsSource = null;
            ListCustomers.ItemsSource = MainWindow.db.Customer.ToList();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow page = new RegWindow((sender as Button).DataContext as Customer);
            page.Show();
            Close();
        }
    }
}
