using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace phoneBook
{
    public partial class contactsListView : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\MASHAL_BCS\5thSemesterMU\CS\CS_PROJECTS\phoneBook\phoneBook\phoneBook_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public contactsListView()
        {
            InitializeComponent();
        }

        private void contactsListView_Load(object sender, EventArgs e)
        {
            searchTxt.Text = "Search Name";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT firstName, phoneNumber from phoneBookTbl", conn);
            DataTable data_Table = new DataTable();
            sda.Fill(data_Table);
            dataGridView1.DataSource = data_Table;

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (searchTxt.Text == "" || searchTxt.Text == "Search Name")
            {
                MessageBox.Show("Please enter contact to search!");
                return;
            }

            if(searchTxt.Text != "" || searchTxt.Text !="Search Name"){
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT firstName, phoneNumber from phoneBookTbl WHERE firstName='"+searchTxt.Text+"'", conn);
            DataTable data_Table = new DataTable();
            sda.Fill(data_Table);
            dataGridView1.DataSource = data_Table;

            conn.Close();
            }
        }

        private void searchTxt_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
        }

        private void searchTxt_MouseLeave(object sender, EventArgs e)
        {
            if (searchTxt.Text == "")
            {
                searchTxt.Text = "Search Name";
            }
        }

     

  
    
    }
}
