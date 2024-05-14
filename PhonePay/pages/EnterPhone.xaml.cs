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
    /// Логика взаимодействия для EnterPhone.xaml
    /// </summary>
    public partial class EnterPhone : Page
    {
        public EnterPhone()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, вызываемый при клике на любую кнопку, которая печатает в поле ввода телефона символ
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
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
        /// Открытие окна с вводом суммы пополнения
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события </param>
        private void TransferToNextWindow(object sender, RoutedEventArgs e)
        {
            new EnterCash(PhoneField.Text).ShowDialog();
        }

        /// <summary>
        /// Переход на новую страницу через Frame
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void TransferToNextPage(object sender, RoutedEventArgs e)
        {
            // Перейти на новую страницу
            ServicesPay servicesPayPage = new ServicesPay();
            NavigationFrame.NavigationService.Navigate(servicesPayPage);
        }

    }
}
