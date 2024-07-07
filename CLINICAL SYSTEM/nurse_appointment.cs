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

namespace CLINICAL_SYSTEM
{

    public partial class nurse_appointment : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";

        int month, year;
        public static int static_month, static_year;
        public nurse_appointment()
        {
            InitializeComponent();
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = MonthName + " " + year;

            static_month = month;
            static_year = year;

            // Get the first day of the month
            DateTime startofthemonth = new DateTime(year, month, 1);

            // get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofMonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);

            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear container
            daycontainer.Controls.Clear();

            // increment month to go to next month
            month++;
            static_month = month;
            static_year = year;

            String MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = MonthName + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            // get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofMonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);

            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Nurse_patient ob = new Nurse_patient();
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Nurse_change_pass ob = new Nurse_change_pass();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clear container
            daycontainer.Controls.Clear();

            // decrement month to go to previous month
            month--;
            static_month = month;
            static_year = year;

            String MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = MonthName + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            // get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofMonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);

            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);

            }
        }

        private void nurse_appointment_Load(object sender, EventArgs e)
        {
            displayDays();
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
    }
}
