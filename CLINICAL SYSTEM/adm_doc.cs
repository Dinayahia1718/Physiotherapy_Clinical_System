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
using System.ComponentModel.DataAnnotations;

namespace CLINICAL_SYSTEM
{
    public partial class adm_doc : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";
        public adm_doc()
        {
            InitializeComponent();
            BindGrid();
        }

        private void BindGrid()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM doctors", con))

                {

                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {
                            sda.Fill(dt);

                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoGenerateColumns = false;
                        }

                    }

                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                String query = "insert into doctors values('" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
                AddData add = new AddData();

                add.adding(query);
                MessageBox.Show("Doctor added successfully!");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }



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

        public void TextBoxFilter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query= "select * from doctors where Doc_ND='"+textBox1.Text+"'";
            MySqlDataAdapter sda= new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(sda);
            var ds= new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
            conn.Close();
        }
        public void grid()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from doctors";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            adm_nurse obj = new adm_nurse();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();

                string idLocRemv = dataGridView1.CurrentRow.Cells["Doc_ND"].Value.ToString();

                string removeVolCred = "DELETE FROM doctors WHERE Doc_ND = " + idLocRemv;

                using (MySqlCommand command = new MySqlCommand(removeVolCred, conn))
                {
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Doctor Deleted Successfully!");

                conn.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            TextBoxFilter();
        }
    }
}
