
namespace SQLDrv
{
    partial class SQLDEVICE
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BDList = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Connect = new System.Windows.Forms.Button();
            this.ConnectionBox = new System.Windows.Forms.GroupBox();
            this.ConnLabel = new System.Windows.Forms.Label();
            this.TypeSettings = new System.Windows.Forms.Button();
            this.ConnectionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BDList
            // 
            this.BDList.FormattingEnabled = true;
            this.BDList.Location = new System.Drawing.Point(37, 21);
            this.BDList.Name = "BDList";
            this.BDList.Size = new System.Drawing.Size(229, 23);
            this.BDList.TabIndex = 1;
            this.BDList.Text = "Выбрать БД...";
            this.BDList.SelectedIndexChanged += new System.EventHandler(this.BDList_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(305, 21);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(97, 23);
            this.Connect.TabIndex = 3;
            this.Connect.Text = "Подключиться";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // ConnectionBox
            // 
            this.ConnectionBox.Controls.Add(this.TypeSettings);
            this.ConnectionBox.Controls.Add(this.ConnLabel);
            this.ConnectionBox.Controls.Add(this.BDList);
            this.ConnectionBox.Controls.Add(this.Connect);
            this.ConnectionBox.Location = new System.Drawing.Point(12, 12);
            this.ConnectionBox.Name = "ConnectionBox";
            this.ConnectionBox.Size = new System.Drawing.Size(473, 83);
            this.ConnectionBox.TabIndex = 5;
            this.ConnectionBox.TabStop = false;
            this.ConnectionBox.Text = "Подключение";
            // 
            // ConnLabel
            // 
            this.ConnLabel.AutoSize = true;
            this.ConnLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnLabel.Location = new System.Drawing.Point(37, 47);
            this.ConnLabel.Name = "ConnLabel";
            this.ConnLabel.Size = new System.Drawing.Size(192, 15);
            this.ConnLabel.TabIndex = 4;
            this.ConnLabel.Text = "Подключение к базе отстутствует";
            // 
            // TypeSettings
            // 
            this.TypeSettings.Location = new System.Drawing.Point(305, 50);
            this.TypeSettings.Name = "TypeSettings";
            this.TypeSettings.Size = new System.Drawing.Size(97, 23);
            this.TypeSettings.TabIndex = 5;
            this.TypeSettings.Text = "Настройки";
            this.TypeSettings.UseVisualStyleBackColor = true;
            this.TypeSettings.Click += new System.EventHandler(this.TypeSettings_Click);
            // 
            // SQLDEVICE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(498, 110);
            this.Controls.Add(this.ConnectionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SQLDEVICE";
            this.Text = "SQLDevices";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SQLDEVICE_FormClosed);
            this.Load += new System.EventHandler(this.SQLDEVICE_Load);
            this.ConnectionBox.ResumeLayout(false);
            this.ConnectionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox BDList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.GroupBox ConnectionBox;
        private System.Windows.Forms.Button TypeSettings;
        private System.Windows.Forms.Label ConnLabel;
    }
}

