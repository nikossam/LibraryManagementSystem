using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
    public partial class ViewStudent : Form
    {
       

        public ViewStudent()
        {
            InitializeComponent();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String name = sName_textBox.Text;
                String enrollement = sEnroll_textBox.Text;
                String deparment = sDepartment_textBox.Text;
                String semester = sSemester_textBox.Text;
                Int64  contact = Int64.Parse(sContact_textBox.Text);
                String email = sEmail_textBox.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname = '" + name + "',enroll='" + enrollement + "',dep='" + deparment + "',sem='" + semester + "',contact=" + contact + ",email='" + email + "' where stuid=" + rowId + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be delete.Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid=" + rowId + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data will be lost.","Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void enroll_textBox_TextChanged(object sender, EventArgs e)
        {
            if(enroll_textBox.Text != "")
            {
                label1.Visible = false;
                System.Drawing.Image image = System.Drawing.Image.FromFile("C:/Users/nikos/Desktop/LibraryManagement/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll LIKE '"+ sEnroll_textBox.Text +"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;
                System.Drawing.Image image = System.Drawing.Image.FromFile("C:/Users/nikos/Desktop/LibraryManagement/search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowId;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid= " + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            sName_textBox.Text = ds.Tables[0].Rows[0][1].ToString();
            sEnroll_textBox.Text = ds.Tables[0].Rows[0][2].ToString();
            sDepartment_textBox.Text = ds.Tables[0].Rows[0][3].ToString();
            sSemester_textBox.Text = ds.Tables[0].Rows[0][4].ToString();
            sContact_textBox.Text = ds.Tables[0].Rows[0][5].ToString();
            sEmail_textBox.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void ViewStudent_Load_1(object sender, EventArgs e)
        {

        }

        private void refresh_button_Click(object sender, EventArgs e)
        {           
            ViewStudent_Load(this,null);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid= " + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowId = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            sName_textBox.Text = ds.Tables[0].Rows[0][1].ToString();
            sEnroll_textBox.Text = ds.Tables[0].Rows[0][2].ToString();
            sDepartment_textBox.Text = ds.Tables[0].Rows[0][3].ToString();
            sSemester_textBox.Text = ds.Tables[0].Rows[0][4].ToString();
            sContact_textBox.Text = ds.Tables[0].Rows[0][5].ToString();
            sEmail_textBox.Text = ds.Tables[0].Rows[0][6].ToString();
        }
    }
}
