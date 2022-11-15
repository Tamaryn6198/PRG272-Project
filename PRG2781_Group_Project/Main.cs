using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            MemoryStream ms;
            byte[] bytes = null;

            // Get image using memory stream
            if (pictureBox.Image != null)
            {
                ms = new MemoryStream();
                pictureBox.Image.Save(ms, ImageFormat.Jpeg);
                bytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytes, 0, bytes.Length);

                // Get info
                string stdNum = stdNumTxt.Text;
                string name = stdNameTxt.Text;
                string surname = stdSurnameTxt.Text;
                DateTime dob = stdDobDate.Value.Date;
                string gender = stdGenderTxt.Text;
                string phone = stdPhoneTxt.Text;
                string address = stdAddressTxt.Text;
                string module = stdModuleBox.Text;

                // Add to database
                dataHandler.AddStudent(stdNum, name, surname, bytes, dob, gender, phone, address, module);
            }
            else
            {
                // Get info
                string stdNum = stdNumTxt.Text;
                string name = stdNameTxt.Text;
                string surname = stdSurnameTxt.Text;
                DateTime dob = stdDobDate.Value.Date;
                string gender = stdGenderTxt.Text;
                string phone = stdPhoneTxt.Text;
                string address = stdAddressTxt.Text;
                string module = stdModuleBox.Text;

                // Add to database
                dataHandler.AddStudent(stdNum, name, surname, bytes, dob, gender, phone, address, module);
            }
        }

        private void displayStdButt_Click(object sender, EventArgs e)
        {
            DisplayStudentDGV();
        }

        private void updateStdButt_Click(object sender, EventArgs e)
        {
            MemoryStream ms;
            byte[] bytes = null;

            // Get image using memory stream
            if (pictureBox.Image != null)
            {
                ms = new MemoryStream();
                pictureBox.Image.Save(ms, ImageFormat.Jpeg);
                bytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytes, 0, bytes.Length);

                // Get info
                string stdNum = stdNumTxt.Text;
                string name = stdNameTxt.Text;
                string surname = stdSurnameTxt.Text;
                DateTime dob = stdDobDate.Value.Date;
                string gender = stdGenderTxt.Text;
                string phone = stdPhoneTxt.Text;
                string address = stdAddressTxt.Text;
                string module = stdModuleBox.Text;

                dataHandler.UpdateStudent(stdNum, stdNum, name, surname, bytes, dob, gender, phone, address, module);    
            }
            else
            {
                // Get info
                string stdNum = stdNumTxt.Text;
                string name = stdNameTxt.Text;
                string surname = stdSurnameTxt.Text;
                DateTime dob = stdDobDate.Value.Date;
                string gender = stdGenderTxt.Text;
                string phone = stdPhoneTxt.Text;
                string address = stdAddressTxt.Text;
                string module = stdModuleBox.Text;

                dataHandler.UpdateStudent(stdNum, stdNum, name, surname, bytes, dob, gender, phone, address, module);
            }
        }

        private void deleteStdButt_Click(object sender, EventArgs e)
        {
            // Find selected entry/row
            string selectedID = null;

            if (stdDgv.SelectedCells.Count > 0)
            {
                selectedID = stdDgv.SelectedCells[0].Value.ToString();
            }
            //string selectedID = row.Cells[0].Value.ToString();

            // Update database entry
            if (selectedID != null)
            {
                dataHandler.DeleteStudent(selectedID);
            }

            // Update data grid view
            DisplayStudentDGV();
        }

        private void searchStdButt_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            list = dataHandler.SearchStudent(searchStdTxt.Text);

            stdNumTxt.Text = list[0].ToString();
            stdNameTxt.Text = list[1].ToString();
            stdSurnameTxt.Text = list[2].ToString();
            /*byte[] bytes = new byte[list[3].ToString().Length];
            string[] str = list[3].ToString().Split();
            bytes = Convert.ToByte(str);
            MemoryStream ms = new MemoryStream(bytes);
            pictureBox.Image.Clone(ms);*/

            /*            byte[] bytes = null;
                        BinaryFormatter bf = new BinaryFormatter();
                        using (var ms = new MemoryStream())
                        {
                            bf.Serialize(ms, list[3]);
                            bytes = ms.ToArray();
                            Image img = Image.FromStream(ms);
                            pictureBox.Image = img;
                        }*/
            /*using (var ms = new MemoryStream(bytes))
            {
                Image img = Image.FromStream(ms);
                pictureBox.Image = img;
            }*/
            string host = "TAMMYLAPTOP\\SQLEXPRESS";
            string database = "BCdatabase";
            string connString = @"Data Source = " + host + "; Initial Catalog=" + database + ";Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            string query = "select StudentImage from tblStudents";
            SqlCommand imgCmd = new SqlCommand(query, conn);
            
            byte[] bytes = null;
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, imgCmd.ExecuteScalar());
                bytes = ms.ToArray();
                /*Image img = Image.FromStream(ms);
                pictureBox.Image = img;*/

                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
            }

            //pictureBox.Image = img;

            conn.Close();

            stdDobDate.Value = Convert.ToDateTime(list[4]);
            stdGenderTxt.Text = list[5].ToString();
            stdPhoneTxt.Text = list[6].ToString();
            stdAddressTxt.Text = list[7].ToString();
            //stdModuleBox.Text = list[7].ToString();
        }
    }
}
