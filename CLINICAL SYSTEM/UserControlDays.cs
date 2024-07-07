using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLINICAL_SYSTEM
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none";

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            // start timer if usercontroldays is clicked
            timer1.Start();
            @event obj = new @event();
            obj.Show();

        }

        private void displayEvent()

        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String mysql = "SELECT *FROM appointment where Appointment_Date=?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = mysql;
            cmd.Parameters.AddWithValue("Appointment_Date", nurse_appointment.static_month + "/" + UserControlDays.static_day+ "/"+ nurse_appointment.static_year + "/" + lbdays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbevent.Text = reader["Appointment_Number"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();

        }

        // create a timer for auto display event if new eventis added
        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

       
    }
}
