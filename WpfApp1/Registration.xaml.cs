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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
           
        }

        private void Regisration_Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Проверка и регистрация пользователя 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            DateTime time = new DateTime(2001, Birthday_DataPicker.SelectedDate.Value.Month, Birthday_DataPicker.SelectedDate.Value.Day);
            Zodiac zodiac = new Zodiac(time);
            using (MyDbContex context = new MyDbContex())
            {
                var user = context.Users.Where(p => p.Login == LoginReg_Textbox.Text);
                if (user != null)
                {
                     if (user.FirstOrDefault()?.Login == null)
                    {
                        if (user.FirstOrDefault()?.Login == LoginReg_Textbox.Text)
                        {
                            debugRegister_Textblock.Text = "Пользователь с таким логином уже существует";
                        }
                        else
                        {
                            User newuser = new User(LoginReg_Textbox, PasswordReg_TextBox, Birthday_DataPicker, debugRegister_Textblock, zodiac);
                            context.Users.Add(newuser);
                            context.SaveChanges();
                            MessageBox.Show("Пользователь успешно создан");
                        }
                    }
                    else
                    {
                        debugRegister_Textblock.Text = "Пользователь с таким логином уже существует";

                    }



                }


            }
            if (debugRegister_Textblock.Text != "")
            {
                Registration_Button.IsEnabled = false;

            }
           

        }

        private void LoginReg_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Registration_Button.IsEnabled = true;
        }

        private void PasswordReg_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Registration_Button.IsEnabled = true;
        }
        private void Birthday_DataPicker_ValueChanged(Object sender, EventArgs e)
        {
            Registration_Button.IsEnabled = true;

        }
        /// <summary>
        /// Преход к окну логина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
         
            this.Regisration_Window.Hide();

            MainWindow window = new MainWindow();
            window.ShowDialog();

        }
    }
}
