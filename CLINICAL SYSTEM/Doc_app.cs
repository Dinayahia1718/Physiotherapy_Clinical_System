using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace CLINICAL_SYSTEM
{
    public partial class Doc_app : Form
    {
        protected FhirClient client;
        Dictionary<string, Appointment> appDict = new Dictionary<string, Appointment>();

        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";


        public Doc_app()
        {
            FhirClientSettings settings = new FhirClientSettings()
            {
                PreferredFormat = ResourceFormat.Json,
            };

            client = new FhirClient("https://fhir.simplifier.net/System-Project", settings);
            client.RequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGluYXphaHJhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMjNmZjBlZGYtYjM2NS00NGE4LWJkZmQtNmYxNTYxZTJiNjMyIiwianRpIjoiN2E1OWIxYmEtODkxZS00NTJlLWIxMTMtNTMwZTkwYzRjN2ZjIiwiZXhwIjoxNjg0MTIxODA4LCJpc3MiOiJhcGkuc2ltcGxpZmllci5uZXQiLCJhdWQiOiJhcGkuc2ltcGxpZmllci5uZXQifQ.zQE_ij6dMRZd3gNyx7etrVl_HnxUySjtHx26s7mhzBE");
            InitializeComponent();
            BindGrid();
        }

        public void TextBoxFilter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from appointment where Patient_Medical_Number='" + textBox1.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        public void grid()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select * from appointment";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void BindGrid()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM appointment", con))

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
        private void label1_Click(object sender, EventArgs e)
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

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Appointment_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            doc_change_pass obj = new doc_change_pass();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient_Medical_Record ob = new Patient_Medical_Record();
            ob.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel Appointment?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {

                    conn.Open();

                    string idLocRemv = dataGridView1.CurrentRow.Cells["Appointment_Number"].Value.ToString();
                    string removeVolCred = "DELETE FROM appointment WHERE Appointment_Number = " + idLocRemv;

                    using (MySqlCommand command = new MySqlCommand(removeVolCred, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Appointment Deleted Successfully!");

                    conn.Close();
                }
            }
            else
            {
                this.Activate();
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TextBoxFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grid();
        }
    }
}
