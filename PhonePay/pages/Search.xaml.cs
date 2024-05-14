using Microsoft.Data.Sqlite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace PhonePay.pages
{

    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();

            //Загрузка всех услуг из БД
            LoadAllServices(SearchField.Text);
        }

        /// <summary>
        /// Функция, возвращаемая кнопку, которая содержит в себе название услуги
        /// </summary>
        /// <param name="buttonContent">Название сервиса</param>
        /// <returns>Объект кнопки Button</returns>
        private Button GetServiceButton(string buttonContent)
        {
            Button serviceButton = new Button();
            serviceButton.Width = 300;
            serviceButton.Height = 100;
            serviceButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            serviceButton.VerticalContentAlignment = VerticalAlignment.Center;
            serviceButton.Margin = new Thickness(130, 30, 0, 0);
            serviceButton.Click += OpenChoosedService;

            TextBox contentButton = new TextBox();
            contentButton.Text = buttonContent;
            contentButton.FontSize = 30;
            contentButton.BorderThickness = new Thickness(0);
            contentButton.IsReadOnly = true;
            contentButton.Background = Brushes.Transparent;
            contentButton.TextWrapping = TextWrapping.Wrap;
            contentButton.TextAlignment = TextAlignment.Center;
            contentButton.Cursor = Cursors.Arrow;

            serviceButton.Content = contentButton;
            return serviceButton;
        }

        /// <summary>
        /// Метод, создающий кнопки с названием услуг и добавляющий их в объект WrapPanel
        /// </summary>
        /// <param name="userSearch">Текст со строки поиска</param>
        private void LoadAllServices(string userSearch)
        {
            //Очистка панели (для обновления отображения)
            PanelOfServices.Children.Clear();

            //Открытие соединения с БД
            using (var connection = new SqliteConnection("Data Source=PhonePay.db"))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Services";
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                //Если строка ввода пользователем пустая, то показываются все существующие услуги
                if (userSearch == string.Empty)
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {
                                PanelOfServices.Children.Add(GetServiceButton(reader.GetValue(0).ToString()));
                            }
                        }
                    }
                }

                //Отображение услуг, содержащих в себе текст со строки поиска
                else
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {
                                if (reader.GetValue(0).ToString().ToLower().Contains(userSearch.ToLower()))
                                {
                                    PanelOfServices.Children.Add(GetServiceButton(reader.GetValue(0).ToString()));
                                }
                                
                            }
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// Метод, срабатываемый при нажатии на кнопку с описанным ниже содержанием
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void OpenChoosedService(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            TextBox clickedButtonContent = (TextBox)clickedButton.Content;

            //Если содержание кнопки - сотовый оператор, то открывается страница с вводом номера телефона
            if (clickedButtonContent.Text.ToLower() == "билайн" ||
                clickedButtonContent.Text.ToLower() == "мегафон" ||
                clickedButtonContent.Text.ToLower() == "теле2" ||
                clickedButtonContent.Text.ToLower() == "тинькофф" ||
                clickedButtonContent.Text.ToLower() == "мтс")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("pages/EnterPhone.xaml", UriKind.Relative));
            }

            //Если содержание кнопки - Qiwi, то открывается страница со входом в Qiwi кошелёк.
            else if (clickedButtonContent.Text.ToLower() == "qiwi")
            {
                NavigationFrame.NavigationService.Navigate(new Uri("pages/QiwiWallet.xaml", UriKind.Relative));
            }

            else
            {
                MessageBox.Show("В разработке");
            }
        }

        /// <summary>
        /// Метод, срабатываемый при изменении строки поиска
        /// </summary>
        /// <param name="sender">Текстовое поле TextBox</param>
        /// <param name="e">Объект события</param>
        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox usedTextBox = sender as TextBox;
            LoadAllServices(usedTextBox.Text);
        }

        /// <summary>
        /// Метод, срабатываемый при нажатии на кнопку "Назад" для возвращения в главное меню.
        /// </summary>
        /// <param name="sender">Объект кнопки Button</param>
        /// <param name="e">Объект события</param>
        private void TransferToBack(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}
