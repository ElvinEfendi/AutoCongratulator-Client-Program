using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Pulsuz_Mesaj
{
    class Azercell:FreeMessage
    {      
        private string loginPrefix;
        private bool passwordBlocked = false;

        public string LoginPrefix
        {
            get
            {
                return loginPrefix;
            }
            set
            {
                loginPrefix = value;
            }
        }
        public bool PasswordBlocked
        {
            get
            {
                return passwordBlocked;
            }
        }

        public Azercell()
        {
            url = "http://www.azercell.com/WebModule1/mainservlet";
            userName = null;
            loginPrefix = null;
            password = null;
            numberPrefix = null;
            number = null;
            message = null;
            messageDate = null;
            remainderCount = null;
        }
        public override void Login()
        {
            try
            {
                string param = "cmnd=login&loginprefix=" + loginPrefix + "&login=" + userName +
                               "&pw=" + password + "&Submit=Daxil et";
                string receiveData = null;
                GetResponseByRequest grr = new GetResponseByRequest(url, param, cc);
                grr.StartProcess();
                StreamReader sr = new StreamReader(grr.ReceiveData);
                receiveData = sr.ReadToEnd();
                if (receiveData.Contains("Your login and password are OK"))
                {
                    //login parol duzdur
                    successLoggin = true;
                }
                else
                {
                    //login parol kombinasiyasi sehvdir
                    successLoggin = false;
                }
                if (receiveData.Contains("Your account has reached maximal attempts count. Please try 24 hours later."))
                {
                    //parola blok qoylub bir nece defe sehv yigildigina gore
                    passwordBlocked = true;
                }
                if (receiveData.Contains("Your login or password is invalid."))
                {
                    //login parol kombinasiyasi sehvdir
                    loginOrPasswordIsWrong = true;
                }
            }
            catch { }
        }
        public override void SendMessage()
        {
            string param = "cmnd=sms&subcmnd=submit&prefix=" + numberPrefix + "&sendto=" + number +
                           "&messj=" + message + "&smsdate=" + messageDate + "&cntr=" + remainderCount + "&submit=Göndər";
            //System.Windows.Forms.MessageBox.Show(param);
            string receiveData = null;
            GetResponseByRequest grr = new GetResponseByRequest("http://www.azercell.com/WebModule1/mainservlet", param, cc); ;
            grr.StartProcess();
            StreamReader sr = new StreamReader(grr.ReceiveData);
            receiveData = sr.ReadToEnd();

            if (receiveData.Contains("Your SMS was sent"))
            {
                //sms gonderildi
                successSmsSending = true;
            }
            else
            {
                //sms gonderilmedi
                successSmsSending = false;
            }
            //qaliq sms lerin sayini gotturek
            try
            {
                freeSmsCount =
                    receiveData.Substring(receiveData.IndexOf("FREE SMS remains:") + 47, 2);
            }
            catch { }
        }
    }
}
