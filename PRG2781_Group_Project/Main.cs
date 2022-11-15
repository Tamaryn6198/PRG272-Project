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
    public partial class frmMain : Form
    {
        DataHandler dataHandler = new DataHandler();
        public frmMain()
        {
            InitializeComponent();
        }

        private void uploadImgButt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(ofd.FileName);
            }
        }

        public void DisplayStudentDGV()
        {
            DataSet ds = dataHandler.GetStudents();
            stdDgv.DataSource = ds.Tables["tblStudents"].DefaultView;
        }

        private void createStdButt_Click(object sender, EventArgs e)
        {
            DisplayStudentDGV();
        }
    }
}
