using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class User
    {
       public int Id { get; set;  }
       public string Login { get; set; }
       public string Password { get; set; }
       public DateTime Birthday { get; set; }
      
        public int? ZodiacId { get; set; }
       public virtual  Zodiac Zodiac { get; set; }
      
        

        public User(TextBox login, TextBox password, DatePicker birtday,TextBlock debug, Zodiac zodiac)
  
        { ///Todo 
            ///Начать делать БД

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
        public User() { }

    }
}
