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
    /// Логика взаимодействия для AddPens.xaml
    /// </summary>
    public partial class AddPens : Window
    {
        private Pens _pen = new Pens();
        public AddPens(Pens selected)
        {
            InitializeComponent();
            if (selected != null)
                _pen = selected;

            DataContext = _pen;
            cbCompany.ItemsSource = PenEntities1.GetContext().Company.ToList();
            cbTypePen.ItemsSource = PenEntities1.GetContext().TypePen.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tbName.Text))
                stringBuilder.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(tbColor.Text))
                stringBuilder.AppendLine("Укажите Цвет");
            if (string.IsNullOrWhiteSpace(tbPrice.Text))
                stringBuilder.AppendLine("Укажите цену");
            if (_pen.TypePen == null)
                stringBuilder.AppendLine("Укажите тип");
            if (_pen.Company == null)
                stringBuilder.AppendLine("Укажите компанию");


            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }
            if (_pen.id_Pen == 0)
            {
                PenEntities1.GetContext().Pens.Add(_pen);
            }
            try
            {
                PenEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                PensWindow pensWindow = new PensWindow();
                pensWindow.Show();
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
