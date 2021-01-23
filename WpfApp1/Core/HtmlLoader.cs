using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Core
{/// <summary>
/// Загружает изходный код странице  из настроик 
/// </summary>
    class HtmlLoader
    {
       readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSetting setting)
        {
            client = new HttpClient();
            url = $"{setting.BaseUrl}/{setting.Prefix}/";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();

            }
            return source;
        }


    }
}
