using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

class GetResponseByRequest
{
    private string url;
    private string sendData=null;
    private Stream receiveData;
    private CookieContainer cc;
    private int requestTimeout;
    private HttpWebRequest request;

    public string Url
    {
        get
        {
            return this.url;
        }
        set
        {
            this.url = value;
        }
    }
    public string SendData
    {
        get
        {
            return sendData;
        }
        set
        {
            this.sendData = value;
        }
    }
    public Stream ReceiveData
    {
        get
        {
            return this.receiveData;
        }
    }
    public int RequestTimeout
    {
        get
        {
            return this.requestTimeout;
        }
        set
        {
            this.requestTimeout = value;
        }
    }

    public GetResponseByRequest(string url, CookieContainer ccIn)
    {
        this.url = url;
        sendData = null;
        this.cc = ccIn;

        this.requestTimeout = 120000; //iki deqiqe;
    }
    public GetResponseByRequest(string url, string data, CookieContainer ccIn)
    {
        this.url = url;
        this.sendData = data;
        this.cc = ccIn;

        this.requestTimeout = 120000; //iki deqiqe;
    }
    public void StartProcess()
    {
        try
        {
            byte[] byteData = null;
            request = (HttpWebRequest)WebRequest.Create(this.url);
            request.CookieContainer = cc;
            request.UserAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request.Timeout = requestTimeout;
            if (this.sendData != null)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byteData = System.Text.Encoding.UTF8.GetBytes(this.sendData);//encoding.GetBytes(this.sendData);
                request.Method = "POST";
                request.ContentLength = byteData.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                Stream s = request.GetRequestStream();
                s.Write(byteData, 0, byteData.Length);
                s.Close();
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                receiveData = response.GetResponseStream();
            }
            catch (WebException we)
            {
                receiveData = we.Response.GetResponseStream();
            }

            //System.Windows.Forms.MessageBox.Show(response.Headers.Get("Set-Cookie"));
        }
        catch (Exception exc)
        {
            System.Windows.Forms.MessageBox.Show("Səhv baş verdi!\nİnternet bağlantınızın açıq olmağını dəqiqləşdirin.","Xəbərdarlıq",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
        }

    }
}