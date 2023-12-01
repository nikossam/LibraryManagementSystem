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
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-T3HRPBP\\SQLEXPRESS02; database=library; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where book_return_date is null";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            issuedBooks_dataGridView.DataSource = ds.Tables[0];

       

            cmd.CommandText = "select * from IRBook where book_return_date is not null";
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet dS = new DataSet();
            dAdapter.Fill(dS);

            returnedBooks_dataGridView.DataSource = dS.Tables[0];
        }
    }
}
