using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{/// <summary>
/// Класс знака зодиака
/// </summary>
    public class Zodiac
    {
        public int Id { get; set; }
        /// <summary>
        /// Название зодиака
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Хранилище URL
        /// </summary>
        public string Pool { get; set; }
        /// <summary>
        ///Коллекция пользователя относящийся к пользователя
        /// </summary>
        public virtual ICollection <User> Users {get; set;}
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="date"></param>
        public Zodiac(DateTime date)
        {
            #region Распределение имен
            if (Sersh(date, new DateTime(2001, 3,21), new DateTime(2001, 4, 19)))
            {
                Name = "Овен";
                Pool = "https://horo.mail.ru/prediction/aries/today/";

            }
            if (Sersh(date, new DateTime(2001, 4, 20), new DateTime(2001, 5, 20)))
            {
                Name = "Телец";

            }
            if (Sersh(date, new DateTime(2001,5,21), new DateTime(2001, 6, 20)))
            {
                Name = "Близницы";
                Pool = "https://horo.mail.ru/prediction/gemini/today/";
            }
            if (Sersh(date, new DateTime(2001, 6, 21), new DateTime(2001, 7, 22)))
            {
                Name = "Раки";
                Pool = " https://horo.mail.ru/prediction/cancer/today/";
            }
            if (Sersh(date, new DateTime(2001, 7, 23), new DateTime(2001, 8, 22)))
            {
                Name = "Львы";
                Pool = "https://horo.mail.ru/prediction/leo/today/";

            }
            if (Sersh(date, new DateTime(2001, 8, 23), new DateTime(2001, 9, 22)))
            {
                Name = "Девы";
                Pool = "https://horo.mail.ru/prediction/virgo/today/";
            }
            if (Sersh(date, new DateTime(2001, 9, 23), new DateTime(2001, 10, 22)))
            {
                Name = "Весы";
                Pool= "https://horo.mail.ru/prediction/libra/today/";
            }
            if (Sersh(date, new DateTime(2001, 10, 23), new DateTime(2001, 11, 21)))
            {
                Name = "Скорпион";
                Pool = "https://horo.mail.ru/prediction/scorpio/today/";
            }
            if (Sersh(date, new DateTime(2001, 11, 22), new DateTime(2001, 12, 21)))
            {
                Name = "Стрелец";
                Pool= "https://horo.mail.ru/prediction/sagittarius/today/";

            }
            if (Sersh(date, new DateTime(2001, 12, 22), new DateTime(2002, 1, 20)))
            {
                Name = "Козерог";
                Pool = "https://horo.mail.ru/prediction/capricorn/today/";
            }
            if (Sersh(date, new DateTime(2001, 1, 21), new DateTime(2001, 2, 18)))
            {
                Name = "Водолей";
                Pool= "https://horo.mail.ru/prediction/aquarius/today/";
            }
            if (Sersh(date, new DateTime(2001, 2, 19), new DateTime(2001, 3, 20)))
            {
                Name = "Рыбы";
                Pool = "https://horo.mail.ru/prediction/pisces/today/";

            }
            #endregion
            Users = new List<User>();
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Zodiac()
        {
            Users = new List<User>();
        }
        /// <summary>
        ///Присвоение имени за счет даты
        /// </summary>
        /// <param name="SelectDate"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public bool Sersh(DateTime SelectDate, DateTime StartDate, DateTime EndDate)
        {
            bool temp = false;
#pragma warning disable CS1718 // Выполнено сравнение с той же переменной
            temp = SelectDate >= StartDate && SelectDate < EndDate;
#pragma warning restore CS1718 // Выполнено сравнение с той же переменной

            return temp;

     
        }
        
    }
}
