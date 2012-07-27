using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Pulsuz_Mesaj
{
    class Bakcell:FreeMessage
    {
        private string urlLogin;
        private string urlMessage;
        //muveqqeti
        //public string response;

        public string UrlLogin
        {
            get
            {
                return urlLogin;
            }
            set
            {
                urlLogin = value;
            }
        } 
        public string UrlMessage
        {
            get
            {
                return urlMessage;
            }
            set
            {
                urlMessage = value;
            }
        }

        public Bakcell()
        {
            urlLogin = "http://bakcell.com/en/login";
            urlMessage = "http://bakcell.com/en/sendSMS";
            userName = null;            
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
                string csrf = null;
                string receivedData = null;
                //evvelce login csrf -i goturek
                GetResponseByRequest tmpGrr = new GetResponseByRequest(urlLogin, cc);
                tmpGrr.StartProcess();
                StreamReader tmpSr = new StreamReader(tmpGrr.ReceiveData);
                string tmpReceivedData = tmpSr.ReadToEnd();
                csrf = tmpReceivedData.Substring(tmpReceivedData.IndexOf("signin[_csrf_token]\" value=\"") + 28, 32);
                //---------------------csrf-i goturduk

                string param = "signin[username]=" + userName + "&signin[password]=" + password + "&signin[_csrf_token]=" + csrf;
                GetResponseByRequest grr = new GetResponseByRequest(urlLogin, param, cc);
                grr.StartProcess();
                StreamReader sr = new StreamReader(grr.ReceiveData);
                receivedData = sr.ReadToEnd();
                if (!receivedData.Contains("The username and/or password is invalid."))
                {
                    //login parol duzdur
                    successLoggin = true;
                }
                else
                {
                    //login parol kombinasiyasi sehvdir
                    successLoggin = false;
                }
            }
            catch
            {}
        }
        public override void SendMessage()
        {
            string csrf = null;
            string smsUserId = null;
            string receivedData = null;

            //evvelce sms csrf -i ve sms[user_id]-ni goturek
            GetResponseByRequest tmpGrr = new GetResponseByRequest(urlMessage, cc);
            tmpGrr.StartProcess();
            StreamReader tmpSr = new StreamReader(tmpGrr.ReceiveData);
            string tmpReceivedData = tmpSr.ReadToEnd();
            //yoxluyaq gorek bir pulsuz mesajimiz qalibmi balansimizda
            if (!tmpReceivedData.Contains("You have reached your daily limit, please come back tomorrow and try again"))
            {
                //csrf
                csrf = tmpReceivedData.Substring(tmpReceivedData.IndexOf("sms[_csrf_token]\" value=\"") + 25, 32);
                //sms[user_id]
                //bu yaxshi olmadi haa id 5 reqemli olmasa sehv verecek
                smsUserId = tmpReceivedData.Substring(tmpReceivedData.IndexOf("id=\"sms__csrf_token\"") + 39, 5);
                //------------------csrf-i ve sms[user_id] -ni goturduk

                string param = "sms[_csrf_token]=" + csrf + "&sms[user_id]=" + smsUserId + "&code=994" + numberPrefix +
                               "&sms[mobile]=" + number + "&sms[message]=" + message;
                //System.Windows.Forms.MessageBox.Show(param);
                GetResponseByRequest grr = new GetResponseByRequest(urlMessage, param, cc); ;
                grr.StartProcess();
                StreamReader sr = new StreamReader(grr.ReceiveData);
                receivedData = sr.ReadToEnd();
                if (!receivedData.Contains("Your sms has failed."))
                {
                    //sms gonderildi
                    successSmsSending = true;
                    //qaliq sms lerin sayini gotturek
                    try
                    {
                        freeSmsCount = tmpReceivedData.Substring(tmpReceivedData.IndexOf("You may send ") + 15, 1);
                    }
                    catch { }
                }
                else
                {
                    //sms gonderilmedi
                    successSmsSending = false;
                }
            }
            else
            {
                //gundelik pulsuz sms balansi qurtarib
                freeSmsFinished = true;
            }
        }
    }
}
