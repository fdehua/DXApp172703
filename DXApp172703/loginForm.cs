using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApp172703
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(string[] args)
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}