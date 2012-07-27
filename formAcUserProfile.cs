using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Pulsuz_Mesaj
{
    public partial class formAcUserProfile : Form
    {
        int currUserId;
        formMain fm;
        AutoCongratulate ac = null;
        public formAcUserProfile(formMain fm, int userId)
        {
            this.currUserId = userId; //yeni cari istifadecinin id-si budur
            ac = new AutoCongratulate();
            this.fm = fm;
            //bu formani acan duymeni disable edek ki basqa pencere aca bilmesin
            fm.lnklAcUserProfile.Enabled = false;
            //eger qlobal userId ==-1 ise demeli login olmuyub yeni bu pencereni aca bilmez
            if (fm.acUserId == -1)
            {
                this.Close();
            }
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Profilinizi dəyişməyə əminsiniz?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    btnUpdate.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    string mobileOperator = (string)cmbOperator.SelectedItem;
                    string mobileNumberPrefix = cmbMobileNumberPrefix.SelectedItem.ToString();
                    string mobileNumber = txtMobileNumber.Text.Trim();
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    string sign = txtSign.Text.Trim();

                    bool hasError = false;

                    if (mobileNumber.Length != 7)
                    {
                        hasError = true;
                        MessageBox.Show("Mobil nömrənizi düzgün daxil etmədiniz!\nNömrə 7 rəqəmli olmalıdır",
                                        "Xəbərdarlıq",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }

                    if (!hasError)
                    {
                        switch (mobileOperator)
                        {
                            case "Bakcell":
                                Bakcell bk = new Bakcell();
                                bk.UserName = username;
                                bk.Password = password;
                                bk.Login();
                                if (bk.SuccessLogin)
                                {
                                    //heqiqetende bele istifadeci var
                                    hasError = false;
                                }
                                else
                                {
                                    //Bakcell de bele istifadeci yoxdur
                                    hasError = true;
                                }
                                break;
                            case "Azercell":
                                Azercell az = new Azercell();
                                az.LoginPrefix = mobileNumberPrefix;
                                az.UserName = mobileNumber;
                                az.Password = password;
                                az.Login();
                                if (az.SuccessLogin)
                                {
                                    //heqiqetende bele istifadeci var
                                    hasError = false;
                                }
                                else
                                {
                                    //Bakcell de bele istifadeci yoxdur
                                    hasError = true;
                                }
                                break;
                        }
                    }
                    if (!hasError)
                    {
                        //yuxaridaki yoxlamadan sonra da sehv olmadigina gore 
                        //melumatlari sistemin bazasina gonderirik
                        Pulsuz_Mesaj.AutoCongratulateServices.UserObject user = new Pulsuz_Mesaj.AutoCongratulateServices.UserObject();
                        user.mobileOperator = mobileOperator;
                        user.username = username;
                        user.password = password;
                        user.phoneNumber = mobileNumberPrefix + mobileNumber;
                        user.sign = sign;
                        //cari userin meluatlarini yenileyir, ugurlu olanda true eks halda false qaytarir
                        int result = ac.updateUser(user, currUserId);
                        if (result == 1)
                        {
                            //yeni bazaya ugurla yazildi=istifadeci yaradildi
                            //bazaya yazilma ile elaqeli sehv bas verdi
                            MessageBox.Show("Təbriklər, sizin məlumatlar uğurla yeniləndi\n",
                                            "Məlumat",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        //bu nomre artiq sistemde qydiyyatdan kecib
                        else if (result == -1)
                        {
                            MessageBox.Show("Daxil etdiyiniz nömrəyə uyğun istifadəçi artıq sistemdə mövcuddur! \n" +
                                            "Əgər şifrəni unutmuşsunuzsa \"Şifrəni xatırla\" düyməsinə sıxın",
                                            "Xəbərdarlıq",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        //bele istifadeci movcuddur
                        else if (result == -2)
                        {
                            MessageBox.Show("Daxil etdiyiniz istifadəçi adı artıq sistemdə mövcuddur! \n" +
                                            "Zəhmət olmasa fərqli istifadəçi adı seçin!",
                                            "Xəbərdarlıq",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //bazaya yazilma ile elaqeli sehv bas verdi
                            MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi! \n" +
                                            "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                            "Xəbərdarlıq",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        //Azercell ve ya Bakcell de bele istifadeci yoxdur
                        MessageBox.Show(mobileOperator + " -də daxil etdiyniz istifadəçi adı və şifrə \n" +
                            "kombinasiyasına uyğun məlumat tapılmadı!",
                            "Xəbərdarlıq",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    }
                }
                catch
                {
                    MessageBox.Show("Səhv baş verdi! \n",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    btnUpdate.Enabled = true;
                }
            }//end_of_dialogbox
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAcUserProfile_Load(object sender, EventArgs e)
        {
            //form uzerindeki komponentler melumat yuklenmeyenedek deaktiv olsun
            panel1.Enabled = false;
            //kursoru wait edek
            this.Cursor = Cursors.WaitCursor;
        }

        /**
         * istifadecini sistemin bazasindan silir
         */
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Profilinizi sistemdən silməyə əminsiniz?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    btnDeleteUser.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    bool rt = ac.deleteUser(currUserId);
                    if (rt)
                    {
                        MessageBox.Show("Sizin məlumat sistemdən silindi\n",
                                        "Məlumat",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                        //logout olaq
                        LinkLabelLinkClickedEventArgs tmpE = new LinkLabelLinkClickedEventArgs(fm.lnklAcLogout.Links[0]);
                        fm.lnklAcLogout_LinkClicked(sender, tmpE);
                    }
                    else
                    {
                        //bazaya  ile elaqeli sehv bas verdi
                        MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi! \n" +
                                        "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                        "Xəbərdarlıq",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Səhv baş verdi! \n",
                               "Xəbərdarlıq",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    btnDeleteUser.Enabled = true;
                }
            }
        }

        private void btnCurrentProfile_Click(object sender, EventArgs e)
        {
            //istifadecinin bazadaki infosunu yeniden yukleyir
            try
            {
                btnCurrentProfile.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                Pulsuz_Mesaj.AutoCongratulateServices.UserObject user = ac.getUserObject(currUserId);
                cmbOperator.SelectedItem = user.mobileOperator;
                cmbMobileNumberPrefix.SelectedItem = user.phoneNumber.Substring(0, 2);
                txtMobileNumber.Text = user.phoneNumber.Substring(2);
                txtUsername.Text = user.username;
                txtPassword.Text = user.password;
                txtSign.Text = user.sign;
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi! \n",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnCurrentProfile.Enabled = true;
            }
        }

        //userin melumatlarini goturur
        Thread thGetUserProfile;
        private void getUserProfile()
        {
            try
            {
                Pulsuz_Mesaj.AutoCongratulateServices.UserObject user = ac.getUserObject(currUserId);
                this.Invoke((MethodInvoker)delegate
                {
                    cmbOperator.SelectedItem = user.mobileOperator;
                    cmbMobileNumberPrefix.SelectedItem = user.phoneNumber.Substring(0, 2);
                    txtMobileNumber.Text = user.phoneNumber.Substring(2);
                    txtUsername.Text = user.username;
                    txtPassword.Text = user.password;
                    txtSign.Text = user.sign;
                });
            }
            catch
            {
                MessageBox.Show("Səhv baş verdi! \n",
                                "Xəbərdarlıq",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            finally
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel1.Enabled = true;
                    this.Cursor = Cursors.Default;
                });
            }
            thGetUserProfile.Abort();
        }
        //bu hadise form ilk defe gorunende isleyir
        private void formAcUserProfile_Shown(object sender, EventArgs e)
        {
            ThreadStart thsUp = new ThreadStart(getUserProfile);
            thGetUserProfile = new Thread(thsUp);
            thGetUserProfile.Start();
        }

        private void formAcUserProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            fm.lnklAcUserProfile.Enabled = true;
            fm.Focus();
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox.ObjectCollection rows = new ComboBox.ObjectCollection(cmbMobileNumberPrefix);
            rows.Clear();
            if (cmbOperator.SelectedItem.ToString() == "Bakcell")
            {
                //bakcell de prefix yalniz bir denedir
                rows.Add("55");
                cmbMobileNumberPrefix.SelectedItem = "55";
            }
            else
            {
                rows.Add("50");
                rows.Add("51");
                cmbMobileNumberPrefix.SelectedItem = "50";
            }
        }
    }
}
