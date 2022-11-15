using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.IO;

namespace PRG2781_Group_Project
{
    internal class DataHandler
    {
        // details for connection string
        static string host = "TAMMYLAPTOP\\SQLEXPRESS";
        static string database = "BCdatabase";
        public static string connString = @"Data Source = " + host + "; Initial Catalog=" + database + ";Integrated Security=SSPI";

        // variables for connection and commands
        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cmd2;

        public DataHandler()
        {
            // Constructor
        }

        // Methods for Modules


        //-----------------------------------------------------------------------------------------------------------------------------------------------------//

        // Methods for Students

        //Get students method
        public DataSet GetStudents()
        {
            string sqlCmd = @"SELECT * FROM tblStudents";

            conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
                DataSet ds = new DataSet();

                da.Fill(ds, "tblStudents");
                return ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return null;
        }

        // Add method
        public void AddStudent(string stdNum, string name, string surname, byte[] bytes, DateTime dob, string gender, string phone, string address, string module)
        {
            string sqlCmd = @"INSERT INTO tblStudents VALUES ('" + stdNum + "', '" + name + "', '" + surname + "', '" + bytes + "', '" + dob + "', '" + gender + "', '" + phone + "', '" + address + "')";
            string sqlCmd2 = @"INSERT INTO tblStudent_Module VALUES ('" + stdNum + "', '" + module + "')";

            conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();

                cmd2 = new SqlCommand(sqlCmd2, conn);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Update method
        public void UpdateStudent(string selectedID, string stdNum, string name, string surname, byte[] bytes, DateTime dob, string gender, string phone, string address, string module)
        {
            string sqlCmd = @"UPDATE tblStudents SET StudentNumber = '" + stdNum + "', StudentName = '" + name + "', StudentSurname = '" + surname + "', StudentImage = '" + bytes + "', DateOfBirth = '" + dob + "', Gender = '" + gender + "', PhoneNumber = '" + phone + "', Address = '" + address + "' WHERE StudentNumber = '" + selectedID + "'";
            string sqlCmd2 = @"UPDATE tblStudent_Module SET StudentNumber = '" + stdNum + "', ModuleCode = '" + module + "'";

            conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();

                cmd2 = new SqlCommand(sqlCmd2, conn);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        // Delete method
        public void DeleteStudent(string selectedID)
        {
            string sqlCmd = @"DELETE FROM tblStudents WHERE StudentNumber = '" + selectedID + "'";
            string sqlCmd2 = @"DELETE FROM tblStudent_Module WHERE StudentNumber = '" + selectedID + "'";

            conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();

                cmd2 = new SqlCommand(sqlCmd2, conn);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        // Search method
        public List<string> SearchStudent(string selectedID)
        {
            string sqlCmd = @"SELECT * FROM tblStudents WHERE StudentNumber = '" + selectedID + "'";
            conn = new SqlConnection(connString);

            try
            {
                List<string> list = new List<string>();
                conn.Open();
                cmd = new SqlCommand(sqlCmd, conn);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();

                    list.Add(dr["StudentNumber"].ToString());
                    list.Add(dr["StudentName"].ToString());
                    list.Add(dr["StudentSurname"].ToString());
                    //list.Add(dr["StudentImage"].ToString());
                    list.Add(dr["DateOfBirth"].ToString());
                    list.Add(dr["Gender"].ToString());
                    list.Add(dr["PhoneNumber"].ToString());
                    list.Add(dr["Address"].ToString());
                }

                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }

            return null;
        }
    }
}
