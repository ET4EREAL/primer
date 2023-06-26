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

namespace primer
{
    /// <summary>
    /// Логика взаимодействия для AddEd.xaml
    /// </summary>
    public partial class AddEd : Page
    {
        Product prod = new Product();
        public Product prod123 { get; set; } = new Product();

        public AddEd(Product pp)
        {
            InitializeComponent();
            if (pp == null)
            {
                DataContext = prod;
                gl.Content = "Добавление";
            }
            else
            {
                DataContext = pp;
                gl.Content = "Изменение";
            }
            manufacturer_idTextBox.ItemsSource = MainWindow.context.Manufacturer.ToList();
            manufacturer_idTextBox.DisplayMemberPath = "name";
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate(new List());

        }

        private void aded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = manufacturer_idTextBox.SelectedIndex + 1;
                if (DataContext == prod)
                {
                    if (prod.Discount > 50) MessageBox.Show("Скидка не может быть больше 50%");
                    else
                    {
                        prod.Manufacturer_id = k;
                        prod.Photo = "p.png";

                        MainWindow.context.Product.Add(prod);
                        MainWindow.context.SaveChanges();
                        Navigator.frame.Navigate(new List());
                    }
                }
                else
                {
                    MainWindow.context.SaveChanges();
                    Navigator.frame.Navigate(new List());
                }
                MessageBox.Show("Запись сохранена!");

            }
            catch { 
            MessageBox.Show("Ошибка. Введите корректные данные");
            }
        }

        private void photoTextBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
