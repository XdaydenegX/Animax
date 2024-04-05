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

namespace Animax
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = Util.GetProduct().Where(product => Basket.getBasket().Contains(product.id));
            var sum_price = Util.GetProduct().Where(product => Basket.getBasket().Contains(product.id)).Sum(product => product.price);
            ResultLabel.Content = sum_price.ToString();
        }

        private void order_up_ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Успех оплаты, итоговая сумма составляет {ResultLabel.Content}", "Чек", MessageBoxButton.OK, MessageBoxImage.Information);
            Basket.ClearBasket();
            ShopWindow shopWindow = (ShopWindow)Window.GetWindow(this);
            shopWindow.ShopFrame.Content = new HomePage();
            return;
        }
    }
}
