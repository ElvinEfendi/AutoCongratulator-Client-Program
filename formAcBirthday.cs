using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pulsuz_Mesaj.AutoCongratulateServices;
using System.Threading;

namespace Pulsuz_Mesaj
{
    public partial class formAcBirthday : Form
    {
        int currUserId;
        int selectedAutoCongratId = -1;
        formMain fm;
        AutoCongratulate ac;

        //allbirthday tabinin ilk dfe acildigini bilmek ucun
        bool abFirstOpening = true;
        //bunu ona gore qlobal edirik ki, avtotebrike edit edende bazaya yeniden qosulmasin,
        //ele bu arraydan gotursun avtocongrat-in melumatlarini
        List<AutoCongratObject> acObjects = null;
        //secilen cari avtotebrik-in listdeki indeksi
        //yuxaridaki arraydan edit ednde istifade etmek ucundur buda
        int selectedRowIndex = -1;

        public formAcBirthday(formMain fm, int currUserId)
        {
            InitializeComponent();
            this.currUserId = currUserId;
            this.fm = fm;
            //bu formani acan duymeni disable edek ki basqa pencere aca bilmesin
            fm.lnklAcBirthdays.Enabled = false;
            //autocongrat obyekti yaradaq
            ac = new AutoCongratulate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNbClearMessage_Click(object sender, EventArgs e)
        {
            txtNbMessage.Clear();
        }

        private void txtNbMessage_TextChanged(object sender, EventArgs e)
        {
            int tmp = txtNbMessage.Text.Trim().Length;
            if (tmp <= 140)
            {
                txtNbRemainderCount.Text = (140 - tmp).ToString();
            }
            else
            {
                txtNbMessage.Text = txtNbMessage.Text.Remove(140);
                MessageBox.Show("Siz mesajdakı simvolların sayı üçün qoyulmuş limiti keçdiniz", "Xəbərdarlıq");
            }
        }

        private void btnNbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                btnNbSubmit.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                bool hasError = false;
                bool errorShown = false;

                AutoCongratObject acObject = new AutoCongratObject();

                acObject.userId = currUserId;

                if (txtNbTitle.Text.Length < 3 || txtNbTitle.Text.Length > 100)
                {
                    hasError = true;
                    MessageBox.Show("Təbrikin başlığını düzgün daxil etmədiniz!\n" +
                                    "Təbrikin başlığı ən azı 3 an çoxu 100 simvol ola bilər",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                    errorShown = true;
                }
                else
                {
                    acObject.title = txtNbTitle.Text.Trim();
                }
                if (cmbNbNumberPrefix.SelectedIndex > -1)
                {
                    if (txtNbReceiverNumber.Text.Length != 7)
                    {
                        hasError = true;
                        if (!errorShown)
                        {
                            MessageBox.Show("Daxil etdiyiniz nömrə düzgün deyil(7 rəqəmli olmalıdır)!",
                                            "Xəbərdarlıq",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                            errorShown = true;
                        }
                    }
                    else
                    {
                        acObject.receiverFullNumber = cmbNbNumberPrefix.SelectedItem.ToString() +
                                                      txtNbReceiverNumber.Text;
                    }
                }
                else
                {
                    hasError = true;
                    if (!errorShown)
                    {
                        MessageBox.Show("Nömrənin kodunu seçməlisiniz!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                        errorShown = true;
                    }
                }
                string tmpDate = dtpNbBirthDate.Value.Year.ToString() + "-" +
                                 dtpNbBirthDate.Value.Month.ToString() + "-" +
                                 dtpNbBirthDate.Value.Day.ToString();
                acObject.birthDate = tmpDate;
                if (txtNbMessage.Text.Length < 7)
                {
                    hasError = true;
                    if (!errorShown)
                    {
                        MessageBox.Show("Mesaj ən azı 7 simvol olmalıdır!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    acObject.message = txtNbMessage.Text;
                }

                if (!hasError)
                {
                    //error yoxdu demeli yarada bilerik
                    int rt = ac.createAutoCongrat(acObject);
                    if (rt>0) //yeni id qaytaribsa - ugurla daxil edibse
                    {
                        //ikinci tabi acanda listi refresh elesin cunki teze avtocongrat elave edildi
                        abFirstOpening = true;
                        //yeni yaradilan avtotebrikin id sini de obyekte elave edek
                        acObject.id = rt;
                        //avtocongrat bazaya yazildi indi onu siyahi varsa siyahiyada yazaq
                        if (acObjects != null)
                        {
                            //en uste elave edir
                            acObjects.Insert(0, acObject);
                        }

                        MessageBox.Show("Təbriklər, yeni AvtoTəbrik-iniz uğurla yaradıldı!",
                                        "Məlumat",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                    else if (rt == -3)
                    {
                        //lisenziya problemi:avtotebrik limiti dolub
                        MessageBox.Show("Sizin təbrik yaratma limitiniz dolmuşdur!\n" +
                                    "Daha çox təbrik yaratmaq üçün müəllif ilə əlaqə saxlayın\n" +
                                    "E-mail: elvin.efendiyev@gmail.com",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);

                    }
                    else if (rt == 0)
                    {
                        MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi!\n" +
                                        "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }
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
                this.Cursor = Cursors.Default;
                btnNbSubmit.Enabled = true;
            }
        }

        private void formAcBirthday_Load(object sender, EventArgs e)
        {
            //bakcell istifadecileri yalniz 55, 50, 51, 70 e gondere bilir
            if (fm.loggedinUser.mobileOperator == "Bakcell")
            {
                cmbNbNumberPrefix.Items.Remove("77");
                cmbNbNumberPrefix.Items.Remove("40");
                //bakcellde 140 simvol olur
                txtNbRemainderCount.Text = "140";
            }
        }

        private void tbcAcBirthdays_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbcAb tabi ilk defe acilanda bunu etsin
            if (tbcAcBirthdays.SelectedIndex == 1 && abFirstOpening == true)
            {
                refreshDataGrid();
                abFirstOpening = false;
            }
            if (selectedRowIndex > -1 && tbcAcBirthdays.SelectedIndex == 2)
            {
                //avtocongrat secilibse
                tbcAcBirthdays.SelectedIndex = 2;
            }
            else if (tbcAcBirthdays.SelectedIndex == 2)
            {
                MessageBox.Show("Siyahıda heç bir sətr seçilməyib!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                tbcAcBirthdays.SelectedIndex = 1;
            }
        }

        //listi refresh edek
        Thread thRefreshDataGrid;
        private void refreshDataGridInThread()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Cursor = Cursors.WaitCursor;
                    });
                }
                //avtotebrikleri bazdan almamisiqsa alib liste doldura
                if (acObjects == null)
                {
                    acObjects = new List<AutoCongratObject>();
                    AutoCongratObject[] tmpAco = ac.getAutoCongrats(currUserId);
                    for (int i = 0; i < tmpAco.Length; i++)
                    {
                        acObjects.Add(tmpAco[i]);
                    }
                }

                //listimizdeki avto tebrikleri  datagridvyuya dolduraq                
                if (dgvAbBirthdayList.InvokeRequired)
                {
                    dgvAbBirthdayList.Invoke((MethodInvoker)delegate
                    {
                        dgvAbBirthdayList.Columns.Clear();
                        dgvAbBirthdayList.AutoGenerateColumns = false;
                    });
                }
                else
                {
                    dgvAbBirthdayList.Columns.Clear();
                    dgvAbBirthdayList.AutoGenerateColumns = false;
                }

                DataGridViewTextBoxColumn firstColumn = new DataGridViewTextBoxColumn();
                firstColumn.DataPropertyName = "id";
                firstColumn.HeaderText = "Kod";
                firstColumn.Resizable = DataGridViewTriState.False;
                firstColumn.Width = 40;
                firstColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewTextBoxColumn secondColumn = new DataGridViewTextBoxColumn();
                secondColumn.DataPropertyName = "title";
                secondColumn.HeaderText = "Təbrikin adı";
                secondColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewTextBoxColumn thirdColumn = new DataGridViewTextBoxColumn();
                thirdColumn.DataPropertyName = "birthDate";
                thirdColumn.HeaderText = "Təbrik günü";
                thirdColumn.Width = 100;
                thirdColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgvAbBirthdayList.InvokeRequired)
                {
                    dgvAbBirthdayList.Invoke((MethodInvoker)delegate
                    {
                        dgvAbBirthdayList.Columns.Add(firstColumn);
                        dgvAbBirthdayList.Columns.Add(secondColumn);
                        dgvAbBirthdayList.Columns.Add(thirdColumn);

                        dgvAbBirthdayList.DataSource = acObjects;

                        //listde ele edek ki hec bir row secilmis olmasin
                        dgvAbBirthdayList.ClearSelection();
                    });
                }
                else
                {
                    dgvAbBirthdayList.Columns.Add(firstColumn);
                    dgvAbBirthdayList.Columns.Add(secondColumn);
                    dgvAbBirthdayList.Columns.Add(thirdColumn);

                    dgvAbBirthdayList.DataSource = acObjects;

                    //listde ele edek ki hec bir row secilmis olmasin
                    dgvAbBirthdayList.ClearSelection();
                }
                //gonderlimislerin rengini deyisek
                int tmpDgvRL = dgvAbBirthdayList.Rows.Count;
                for (int i = 0; i < tmpDgvRL; i++)
                {
                    if (acObjects[i].wasSent == 1)
                    {
                        if (dgvAbBirthdayList.InvokeRequired)
                        {
                            dgvAbBirthdayList.Invoke((MethodInvoker)delegate
                            {
                                dgvAbBirthdayList.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                            });
                        }
                        else
                        {
                            dgvAbBirthdayList.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        }
                    }
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
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Cursor = Cursors.Default;
                    });
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            thRefreshDataGrid.Abort(); //thredi silek
        }
        private void refreshDataGrid()
        {
            ThreadStart ths = new ThreadStart(refreshDataGridInThread);
            thRefreshDataGrid = new Thread(ths);
            thRefreshDataGrid.Start();
        }
        //listi refresh etdik

        private void btnAbEdit_Click(object sender, EventArgs e)
        {
            tbcAcBirthdays.SelectedIndex = 2;
        }

        private void btnAbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAbBirthdayList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (dgvAbBirthdayList.SelectedRows.Count > 0)
                {
                    selectedRowIndex = dgvAbBirthdayList.SelectedRows[0].Index;
                    selectedAutoCongratId = Convert.ToInt32(dgvAbBirthdayList.SelectedRows[0].Cells[0].Value);
                    btnAbEdit.Enabled = true;
                    btnAbDelete.Enabled = true;
                    //ve edit tabindaki xanalari dolduraq
                    AutoCongratObject acObject = acObjects[selectedRowIndex];
                    txtEbTitle.Text = acObject.title;
                    cmbEbReceiverNumberPrefix.SelectedItem = acObject.receiverFullNumber.Substring(0, 2);
                    txtEbReceiverNumber.Text = acObject.receiverFullNumber.Substring(2);
                    dtpEbBirthDate.Text = acObject.birthDate;
                    txtEbMessage.Text = acObject.message;
                    (tbpAcEditBirthday as Control).Enabled = true;
                    //bu tebrik gonderilmishse onu deeyise bilmesi ancaq baxa bilsin
                    if (acObject.wasSent == 1)
                    {
                        btnEbClearMessage.Enabled = false;
                        btnEbSave.Enabled = false;
                    }
                    else
                    {
                        btnEbClearMessage.Enabled = true;
                        btnEbSave.Enabled = true;
                    }
                }
                else
                {
                    selectedAutoCongratId = -1;
                    selectedRowIndex = -1;
                    (tbpAcEditBirthday as Control).Enabled = false;
                    btnAbEdit.Enabled = false;
                    btnAbDelete.Enabled = false;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Səhv baş verdi!\n" + exc.Message,
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
        }

        private void btnAbRefreshList_Click(object sender, EventArgs e)
        {
            btnAbRefreshList.Enabled = false;
            refreshDataGrid();
            btnAbRefreshList.Enabled = true;
        }

        private void formAcBirthday_FormClosing(object sender, FormClosingEventArgs e)
        {
            fm.lnklAcBirthdays.Enabled = true;
            fm.Focus();
        }

        private void btnAbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                btnAbDelete.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (selectedRowIndex > -1) //yeni secileni varsa
                {
                    if (MessageBox.Show("AvtoTəbrik-i silməyə əminsiniz?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        bool rt = ac.deleteAutoCongrat(selectedAutoCongratId);
                        if (rt)
                        {
                            MessageBox.Show("AvtoTəbrik sistemdən silindi!",
                                            "Məlumat",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                            //siyahidan da silek
                            acObjects.Remove(acObjects[selectedRowIndex]);
                            //datagridi yenileyek
                            refreshDataGrid();
                            if (dgvAbBirthdayList.Rows.Count > 0)
                            {
                                dgvAbBirthdayList.Rows[0].Selected = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi!\n" +
                                            "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                            "Xəbərdarlıq",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                        }
                    }
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
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbNbNumberPrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            //azercell-li azercell abunacisine gondermirse
            if (fm.loggedinUser.mobileOperator == "Azercell" && cmbNbNumberPrefix.SelectedIndex > 1)
            {
                MessageBox.Show("Seçdiyiniz kod Azercell-ə aid olmadığından,\n balansınızdan 11 kontur çıxılacaqdır!",
                                "Xəbərdarlıq",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
        }

        private void btnEbClearMessage_Click(object sender, EventArgs e)
        {
            txtEbMessage.Clear();
        }

        private void btnEbReset_Click(object sender, EventArgs e)
        {
            try
            {
                btnEbReset.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (selectedRowIndex > -1)
                {
                    AutoCongratObject acObject = acObjects[selectedRowIndex];
                    txtEbTitle.Text = acObject.title;
                    cmbEbReceiverNumberPrefix.SelectedItem = acObject.receiverFullNumber.Substring(0, 2);
                    txtEbReceiverNumber.Text = acObject.receiverFullNumber.Substring(2);
                    dtpEbBirthDate.Text = acObject.birthDate;
                    txtEbMessage.Text = acObject.message;
                }
                else
                {
                    MessageBox.Show("Heç bir sətr seçilməyib!",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
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
                btnEbReset.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnEbSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnEbSave.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                bool hasError = false;
                bool errorShown = false;

                AutoCongratObject acObject = new AutoCongratObject();

                acObject.userId = currUserId;

                if (txtEbTitle.Text.Length < 3 || txtEbTitle.Text.Length > 100)
                {
                    hasError = true;
                    MessageBox.Show("Təbrikin başlığını düzgün daxil etmədiniz!\n" +
                                    "Təbrikin başlığı ən azı 3 an çoxu 100 simvol ola bilər",
                                    "Xəbərdarlıq",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                    errorShown = true;
                }
                else
                {
                    acObject.title = txtEbTitle.Text;
                }
                if (cmbEbReceiverNumberPrefix.SelectedIndex > -1)
                {
                    if (txtEbReceiverNumber.Text.Length != 7)
                    {
                        hasError = true;
                        if (!errorShown)
                        {
                            MessageBox.Show("Daxil etdiyiniz nömrə düzgün deyil(7 rəqəmli olmalıdır)!",
                                            "Xəbərdarlıq",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                            errorShown = true;
                        }
                    }
                    else
                    {
                        acObject.receiverFullNumber = cmbEbReceiverNumberPrefix.SelectedItem.ToString() +
                                                      txtEbReceiverNumber.Text;
                    }
                }
                else
                {
                    hasError = true;
                    if (!errorShown)
                    {
                        MessageBox.Show("Nömrənin kodunu seçməlisiniz!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                        errorShown = true;
                    }
                }
                string tmpDate = dtpEbBirthDate.Value.Year.ToString() + "-" +
                                 dtpEbBirthDate.Value.Month.ToString() + "-" +
                                 dtpEbBirthDate.Value.Day.ToString();
                acObject.birthDate = tmpDate;
                if (txtEbMessage.Text.Length < 7)
                {
                    hasError = true;
                    if (!errorShown)
                    {
                        MessageBox.Show("Mesaj ən azı 7 simvol olmalıdır!",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    acObject.message = txtEbMessage.Text;
                }

                if (!hasError)
                {
                    //avtocongratin id-si
                    acObject.id = selectedAutoCongratId;
                    //error yoxdu demeli yeniliye bilerik
                    bool rt = ac.updateAutoCongrat(acObject, selectedAutoCongratId);
                    if (rt)
                    {
                        //lokaldaki yerini de tezeliyek
                        acObjects[selectedRowIndex] = acObject;
                        MessageBox.Show("Təbriklər, AvtoTəbrik-iniz uğurla yeniləndi!",
                                        "Məlumat",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sorğunun icrası ilə əlaqəli səhv baş verdi\n!" +
                                        "Zəhmət olmasa bir az sonra yenidən yoxlayın",
                                        "Xəbərdarlıq",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);
                    }
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
                this.Cursor = Cursors.Default;
                btnEbSave.Enabled = true;
            }
        }

        //filtrasiya ucun
        private bool equalDate(AutoCongratObject ac)
        {
            string tmpDate = dtpAbFilter.Value.Year.ToString() + "-" +
                             dtpAbFilter.Value.Month.ToString() + "-" +
                             dtpAbFilter.Value.Day.ToString();
            if (ac.birthDate == tmpDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //filtrasiya
        private void btnAbFilter_Click(object sender, EventArgs e)
        {
            var filteredList = acObjects.FindAll(equalDate);
            dgvAbBirthdayList.DataSource = filteredList;

            //secileni olmasin
            dgvAbBirthdayList.ClearSelection();

            //gonderilmislerin rengini deyisir
            int tmpDgvRL = dgvAbBirthdayList.Rows.Count;
            for (int i = 0; i < tmpDgvRL; i++)
            {
                if (filteredList[i].wasSent == 1)
                {
                    dgvAbBirthdayList.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                }
            }

        }
    }
}
