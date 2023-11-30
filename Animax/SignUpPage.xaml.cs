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
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        public void Sign_In_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            AuthWindow authwindow = (AuthWindow)Application.Current.MainWindow;
            Frame mainframe = authwindow.MainFrame;
            mainframe.Content = new SignInPage().SignInPageGrid;
        }

        private void sign_up_email_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sign_up_email_regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            if (!string.IsNullOrEmpty(sign_up_email_textbox.Text.ToString()) || Regex.IsMatch(sign_up_email_textbox.Text, sign_up_email_regex))
            {
                sign_up_button.IsEnabled = true;
            }
            else
            {
                sign_up_button.IsEnabled = false;
            }
        }

        private void sign_up_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            sign_up_password_error_label.Visibility = Visibility.Hidden;

            if (sign_up_password_textbox.Text != "" && sign_up_password_textbox.Text.Length <= 20 || sign_up_repeat_password_textbox.Text == sign_up_password_textbox.Text)
            {
                sign_up_password_error_label.Visibility = Visibility.Visible;
                sign_up_password_error_label.Content = $"{sign_up_password_textbox.Text.Length} / 20";
                sign_up_button.IsEnabled = true;
                sign_up_password_textbox.IsEnabled = true;
            }
            else
            {
                sign_up_password_error_label.Content = "[ ! ]";
                sign_up_password_error_label.Visibility = Visibility.Visible;
                sign_up_button.IsEnabled = false;
            }
        }

        private void sign_up_repeat_password_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            sign_up_repeat_password_error_label.Visibility = Visibility.Hidden;

            if (sign_up_repeat_password_textbox.Text != "" && sign_up_repeat_password_textbox.Text.Length <= 20 && sign_up_repeat_password_textbox.Text == sign_up_password_textbox.Text)
            {
                sign_up_repeat_password_error_label.Visibility = Visibility.Visible;
                sign_up_repeat_password_error_label.Content = $"{sign_up_repeat_password_textbox.Text.Length} / 20";
                sign_up_button.IsEnabled = true;
                sign_up_repeat_password_textbox.IsEnabled = true;
                sign_up_password_error_label.Visibility= Visibility.Hidden;
            }
            else
            {
                sign_up_password_error_label.Content = "[ ! ]";
                sign_up_repeat_password_error_label.Visibility = Visibility.Visible;
                sign_up_button.IsEnabled = false;
            }
        }
    }
}
