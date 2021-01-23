using AngleSharp.Html.Dom;

namespace WpfApp1.Core
{/// <summary>
/// Это обобщенный интерфейс , это значит что классы которое его реализовуют будут вовзращать данные ссылочного типа   
/// </summary>
/// <typeparam name="T"></typeparam>
    interface IParser<T> where T:class 
    {
        T Parser(IHtmlDocument document);




    }
}
