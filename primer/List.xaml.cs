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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        int cc = MainWindow.context.Product.Count();
        List<Product> qq = new List<Product>();

        public List()
        {
            InitializeComponent();
            // combobox.ItemsSource = MainWindow.context.Manufacturer.ToList();
            //  combobox.DisplayMemberPath = "name";
            qq = MainWindow.context.Product.ToList();

            ProductLV.ItemsSource = qq;
            voz.IsChecked = true;
         

        }
        bool po = false;
        bool sr = false;
        bool fil = false;
        private void add_Click(object sender, RoutedEventArgs e)
        {
            Navigator.frame.Navigate(new AddEd(null));

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Product prod = ProductLV.SelectedItem as Product;
            AddEd proded = new AddEd(prod) { prod123 = prod };
            Navigator.frame.Navigate(proded);
            
            
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            Product prod = ProductLV.SelectedItem as Product;

            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить товар?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No) return;
            try
            {
                MainWindow.context.Product.Remove(prod);
                MainWindow.context.SaveChanges();
                MessageBox.Show("Товар удален");
                Navigator.frame.Navigate(new List());
            }
            catch
            {
                MessageBox.Show("Данные удалить нельзя");
            }
        }
        void SORT()
        {
            qq = MainWindow.context.Product.ToList();
            if (po == true)
            {
                var p = qq.Where(s => s.Name.ToLower().StartsWith(poisk.Text)).ToList();
               
                //ToLower для стринг
                //ToString для инти
                //DayOfYear для даты
                qq = p;
            }
            if (fil == true)
            {
                int diskX = 0;
                int diskM = 0;
                // var m = qq.Where(s => s.id_staff == manu.Text).ToList();
                if (filt.SelectedIndex == 1)
                {
                    diskX = 10; diskM = 0;
                }
                if(filt.SelectedIndex == 2)
                {
                    diskX = 15; diskM = 10;
                }
                if (filt.SelectedIndex == 3)
                {
                    diskX = 100; diskM = 15;
                }
                var m = qq.Where(s => s.Discount < diskX && s.Discount >= diskM).ToList();
                qq = m;
            }
            if (sr == true)
            {
                //var v = qq.OrderBy(s => s.Date).ToList();
                var v = qq.OrderBy(s => s.Price).ToList();
                qq = v;
            }
            else
            {
                var y = qq.OrderByDescending(s => s.Price).ToList();
                qq = y;
            }
            ProductLV.ItemsSource = qq;
            count.Text = qq.Count.ToString() + " из " + cc.ToString();

        }
        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (poisk.Text == "") po = false;
            else po = true;
            SORT();
        }

       

        private void filt_DropDownClosed(object sender, EventArgs e)
        {
            if (filt.Text == "Все диапазоны") fil = false;
            else fil = true;
            SORT();
        }


        private void voz_Checked(object sender, RoutedEventArgs e)
        {
            sr = true;
            SORT();
        }

        private void ub_Checked(object sender, RoutedEventArgs e)
        {
            sr = false;
            SORT();
        }
    }
}
