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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            enroll_textBox.Clear();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where std_enroll = '"+ enroll_textBox.Text +"' and book_return_date IS NULL";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or no book issued.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            enroll_textBox.Clear();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String bname;
        String bdate;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }

            bName_textBox.Text = bname;
            bIssueDate_textBox.Text = bdate;           

        }

        private void return_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRBook set book_return_date = '"+ dateTimePicker1.Text +"' where std_enroll = '"+ enroll_textBox.Text +"' and id= "+ rowid +"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Successful.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void enroll_textBox_TextChanged(object sender, EventArgs e)
        {
            if(enroll_textBox.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }
    }
}
