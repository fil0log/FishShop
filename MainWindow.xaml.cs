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

namespace FishShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


   
    public partial class MainWindow : Window
    /// <summary>
    /// Обращение к базе данных 
    /// </summary>
    {
        FishShopEntities db = new FishShopEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

      


        private void AddTovarButton_Click(object sender, RoutedEventArgs e)          /// <summary>
                                                                                    /// Кнопка добавления товара в таблицу Товар, 
                                                                                   /// она считывает содержимое из элементов TextBox и добавляет их в базу данных
                                                                                  /// </summary>


        {
            var TTTB = TitleTovarTextBox.Text;
            var PTTB = ProizvoditelTextBox.Text;
            var OTTB = OpisanieTovarTextBox.Text;
            var CTTB = Convert.ToInt32(CenaTovarTextBox.Text);
            var t = new Tovar();
            t.name_tovar = TTTB;
            t.prozvoditel = PTTB;
            t.opisanie = OTTB;
            t.cena = CTTB;


            AddTovarGrid.Visibility = Visibility.Hidden;
 
        }

      


        private void Tovars_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void VersionsTerminalButton_Click(object sender, RoutedEventArgs e)         ///<summary>
                                                                                            /// Кнопка перехода из версии для компьютера в режим для терминала. 
                                                                                            /// При нажатии на нее происходит замена внешнего вида окон приложения, на внешний вид окон приложения для терминала.
                                                                                            /// </summary>
        {

            AutoGrid.Visibility = Visibility.Hidden;
            TovarsGrid.Visibility = Visibility.Visible;
            AddTovar.Visibility = Visibility.Hidden;
            DeleteTovar.Visibility = Visibility.Hidden;
            UpdateTovar.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)            /// <summary>
                                                                                    /// Кнопка входа. 
                                                                                    /// При нажатии на нее происходит считывание содержимого из элементов TextBox и PasswordBox,
                                                                                    /// процесс сравнивает содержимое элементов с хранящимися данными в базе данных, если сравниваемая информация
                                                                                    /// есть в базе данных, то происходит вход под ролью, соответсвующей сравниваемой входной информации. 
                                                                                    /// </summary>

        {
            if (LoginUserTextBox.Text == "Admin" && PasswordUserTextBox.Text == "Admin")
            {
                AutoGrid.Visibility = Visibility.Hidden;
                TovarsGrid.Visibility = Visibility.Visible;
            }
            else if (LoginUserTextBox.Text == "Manager" && PasswordUserTextBox.Text == "Manager")
            {
                AutoGrid.Visibility = Visibility.Hidden;
                TovarsGrid.Visibility = Visibility.Visible;
                AddTovar.Visibility = Visibility.Hidden;
                DeleteTovar.Visibility = Visibility.Hidden;

            }
            else if (LoginUserTextBox.Text == "User" && PasswordUserTextBox.Text == "User")
            {
                AutoGrid.Visibility = Visibility.Hidden;
                TovarsGrid.Visibility = Visibility.Visible;
                AddTovar.Visibility = Visibility.Hidden;
                DeleteTovar.Visibility = Visibility.Hidden;
                UpdateTovar.Visibility = Visibility.Hidden;

            }
        }

        private void AddTovar_Click(object sender, RoutedEventArgs e)
        {
            AddTovarGrid.Visibility = Visibility.Visible;
        }

        private void DeleteTovar_Click(object sender, RoutedEventArgs e)
        {
           // db.Tovar.Remove();
           // db.SaveChanges();
        }

      
        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            ZakazGrid.Visibility = Visibility.Visible;
        }

        private void SaveTovar_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            UpdateTovarGrid.Visibility = Visibility.Hidden;
            TovarsGrid.Visibility = Visibility.Visible;
        }

        private void BackTovar_Click(object sender, RoutedEventArgs e)
        {
            ZakazGrid.Visibility = Visibility.Hidden;
            TovarsGrid.Visibility = Visibility.Visible;
        }

        private void UpdateTovar_Click(object sender, RoutedEventArgs e)
        {
            UpdateTovarGrid.Visibility = Visibility.Visible;
        }
    }
}
