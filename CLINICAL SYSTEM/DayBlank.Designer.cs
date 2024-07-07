namespace CLINICAL_SYSTEM
{
    partial class DayBlank
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dayNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dayNumber
            // 
            this.dayNumber.BackColor = System.Drawing.Color.Transparent;
            this.dayNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayNumber.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayNumber.Location = new System.Drawing.Point(0, 0);
            this.dayNumber.Name = "dayNumber";
            this.dayNumber.Size = new System.Drawing.Size(170, 84);
            this.dayNumber.TabIndex = 0;
            this.dayNumber.Text = "01";
            this.dayNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dayNumber.Click += new System.EventHandler(this.dayNumber_Click);
            // 
            // DayBlank
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dayNumber);
            this.Name = "DayBlank";
            this.Size = new System.Drawing.Size(170, 84);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label dayNumber;
    }
}
