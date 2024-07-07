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
    public partial class @event : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none";

        public @event()
        {
            InitializeComponent();
        }

        private void event_Load(object sender, EventArgs e)
        {
            txdate.Text = nurse_appointment.static_month + "/" + UserControlDays.static_day + "/" + nurse_appointment.static_year;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String mysql = "INSERT INTO Appointment(Appointment_Number, Appointment_Date,Time, Patient_Medical_Number, Patient_Name, Doctor_Name)values(?,?,?,?,?,?)";
            MySqlCommand cmd = new MySqlCommand(mysql, conn);
            cmd.CommandText = mysql;
            cmd.Parameters.AddWithValue("Appointment_Number", txevent.Text);
            cmd.Parameters.AddWithValue("Appointment_Date", txdate.Text);
            cmd.Parameters.AddWithValue("Time", dateTimePicker1.Value.TimeOfDay);
            cmd.Parameters.AddWithValue("Patient_Medical_Number", txid.Text);
            cmd.Parameters.AddWithValue("Patient_Name", txname.Text);
            cmd.Parameters.AddWithValue("Doctor_Name", txdocname.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment Saved Successfully!");
            this.Hide();
            cmd.Dispose();
            conn.Close();
        }
    }
}
