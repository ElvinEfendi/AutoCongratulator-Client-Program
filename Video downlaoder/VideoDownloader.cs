using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Pulsuz_Mesaj.Video_downlaoder
{
    abstract class VideoDownloader
    {
        protected CookieContainer cc;
        protected string videoPageUrl;
        protected string login;
        protected string pass;
        protected bool loggedIn;

        public VideoDownloader(string videoPageUrl)
        {
            this.videoPageUrl = videoPageUrl;
            this.cc = new CookieContainer();
            loggedIn = false;
        }

        public abstract string getVideoUrl();
    }
}
