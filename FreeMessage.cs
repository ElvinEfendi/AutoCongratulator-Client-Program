using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Pulsuz_Mesaj
{
    abstract class FreeMessage
    {
        protected CookieContainer cc = new CookieContainer();
        protected string url;
        protected bool successLoggin = false;
        protected bool successSmsSending = false;
        protected bool loginOrPasswordIsWrong = false;
        protected string freeSmsCount;
        protected bool freeSmsFinished = false;
        //for login
        protected string userName;
        protected string password;
        //for sending message
        protected string numberPrefix;
        protected string number;        
        protected string message;
        protected string messageDate;
        protected string remainderCount;

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }
        public bool SuccessLogin
        {
            get
            {
                return successLoggin;
            }
        }
        public bool SuccessSmsSending
        {
            get
            {
                return successSmsSending;
            }
        }
        public bool LoginOrPasswordIsWrong
        {
            get
            {
                return loginOrPasswordIsWrong;
            }
        }
        public string FreeSmsCount
        {
            get
            {
                return freeSmsCount;
            }
        }
        public bool FreeSmsFinished
        {
            get
            {
                return freeSmsFinished;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string NumberPrefix
        {
            get
            {
                return numberPrefix;
            }
            set
            {
                numberPrefix = value;
            }
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }        
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public string MessageDate
        {
            get
            {
                return messageDate;
            }
            set
            {
                messageDate = value;
            }
        }
        public string RemainderCount
        {
            get
            {
                return remainderCount;
            }
            set
            {
                remainderCount = value;
            }
        }

        public abstract void Login();
        public abstract void SendMessage();        
    }
}
