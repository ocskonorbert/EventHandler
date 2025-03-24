using EventHandler;
using System;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.UserActivities;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using EventHandler;

namespace EventHandler
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (!IsValidEmail(email))
            {
                ErrorTextBlock.Text = "Hibás email formátum!";
                return;
            }

            if (!IsValidPassword(password))
            {
                ErrorTextBlock.Text = "A jelszónak tartalmaznia kell kisbetűt, nagybetűt és számot!";
                return;
            }

            // Ide jöhetne a valódi hitelesítés
            // Mockolt belépés:
            if (email == "teszt@example.com" && password == "Teszt123")
            {
                Frame.Navigate(typeof(EventSelectionPage)); // Sikeres belépés után listázó oldalra lépés
            }
            else
            {
                ErrorTextBlock.Text = "Helytelen belépési adatok!";
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        private bool IsValidPassword(string password)
        {
            bool hasLower = Regex.IsMatch(password, "[a-z]");
            bool hasUpper = Regex.IsMatch(password, "[A-Z]");
            bool hasDigit = Regex.IsMatch(password, "[0-9]");

            return hasLower && hasUpper && hasDigit;
        }
    }
}
