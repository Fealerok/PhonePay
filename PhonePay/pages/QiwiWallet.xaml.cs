using PhonePay.windows;
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

namespace PhonePay.pages
{
    /// <summary>
    /// Логика взаимодействия для QiwiWallet.xaml
    /// </summary>
    public partial class QiwiWallet : Page
    {
        public QiwiWallet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на кнопку, предназначенную для ввода символов
        /// </summary>
        /// <param name="sender">Объект кнокпи Button</param>
        /// <param name="e">Объект события</param>
        private void PrintSymbol(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (PhoneField.Text.Length != 12)
            {
                PhoneField.Text += clickedButton.Content;
                if (PhoneField.Text.Length == 12)
                {
                    NextPageButton.IsEnabled = true;
                }
                else
                {
                    NextPageButton.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на кнопку удаления символа
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void DeleteSymbol(object sender, RoutedEventArgs e)
        {
            //Если длина больше 2, т.е. символов больше, чем +7, то удаляется последний символ поля.
            if (PhoneField.Text.Length > 2)
            {
                PhoneField.Text = PhoneField.Text.Substring(0, PhoneField.Text.Length - 1);
                PhoneField.CaretIndex = PhoneField.Text.Length;
            }

            //Если кол-во символов в поле меньше, чем требуемая длина номера телефона, то кнопка деактивируется для перехода на новую страницу.
            if (PhoneField.Text.Length < 12)
            {
                NextPageButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Метод, срабатываемый после нажатия на кнопку "Войти в профиль"
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void LoginToProfile(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Успешный вход!");
            MainPage mainPage = new MainPage();
            NavigationFrame.NavigationService.Navigate(mainPage);

        }

        /// <summary>
        /// Открытие главного окна
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события </param>
        private void TransferToNextWindow(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            NavigationFrame.NavigationService.Navigate(mainPage);
        }
    }
}
