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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CLINICAL_SYSTEM
{
    public partial class adm_nurse : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";

        public adm_nurse()
        {
            InitializeComponent();
        }

        public void TextBoxFilter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from nurse where Nurse_ND='" + textBox1.Text + "'";
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
            string query = "select * from Nurse_ND";
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
                String query = "insert into nurse values('" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                AddData add = new AddData();

                add.adding(query);
                MessageBox.Show("Nurse added successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            adm_doc obj = new adm_doc();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            adm_equip obj = new adm_equip();
            obj.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TextBoxFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grid();
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

        private void label4_Click_1(object sender, EventArgs e)
        {
            adm_doc obj = new adm_doc();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            adm_equip obj = new adm_equip();
            obj.Show();
            this.Hide();
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
    }
}
