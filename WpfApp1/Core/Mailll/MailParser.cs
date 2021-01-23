using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Core.Mailll
{
    class MailParser : IParser<string[]>
    {
        public string[] Parser(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("article__item article__item_alignment_left article__item_html"));

            foreach(var item in items)
            {
                list.Add(item.TextContent);

            }
            return list.ToArray();

        }
    }
}
