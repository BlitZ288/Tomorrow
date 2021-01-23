using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Core
{/// <summary>
/// Настройки парсера 
/// </summary>
    interface IParserSetting
    {/// <summary>
    /// Url ссылка
    /// </summary>
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        /// <summary>
        /// С какой странице начать 
        /// </summary>
        int StartPoint { get; set; }
        /// <summary>
        /// Конечная страница парсинга
        /// </summary>
        int EndPoint { get; set; }
    }
}
