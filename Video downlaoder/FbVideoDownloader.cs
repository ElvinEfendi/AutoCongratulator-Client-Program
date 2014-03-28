using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Pulsuz_Mesaj.Video_downlaoder
{
    class FbVideoDownloader : VideoDownloader
    {
        public FbVideoDownloader(string videoPageUrl)
            : base(videoPageUrl)
        {
            this.login = "";
            this.pass = "";
        }

        public FbVideoDownloader(string videoPageUrl, string login, string pass)
            : base(videoPageUrl)
        {
            if (login != this.login || pass != this.pass) //evvelki istifadeci adiyla deyilse
            {
                loggedIn = false; //edek ki yeniden login olsun
            }
            this.login = login;
            this.pass = pass;
        }

        public override string getVideoUrl()
        {
            string url = "";
            string source = getVideoPageSource(videoPageUrl);

            string start_key = "\"video_src\",";
            string finish_key = "\");";
            int start = source.IndexOf(start_key) + 14;
            int finish = source.IndexOf(finish_key, start + 1);

            int length = finish - start;
            string encoded_url = source.Substring(start, length);

            /*
              Evezlemeler:
                           \   ->
                     u00253A   ->   :
                     u00252F   ->   /
                     u00253F   ->   ?
                     u00253D   ->   =
                     u002526   ->   &
             */

            url = encoded_url.Replace(@"\", "");
            url = url.Replace("u00253A", ":");
            url = url.Replace("u00252F", "/");
            url = url.Replace("u00253F", "?");
            url = url.Replace("u00253D", "=");
            url = url.Replace("u002526", "&");

            return url;
        }

        private string getVideoPageSource(string videoPageUrl)
        {
            string urlLogin = "https://www.facebook.com/login.php?login_attempt=1";
            string email = this.login;
            string pass = this.pass;
            string source = "";
            try
            {
                if (loggedIn == false) //login olmamishsa login olsun
                {
                    string lsd = null;
                    //evvelce login lsd -i goturek
                    GetResponseByRequest tmpGrr = new GetResponseByRequest(urlLogin, cc);
                    tmpGrr.StartProcess();
                    StreamReader tmpSr = new StreamReader(tmpGrr.ReceiveData);
                    string tmpReceivedData = tmpSr.ReadToEnd();
                    lsd = tmpReceivedData.Substring(tmpReceivedData.IndexOf("lsd") + 12, 5);
                    //---------------------lsd-i goturduk

                    //login olmaga calisaq
                    string param = "charset_test=&euro;,&acute;,€,´,水,Д,Є" +
                        "&lsd=" + lsd +
                        "&locale=en_US" +
                        "&email=" + email +
                        "&pass=" + pass +
                        "&persistent=1&default_persistent=0";
                    GetResponseByRequest grr = new GetResponseByRequest(urlLogin, param, cc);
                    grr.StartProcess();
                    /*StreamReader tmp = new StreamReader(grr.ReceiveData);
                    string tmpS = tmp.ReadToEnd();*/
                }
                //indi ise videonun oldugu sehifenin kodunu(html) goturek
                GetResponseByRequest videoGrr = new GetResponseByRequest(videoPageUrl, cc);
                videoGrr.StartProcess();
                StreamReader videoSr = new StreamReader(videoGrr.ReceiveData);
                source = videoSr.ReadToEnd();

            }
            catch(Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Səhv baş verdi!\n" + exc.Message);
            }
            return source;

        }
    }
}
