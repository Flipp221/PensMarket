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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        private Customer _customer = new Customer();
        public RegWindow(Customer selected)
        {
            InitializeComponent();
            if (selected != null)
                _customer = selected;

            DataContext = _customer;
            cbType.ItemsSource = PenEntities.GetContext().TypeCustomer.ToList();

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(tbName.Text))
                stringBuilder.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(tbSurname.Text))
                stringBuilder.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(tbPatron.Text))
                stringBuilder.AppendLine("Укажите отчество");
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
                stringBuilder.AppendLine("Укажите телефон");
            if (string.IsNullOrWhiteSpace(tbPas.Text))
                stringBuilder.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(tbRoll.Text))
                stringBuilder.AppendLine("Укажите роль");
            if (_customer.TypeCustomer == null)
                stringBuilder.AppendLine("Укажите тип");

            _customer.id_Role = 2;
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }
            if (_customer.id_Customer == 0)
            {
                PenEntities.GetContext().Customer.Add(_customer);
            }
            try
            {
                PenEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
