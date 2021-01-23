using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Core
{
    class ParserWorker<T> where T: class
    {
        IParser<T> parser;
        IParserSetting parserSetting;
        HtmlLoader loader;
        bool isActive;

        #region PropperLies
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }

        }
        public IParserSetting Setting
        {
        
        get
            {
                return parserSetting;

            }
    set
            {
                parserSetting = value;
                loader = new HtmlLoader(value);

}
        }

        public bool IsActive
{
    get
    {
        return isActive;
    }
}
#endregion

     public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
       
        public ParserWorker(IParser<T> parser)
        {

            this.parser = parser;

        }
        public ParserWorker(IParser<T> parser,IParserSetting parserSetting) : this(parser)
         {

            this.parserSetting = parserSetting;

        }
        public void Start()
        {
            isActive = true;
             Worker();
        }
        public void Abort()
        {
            isActive = false;

        }
        private async void Worker()
        {

            for (int i = parserSetting.StartPoint; i <= parserSetting.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);
                var dosParser = new HtmlParser();

                var document = await dosParser.ParseDocumentAsync(source);

                var result= parser.Parser(document);
                OnNewData?.Invoke(this, result);


            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }

    }
}
