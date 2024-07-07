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
using System.Configuration;

namespace CLINICAL_SYSTEM
{
    public partial class Login_Page : Form
    {
        String connString = "server=localhost; port=3306; user id=root; password= Dina@2020; database=clinical_system; sslmode=none; convert zero datetime=True";
        //MySqlConnection conn = new MySqlConnection(@"Data Source=localhost;Initial Catalog=clinical_system;User id=root;Password=Dina@2020;");

        public Login_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            if (RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Your Position");
            }
            else if(RoleCb.SelectedIndex == 0)
            {
                if (UserNameTb.Text== "" || PasswordTb.Text == "")
                {
                    MessageBox.Show("Please Enter Both Admin Name and Password");
                }
                else if(UserNameTb.Text== "Nada" && PasswordTb.Text =="admin")
                {
                    adm_doc obj = new adm_doc();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name or Password!","ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (RoleCb.SelectedIndex == 1)
            {
                if (UserNameTb.Text == "" || PasswordTb.Text == "")
                {
                    MessageBox.Show("Please Enter Both Doctor Name and Password!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                else
                {
                    conn.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter("Select * from doctors where Doc_Username= '" +UserNameTb.Text+ "' and Doc_Pass='"+PasswordTb.Text+"'", conn);
                    DataTable table = new DataTable();

                    sda.Fill(table);
                    if (table.Rows.Count <= 0)
                    {
                        MessageBox.Show("Doctor Not Found!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Doc_app obj = new Doc_app();
                        obj.Show();
                        this.Hide();
                    }
                    conn.Close();
                }
            }
            else
            {
                if (UserNameTb.Text == "" || PasswordTb.Text == "")
                {
                    MessageBox.Show("Please Enter Both Nurse Name and Password", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    conn.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter("Select * from nurse where Nurse_Username= '" + UserNameTb.Text + "' and Nurse_Pass='" + PasswordTb.Text + "'", conn);
                    DataTable table = new DataTable();

                    sda.Fill(table);
                    if (table.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nurse Not Found!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Nurse_patient obj = new Nurse_patient();
                        obj.Show();
                        this.Hide();
                    }
                    conn.Close();
                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            RoleCb.SelectedIndex = 0;
            UserNameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit The System?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }
    }
}
