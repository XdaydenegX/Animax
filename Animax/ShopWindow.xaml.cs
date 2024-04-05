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
using System.Xml.Serialization;

namespace Animax
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
            ShopFrame.Content = new HomePage();
        }

        private void Category_RequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            ShopFrame.Content = new ProductPage();
        }

        private void Banner_RequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            ShopFrame.Content = new HomePage();
        }

        private void Profile_RequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            ShopFrame.Content = new ProfilePage();
        }

        private void Order_RequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            ShopFrame.Content = new OrderPage();
        }

    }
}
