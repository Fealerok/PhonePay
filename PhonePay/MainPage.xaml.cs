using PhonePay.pages;
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

namespace PhonePay
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void NavigateToMainWindow()
        {
            NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Метод, вызываемый при клике на выбираемую функцию пользователем (Оплата услуг, Qiwi кошелёк и поиск )
        /// </summary>
        /// <param name="sender">Элемент Grid, который был нажат</param>
        /// <param name="e">Объект события</param>
        private void GridMouseClick(object sender, MouseButtonEventArgs e)
        {
            Grid clickedGrid = sender as Grid;

            //Выполнение перехода на другую страницу через объект Frame в зависимости от имени нажимаемого объекта Grid
            switch (clickedGrid.Name)
            {
                case "ServicesPayGrid":
                    ServicesPay servicesPayPage = new ServicesPay();
                    NavigationFrame.NavigationService.Navigate(servicesPayPage);
                    break;

                case "QiwiWalletGrid":
                    QiwiWallet qiwiWalletPage = new QiwiWallet();
                    NavigationFrame.NavigationService.Navigate(qiwiWalletPage);
                    break;

                case "SearchGrid":
                    Search searchPage = new Search();
                    NavigationFrame.NavigationService.Navigate(searchPage);
                    break;
            }
        }
    }
}
