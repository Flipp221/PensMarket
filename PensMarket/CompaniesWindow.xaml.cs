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
    /// Логика взаимодействия для CompaniesWindow.xaml
    /// </summary>
    public partial class CompaniesWindow : Window
    {
        public CompaniesWindow()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh() 
        {
            ListCompanies.ItemsSource = null;
            ListCompanies.ItemsSource = MainWindow.db.Company.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
    }
}
