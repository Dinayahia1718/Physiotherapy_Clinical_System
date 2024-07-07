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
    public partial class eventform : Form

    {
        //create a connectionstring
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none";
        public eventform()
        {
            InitializeComponent();
        }

        private void eventform_Load(object sender, EventArgs e)
        {
            txdate.Text =nurse_appointment.static_month+"/"+ UserControlDays.static_day + "/" + nurse_appointment.static_year;  
        }

        private void txdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String mysql = "INSERT INTO Appointment(Appointment_Date,event_c)values(?,?)";
            MySqlCommand cmd = new MySqlCommand(mysql, conn);
            cmd.CommandText = mysql;
            cmd.Parameters.AddWithValue("Appointment_Date", txdate.Text);
            cmd.Parameters.AddWithValue("event_c", txevent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            cmd.Dispose();
            conn.Close();
        }
    }
}
