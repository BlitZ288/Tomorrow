
using System.Collections.Generic;

namespace WpfApp1.Core.Mailll
{
    class MailSetting : IParserSetting
    {
        public MailSetting(string baseUrl) 
        {
            BaseUrl = baseUrl;
        
        }

        public string BaseUrl { get; set; } 
        public string Prefix { get; set; } 
        public int StartPoint { get ; set ; }
        public int EndPoint { get ; set ; }
    }
}
