using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Configuration;
using System.IO;

namespace CLINICAL_SYSTEM
{
    public partial class Patient_Medical_Record : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";
        //Image picimage;

        public Patient_Medical_Record()
        {
            InitializeComponent();
            BindGrid1();
            BindGrid2();
            BindGrid3();
            BindGrid4();
            BindGrid5();
        }

        /*public void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["UploadImageToDatabase.Properties.Settings.DatabaseConnectionString"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (DataTable dt = new DataTable("Pictures"))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from nursing_assessment", conn);
                    adapter.Fill(dt);   

                }
            }
        }*/
        private void BindGrid1()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT medical_number, patient_ND, patient_Name, patient_Phone, patient_medical_case, patient_Gender from patients", con))

                {
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            patienthistory.DataSource = dt;
                            patienthistory.AutoGenerateColumns = false;

                        }
                    }

                }

            }

        }

        private void BindGrid2()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM doctor_assessment", con))

                {
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            doctorassessment.DataSource = dt;
                            doctorassessment.AutoGenerateColumns = false;

                        }

                    }

                }

            }

        }

        private void BindGrid3()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nursing_assessment", con))

                {
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            nursingassessment.DataSource = dt;
                            nursingassessment.AutoGenerateColumns = false;

                        }

                    }

                }

            }

        }

        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }

        }

        private void BindGrid4()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM medical_report", con))

                {
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            medicalreport.DataSource = dt;
                            medicalreport.AutoGenerateColumns = false;

                        }

                    }

                }

            }

        }

        private void BindGrid5()

        {
            using (MySqlConnection con = new MySqlConnection(connString))

            {

                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM orthopedist_report", con))

                {
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))

                    {

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            orthopedistreport.DataSource = dt;
                            orthopedistreport.AutoGenerateColumns = false;

                        }

                    }

                }

            }

        }
        /*Image Zoom(Image im, Size size)
        {
            Bitmap bmp = new Bitmap(im, im.Width + (im.Width * size.Width / 100), im.Height + (im.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;

        }*/

        public void TextBoxFilter()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string query = "select medical_number, patient_ND, patient_Name, patient_Phone, patient_medical_case, patient_Gender from patients where medical_number='" + textBox17.Text + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            var ds = new DataSet();
            sda.Fill(ds);
            patienthistory.DataSource = ds.Tables[0];

            string query2 = "select * from doctor_assessment where medical_number='" + textBox17.Text + "'";
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn);
            var ds2 = new DataSet();
            sda2.Fill(ds2);
            doctorassessment.DataSource = ds2.Tables[0];

            string query3 = "select * from nursing_assessment where medical_number='" + textBox17.Text + "'";
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, conn);
            var ds3 = new DataSet();
            sda3.Fill(ds3);
            nursingassessment.DataSource = ds3.Tables[0];

            string query4 = "select * from medical_report where medical_number='" + textBox17.Text + "'";
            MySqlDataAdapter sda4 = new MySqlDataAdapter(query4, conn);
            var ds4 = new DataSet();
            sda4.Fill(ds4);
            medicalreport.DataSource = ds4.Tables[0];

            string query5 = "select * from orthopedist_report where Patient_Medical_Number='" + textBox17.Text + "'";
            MySqlDataAdapter sda5 = new MySqlDataAdapter(query5, conn);
            var ds5 = new DataSet();
            sda5.Fill(ds5);
            medicalreport.DataSource = ds5.Tables[0];

            conn.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TextBoxFilter();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                pictureBox1.Image = Zoom(picimage, new Size(trackBar1.Value, trackBar1.Value));

            }
        }*/

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

        private void button8_Click(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();
            BindGrid3();
            BindGrid4();
            BindGrid5();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "insert into medical_report(medical_number,Patient_name,Patient_Age,Diagnosis," +
                    "Report_Date, Sessions_Number, Working_Place,Doctor_Signature,Equipment, Therapeutic_Exercises) values('" + maskedTextBox1.Text
                    + "','" + textBox29.Text + "','" + textBox28.Text + "','" + comboBox3.SelectedItem + "','" +
                    dateTimePicker4.Value.ToString("yyyy-MM-dd") + "','" + comboBox6.SelectedItem + "','" +
                     textBox27.Text + "','" + textBox30.Text + "','" + comboBox10.SelectedItem + "','" + comboBox11.SelectedItem + "')";
                AddData add = new AddData();
                add.adding(query);
                MessageBox.Show("Report added successfully!");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Doc_app ob = new Doc_app();
            ob.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TextBoxFilter();
        }

        
        /*private void button10_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "JPEG|*.jpg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    picimage = pictureBox1.Image;
                }
            }
        }*/

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void nursingassessment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = nursingassessment.DataSource as DataTable;
            if(dt != null)
            {
                DataRow row= dt.Rows[e.RowIndex];
                pictureBox1.Image = ConvertByteArrayToImage((byte[]) row["xray"]);
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                String mysql = "INSERT INTO doctor_assessment(patient_Name,medical_number,Gender,patient_type,Age," +
                    "Number_of_sessions,diagnosis,Payment_process,Pain_of,Past_History,Referred_to ," +
                    "swelling_of ,Stiffness ,Limitation_ROM ,Weakness_of ,Paralysis ,Objective_Others, Tenderness_of," +
                    "Assess_Date, Patient_Entry_Date ,Xray," +
                    "Lab ,Goals ,MRI ,List_Of_Problems,Patient_need,Outcome,Time_Frame,Physiotherapy_Specialist," +
                    "Signature,Signature_Date,Interventions) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                MySqlCommand cmd = new MySqlCommand(mysql, conn);
                cmd.CommandText = mysql;
                cmd.Parameters.AddWithValue("patient_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("medical_number", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("Gender", comboBox4.Text);
                cmd.Parameters.AddWithValue("patient_type", comboBox1.Text);
                cmd.Parameters.AddWithValue("Age", textBox5.Text);
                cmd.Parameters.AddWithValue("Number_of_sessions", comboBox7.SelectedItem);
                cmd.Parameters.AddWithValue("diagnosis", comboBox5.SelectedItem);
                cmd.Parameters.AddWithValue("Payment_process", textBox1.Text);
                cmd.Parameters.AddWithValue("Pain_of", textBox7.Text);
                cmd.Parameters.AddWithValue("Past_History", comboBox8.SelectedItem);
                cmd.Parameters.AddWithValue("Referred_to", textBox8.Text);
                cmd.Parameters.AddWithValue("swelling_of", textBox9.Text);
                cmd.Parameters.AddWithValue("Stiffness", textBox11.Text);
                cmd.Parameters.AddWithValue("Limitation_ROM", textBox13.Text);
                cmd.Parameters.AddWithValue("Weakness_of", textBox12.Text);
                cmd.Parameters.AddWithValue("Paralysis", textBox15.Text);
                cmd.Parameters.AddWithValue("Objective_Others", textBox14.Text);
                cmd.Parameters.AddWithValue("Tenderness_of", textBox10.Text);
                cmd.Parameters.AddWithValue("Assess_Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("Patient_Entry_Date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("Xray", textBox20.Text);
                cmd.Parameters.AddWithValue("Lab", textBox18.Text);
                cmd.Parameters.AddWithValue("Goals", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("MRI", textBox19.Text);
                cmd.Parameters.AddWithValue("List_Of_Problems", textBox3.Text);
                cmd.Parameters.AddWithValue("Patient_need", textBox21.Text);
                cmd.Parameters.AddWithValue("Outcome", textBox25.Text);
                cmd.Parameters.AddWithValue("Time_Frame", textBox24.Text);
                cmd.Parameters.AddWithValue("Physiotherapy_Specialist", textBox23.Text);
                cmd.Parameters.AddWithValue("Signature", textBox22.Text);
                cmd.Parameters.AddWithValue("Signature_Date", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("Interventions", comboBox9.SelectedItem);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully!");
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
