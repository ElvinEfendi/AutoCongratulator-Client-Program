using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pulsuz_Mesaj
{
    public partial class formAcUserRegistration : Form
    {
        public formAcUserRegistration()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbOperator.SelectedIndex = -1;
            txtMobileNumber.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSign.Clear();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                btnSubmit.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                string mobileOperator = (string)cmbOperator.SelectedItem;
                string mobilNumberPrefix = (string)cmbMobileNumberPrefix.SelectedItem;
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
                else
                {
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
                                    //Bakcell de bele istifadeci yoxdur
                                    MessageBox.Show("Bakcell -də daxil etdiyniz istifadəçi adı və şifrə \n" +
                                                    "kombinasiyasına uyğun məlumat tapılmadı!",
                                                    "Xəbərdarlıq",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                }
                                break;
                            case "Azercell":
                                Azercell az = new Azercell();
                                az.LoginPrefix = mobilNumberPrefix;
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
                                    //Azercell de bele istifadeci yoxdur
                                    MessageBox.Show("Azercell-də daxil etdiyniz istifadəçi adı və şifrə \n" +
                                                    "kombinasiyasına uyğun məlumat tapılmadı!",
                                                    "Xəbərdarlıq",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Warning);
                                }
                                break;
                            default:
                                //opertaor secmeyende
                                hasError = true;
                                MessageBox.Show("Operator seçməlisiniz! \n",
                                                "Xəbərdarlıq",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);
                                break;
                        }
                    }
                    if (!hasError)
                    {
                        //yuxaridaki yoxlamadan sonra da sehv olmadigina gore 
                        //melumatlari sistemin bazasina gonderirik
                        AutoCongratulate ac = new AutoCongratulate();
                        Pulsuz_Mesaj.AutoCongratulateServices.UserObject user = new Pulsuz_Mesaj.AutoCongratulateServices.UserObject();
                        user.mobileOperator = mobileOperator;
                        user.username = username;
                        user.password = password;
                        user.phoneNumber = mobilNumberPrefix + mobileNumber;
                        user.sign = sign;
                        int result = ac.createUser(user);
                        if (result == 1)//yeni ugurla yaradildisa
                        {
                            //yeni bazaya ugurla yazildi=istifadeci yaradildi
                            MessageBox.Show("Təbriklər, siz uğurla qeydiyyatdan keçdiniz\n",
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
                            //bazaya yazilma ile elaqeli sehv bas verdi, yada nese basqa anlasilmaz bir sehv
                            MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi! \n" +
                                            "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                            "Xəbərdarlıq",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }//if !hasRrror
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
                btnSubmit.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMobileNumber_Leave(object sender, EventArgs e)
        {
            //azercell de istifadeci adi nore olur adeten ona gore rehatladiraq userin isini biraz
            if ((string)cmbOperator.SelectedItem == "Azercell")
            {
                txtUsername.Text = (string)cmbMobileNumberPrefix.SelectedItem + txtMobileNumber.Text;
            }
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
