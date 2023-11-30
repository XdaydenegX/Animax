using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void Sign_Up_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            AuthWindow authwindow = (AuthWindow)Application.Current.MainWindow;
            Frame mainframe = authwindow.MainFrame;
            mainframe.Content = new SignUpPage().SignUpPageGrid;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string login_email_regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (!string.IsNullOrEmpty(login_email_textbox.Text.ToString()) || Regex.IsMatch(login_email_textbox.Text, login_email_regex))
            {
                login_email_error_label.Visibility = Visibility.Hidden;
                login_button.IsEnabled = true;
            }
            else
            {
                login_email_error_label.Visibility = Visibility.Visible;
                login_button.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shopWindow = new ShopWindow();
            shopWindow.Show();
            AuthWindow authwindow = (AuthWindow)Application.Current.MainWindow;
            authwindow.Close();

        }

        private void login_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_password_error_label.Visibility = Visibility.Hidden;

            if (login_password_textbox.Text != "" && login_password_textbox.Text.Length <= 20)
            {
                login_password_error_label.Visibility = Visibility.Visible;
                login_password_error_label.Content = $"{login_password_textbox.Text.Length} / 20";
                login_button.IsEnabled = true;
                login_password_textbox.IsEnabled = true;
            }
            else
            {
                login_password_error_label.Content = "[ ! ]";
                login_password_error_label.Visibility = Visibility.Visible;
                login_button.IsEnabled = false;
            }

        }

    }
}
