using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Core;
using WpfApp1.Core.Mailll;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для horoscope_Window.xaml
    /// </summary>
    public partial class horoscope_Window : Window
    {
        ParserWorker<string[]> parser;
        /// <summary>
        /// Выводим информацию о пользователя, и выделение памяти для парсера
        ///  </summary>
        /// <param name="user"></param>
        public horoscope_Window(User user)
        {
            InitializeComponent();
            Login_canvas.Content = user.Login;
            Birthdei_canvas.Content = user.Birthday;
            Zodiac_canvas.Content = user.Zodiac.Name;
            parser = new ParserWorker<string[]>((new MailParser()));
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
        /// <summary>
        /// Вывод информации
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listbox.ItemsSource = arg2;
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Ваш горскоп на сегодня");
        }
        /// <summary>
        /// Кнопка начала парсинга 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            using(MyDbContex contex =new MyDbContex())//Выдает именно тот гороскоп
            {
                var zodiacs = contex.Zodiacs.Where(p => p.Name == Zodiac_canvas.Content.ToString());
              foreach(Zodiac zodiac in zodiacs)
                {
                    parser.Setting = new MailSetting(zodiac.Pool);
                   
                    parser.Start();
                }

            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }

        private void Listtt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listtt_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Horoscope_Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
