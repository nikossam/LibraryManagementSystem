using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void password_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(password_TextBox.Text == "Password")
            {
                password_TextBox.Clear();
                password_TextBox.PasswordChar = '*';
            }
        }

        private void userName_TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (userName_TextBox.Text == "Username")
            {
                userName_TextBox.Clear();
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from loginTable where username='"+userName_TextBox.Text+"' and pass ='"+password_TextBox.Text+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                DashBoard dsa = new DashBoard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username OR Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
