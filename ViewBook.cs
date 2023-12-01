using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        int bid;
        Int64 rowId;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where bid= "+ bid +"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            bName_textBox.Text = ds.Tables[0].Rows[0][1].ToString();
            bAuthor_textBox.Text = ds.Tables[0].Rows[0][2].ToString();
            bPublic_textBox.Text = ds.Tables[0].Rows[0][3].ToString();
            bDateTimePicker.Text = ds.Tables[0].Rows[0][4].ToString();
            bPrice_textBox.Text = ds.Tables[0].Rows[0][5].ToString();
            bQuan_textBox.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be delete.Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where bid="+ rowId +"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = bName_textBox.Text;
                String bauthor = bAuthor_textBox.Text;
                String bpublication = bPublic_textBox.Text;
                String bdate = bDateTimePicker.Text;
                Int64 bprice = Int64.Parse(bPrice_textBox.Text);
                Int64 bquan = Int64.Parse(bQuan_textBox.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewBook set bName = '" + bname + "',bAuthor='" + bauthor + "',bPubl='" + bpublication + "',bPDate='" + bdate + "',bPrice=" + bprice + ",bQuan=" + bquan + " where bid=" + rowId + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            
        }

        private void bookName_textBox_TextChanged(object sender, EventArgs e)
        {
            if(bookName_textBox.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bName LIKE '" + bookName_textBox.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bName LIKE '"+ bookName_textBox.Text +"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            bookName_textBox.Clear();
            panel2.Visible = false;
        }
    }
}
