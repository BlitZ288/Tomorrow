using System;
using System.Windows.Controls;

namespace WpfApp1
{/// <summary>
/// Класс пользователя 
/// </summary>
    public class User
    {
       public int Id { get; set;  }
        /// <summary>
        /// Имя пользователя
        /// </summary>
       public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
       public string Password { get; set; }
        /// <summary>
        /// День рождения пользователя 
        /// </summary>
       public DateTime Birthday { get; set; }

      /// <summary>
      /// Id знака
      /// </summary>
        public int? ZodiacId { get; set; }
        /// <summary>
        /// Знак зодиака
        /// </summary>
        public virtual  Zodiac Zodiac { get; set; }


        /// <summary>
        ///инициализация
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="birtday"></param>
        /// <param name="debug"></param>
        /// <param name="zodiac"></param>
        public User(TextBox login, TextBox password, DatePicker birtday,TextBlock debug, Zodiac zodiac)
  
        { 

              if (string.IsNullOrWhiteSpace(login.Text))
                {
                    debug.Text = "Имя пользователя не может быть пустым";
                 

                }
                if (password.Text.Length <= 4)
                {
                   debug.Text = "Пароль должен состоят минимум из 4 символов";
                

                }
                if (birtday.SelectedDate < DateTime.Parse("01.01.1900")&&birtday.SelectedDate.Value==null)
                {
                    debug.Text = "Проверте правильность даты";

                }
           
            Login = login.Text;
            Password = password.Text;
            Birthday = (DateTime)birtday.SelectedDate.Value;
            Zodiac = zodiac;
        }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public User() { }

    }
}
