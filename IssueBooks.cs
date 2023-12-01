using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LibraryManagementSystem
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con; 
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                for(int i = 0; i < rdr.FieldCount; i++)
                {
                    bName_comboBox.Items.Add(rdr.GetString(i));
                }
            }

            rdr.Close();
            con.Close();
        }
        

        private void enroll_textBox_TextChanged(object sender, EventArgs e)
        {
            if(enroll_textBox.Text == "")
            {
                sName_textBox.Clear();
                department_textBox.Clear();
                sSemester_textBox.Clear();
                sContact_textBox.Clear();
                sEmail_textBox.Clear();
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("You want to exit?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        int Count;

        private void search_button_Click_1(object sender, EventArgs e)
        {
            if(enroll_textBox.Text != "")
            {
                String eid = enroll_textBox.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                cmd.CommandText = "select * from NewStudent where enroll = '" + eid + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                adapter.Fill(DS);

                cmd.CommandText = "select count(std_enroll) from IRBook where std_enroll = '" + eid + "' and book_return_date IS NULL";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                Count = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                if (DS.Tables[0].Rows.Count != 0)
                {
                    sName_textBox.Text = DS.Tables[0].Rows[0][1].ToString();
                    department_textBox.Text = DS.Tables[0].Rows[0][3].ToString();
                    sSemester_textBox.Text = DS.Tables[0].Rows[0][4].ToString();
                    sContact_textBox.Text = DS.Tables[0].Rows[0][5].ToString();
                    sEmail_textBox.Text = DS.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    sName_textBox.Clear();
                    department_textBox.Clear();
                    sSemester_textBox.Clear();
                    sContact_textBox.Clear();
                    sEmail_textBox.Clear();
                    MessageBox.Show("Invalid Enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void isBook_button_Click(object sender, EventArgs e)
        {
            if (sName_textBox.Text != "")
            {
                if (bName_comboBox.SelectedIndex != -1 && Count <= 2)
                {
                    String enroll = enroll_textBox.Text;
                    String sname = sName_textBox.Text;
                    String sdep = department_textBox.Text;
                    String sem = sSemester_textBox.Text;
                    Int64 contact = Int64.Parse(sContact_textBox.Text);
                    String email = sEmail_textBox.Text;
                    String bookName = bName_comboBox.Text;
                    String bookIssueDate = dateTimePicker1.Text;

                    String eid = enroll_textBox.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into IRBook (std_enroll,std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date) values('" + enroll + "', '" + sname + "','" + sdep + "','" + sem + "'," + contact + ",'" + email + "','" + bookName + "','" + bookIssueDate + "' )";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select book or maximum number of books has been issued.", "No book selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter a valid enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
