using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLINICAL_SYSTEM
{
    public partial class Nurse_change_pass : Form
    {
        public Nurse_change_pass()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Nurse_patient ob = new Nurse_patient();
            ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            adm_nurse ob = new adm_nurse();
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
    }
}
