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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Переход в окно регистрации 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Login_Window.Hide();
            Registration window = new Registration();
            window.ShowDialog();

        }
        /// <summary>
        /// Проверка пользователя 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            bool temp = false;
            User userLogin = new User();
            
            using (MyDbContex contex = new MyDbContex())//Проверяем существует уже такой пользователь или нет 
            {
                var user = contex.Users.Where(p => p.Login == Login_textbox.Text);
                if (user != null)
                {
                    
                    foreach (User p in user)
                    {
                        if (p.Password == Password_textbox.Text)
                        {
                            temp = true;
                            userLogin = p;

                        }
                        else 
                        {
                            Debug_TextBloc.Text = "Проверьте правильность пароля";
                        }
                    }
                }
                else 
                {
                    Debug_TextBloc.Text = "Пользователь с таким логином не найдет";
                }
                if ( temp)
                {
                    this.Login_Window.Hide();
                    horoscope_Window window = new horoscope_Window(userLogin);
                  
                    window.ShowDialog();
                }
            }
        }
    }
}
