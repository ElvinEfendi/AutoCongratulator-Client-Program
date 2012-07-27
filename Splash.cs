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
    public partial class Splash : Form
    {
        formMain fm;
        public Splash(formMain fm )
        {
            InitializeComponent();

            this.fm = fm;

            this.Opacity = 0;//balangıçda  formum görünmez (saydamlık  değeri=0)
        }

        private Bitmap arkaresim = new Bitmap("splash.jpg");
        // formumda  kullanacağım resmi bir  bitmap nesnesine atıyorum
        private Rectangle sınırlar = new Rectangle(0, 0, 250, 250);
        /*Formumu  yeniden  oluşturacağım için boyut  değerleri  ebatınca bir  rectangle
         nesnesi oluşturuyorum
         */

        /*override fonksiyonum sayesinde Formumu  yapmış  olduğum  resme  göre  yeniden  çiziyorum*/
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(arkaresim,
               sınırlar,
                0, 0, arkaresim.Width, arkaresim.Height,
                GraphicsUnit.Pixel);
        }

        private float opacity = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            opacity += 0.07f;//0.03'er değerlerler arttırma işlemini  yapıyorum
            this.Opacity = opacity;
            if (opacity > 1.0)
            {

                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            opacity -= 0.1f;//0.03'erlik değerlerle azaltıyom
            this.Opacity = opacity;
            if (this.Opacity == 0.0f)
            {

                this.Close();//opacite  değeri=0 olduğunda splash  form  kapanır.
            }
        }

        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            //esas formani onload ve onshown unda olan hadisleri burda edek
            try
            {
                //azercell
                fm.cmbAzUserNamePrefix.SelectedIndex = 0;
                fm.cmbAzSendToPrefix.SelectedIndex = 0;
                //bakcell
                fm.cmbBkSendToPrefix.SelectedIndex = 0;
                //3-cu esas tab secili olsun
                fm.tbcMain.SelectedIndex = 2;

                //registry-deki melumatlara da baxaq - registry deyil bu eslinde 
                //ap settings faylina baxir evvel registr idi
                fm.loadRegistryData();
            }
            catch { }
        }

    }
}
