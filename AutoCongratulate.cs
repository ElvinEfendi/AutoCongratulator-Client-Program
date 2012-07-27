using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsuz_Mesaj.AutoCongratulateServices;

namespace Pulsuz_Mesaj
{
    class AutoCongratulate
    {
        AutoCongratulateService autoCongrat;
        public AutoCongratulate()
        {
            autoCongrat = new AutoCongratulateService();
        }
        //----------------------User ucun olan funksyalar---------------------------------
        /**
         * avto tebrik sisteminde bele istifadeci olub olmadigni yoxlayir
         */
        public int login(string userName, string password)
        {
            return autoCongrat.login(userName.Trim(), password.Trim());
        }

        /**
         * avto tebrik sistemindeki uygun istifadecinin yazisini qaytarir
         */
        public UserObject getUserObject(int userId)
        {
            return autoCongrat.getUserObject(userId);
        }

        /**
         * bu funksya sistemde yeni istifadeci yaradir
         * istifadeci yarandisa 1 ele istifadeci varsa -1 alnasilmaz sehv zamani 0 qaytarir
         */
        public int createUser(UserObject userObject)
        {
            int rt = autoCongrat.createUser(userObject);
            return rt;
        }

        /**
         * istifadecini melumatlarini yenileyir
         */
        public int updateUser(UserObject userObject, int userId)
        {
            int rt = autoCongrat.updateUser(userObject, userId);
            return rt;
        }

        /**
         * istifadecini sistemden silir
         */
        public bool deleteUser(int userId)
        {
            bool rt = autoCongrat.deleteUser(userId);
            return rt;
        }
        //----------------------autoCongrat(Birthday) ucun olan funksyalar---------------------------------
        /**
         * yeni bir avto tebrik yaradir yeni ad gunu daxil edir
         * ugurla yarandisa id sini eks halda uygun sehvin kodunu qaytarir
         */
        public int createAutoCongrat(AutoCongratObject autoCongratObject)
        {
            int rt = autoCongrat.createAutoCongrat(autoCongratObject);
            return rt;
        }

        /**
        * autocongrat melumatlarini yenileyir
        */
        public bool updateAutoCongrat(AutoCongratObject acObject, int bId)
        {
            return autoCongrat.updateAutoCongrat(acObject, bId);
        }

        /**
         * autocongrat -i sistemden silir
         */
        public bool deleteAutoCongrat(int bId)
        {
            return autoCongrat.deleteAutoCongrat(bId);
        }

        /**
        * uygun autoCongrat -i qaytarir
        */
        public AutoCongratObject getAutoCongrat(int bId)
        {
            return autoCongrat.getAutoCongrat(bId);
        }

        /**
         * istifadeciye uygun autoCongrat lari cekir
         */
        public AutoCongratObject[] getAutoCongrats(int userId)
        {
            return autoCongrat.getAutoCongrats(userId);
        }
    }
}
