using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pulsuz_Mesaj
{
    class AzeriColor
    {
        public AzeriColor(){}
        public Color colorFromName(string colorName)
        {
            Color rt;
            switch (colorName)
            {
                case "Ağ":
                    rt = Color.White;
                    break;
                case "Boz":
                    rt = Color.Gainsboro;
                    break;
                case "Sarı":
                    rt = Color.Yellow;
                    break;
                case "Göy":
                    rt = Color.LightSteelBlue;
                    break;
                case "Yaşıl":
                    rt = Color.Aquamarine;
                    break;
                case "Qırmızı":
                    rt = Color.Tomato;
                    break;
                case "Çəhrayı":
                    rt = Color.Pink;
                    break;
                default:
                    rt = Color.AntiqueWhite;
                    break;
            }
            return rt;
        }
    }
}
