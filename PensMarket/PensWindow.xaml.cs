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
            RefreshComboBox();
        }
        int pageSize;
        int pageNumber;
        List<Pen> pens = MainWindow.db.Pen.ToList();
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
        private void RefreshComboBox()
        {
            SortCB.Items.Add("По умолчанию");
            SortCB.Items.Add("По названию");
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListPens.ItemsSource = null;
            if (SortCB.SelectedIndex == 0)
            {
                ListPens.ItemsSource = pens.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            }
            else if (SortCB.SelectedIndex == 1)
            {
                var a = pens.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                for (int? j = 0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count - 1; i++)
                    {
                        if (a[i].CompareTo(a[i + 1]) > 0)
                        {
                            var temp = a[i];
                            a[i] = a[i + 1];
                            a[i + 1] = temp;
                        }
                    }
                }
                ListPens.ItemsSource = a;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PensDelete = ListPens.SelectedItems.Cast<Pen>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить сдедующие{PensDelete.Count()} элементов?", "Внимение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PenEntities.GetContext().Pen.RemoveRange(PensDelete);
                    PenEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    ListPens.ItemsSource = PenEntities.GetContext().Pen.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            AddPens page = new AddPens((sender as Button).DataContext as Pen);
            page.Show();
            Close();
        }
    }
}
