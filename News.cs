using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsuz_Mesaj.AzinfServices;

namespace Pulsuz_Mesaj
{
    class News
    {
        AzinfService azinf;
        private string newsAgent;
        public string NewsAgent
        {
            get
            {
                return newsAgent;
            }
            set
            {
                newsAgent = value;
            }
        }
        public News(string agent)
        {
            azinf = new AzinfService();
            //maksimum 10 saniye gozduyur
            azinf.Timeout = 10000;
            this.newsAgent = agent;
        }
        public string[] getNewsArray()
        {
            string[] rt;
            try
            {
                MySoapObject[] news;
                news = azinf.returnNewsArray(this.newsAgent);
                rt = new string[news.Length];
                for (int i = 0; i < news.Length; i++)
                {
                    rt[i] = news[i].newsTitle;
                }
            }
            catch
            {
                rt = new string[1];
                rt[0] = "Xəbərləri göstərmək mümkün olmadı";
            }
            return rt;
        }
        public string getNewsHtml()
        {
            string rt = "";
            try
            {
                MySoapObject[] news;
                news = azinf.returnNewsArray(this.newsAgent);
                int tmp = news.Length;
                for (int i = 0; i < tmp; i++)
                {
                    rt += "<li><a id=\"" + news[i].newsId +
                          "\" style=\"text-decoration:none\" href=\"http://yoxlama.com/azinf\">" + news[i].newsTitle +
                          "</a></li>";
                }
            }
            catch
            {
                rt = "<h3>Xəbərləri göstərmək mümkün olmadı</h3>";
            }
            return rt;
        }
    }
}
