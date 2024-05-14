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
    /// Логика взаимодействия для ServicesPay.xaml
    /// </summary>
    public partial class ServicesPay : Page
    {
        public ServicesPay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод, вызываемый при клике на любую функцию страницы.
        /// </summary>
        /// <param name="sender">Нажатый пользователем объект Grid</param>
        /// <param name="e">Объект события</param>
        private void GridMouseClick(object sender, MouseButtonEventArgs e)
        {
            Grid clickedGrid = sender as Grid;

            //Выполнение действий в зависимости от нажатого объекта Grid
            switch (clickedGrid.Name) 
            {
                case "PhoneCommunicationGrid":
                    
                    EnterPhone enterPhonePage = new EnterPhone();
                    //Отключение видимости линии скролла
                    ScrollViewerObject.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

                    //Очистка всех строк в объекте Grid (Для уменьшения высоты всей страницы)
                    GridObject.RowDefinitions.Clear();
                    NavigationFrame.NavigationService.Navigate(enterPhonePage);
                    break;
                
                //Доступные для реализации другие кнопки (Сейчас действуют как заглушки).
                case "MoneyTransfersGrid":
                    MessageBox.Show("В разработке");
                    break;

                case "TransferToCardGrid":
                    MessageBox.Show("В разработке");
                    break;

                case "BankServicesGrid":
                    MessageBox.Show("В разработке");
                    break;

                case "CommunalServicesGrid":
                    MessageBox.Show("В разработке");
                    break;
            }
        }
    }
}
