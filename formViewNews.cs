using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pulsuz_Mesaj
{
    public partial class formViewNews : Form
    {
        string newsId, agent;
        public formViewNews(string newsId, string agent)
        {
            InitializeComponent();
            this.newsId = newsId;
            this.agent = agent;
        }

        private void formViewNews_Load(object sender, EventArgs e)
        {
            //newsId ye uygun xeber linkini proqramin webbrosderle gosterek
            string url = "http://yoxlama.com/azinf/news.php?id=" + newsId + "&agent=" + agent + "&program";
            webBrowser.Navigate(url);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = webBrowser.Document.Title;
            int tmpHeight = webBrowser.Document.Body.ScrollRectangle.Height ;
            if (tmpHeight < this.Height)
            {
                this.Height = tmpHeight+75;
            }
        }
    }
}
