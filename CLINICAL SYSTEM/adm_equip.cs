using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CLINICAL_SYSTEM
{

    public partial class adm_equip : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";
        public adm_equip()
        {
            InitializeComponent();
        }

        public void TextBoxFilter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from equipment where Equip_ID='" + textBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        public void grid()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from equipment";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                String query = "insert into equipment values('" + textBox10.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                AddData add = new AddData();
                add.adding(query);
                MessageBox.Show("Equipment added successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string idLocRemv = dataGridView1.CurrentRow.Cells["Equip_ID"].Value.ToString();
                string removeVolCred = "DELETE FROM equipment WHERE Equip_ID = " + idLocRemv;
                using (MySqlCommand command = new MySqlCommand(removeVolCred, conn))
                {
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Equipment Deleted Successfully!");
                conn.Close();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TextBoxFilter();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            grid();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            adm_doc ob = new adm_doc();
            ob.Show();
            this.Hide();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            adm_nurse ob = new adm_nurse();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
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

        private void label4_Click_1(object sender, EventArgs e)
        {
            adm_doc obj = new adm_doc();
            obj.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            adm_nurse obj = new adm_nurse();
            obj.Show();
            this.Hide();
        }
    }
}
