using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CLINICAL_SYSTEM
{
    public partial class doc_change_pass : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";

        public doc_change_pass()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Doc_app ob = new Doc_app();
            ob.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Logout?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Login_Page obj = new Login_Page();
                obj.Show();
                this.Hide();
            }
            else
            {
                this.Activate();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient_Medical_Record ob = new Patient_Medical_Record();
            ob.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlDataAdapter sda = new MySqlDataAdapter("select Doc_Pass from doctors where Doc_Pass= '" + oldpass.Text + "'", conn); 
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if(dt.Rows.Count.ToString() == "1")
            {
                if(newpass.Text == confirmpass.Text)
                {
                    conn.Open();
                    MySqlCommand cmd= new MySqlCommand("update doctors set Doc_Pass= '"+confirmpass.Text+"' where Doc_Pass= '"+ oldpass.Text+ "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Updated!");
                }
                else
                {
                    MessageBox.Show("Wrong Password! Please Check It!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Wrong Old Password! Please Check It!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
