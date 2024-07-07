using MySql.Data.MySqlClient;
using Patagames.Ocr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ServiceStack;
using Org.BouncyCastle.Utilities.Collections;

namespace CLINICAL_SYSTEM
{
    public partial class Nurse_patient : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";

        public Nurse_patient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        { 

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Insert(textBox3.Text, ConvertImageToByte(pictureBox5.Image));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            nurse_appointment ob = new nurse_appointment();
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Nurse_change_pass ob = new Nurse_change_pass();
            ob.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String imageLocation = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg | PNG files(*.png)|*.png | All Files(*.*) |*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox4.ImageLocation = imageLocation;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("An Error Occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var objOcr = OcrApi.Create())
            {
                objOcr.Init(Patagames.Ocr.Enums.Languages.English);
                string plainText = objOcr.GetTextFromImage(pictureBox4.ImageLocation);
                textBox1.Text = plainText;
            }
        }

        private void Insert(string filename, byte[] image)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO nursing_assessment(patient_Name, medical_number, Mode_of_arrival, " +
                    "Accompanied_By, Language_Spoken,Temp,Pulse,BP,BP2,Resp_Rate,Weight,Height, Blood_sugar,Patient_Date," +
                    "Psychological_Problem ,Smoking ,Alcohol," +
                    "Allergies,If_Yes,Diet ,Specify,Appetite ,Problems," +
                    " Wt_Loss,Wt_Gain, Self_Caring, Musculoskeletal, Use_Of_Ass_Equip, refer_to_nutritionist,Specify2,filename, xray)" +
                    "values(@patient_Name, @medical_number, @Mode_of_arrival,@Accompanied_By, @Language_Spoken," +
                    "@Temp,@Pulse,@BP,@BP2,@Resp_Rate,@Weight,@Height, @Blood_sugar,@Patient_Date,@Psychological_Problem," +
                    "@Smoking ,@Alcohol,@Allergies,@If_Yes,Diet ,@Specify,@Appetite ,@Problems,@Wt_Loss,@Wt_Gain, @Self_Caring, " +
                    "@Musculoskeletal, @Use_Of_Ass_Equip,@refer_to_nutritionist,@Specify2, @filename, @image)", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@patient_Name", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@medical_number", maskedTextBox2.Text);
                        cmd.Parameters.AddWithValue("@Mode_of_arrival", comboBox4.Text);
                        cmd.Parameters.AddWithValue("@Accompanied_By", comboBox3.Text);
                        cmd.Parameters.AddWithValue("@Language_Spoken", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Temp", maskedTextBox3.Text);
                        cmd.Parameters.AddWithValue("@Pulse", maskedTextBox4.Text);
                        cmd.Parameters.AddWithValue("@BP", maskedTextBox5.Text);
                        cmd.Parameters.AddWithValue("@BP2", maskedTextBox10.Text);
                        cmd.Parameters.AddWithValue("@Resp_Rate", maskedTextBox7.Text);
                        cmd.Parameters.AddWithValue("@Weight", maskedTextBox9.Text);
                        cmd.Parameters.AddWithValue("@Height", maskedTextBox8.Text);
                        cmd.Parameters.AddWithValue("@Blood_sugar", maskedTextBox6.Text);
                        cmd.Parameters.AddWithValue("@Patient_Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Psychological_Problem", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@Smoking", comboBox5.SelectedItem);
                        cmd.Parameters.AddWithValue("@Alcohol", comboBox6.SelectedItem);
                        cmd.Parameters.AddWithValue("@Allergies", comboBox7.SelectedItem);
                        cmd.Parameters.AddWithValue("@If_Yes", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Diet", comboBox8.SelectedItem);
                        cmd.Parameters.AddWithValue("@Specify", textBox12.Text);
                        cmd.Parameters.AddWithValue("@Appetite", comboBox9.SelectedItem);
                        cmd.Parameters.AddWithValue("@Problems", comboBox10.SelectedItem);
                        cmd.Parameters.AddWithValue("@Wt_Loss", comboBox11.SelectedItem);
                        cmd.Parameters.AddWithValue("@Wt_Gain", comboBox12.SelectedItem);
                        cmd.Parameters.AddWithValue("@Self_Caring", comboBox15.Text);
                        cmd.Parameters.AddWithValue("@Musculoskeletal", comboBox16.Text);
                        cmd.Parameters.AddWithValue("@Use_Of_Ass_Equip", comboBox17.Text);
                        cmd.Parameters.AddWithValue("@refer_to_nutritionist", comboBox13.Text);
                        cmd.Parameters.AddWithValue("@Specify2", textBox11.Text);
                        cmd.Parameters.AddWithValue("@filename", textBox3.Text);
                        cmd.Parameters.AddWithValue("@image", image);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Saved Successfully!");
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog()
                {
                    Multiselect = false,
                    ValidateNames = true,
                    Filter = "JPEG|*.jpg"

                })

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox5.Image = Image.FromFile(dialog.FileName);
                    }
            }
            catch (Exception)
            {

                MessageBox.Show("An Error Occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            double.TryParse(maskedTextBox3.Text, out double result);
            if (result < 36.0 && maskedTextBox3.Text != "")
            {
                maskedTextBox3.Text = "36.0";
                MessageBox.Show("Minimum Allowed Number is 36.0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result > 42.0 && maskedTextBox3.Text != "")
            {
                maskedTextBox3.Text = "42.0";
                MessageBox.Show("Maximum Allowed Number is 42.0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox4_Leave(object sender, EventArgs e)
        {
            int box_int = 0;
            Int32.TryParse(maskedTextBox4.Text, out box_int);
            if (box_int < 40 && maskedTextBox4.Text != "")
            {
                maskedTextBox3.Text = "40";
                MessageBox.Show("Minimum Allowed Number is 40!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (box_int > 180 && maskedTextBox4.Text != "")
            {
                maskedTextBox4.Text = "180";
                MessageBox.Show("Maximum Allowed Number is 180!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox5_Leave(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;
        private void button7_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp= new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Nurse_patient_Load(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox11_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox12_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select Patient_name,Patient_Age,Diagnosis ,Report_Date " +
                                ",Sessions_Number ,Therapeutic_Exercises ,Working_Place ,Doctor_Signature ," +
                                "Equipment from medical_report where medical_number= '" + int.Parse(maskedTextBox11.Text) + "'", conn);
                MySqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox29.Text = da.GetValue(0).ToString();
                    textBox28.Text = da.GetValue(1).ToString();
                    textBox4.Text = da.GetValue(2).ToString();
                    dateTimePicker2.Text = da.GetValue(3).ToString();
                    textBox5.Text = da.GetValue(4).ToString();
                    textBox8.Text = da.GetValue(5).ToString();
                    textBox27.Text = da.GetValue(6).ToString();
                    textBox6.Text = da.GetValue(7).ToString();
                    textBox7.Text = da.GetValue(8).ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Patient Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
