using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulsuz_Mesaj.Video_downlaoder
{
    class YtVideoDownloader : VideoDownloader
    {
        public YtVideoDownloader(string videoPageUrl)
            : base(videoPageUrl)
        {
        }

        public override string getVideoUrl()
        {
            return "rlu yaz";
        }
    }
}
