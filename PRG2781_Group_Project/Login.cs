using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG2781_Group_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Net vir die coding van die main form
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister Register = new frmRegister();
            Register.Show();
            this.Hide();
        }
    }
}
