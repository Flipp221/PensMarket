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
    /// Логика взаимодействия для PensWindow.xaml
    /// </summary>
    public partial class PensWindow : Window
    {
        public PensWindow()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            ListPens.ItemsSource = null;
            ListPens.ItemsSource = MainWindow.db.Pen.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
    }
}
