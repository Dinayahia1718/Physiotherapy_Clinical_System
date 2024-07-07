using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLINICAL_SYSTEM
{
    public partial class DayBlank : UserControl
    {
        private DateTime _currentDate;
        public DayBlank()
        {
            InitializeComponent();
        }

        public void Refresh(Color backcolor, int Day, DateTime date, Color foreColor)
        {
            BackColor = backcolor;
            dayNumber.Text = Day.ToString();
            _currentDate = date;
            if (_currentDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                BackColor = Color.FromArgb(222, 255, 159, 67);

            dayNumber.ForeColor = foreColor;
        }

        private void dayNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
