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
        }
        private void Mouse_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PenEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                ListPens.ItemsSource = PenEntities.GetContext().Pen.ToList();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }

        private void btnAddPens_Click(object sender, RoutedEventArgs e)
        {
            AddPens addPens = new AddPens(null);
            addPens.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            AddPens page = new AddPens((sender as Button).DataContext as Pen);
            page.Show();
            Close();
        }
    }
}
