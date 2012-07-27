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
    public partial class formFeedBack : Form
    {
        public formFeedBack()
        {
            InitializeComponent();
        }

        private void lblFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com/elvin.efendiyev?v=info");
        }
    }
}
