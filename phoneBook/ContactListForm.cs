using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace phoneBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\MASHAL_BCS\5thSemesterMU\CS\CS_PROJECTS\phoneBook\phoneBook\phoneBook_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxadd.Visible = false;
            textBoxafn.Visible = false;
            textBoxln.Visible = false;
            textBoxpn.Visible = false;
            buttonAdd.Visible = false;
            lnlabel3.Visible = false;
            fnlabel2.Visible = false;
            addlabel4.Visible = false;
            pnlabel1.Visible = false;
            suclabel1.Visible = false;


   

        }

        private void linkLabel_addn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
            textBoxadd.Visible = true;
            textBoxafn.Visible = true;
            textBoxln.Visible = true;
            textBoxpn.Visible = true;
            buttonAdd.Visible = true;
            lnlabel3.Visible = true;
            fnlabel2.Visible = true;
            addlabel4.Visible = true;
            pnlabel1.Visible = true;
            //linkLabel_addn.Text = "Close Contact Form";
        
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
        
                SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO phoneBookTbl VALUES('" + textBoxpn.Text + "','" + textBoxafn.Text + "','" + textBoxln.Text + "','" + textBoxadd.Text + "')", conn);
                sda.SelectCommand.ExecuteNonQuery();
                suclabel1.Visible = true;
                conn.Close();
            
          
        }

        private void closeLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

  

        private void viewLab_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            contactsListView clv = new contactsListView();
            clv.ShowDialog();
        }

       
    }
}
