using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Pulsuz_Mesaj.Video_downlaoder;

namespace Pulsuz_Mesaj
{
    public partial class formMain : Form
    {
        public int acUserId = -1; //yeni hec bir istifadeci sisteme daxil olmayib
        //bu formlari qlobal veririk ki basqa funksyada da istifade edecikk onlari baglamaq ucun
        formAcUserProfile up = null;
        formAcBirthday ub = null;
        //istifadecinin melumatlarini o login olanda alib 
        //bu obyekte menimsedecikki lazim olanda bundna goturek birde servere qosulmasin
        public Pulsuz_Mesaj.AutoCongratulateServices.UserObject loggedinUser=null;

        string newsAgent;
        public formMain()
        {
            InitializeComponent();

            //bezi xususi hadiseleri buradan qoyaq
            txtAzUserName.KeyUp += new KeyEventHandler(azLoginOnEnter);
            txtAzPassword.KeyUp += new KeyEventHandler(azLoginOnEnter);

            txtBkUserName.KeyUp += new KeyEventHandler(bkLoginOnEnter);
            txtBkPassword.KeyUp += new KeyEventHandler(bkLoginOnEnter);

            txtAcUsername.KeyUp += new KeyEventHandler(acLoginOnEnter);
            txtAcPassword.KeyUp += new KeyEventHandler(acLoginOnEnter);
        }
        //webbrowserde linke sixanda bu funksya isleyir
        public void handleLinkClick(Object Sender, HtmlElementEventArgs e)
        {
            HtmlElement a = (HtmlElement)Sender;
            if (a.Id == "openWithBrowser")
            {
                //bunu xususi bele qoymusam bele id-li link bir denedi ve ona click edende onu browserde acsin istiyirem
                System.Diagnostics.Process.Start(a.GetAttribute("href"));
            }
            else
            {
                //qalan hallarda proqramin ozunde olan browserle yeni pencerede acsin
                /*proqramin esas penceresi gorunsun deye yuxari qaldiraq
                this.Top = 10;
                this.Left = 10;*/
                formViewNews vn = new formViewNews(a.Id, newsAgent);
                vn.Show();
            }
        }

        //deyisenlerin tesviri

        Azercell az;
        Bakcell bk;
        //istifadeci adlari umumi proqram seviyyesinde lazim olur ona gore qlobal verek
        string currAzUserName;
        string currBkUserName;

        //metodlarin tesviri

        #region umumi komekci metodlar
        //registry -den melumatlari oxuyur, proqram acilmamis isleyir ve proqrami yaddasa uygun acir
        public void loadRegistryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //indi ise user settingsi oxuyaq
                //Bakcell ucun
                //username-i oxuyuruq
                txtBkUserName.Text = userSettings.Default.bkUserName;
                //parolu oxuyuruq
                byte[] bkEncodedBytePassword = System.Convert.FromBase64String(userSettings.Default.bkPassword);
                txtBkPassword.Text = System.Text.UTF8Encoding.UTF8.GetString(bkEncodedBytePassword);
                //fon rengini oxuyuruq
                tbpBakcell.BackColor = Color.FromName(userSettings.Default.bkBgColor);

                //Azercell ucun
                txtAzUserName.Text = userSettings.Default.azUserName;
                //parolu oxuyuruq
                byte[] azEncodedBytePassword = System.Convert.FromBase64String(userSettings.Default.azPassword);
                txtAzPassword.Text = System.Text.UTF8Encoding.UTF8.GetString(azEncodedBytePassword);
                //fon rengini oxuyuruq
                tbpAzercell.BackColor = Color.FromName(userSettings.Default.azBgColor);

                //autoCongrat in forn rengini
                tbpAutoCongrat.BackColor = Color.FromName(userSettings.Default.acBgColor);
            }
            catch
            {
                MessageBox.Show("İstifadəçi məlumatları oxuna bilmir.\n" +
                    "Proqramın bütün funksyalarından yararlanmaq üçün administrator kimi işlədin.",
                    "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //remember isareleyende login parolu registry-ye yazmaq ucun
        private void rememberProfile(bool isChecked,string operatorName,string login, string password)
        {
            if (isChecked)
            {
                try
                {
                    //parolu kodlasdiraq
                    byte[] bytePassword = new byte[password.Length];
                    bytePassword = Encoding.UTF8.GetBytes(password);
                    password = Convert.ToBase64String(bytePassword);
                    //logini yazaq
                    if (operatorName == "Bakcell")
                    {
                        //data bakcell ucunse bakcell ucun datani yaziriq
                        userSettings.Default.bkUserName = login;
                        userSettings.Default.bkPassword = password;
                    }
                    else
                    {
                        //data azercell ucunse azercell ucun datani yaziriq
                        userSettings.Default.azUserName = login;
                        userSettings.Default.azPassword = password;
                    }
                }                
                catch { }
            }
        }


        //fon rengini deyisir ve registry -de yadda saxlayir
        private void changeAndSaveBackColor(object sender, EventArgs e)
        {
            ToolStripMenuItem choosenColorItem = (ToolStripMenuItem)sender;
            //secilen rengi goturek
            AzeriColor azColor = new AzeriColor(); //azeri rengleri
            //secilen reng iteminin parent itemini goturek
            string whichTab = choosenColorItem.OwnerItem.Text;

            //-----uygun fonun rengini deyisirik_BEGIN
            if (whichTab == "Bakcell")
            {
                tbpBakcell.BackColor = azColor.colorFromName(choosenColorItem.Text);
            }

            if (whichTab == "Azercell")
            {
                tbpAzercell.BackColor = azColor.colorFromName(choosenColorItem.Text);
            }

            if (whichTab == "AvtoTəbrik sistemi")
            {
                tbpAutoCongrat.BackColor = azColor.colorFromName(choosenColorItem.Text);
            }
            //-----uygun fonun rengini deyisirik_END

            try
            { 
                if (whichTab == "Bakcell")
                {
                    //bakcellin fon rengini yadda salayiriq
                    userSettings.Default.bkBgColor = azColor.colorFromName(choosenColorItem.Text).Name;
                }
                else if (whichTab == "Azercell")
                {
                    //bakcellin fon rengini yadda salayiriq
                    userSettings.Default.azBgColor = azColor.colorFromName(choosenColorItem.Text).Name;
                }
                else if (whichTab == "AvtoTəbrik sistemi")
                {
                    //autocongratin fon rengini yadda saxlayir
                    userSettings.Default.acBgColor = azColor.colorFromName(choosenColorItem.Text).Name;
                }
            }
            catch
            {
                MessageBox.Show("İstifadəçinin məlumatlarını yadda saxlamaq mümkün olmadı.\n"+
                    "Proqramın bütün funksyalarından yararlanmaq üçün administrator kimi işlədin.",
                    "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Azercellin isleri------------------

        //yaddasdaki azercell istifadecisini silir
        //qeyd: ancaq ozu sile biler ozunu
        private void miaRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (userSettings.Default.azUserName == currAzUserName)
                {
                    userSettings.Default.azUserName = "";
                    userSettings.Default.azPassword = "";
                    //metn qutularini da temizleyek
                    txtAzUserName.Text = "";
                    txtAzPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Siz bu əməliyyatı hesabınıza daxil olduqdan və\n sonra ancaq öz istifadəçiniz üzərində edə bilərsiniz.",
                       "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Win32Exception we)
            {
                MessageBox.Show("Əməliyyatı etmək mümkün olmadı.\n" +
                    "Proqramın bütün funksyalarından yararlanmaq üçün administrator kimi işlədin.",
                    "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                //registry sehvinden basqa sehvlere bazmiriq
            }
        }
        
        private void miaOpen_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedIndex = 1;
        }
        //enter-e sixanda 
        private void azLoginOnEnter(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtAzUserName.Text.Trim().Length > 0) && (txtAzPassword.Text.Trim().Length > 0))
            {
                btnAzLogin_Click(sender, e);
            }
        }
        //azercell e login oluruq
        Thread thAzLogin;
        private void azLogin()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnAzLogin.Enabled = false;
                //this.Cursor = Cursors.WaitCursor;
                pbAzLoginLoading.Visible = true;
            });
            az = new Azercell();
            if (cmbAzSendToPrefix.InvokeRequired)
            {
                cmbAzSendToPrefix.Invoke((MethodInvoker)delegate
                {
                    if (cmbAzSendToPrefix.SelectedIndex > -1)
                    {
                        az.LoginPrefix = cmbAzUserNamePrefix.SelectedItem.ToString();
                    }
                });
            }
            else
            {
                if (cmbAzSendToPrefix.SelectedIndex > -1)
                {
                    az.LoginPrefix = cmbAzUserNamePrefix.SelectedItem.ToString();
                }
            }
            az.UserName = txtAzUserName.Text.Trim();
            az.Password = txtAzPassword.Text.Trim();
            az.Login();
            if (az.SuccessLogin)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblAzInfo.ForeColor = Color.Green;
                    lblAzInfo.Text = "Uğurla daxil oldunuz.";
                    lblAzInfo.Visible = true;
                    btnAzLogin.Enabled = false;
                    btnAzSendMessage.Enabled = true;
                    btnAzLogout.Enabled = true;

                    txtAzUserName.Enabled = false;
                    txtAzPassword.Enabled = false;

                });
                //cari username -i set edek
                currAzUserName = az.UserName;
                //isarelenibse yadda saxlayacaq login parolu
                rememberProfile(ckbAzRemember.Checked, "Azercell", az.UserName, az.Password);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblAzInfo.ForeColor = Color.Red;
                    if (az.PasswordBlocked)
                    {
                        lblAzInfo.Text = "Şifrəniz çoxsaylı yanlış cəhtlərə görə\nbağlanılmışdır. 24 saat sonra yoxlayın.";
                    }
                    else
                    {
                        if (az.LoginOrPasswordIsWrong)
                        {
                            lblAzInfo.Text = "İstifadəçi adınız və ya \nşifrəniz düzgün deyildir.";
                        }
                        else
                        {
                            lblAzInfo.Text = "Səhv baş verdi.";
                        }
                    }
                    lblAzInfo.Visible = true;
                    btnAzLogin.Enabled = true;
                    btnAzSendMessage.Enabled = false;
                    btnAzLogout.Enabled = false;
                });

            }
            this.Invoke((MethodInvoker)delegate
            {
                //this.Cursor = Cursors.Default;
                pbAzLoginLoading.Visible = false;
            });

            thAzLogin.Abort();
        }
        private void btnAzLogin_Click(object sender, EventArgs e)
        {
            ThreadStart thsAzLogin = new ThreadStart(azLogin);
            thAzLogin = new Thread(thsAzLogin);
            thAzLogin.Start();
            //mueyyen muddetden sonra yeniden login olaqki sessiya olmesin
            timerForAzLoginSession.Enabled = true;
        }
        //azercell-e login olduq

        private void btnAzLogout_Click(object sender, EventArgs e)
        {
            btnAzLogin.Enabled = true;
            lblAzInfo.Visible = false;
            btnAzLogout.Enabled = false;
            btnAzSendMessage.Enabled = false;

            txtAzUserName.Enabled = true;
            txtAzPassword.Enabled = true;

            timerForAzLoginSession.Enabled = false;

            GC.Collect();
        }

        //azercell SMS gonderirik
        Thread thAzSendMessage;
        private void azSendMessage()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnAzSendMessage.Enabled = false;
                //this.Cursor = Cursors.WaitCursor;
                pbAzSendMessageLoading.Visible = true;
            });
            StringBuilder dateTime = new StringBuilder(dtpAzMessageSentTime.Value.ToString());
            dateTime.Replace("/", ".");
            dateTime.Replace("PM", "");

            if (cmbAzSendToPrefix.InvokeRequired)
            {
                cmbAzSendToPrefix.Invoke((MethodInvoker)delegate
                {
                    if (cmbAzSendToPrefix.SelectedIndex > -1)
                    {
                        az.NumberPrefix = cmbAzSendToPrefix.SelectedItem.ToString();
                    }
                });
            }
            else
            {
                if (cmbAzSendToPrefix.SelectedIndex > -1)
                {
                    az.NumberPrefix = cmbAzSendToPrefix.SelectedItem.ToString();
                }
            }
            az.Number = txtAzSendTo.Text.Trim();
            az.Message = txtAzMessage.Text.Trim();
            az.RemainderCount = txtAzRemainderCount.Text.Trim();
            az.MessageDate = dateTime.ToString().Trim();
            az.SendMessage();
            //susmaya gore bele verek duz olsa asagida yasil edir onsuzda
            this.Invoke((MethodInvoker)delegate
            {
                lblAzInfo.ForeColor = Color.Red;
            });
            if (az.SuccessSmsSending)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblAzInfo.ForeColor = Color.Green;
                    lblAzInfo.Text = "Mesaj göndərildi.";
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblAzInfo.Text = "Mesaj göndərilmədi.";
                });
            }

            //qaliq sms lerin sayi
            int tmp = Int32.Parse(az.FreeSmsCount);
            this.Invoke((MethodInvoker)delegate
            {
                txtAzFreeMessageCount.Text = (tmp > 0) ? tmp.ToString() : tmp.ToString();
                //qaliq sms blokunu gosterek
                lblAzFreeMessageCount.Visible = true;
                txtAzFreeMessageCount.Visible = true;

                //this.Cursor = Cursors.Default;
                pbAzSendMessageLoading.Visible = false;

                btnAzSendMessage.Enabled = true;
            });
            thAzSendMessage.Abort();
        }
        private void btnAzSendMessage_Click(object sender, EventArgs e)
        {
            ThreadStart thsAzSendMessage = new ThreadStart(azSendMessage);
            thAzSendMessage = new Thread(thsAzSendMessage);
            thAzSendMessage.Start();
        }
        //Azercell SMS gonderildi

        private void txtAzMessage_TextChanged(object sender, EventArgs e)
        {
            //ne qeder simvol qaldigini yenileyek
            int tmp = txtAzMessage.Text.Trim().Length;
            if (tmp <= 148)
            {
                txtAzRemainderCount.Text = (148 - tmp).ToString();
            }
            else
            {
                txtAzMessage.Text = txtAzMessage.Text.Remove(148);
                MessageBox.Show("Siz mesajdakı simvolların sayı üçün qoyulmuş limiti keçdiniz", "Xəbərdarlıq");
            }
        }

        private void btnAzClearMessage_Click(object sender, EventArgs e)
        {
            cmbAzSendToPrefix.SelectedIndex = 0;
            txtAzSendTo.Text = "";
            txtAzMessage.Text = "";

            lblAzInfo.Text = "";

        }

        private void ckbAzShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbAzShowPassword.Checked)
            {
                txtAzPassword.PasswordChar = '*';
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstər");
            }
            else
            {
                txtAzPassword.PasswordChar = (char)0;
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstərmə");
            }
        }

        private void btnAzRegister_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://subscriber.azercell.com/subscriber/subscriberSignInWithMsisdn.do?locale=az");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //bakcell bitdi
        #endregion

        #region      Bakcell -in isleri---------------------------------------

        //bakcellin yaddasdaki istifadecisini silir
        //qeyd: ancaq ozu sile biler ozunu
        private void mibRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                //evvelce yoxlayaq gorek bu silinen istifadeci caridimi
                if (userSettings.Default.bkUserName == currBkUserName)
                {
                    userSettings.Default.bkUserName = "";
                    userSettings.Default.bkPassword = "";
                    //metn qutularini da temizleyek
                    txtBkUserName.Text = "";
                    txtBkPassword.Text = "";

                }
                else
                {
                    MessageBox.Show("Siz bu əməliyyatı hesabınıza daxil olduqdan sonra və\n ancaq öz istifadəçiniz üzərində edə bilərsiniz.",
                       "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Əməliyyatı etmək mümkün olmadı.\n" +
                    "Proqramın bütün funksyalarından yararlanmaq üçün administrator kimi işlədin.",
                    "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mibOpen_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedIndex = 0;
        }

        private void bkLoginOnEnter(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtBkUserName.Text.Trim().Length > 0) && (txtBkPassword.Text.Trim().Length > 0))
            {
                btnBkLogin_Click(sender, e);
            }
        }
        //bakcelle login oluruq
        Thread thBkLogin;
        private void bkLogin()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnBkLogin.Enabled = false;
                pbBkLoginLoading.Visible = true;
                //this.Cursor = Cursors.WaitCursor;
            });
            bk = new Bakcell();
            bk.UserName = txtBkUserName.Text.Trim();
            bk.Password = txtBkPassword.Text.Trim();
            bk.Login();
            if (bk.SuccessLogin)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblBkInfo.ForeColor = Color.Green;
                    lblBkInfo.Text = "Uğurla daxil oldunuz.";
                    lblBkInfo.Visible = true;
                    btnBkLogin.Enabled = false;
                    btnBkSendMessage.Enabled = true;
                    btnBkLogout.Enabled = true;
                    txtBkUserName.Enabled = false;
                    txtBkPassword.Enabled = false;
                });
                //cari username -i set edek
                currBkUserName = bk.UserName;
                //isarelenibse yadda saxlayacaq login parolu
                rememberProfile(ckbBkRemember.Checked, "Bakcell", bk.UserName, bk.Password);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblBkInfo.ForeColor = Color.Red;
                    lblBkInfo.Text = "Səhv baş verdi.";
                    lblBkInfo.Visible = true;
                    btnBkLogin.Enabled = true;
                    btnBkSendMessage.Enabled = false;
                    btnBkLogout.Enabled = false;
                });

            }
            this.Invoke((MethodInvoker)delegate
            {
                pbBkLoginLoading.Visible = false;
                //this.Cursor = Cursors.Default;
            });
            thBkLogin.Abort();
        }

        private void btnBkLogin_Click(object sender, EventArgs e)
        {
            ThreadStart thsBkLogin = new ThreadStart(bkLogin);
            thBkLogin = new Thread(thsBkLogin);
            thBkLogin.Start();
            //mueyyen vaxtdan sonra yeniden login olaqki sessiya olmesin
            timerForBkLoginSession.Enabled = true;
        }
        //bakcelle login olduq
        //bakcell sms gonderirik
        Thread thBkSendMessage;
        private void bkSendMessage()
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnBkSendMessage.Enabled = false;
                //this.Cursor = Cursors.WaitCursor; bu evvelki versiyada idi indi sekille gosteririk loadingi
                pbBkSendMessageLoading.Visible = true;
            });
            
            StringBuilder dateTime = new StringBuilder(dtpBkMessageSentTime.Value.ToString());
            dateTime.Replace("/", ".");
            dateTime.Replace("PM", "");

            if (cmbBkSendToPrefix.InvokeRequired)
            {
                cmbBkSendToPrefix.Invoke((MethodInvoker)delegate
                {
                    if (cmbBkSendToPrefix.SelectedIndex > -1)
                    {
                        bk.NumberPrefix = cmbBkSendToPrefix.SelectedItem.ToString();
                    }
                });
            }
            else
            {
                if (cmbBkSendToPrefix.SelectedIndex > -1)
                {
                    bk.NumberPrefix = cmbBkSendToPrefix.SelectedItem.ToString();
                }
            }

            bk.Number = txtBkSendTo.Text.Trim();
            bk.Message = txtBkMessage.Text.Trim();
            bk.RemainderCount = txtBkRemainderCount.Text.Trim();
            bk.MessageDate = dateTime.ToString().Trim();
            bk.SendMessage();
            //susmaya gore rengini bele verey daxil olsa asagida yasila cevirecek onsuzda
            lblBkInfo.ForeColor = Color.Red;
            if (!bk.FreeSmsFinished)
            {
                if (bk.SuccessSmsSending)
                {
                    //qaliq sms lerin sayi
                    int tmp = Int32.Parse(bk.FreeSmsCount);

                    this.Invoke((MethodInvoker)delegate
                    {
                        lblBkInfo.ForeColor = Color.Green;
                        lblBkInfo.Text = "Mesaj göndərildi.";
                        //qaliq smslerin sayini yazaq
                        txtBkFreeMessageCount.Text = (tmp > 0) ? (tmp - 1).ToString() : tmp.ToString();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblBkInfo.Text = "Mesaj göndərilmədi.";
                    });
                }
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtBkFreeMessageCount.Text = "0";
                    lblBkInfo.Text = "Bu günə SMS göndərmə limitiniz bitibdir.\nSabah yenidən cəhd edərsiniz.";
                });
            }
            
            this.Invoke((MethodInvoker)delegate
            {
                //qaliq sms blokunu gosterek
                lblBkFreeMessageCount.Visible = true;
                txtBkFreeMessageCount.Visible = true;

                //this.Cursor = Cursors.Default;
                pbBkSendMessageLoading.Visible = false;
                btnBkSendMessage.Enabled = true;
            });
            thBkSendMessage.Abort();
        }
        private void btnBkSendMessage_Click(object sender, EventArgs e)
        {
            ThreadStart thsBkSendMessage = new ThreadStart(bkSendMessage);
            thBkSendMessage = new Thread(thsBkSendMessage);
            thBkSendMessage.Start();
        }
        //bakcell sms gonderdik

        private void btnBkLogout_Click(object sender, EventArgs e)
        {
            btnBkLogin.Enabled = true;
            lblBkInfo.Visible = false;
            btnBkLogout.Enabled = false;
            btnBkSendMessage.Enabled = false;
            txtBkUserName.Enabled = true;
            txtBkPassword.Enabled = true;

            timerForBkLoginSession.Enabled = false;

            GC.Collect();
        }

        private void btnBkClearMessage_Click(object sender, EventArgs e)
        {
            cmbBkSendToPrefix.SelectedIndex = 0;
            txtBkSendTo.Text = "";
            txtBkMessage.Text = "";

            lblBkInfo.Text = "";
        }

        private void ckbBkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbBkShowPassword.Checked)
            {
                txtBkPassword.PasswordChar = '*';
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstər");
            }
            else
            {
                txtBkPassword.PasswordChar = (char)0;
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstərmə");
            }
        }

        private void btnBkRegister_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://bakcell.com/az/register");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtBkMessage_TextChanged(object sender, EventArgs e)
        {
            int tmp = txtBkMessage.Text.Trim().Length;
            if (tmp <= 140)
            {
                txtBkRemainderCount.Text = (140 - tmp).ToString();
            }
            else
            {
                txtBkMessage.Text = txtBkMessage.Text.Remove(140);
                MessageBox.Show("Siz mesajdakı simvolların sayı üçün qoyulmuş limiti keçdiniz", "Xəbərdarlıq");
            }
        }
        //Bakcell bitdi
        #endregion


        private void formMain_Load(object sender, EventArgs e)
        {
            /* bu isleri splash formunda goruruk artiq-optimalliq ucun
            //azercell
            cmbAzUserNamePrefix.SelectedIndex = 0;
            cmbAzSendToPrefix.SelectedIndex = 0;
            //bakcell
            cmbBkSendToPrefix.SelectedIndex = 0;
            //3-cu esas tab secili olsun
            tbcMain.SelectedIndex = 2;
           */
        }

        //proqramdan chixmaq uchun
        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //proqrami destekleyen sayti gosterir
        private void miProvidedSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://pulsuz-yukle.info");
        }

        private void miFeedBack_Click(object sender, EventArgs e)
        {
            formFeedBack ffb = new formFeedBack();
            ffb.Show();
        }

        private void miAboutPorgam_Click(object sender, EventArgs e)
        {
            formAboutProgram fap = new formAboutProgram();
            fap.Show();
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            userSettings.Default.Save();
            if (downloading == true)//video downloaderde yukleme gedirse
            {
                if (MessageBox.Show("Hal hazırda yükləmə gedir,\nYükləmə dayandırılsın və proqram bağansınmı?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    btnVdClear_Click(sender, e);
                }
            }
        }
        //yuxaridaki metoda bax ele ola bilerki form hec vaxt baglanmasin bunun qarsisini almaq ucun bu metodu yazmisam
        void formMain_FormClosing1(object sender, FormClosingEventArgs e)
        {
            userSettings.Default.Save();
            e.Cancel = false;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection links = webBrowser.Document.Links;
            foreach (HtmlElement a in links)
            {
                a.Click += new HtmlElementEventHandler(handleLinkClick);
            }
            //webbroserde naviqasiya etmeyi passiv edek
            webBrowser.AllowNavigation = false;
        }
        //xeberleri yukleyirik
        Thread thLoadNews = null;
        private void loadNewsInThread()
        {
            try
            {
                //kursoru gozleme halina keciririk
                this.Invoke((MethodInvoker)delegate
                {
                    //this.Cursor = Cursors.WaitCursor;
                    pbLnLoading.Visible = true;
                    //istifadeciye gozlemeyini deyirik
                    stlblProgramState.Text = ">>> Xəbərlər yüklənir...";
                });
                //xeber saytlarinin adlari
                string[] agentNames = new string[4]{"Anspress.com",
                                                "Lent.az",
                                                "Milli.az",
                                                "Musavat.com"};
                News news = new News(newsAgent);
                //webbroserde naviqasiya etmeyi aktiv edek
                string newsHtml = news.getNewsHtml();
                this.Invoke((MethodInvoker)delegate
                {
                    webBrowser.AllowNavigation = true;
                    webBrowser.DocumentText = "<HTML><HEAD></HEAD><BODY style=\"margin:3px\"><div align=\"left\"><ul style=\"margin:0px 0px 0px 15px\">" +
                                               newsHtml +
                                               "</ul></div></BODY></HTML>";
                    //melumati gizledirik
                    stlblProgramState.Text = ">>> Xəbərlər: " +
                                                agentNames[Convert.ToInt32(newsAgent) - 1] +
                                                ", son 20 xəbər";
                });
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
            finally
            {
                //kursoru normal veziyyete qaytaririq
                this.Invoke((MethodInvoker)delegate
                {
                    //this.Cursor = Cursors.Default;
                    pbLnLoading.Visible = false;
                });
            }

            thLoadNews.Abort();
        }
        private void loadNews()
        {
            if (thLoadNews == null)
            {
                ThreadStart ths = new ThreadStart(loadNewsInThread);
                thLoadNews = new Thread(ths);
                thLoadNews.Start();
            }
            else
            {
                if (!thLoadNews.IsAlive)
                {
                    ThreadStart ths = new ThreadStart(loadNewsInThread);
                    thLoadNews = new Thread(ths);
                    thLoadNews.Start();
                }
            }
        }
        //xeberleri yukledik qurtardiq

        private void btnLnAnspress_Click(object sender, EventArgs e)
        {            
            //cari olaraq hansi agentin xeberlerini gotururukse o
            newsAgent = "1"; //yeni ansin xeberlerini gotursun
            loadNews();
        }

        private void btnLnLent_Click(object sender, EventArgs e)
        {
            //cari olaraq hansi agentin xeberlerini gotururukse o
            newsAgent = "2"; //yeni lent.az-in xeberlerini gotursun
            loadNews();
        }

        private void btnLnMilli_Click(object sender, EventArgs e)
        {
            //cari olaraq hansi agentin xeberlerini gotururukse o
            newsAgent = "3"; //yeni milli.az-in xeberlerini gotursun
            loadNews();
        }

        private void btnLnMusavat_Click(object sender, EventArgs e)
        {
            //cari olaraq hansi agentin xeberlerini gotururukse o
            newsAgent = "4"; //yeni musavat.com-un xeberlerini gotursun
            loadNews();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcMain.SelectedIndex)
            {
                case 0:
                    stlblProgramState.Text = ">>> Bakcell";
                    break;
                case 1:
                    stlblProgramState.Text = ">>> Azercell";
                    break;
                case 2:
                    stlblProgramState.Text = ">>> Ad günü təbriklərini avtomatlaşdır";
                    break;
                case 3:
                    stlblProgramState.Text = ">>> Xəbərlər";
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        //xeberler bolmesinde ilk olaraq hecne yuklemediyine gore
                        //oz melumatimizi yazaq
                        webBrowser.DocumentText = "<html><body><h4 align=\"center\">" +
                                                  "Bu bölmədə görəcəyiniz bütün məlumatlar <a id=\"openWithBrowser\" href=\"http://azinf.net/about.php\">" +
                                                  "azinf.net</a> saytının veb xidmətidir.<br />" +
                                                  "Son xəbərləri izləmək üçün yuxarıdakı düymələrdən istifadə edə bilərsiniz" +
                                                  "</h4></body></html>";
                    }
                    catch { }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
                case 4:
                    stlblProgramState.Text = ">>> Video yükləmə";
                    break;
            }
        }
        
        //AvtoCongrata login oluruq
        Thread thAcLogin;
        private void acLogin()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btnAcLogin.Enabled = false;
                    //this.Cursor = Cursors.WaitCursor;
                    pbAcLoginLoading.Visible = true;
                });
                AutoCongratulate ac = new AutoCongratulate();
                acUserId = ac.login(txtAcUsername.Text, txtAcPassword.Text);
                if (acUserId > 0)//yeni bele istifadeci varsa
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        //istifadeci paneline kecis mumkun olsun
                        lnklAcUserProfile.Enabled = true;
                        //dogum gunleri penceresine kecis mumkun olsun
                        lnklAcBirthdays.Enabled = true;
                        //tebrikleri indi gonder acig olsun
                        lnklAcCongratNow.Enabled = true;
                        //sistemden cixis duymesi - logout aktiv olsun
                        lnklAcLogout.Enabled = true;
                    });
                    //ve bu userin melumatlarini qlobal(public) deyisene yazaq
                    //bunu basqa modullarda da istifade edecik
                    loggedinUser = ac.getUserObject(acUserId);
                }
                else if (acUserId == -1)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcPassword.Enabled = false; //pencere acilanda enter basilmasin deye
                        txtAcUsername.Enabled = false;
                    });
                    MessageBox.Show("Sistemdə, daxil etdiyiniz istifadəçi adı və \n" +
                        "şifrə kombinasiyasına uyğun profil tapılmadı", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcPassword.Enabled = true; //pencere baglanandan sonra normal olsun deye
                        txtAcUsername.Enabled = true;
                        //login duymesi aktiv olsun
                        btnAcLogin.Enabled = true;
                    });
                }
                else if (acUserId == -3)
                {
                   this.Invoke((MethodInvoker)delegate
                   {
                       //proqramda lisenziya problemi var avtotebrik sistemine daxil olma qadagandir
                       txtAcPassword.Enabled = false; //pencere acilanda enter basilmasin deye
                       txtAcUsername.Enabled = false;
                   });

                    MessageBox.Show("Sistemdən bundan sonra da istifadə etmək üçün müəllif ilə əlaqə saxlayın!\n" +
                        "E-mail: elvin.efendiyev@gmail.com", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcPassword.Enabled = true; //pencere baglanandan sonra normal olsun deye
                        txtAcUsername.Enabled = true;
                        //login duymesi aktiv olsun
                        btnAcLogin.Enabled = true;
                    });

                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcPassword.Enabled = false; //pencere acilanda enter basilmasin deye
                        txtAcUsername.Enabled = false;
                    });
                    MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi,\n" +
                        " zəhmət olmasa bir az sonra yenidən yoxlayın", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcPassword.Enabled = true; //pencere baglanandan sonra normal olsun deye
                        txtAcUsername.Enabled = true;
                        //login duymesi aktiv olsun
                        btnAcLogin.Enabled = true;
                    });
                }
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                this.Invoke((MethodInvoker)delegate
                {
                    btnAcLogin.Enabled = true;
                });
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //this.Cursor = Cursors.Default;
                    pbAcLoginLoading.Visible = false;
                });
            }

            thAcLogin.Abort();
        }
        private void btnAcLogin_Click(object sender, EventArgs e)
        {
            ThreadStart thsAcLogin = new ThreadStart(acLogin);
            thAcLogin = new Thread(thsAcLogin);
            thAcLogin.Start();
        }
        //AvtoCongrata login olduq

        private void ckbAcShowPasword_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbAcShowPassword.Checked)
            {
                txtAcPassword.PasswordChar = '*';
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstər");
            }
            else
            {
                txtAcPassword.PasswordChar = (char)0;
                toolTipMain.SetToolTip(ckbBkShowPassword, "Şifrəni göstərmə");
            }
        }

        /**
         * avto tebrik sistemine daxil olarken enter den istifadeni temin edir
         */
        private void acLoginOnEnter(object sender, KeyEventArgs e)
        {
            if (btnAcLogin.Enabled)
            {
                if ((e.KeyCode == Keys.Enter) && (txtAcUsername.Text.Trim().Length > 0) && (txtAcPassword.Text.Trim().Length > 0))
                {
                    btnAcLogin_Click(sender, e);
                }
            }
        }

        private void btnAcRegistr_Click(object sender, EventArgs e)
        {
            formAcUserRegistration acur = new formAcUserRegistration();
            acur.Show();
        }

        private void lnklAcUserProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            up = new formAcUserProfile(this, acUserId);
            up.Show();
        }

        private void lnklAcBirthdays_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ub = new formAcBirthday(this, acUserId);
            ub.Show();
        }

        public void lnklAcLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //istifadecinin id-ne -1 menimsedek yeni logout olsun
            acUserId = -1;
            //login duymesini enable edek
            btnAcLogin.Enabled = true;
            //texboxlari yenileyek
            txtAcUsername.Clear();
            txtAcPassword.Clear();
            //usere aid olan pencerelerden aciq olan(lar)i varsa baglayaq
            //istifadeci panelini bagliyiri: bu pencere lnklAcUserProfile_LinkClicked bu hadise ile acilir
            if (up != null)
            {
                up.Close();
            }
            //dogum gunleri penceresini baglayq : bu pencere lnklAcBirthdays_LinkClicked hadisesi ile acilir
            if (ub != null)
            {
                ub.Close();
            }
            //formalari bagladiq indi cunki formalar baglananda bezi kecidler enabel olur
            //kecidleri disable edek
            lnklAcUserProfile.Enabled = false;
            lnklAcBirthdays.Enabled = false;
            lnklAcCongratNow.Enabled = false;
            lnklAcLogout.Enabled = false;
            GC.Collect();
        }

        //form ilk defe gorunende
        private void formMain_Shown(object sender, EventArgs e)
        {/* //gorduyumuz kimi burani temiz yigisdirdiq attim bi isleri splash formuna
          * bununla da prqram daha yaxshi acilacaq
            //registry-deki melumatlara da baxaq - registry deyil bu eslinde 
            //ap settings faylina baxir evvel registr idi
            loadRegistryData();
            
            //xeberler bolmesinde ilk olaraq hecne yuklemediyine gore
            //oz melumatimizi yazaq
            webBrowser.DocumentText = "<html><body><h4 align=\"center\">" +
                                      "Bu bölmədə görəcəyiniz bütün məlumatlar <a id=\"openWithBrowser\" href=\"http://azinf.net/about.php\">" +
                                      "azinf.net</a> saytının veb xidmətidir.<br />" +
                                      "Son xəbərləri izləmək üçün yuxarıdakı düymələrdən istafadə edə bilərsiniz" +
                                      "</h4></body></html>";
        */
        }

        private void cmbAzSendToPrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAzSendToPrefix.SelectedIndex > 1)//azercell abunacisine gondermirse
            {
                MessageBox.Show("Seçdiyiniz kod Azercell-ə aid olmadığından,\n balansınızdan 11 kontur çıxılacaqdır!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
        }

        //AutoCongrat sifrenin berpasi
        Thread thAcRememberPassword;
        private void acRememberPassword()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lnklAcRememberPassword.Enabled = false;
                    //this.Cursor = Cursors.WaitCursor;
                    pbAcRememberPasswordLoading.Visible = true;
                });

                string username = txtAcUsername.Text.Trim();
                if (username.Length > 0)
                {
                    string param = "username=" + username;
                    GetResponseByRequest grr =
                        new GetResponseByRequest("http://yoxlama.com/AutoCongratulate/sendUserPassword.php",
                                                  param, null);
                    grr.StartProcess();
                    StreamReader sr = new StreamReader(grr.ReceiveData);
                    string receivedData = sr.ReadToEnd();
                    if (receivedData.Contains("Sent"))
                    {
                        //sifre gonderildi
                        MessageBox.Show("Şifrəniz sizin nömrəyə sms ilə göndərildi!",
                                    "Məlumat",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                    }
                    else
                    {
                        //sifre gonderilmedi
                        MessageBox.Show("Səhv baş verdi!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Şifrənizin sizə mesjla göndərilməsi üçün \nistifadəçi adınızı uyğun xanaya daxil etməlisiniz!",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcUsername.Focus();
                    });
                }
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //this.Cursor = Cursors.Default;
                    pbAcRememberPasswordLoading.Visible = false;
                    lnklAcRememberPassword.Enabled = true;
                });
            }

            thAcRememberPassword.Abort();
        }
        private void lnklAcRememberPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThreadStart ths = new ThreadStart(acRememberPassword);
            thAcRememberPassword = new Thread(ths);
            thAcRememberPassword.Start();
        }
        //AutoCongrat sifrenin berpasi bitdi

        //AutoCongrat tebrikleri indi gonderek
        Thread thAcCogratNow;
        private void acCongratNow()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lnklAcCongratNow.Enabled = false;
                    //this.Cursor = Cursors.WaitCursor;
                    pbAcCongratNowLoading.Visible = true;
                });

                string username = loggedinUser.username;
                if (username.Length > 0)
                {
                    string param = "username=" + username;
                    GetResponseByRequest grr =
                        new GetResponseByRequest("http://yoxlama.com/AutoCongratulate/congratulate.php",
                                                  param, null);
                    grr.StartProcess();
                    StreamReader sr = new StreamReader(grr.ReceiveData);
                    string receivedData = sr.ReadToEnd();
                    if (receivedData.Contains("1"))
                    {
                        //sifre gonderildi
                        MessageBox.Show("Bu günə olan AvtoTəbrik(lər)iniz göndərildi!",
                                    "Məlumat",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                    }
                    else
                    {
                        //sifre gonderilmedi
                        MessageBox.Show("Səhv baş verdi!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Əməliyyatın icrası üçün \n sistemə daxil olmalısınız!",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtAcUsername.Focus();
                    });
                }
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //this.Cursor = Cursors.Default;
                    pbAcCongratNowLoading.Visible = false;
                    lnklAcCongratNow.Enabled = true;
                });
            }

            thAcCogratNow.Abort();
        }
        private void lnklAcCongratNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ThreadStart ths = new ThreadStart(acCongratNow);
            thAcCogratNow = new Thread(ths);
            thAcCogratNow.Start();
        }
        //AutoCongrat tebrikleri indi gonderek bitdi

        private void miAutoCongrat_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedIndex = 2;
        }

        private void miNews_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedIndex = 3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://etiraf.info");
        }

        #region Video Downloader bolmesi--------------------
        Thread tDownload = null;
        HttpWebRequest webRequest = null;
        HttpWebResponse webResponse = null;
        Stream strResponse = null;
        FileStream strLocal = null;
        private static bool downloading = false;

        private void btnVdDownload_Click(object sender, EventArgs e)
        {
            if (downloading == false)
            {
                btnVdClear_Click(sender, e);

                lblVdVideoProgress.Text = "Yükləmə başladılır...";
                ThreadStart ts = new ThreadStart(donwloadVideo);
                tDownload = new Thread(ts);
                tDownload.Start();
                downloading = true;
                btnVdDownload.Enabled = false;
                btnVdStopDownloading.Enabled = true;
                lnklVdOpenVideo.Enabled = false;
            }
        }           

        private static int PercentProgress;
        private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);
        private void UpdateProgress(Int64 BytesRead, Int64 TotalBytes)
        {
            // Calculate the download progress in percentages
            PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
            // Make progress on the progress bar
            pbVdDownloadProgress.Value = PercentProgress;
            // Display the current progress on the form
            if (PercentProgress < 100)
            {
                lblVdVideoProgress.Text = TotalBytes / 1024 + "KB-dan " + BytesRead / 1024 + "KB-ı yüklənib" + " (" + (100 - PercentProgress) + "% qalıb)";
            }
            else
            {
                lblVdVideoProgress.Text = "Yükləmə başa çatdı";
                downloading = false;
                btnVdDownload.Enabled = true;
                btnVdStopDownloading.Enabled = false;
                lnklVdOpenVideo.Enabled = true;

                //forma baglananda aktib yukleme olanda user ele ede bilerki forma baglanmasin hecvaxt ona gore 
                //bunu yaziriq ki baglansin forma
                formMain.ActiveForm.FormClosing += new FormClosingEventHandler(formMain_FormClosing1);
            }
        }

        private void donwloadVideo()
        {
            string videoUrl = "";
            string videoPageUrl = txtVdVideoPageUrl.Text.Trim();
            int selectedSite;
            selectedSite = (rbVdFacebook.Checked) ? 1 : 0;
            selectedSite = (rbVdYoutube.Checked) ? 2 : 0;
            selectedSite = (rbVdMetacafe.Checked) ? 3 : 0;
            selectedSite = (rbVdDailymotion.Checked) ? 4 : 0;
            selectedSite = (rbVdIFilm.Checked) ? 5 : 0;
            selectedSite = (rbVdRutube.Checked) ? 6 : 0;
            selectedSite = (rbVdUnknownSite.Checked) ? 7 : 0;

            VideoDownloader downloader = getDownloader(selectedSite, videoPageUrl);
            videoUrl = downloader.getVideoUrl();

            //fayli yukleyirik
            using (WebClient wcDownload = new WebClient())
            {
                try
                {
                    // Create a request to the file we are downloading
                    webRequest = (HttpWebRequest)WebRequest.Create(videoUrl);
                    // Set default authentication for retrieving the file
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    // Retrieve the response from the server
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    // Ask the server for the file size and store it
                    Int64 fileSize = webResponse.ContentLength;

                    // Open the URL for download
                    strResponse = wcDownload.OpenRead(videoUrl);
                    // Create a new file stream where we will be saving the data (local drive)
                    strLocal = new FileStream(txtVdVideoLocalPath.Text.Trim(), FileMode.Create, FileAccess.Write, FileShare.None);

                    // It will store the current number of bytes we retrieved from the server
                    int bytesSize = 0;
                    // A buffer for storing and writing the data retrieved from the server
                    byte[] downBuffer = new byte[2048];

                    // Loop through the buffer until the buffer is empty
                    while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {
                        // Write the data from the buffer to the local hard drive
                        strLocal.Write(downBuffer, 0, bytesSize);
                        // Invoke the method that updates the form's label and progress bar
                        this.Invoke(new UpdateProgessCallback(this.UpdateProgress), new object[] { strLocal.Length, fileSize });
                    }
                }
                catch (ThreadAbortException)
                {
                    MessageBox.Show("Yükləmə yarımçıq dayandırıldı!");
                }
                catch (IOException ioexc)
                {
                    MessageBox.Show("Fayla yazma ilə əlaqəli səhv baş verdi!\n" + ioexc.Message);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Səhv baş verdi!\n" + exc.Message);
                }
                finally
                {
                    // When the above code has ended, close the streams
                    if (strResponse != null)
                    {
                        strResponse.Close();
                    }
                    if (strLocal != null)
                    {
                        strLocal.Close();
                    }
                    //bu patoku baglayaq
                    if (tDownload != null)
                    {
                        tDownload.Abort();
                    }
                }
            }
        }

        private VideoDownloader getDownloader(int siteIndex, string videoPageUrl)
        {
            VideoDownloader ret = null;
            switch (siteIndex)
            {
                case 0:
                    if (ckbVideoIsPrivate.Checked)
                    {
                        ret = new FbVideoDownloader(videoPageUrl, txtVdUsername.Text.Trim(), txtVdPassword.Text.Trim());
                    }
                    else
                    {
                        ret = new FbVideoDownloader(videoPageUrl);
                    }
                    break;
                default:
                    ret = new FbVideoDownloader(videoPageUrl);
                    break;
            }
            return ret;
        }

        private void btnVdClear_Click(object sender, EventArgs e)
        {
            if (tDownload != null)
            {
                tDownload.Abort();
            }
            if (webRequest != null)
            {
                webRequest.Abort();
            }
            if (webResponse != null)
            {
                webResponse.Close();
            }
            if (strResponse != null)
            {
                strResponse.Close();
            }
            if (strLocal != null)
            {
                strLocal.Close();
            }
            pbVdDownloadProgress.Value = 0;
            lblVdVideoProgress.Text = "";
            downloading = false;
            btnVdDownload.Enabled = true;
            lnklVdOpenVideo.Enabled = true;

            GC.Collect();
        }
        private void lnklVdChoosePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sfdlgVdSaveVideo.ShowDialog() == DialogResult.OK)
            {
                txtVdVideoLocalPath.Text = sfdlgVdSaveVideo.FileName;
            }
        }
        private void lnklVdOpenVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(txtVdVideoLocalPath.Text.Trim());
        }

        private void ckbVideoIsPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbVideoIsPrivate.Checked == true)
            {
                gbVdLogin.Enabled = true;
            }
            else
            {
                gbVdLogin.Enabled = false;
            }
        }

#endregion

        private void timerForBkLoginSession_Tick(object sender, EventArgs e)
        {
            btnBkLogout_Click(sender, e);
            btnBkLogin_Click(sender, e);
        }

        private void timerForAzLoginSession_Tick(object sender, EventArgs e)
        {
            btnAzLogout_Click(sender, e);
            btnAzLogin_Click(sender, e);
        }
    }
}
