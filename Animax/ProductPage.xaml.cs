using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            var allProducts = Util.GetProduct();
            ProductsListView.ItemsSource = allProducts;
            category_box.ItemsSource = Util.GetallCategory();
        }

        private void category_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            confirm_category_button.Visibility = Visibility.Visible;
        }

        private void confirm_category_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (category_box.Text == "")
            {
                ProductsListView.ItemsSource = Util.GetProduct();
            }
            else
            {
                ProductsListView.ItemsSource = Util.getProductsByCategory(category_box.Text);
            }
        }

        private void order_up_ButtonClick(object sender, RoutedEventArgs e)
        {

            int productId = (int)((Button)sender).Tag;

            Product currentProduct = Util.GetProduct().Find(x => x.id == productId);

            MessageBox.Show($"{currentProduct.name} {Basket.Count(currentProduct.id)}");

            Basket.addProduct(currentProduct.id);

            int countInBasket = Basket.Count(currentProduct.id);

            currentProduct.inBasket = "В корзине";

            currentProduct.inBasketCount = $"{countInBasket}";

            ProductsListView.Items.Refresh();

        }
    }
}
