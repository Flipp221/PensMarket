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

namespace PensMarket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PenEntities db = new PenEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BPas_Click(object sender, RoutedEventArgs e)
        {
            var a = MainWindow.db.Customer.Where(z => z.Name == TLog.Text && z.Password == PPas.Password).FirstOrDefault();
            if (a != null)
            {
                MessageBox.Show("Здравсвуйте!");
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow(null);
            regWindow.Show();
            Close();
        }
    }
}
