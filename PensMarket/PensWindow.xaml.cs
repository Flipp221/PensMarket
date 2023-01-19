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
        public static PenEntities1 db = new PenEntities1();
        public List<Pens> pens = new List<Pens>();
        public PensWindow()
        {
            InitializeComponent();
            RefreshComboBox();
        }
        int pageSize;
        int pageNumber;
        List<Pens> users = db.Pens.ToList();
        private void Mouse_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PenEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(a => a.Reload());
                ListPens.ItemsSource = PenEntities1.GetContext().Pens.ToList();
            }
        }
        private void CBNumberWrite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageSize = Convert.ToInt32(CBNumberWrite.SelectedItem.ToString());
            RefreshPagination();
        }
        private void RefreshPagination()
        {
            ListPens.ItemsSource = null;
            ListPens.ItemsSource = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
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
            CBNumberWrite.Items.Add("10");
            SortCB.Items.Add("По умолчанию");
            SortCB.Items.Add("По названию");
            SortCB.Items.Add("По типу ручки");
            SortCB.Items.Add("По цвету");
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListPens.ItemsSource = null;
            if (SortCB.SelectedIndex == 0)
            {
                ListPens.ItemsSource = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            }
            else if (SortCB.SelectedIndex == 1)
            {
                var a = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
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
            else if (SortCB.SelectedIndex == 2)
            {
                var a = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                for (int? j = 0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count - 1; i++)
                    {
                        if (a[i].CompareTo(a[i + 1], 3) > 0)
                        {
                            var temp = a[i];
                            a[i] = a[i + 1];
                            a[i + 1] = temp;
                        }
                    }
                }
                ListPens.ItemsSource = a;
            }
            else if (SortCB.SelectedIndex == 3)
            {
                var a = users.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                for (int? j = 0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count - 1; i++)
                    {
                        if (a[i].CompareTo(a[i + 1], 3,5) > 0)
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
            var PensDelete = ListPens.SelectedItems.Cast<Pens>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить сдедующие{PensDelete.Count()} элементов?", "Внимение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PenEntities1.GetContext().Pens.RemoveRange(PensDelete);
                    PenEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    ListPens.ItemsSource = PenEntities1.GetContext().Pens.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            AddPens page = new AddPens((sender as Button).DataContext as Pens);
            page.Show();
            Close();
        }
    }
}
