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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (bName_textBox.Text != "" && bAuthor_textBox.Text != "" && bPublic_textBox.Text != "" && bPrice_textBox.Text != "" && bQuan_textBox.Text != "")
            {


                String bname = bName_textBox.Text;
                String bauthor = bAuthor_textBox.Text;
                String publication = bPublic_textBox.Text;
                String pdate = bDateTimePicker.Text;
                Int64 price = Int64.Parse(bPrice_textBox.Text);
                Int64 quan = Int64.Parse(bQuan_textBox.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values ('" + bname + "','" + bauthor + "','" + publication + "','" + pdate + "'," + price + "," + quan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bName_textBox.Clear();
                bAuthor_textBox.Clear();
                bPublic_textBox.Clear();
                bPrice_textBox.Clear();
                bQuan_textBox.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field NOT Allowed","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will delete your unsaved data.","Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }
    }
}
