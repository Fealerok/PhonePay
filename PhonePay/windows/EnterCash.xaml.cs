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
using System.Windows.Shapes;

namespace PhonePay.windows
{
    /// <summary>
    /// Логика взаимодействия для EnterCash.xaml
    /// </summary>
    public partial class EnterCash : Window
    {
        //Поля баланса и номера телефона и список сотовых операторов
        private int _balance = 0;
        private string _phoneNumberString;
        private List<string> _mobileOperators = new List<string> {"Билайн", "МТС", "Мегафон", "Теле2", "Тинькофф Мобайл" };
        public EnterCash(string PhoneNumberString)
        {
            InitializeComponent();
            PhoneNumber.Text = PhoneNumberString;
            _phoneNumberString = PhoneNumberString;

            //Случайная подставновка оператора мобильной связи.
            MobileOperator.Text = $"Оператор: {_mobileOperators[new Random().Next(0, _mobileOperators.Count)]}";
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на кнопки "Внести n-ое кол-во рублей". Добавляет сумму в переменную баланса
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void IncreaseBalance(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            
            //Берется содержимое кнопки, например "Внести 100р", затем разделяется на две части - Внести и 100р. Из второй части берется кол-во рублей.
            _balance += int.Parse(clickedButton.Content.ToString().Split(" ")[1].Split("р")[0]);

            Balance.Text = $"Баланс: {_balance}";
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на кнопку "Пополнить баланс"
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void DepositeToBalance(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Телефон {_phoneNumberString} пополнен на сумму {_balance}");
            this.Close();
        }
    }
}
