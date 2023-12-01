using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confrim?","Alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            sName_textBox.Clear();
            sEnroll_textBox.Clear();
            sDepartment_textBox.Clear();
            sSemester_textBox.Clear();
            sContact_textBox.Clear();
            sEmail_textBox.Clear();

            
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (sName_textBox.Text != "" && sEnroll_textBox.Text != "" && sDepartment_textBox.Text != "" && sSemester_textBox.Text != "" && sContact_textBox.Text != "" && sEmail_textBox.Text != "")
            {
                String name = sName_textBox.Text;
                String enrol = sEnroll_textBox.Text;
                String department = sDepartment_textBox.Text;
                String sem = sSemester_textBox.Text;
                Int64 contact = Int64.Parse(sContact_textBox.Text);
                String email = sEmail_textBox.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (sname, enroll, dep, sem, contact, email) values ('" + name + "','" + enrol + "','" + department + "','" + sem + "'," + contact + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                sName_textBox.Clear();
                sEnroll_textBox.Clear();
                sDepartment_textBox.Clear();
                sSemester_textBox.Clear();
                sContact_textBox.Clear();
                sEmail_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field NOT Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
    }
}
