
namespace SQLDrv
{
    partial class Settings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CompCB = new System.Windows.Forms.CheckedListBox();
            this.CompAllCheck = new System.Windows.Forms.CheckBox();
            this.CompAutoIP = new System.Windows.Forms.CheckBox();
            this.CompAutoID = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CompIPBox = new System.Windows.Forms.TextBox();
            this.CompIDBox = new System.Windows.Forms.TextBox();
            this.CompNameBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComAutoIP = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComIPBox = new System.Windows.Forms.TextBox();
            this.ComAutoID = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComBaudBox = new System.Windows.Forms.ComboBox();
            this.ComTypeBox = new System.Windows.Forms.ComboBox();
            this.ComAdaptorBox = new System.Windows.Forms.ComboBox();
            this.ComNumBox = new System.Windows.Forms.ComboBox();
            this.ComPCIDBox = new System.Windows.Forms.ComboBox();
            this.ComIDBox = new System.Windows.Forms.TextBox();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.RSAutoIP = new System.Windows.Forms.CheckBox();
            this.RSAutoID = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.RSInterfaceBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.RSIPBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.RSTypeBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.RSParentBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.RSAddressBox = new System.Windows.Forms.TextBox();
            this.RSPortBox = new System.Windows.Forms.ComboBox();
            this.RSPCBox = new System.Windows.Forms.ComboBox();
            this.RSIDBox = new System.Windows.Forms.TextBox();
            this.AutoSettings = new System.Windows.Forms.CheckBox();
            this.TabSelect = new System.Windows.Forms.TabControl();
            this.CompGB = new System.Windows.Forms.TabPage();
            this.PortGB = new System.Windows.Forms.TabPage();
            this.RSGB = new System.Windows.Forms.TabPage();
            this.Pass = new System.Windows.Forms.TabPage();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.BDSet = new System.Windows.Forms.ToolStripMenuItem();
            this.BDList = new System.Windows.Forms.ToolStripComboBox();
            this.PathDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnState = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TestBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TabSelect.SuspendLayout();
            this.CompGB.SuspendLayout();
            this.PortGB.SuspendLayout();
            this.RSGB.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(392, 45);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 545);
            this.dataGridView1.TabIndex = 0;
            // 
            // CompCB
            // 
            this.CompCB.CheckOnClick = true;
            this.CompCB.FormattingEnabled = true;
            this.CompCB.Items.AddRange(new object[] {
            "Администратор базы данных",
            "Генератор отчетов",
            "Учет рабочего времени",
            "Центральный сервер Орион",
            "Менеджер центрального сервера",
            "Видеодрайвер",
            "Ядро опроса",
            "Монитор системы"});
            this.CompCB.Location = new System.Drawing.Point(29, 153);
            this.CompCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompCB.Name = "CompCB";
            this.CompCB.Size = new System.Drawing.Size(274, 158);
            this.CompCB.TabIndex = 9;
            this.CompCB.Tag = "PC";
            // 
            // CompAllCheck
            // 
            this.CompAllCheck.AutoSize = true;
            this.CompAllCheck.Location = new System.Drawing.Point(29, 359);
            this.CompAllCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompAllCheck.Name = "CompAllCheck";
            this.CompAllCheck.Size = new System.Drawing.Size(118, 24);
            this.CompAllCheck.TabIndex = 8;
            this.CompAllCheck.Tag = "PC";
            this.CompAllCheck.Text = "Выбрать все";
            this.CompAllCheck.UseVisualStyleBackColor = true;
            this.CompAllCheck.CheckedChanged += new System.EventHandler(this.CompAllCheck_CheckedChanged);
            // 
            // CompAutoIP
            // 
            this.CompAutoIP.AccessibleName = "PCIP";
            this.CompAutoIP.AutoSize = true;
            this.CompAutoIP.Location = new System.Drawing.Point(192, 100);
            this.CompAutoIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompAutoIP.Name = "CompAutoIP";
            this.CompAutoIP.Size = new System.Drawing.Size(85, 24);
            this.CompAutoIP.TabIndex = 7;
            this.CompAutoIP.Tag = "PC";
            this.CompAutoIP.Text = "Этот ПК";
            this.CompAutoIP.UseVisualStyleBackColor = true;
            this.CompAutoIP.CheckedChanged += new System.EventHandler(this.CompAutoIP_CheckedChanged);
            // 
            // CompAutoID
            // 
            this.CompAutoID.AccessibleName = "PCID";
            this.CompAutoID.AutoSize = true;
            this.CompAutoID.Location = new System.Drawing.Point(192, 63);
            this.CompAutoID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompAutoID.Name = "CompAutoID";
            this.CompAutoID.Size = new System.Drawing.Size(64, 24);
            this.CompAutoID.TabIndex = 6;
            this.CompAutoID.Tag = "PC";
            this.CompAutoID.Text = "Авто";
            this.CompAutoID.UseVisualStyleBackColor = true;
            this.CompAutoID.CheckedChanged += new System.EventHandler(this.CompAutoID_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "IP*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя";
            // 
            // CompIPBox
            // 
            this.CompIPBox.AccessibleName = "PCIP";
            this.CompIPBox.Location = new System.Drawing.Point(71, 97);
            this.CompIPBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompIPBox.Name = "CompIPBox";
            this.CompIPBox.Size = new System.Drawing.Size(114, 27);
            this.CompIPBox.TabIndex = 2;
            this.CompIPBox.Tag = "PC";
            // 
            // CompIDBox
            // 
            this.CompIDBox.AccessibleName = "PCID";
            this.CompIDBox.Location = new System.Drawing.Point(71, 57);
            this.CompIDBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompIDBox.Name = "CompIDBox";
            this.CompIDBox.Size = new System.Drawing.Size(114, 27);
            this.CompIDBox.TabIndex = 1;
            this.CompIDBox.Tag = "PC";
            // 
            // CompNameBox
            // 
            this.CompNameBox.AccessibleName = "PCNAME";
            this.CompNameBox.Location = new System.Drawing.Point(71, 19);
            this.CompNameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompNameBox.Name = "CompNameBox";
            this.CompNameBox.Size = new System.Drawing.Size(114, 27);
            this.CompNameBox.TabIndex = 0;
            this.CompNameBox.Tag = "PC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Скорость порта";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Тип порта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Тип интерфейса";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Номер порта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Компьютер";
            // 
            // ComAutoIP
            // 
            this.ComAutoIP.AccessibleName = "PORTIP";
            this.ComAutoIP.AutoSize = true;
            this.ComAutoIP.Location = new System.Drawing.Point(249, 77);
            this.ComAutoIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComAutoIP.Name = "ComAutoIP";
            this.ComAutoIP.Size = new System.Drawing.Size(110, 24);
            this.ComAutoIP.TabIndex = 10;
            this.ComAutoIP.Tag = "PORT";
            this.ComAutoIP.Text = "Локальный";
            this.ComAutoIP.UseVisualStyleBackColor = true;
            this.ComAutoIP.CheckedChanged += new System.EventHandler(this.ComAutoIP_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "IP*";
            // 
            // ComIPBox
            // 
            this.ComIPBox.AccessibleName = "PORTIP";
            this.ComIPBox.Location = new System.Drawing.Point(128, 71);
            this.ComIPBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComIPBox.Name = "ComIPBox";
            this.ComIPBox.Size = new System.Drawing.Size(114, 27);
            this.ComIPBox.TabIndex = 8;
            this.ComIPBox.Tag = "PORT";
            // 
            // ComAutoID
            // 
            this.ComAutoID.AccessibleName = "PORTID";
            this.ComAutoID.AutoSize = true;
            this.ComAutoID.Location = new System.Drawing.Point(171, 25);
            this.ComAutoID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComAutoID.Name = "ComAutoID";
            this.ComAutoID.Size = new System.Drawing.Size(64, 24);
            this.ComAutoID.TabIndex = 7;
            this.ComAutoID.Tag = "PORT";
            this.ComAutoID.Text = "Авто";
            this.ComAutoID.UseVisualStyleBackColor = true;
            this.ComAutoID.CheckedChanged += new System.EventHandler(this.ComAutoID_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID*";
            // 
            // ComBaudBox
            // 
            this.ComBaudBox.AccessibleName = "BAUD";
            this.ComBaudBox.FormattingEnabled = true;
            this.ComBaudBox.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.ComBaudBox.Location = new System.Drawing.Point(129, 273);
            this.ComBaudBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComBaudBox.Name = "ComBaudBox";
            this.ComBaudBox.Size = new System.Drawing.Size(138, 28);
            this.ComBaudBox.TabIndex = 5;
            this.ComBaudBox.Tag = "PORT";
            this.ComBaudBox.Text = "Скорость порта";
            // 
            // ComTypeBox
            // 
            this.ComTypeBox.AccessibleName = "TYPEID";
            this.ComTypeBox.FormattingEnabled = true;
            this.ComTypeBox.Items.AddRange(new object[] {
            "COM",
            "LAN",
            "USB",
            "GSM"});
            this.ComTypeBox.Location = new System.Drawing.Point(129, 235);
            this.ComTypeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComTypeBox.Name = "ComTypeBox";
            this.ComTypeBox.Size = new System.Drawing.Size(138, 28);
            this.ComTypeBox.TabIndex = 4;
            this.ComTypeBox.Tag = "PORT";
            this.ComTypeBox.Text = "Тип порта";
            // 
            // ComAdaptorBox
            // 
            this.ComAdaptorBox.AccessibleName = "INTID";
            this.ComAdaptorBox.FormattingEnabled = true;
            this.ComAdaptorBox.Items.AddRange(new object[] {
            "ПИ-ГР",
            "С2000-ПИ",
            "С2000"});
            this.ComAdaptorBox.Location = new System.Drawing.Point(129, 196);
            this.ComAdaptorBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComAdaptorBox.Name = "ComAdaptorBox";
            this.ComAdaptorBox.Size = new System.Drawing.Size(138, 28);
            this.ComAdaptorBox.TabIndex = 3;
            this.ComAdaptorBox.Tag = "PORT";
            this.ComAdaptorBox.Text = "Тип интерфейса";
            // 
            // ComNumBox
            // 
            this.ComNumBox.AccessibleName = "PORTNUM";
            this.ComNumBox.FormattingEnabled = true;
            this.ComNumBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.ComNumBox.Location = new System.Drawing.Point(129, 157);
            this.ComNumBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComNumBox.Name = "ComNumBox";
            this.ComNumBox.Size = new System.Drawing.Size(138, 28);
            this.ComNumBox.TabIndex = 2;
            this.ComNumBox.Tag = "PORT";
            this.ComNumBox.Text = "Номер порта";
            // 
            // ComPCIDBox
            // 
            this.ComPCIDBox.AccessibleName = "PCID";
            this.ComPCIDBox.FormattingEnabled = true;
            this.ComPCIDBox.Location = new System.Drawing.Point(129, 115);
            this.ComPCIDBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComPCIDBox.Name = "ComPCIDBox";
            this.ComPCIDBox.Size = new System.Drawing.Size(138, 28);
            this.ComPCIDBox.TabIndex = 1;
            this.ComPCIDBox.Tag = "PORT";
            this.ComPCIDBox.Text = "Компьютер";
            this.ComPCIDBox.SelectedIndexChanged += new System.EventHandler(this.ComPCIDBox_SelectedIndexChanged);
            // 
            // ComIDBox
            // 
            this.ComIDBox.AccessibleName = "PORTID";
            this.ComIDBox.Location = new System.Drawing.Point(129, 23);
            this.ComIDBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComIDBox.Name = "ComIDBox";
            this.ComIDBox.Size = new System.Drawing.Size(35, 27);
            this.ComIDBox.TabIndex = 0;
            this.ComIDBox.Tag = "PORT";
            // 
            // InsertBtn
            // 
            this.InsertBtn.Enabled = false;
            this.InsertBtn.Location = new System.Drawing.Point(14, 533);
            this.InsertBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(107, 57);
            this.InsertBtn.TabIndex = 3;
            this.InsertBtn.Text = "Добавить компонент";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.INSBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Enabled = false;
            this.UpdateBtn.Location = new System.Drawing.Point(128, 533);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(102, 57);
            this.UpdateBtn.TabIndex = 4;
            this.UpdateBtn.Text = "Обновить компонент";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(235, 533);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(101, 57);
            this.DeleteBtn.TabIndex = 5;
            this.DeleteBtn.Text = "Удалить компонент";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // RSAutoIP
            // 
            this.RSAutoIP.AccessibleName = "RSIP";
            this.RSAutoIP.AutoSize = true;
            this.RSAutoIP.Location = new System.Drawing.Point(176, 108);
            this.RSAutoIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSAutoIP.Name = "RSAutoIP";
            this.RSAutoIP.Size = new System.Drawing.Size(110, 24);
            this.RSAutoIP.TabIndex = 17;
            this.RSAutoIP.Tag = "RS";
            this.RSAutoIP.Text = "Локальный";
            this.RSAutoIP.UseVisualStyleBackColor = true;
            this.RSAutoIP.CheckedChanged += new System.EventHandler(this.RSAutoIP_CheckedChanged);
            // 
            // RSAutoID
            // 
            this.RSAutoID.AccessibleName = "RSID";
            this.RSAutoID.AutoSize = true;
            this.RSAutoID.Location = new System.Drawing.Point(95, 24);
            this.RSAutoID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSAutoID.Name = "RSAutoID";
            this.RSAutoID.Size = new System.Drawing.Size(64, 24);
            this.RSAutoID.TabIndex = 16;
            this.RSAutoID.Tag = "RS";
            this.RSAutoID.Text = "Авто";
            this.RSAutoID.UseVisualStyleBackColor = true;
            this.RSAutoID.CheckedChanged += new System.EventHandler(this.RSAutoID_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(121, 184);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 20);
            this.label18.TabIndex = 15;
            this.label18.Text = "Интерфейс";
            // 
            // RSInterfaceBox
            // 
            this.RSInterfaceBox.AccessibleName = "INTID";
            this.RSInterfaceBox.FormattingEnabled = true;
            this.RSInterfaceBox.Items.AddRange(new object[] {
            "COM",
            "LAN",
            "USB",
            "GSM"});
            this.RSInterfaceBox.Location = new System.Drawing.Point(207, 180);
            this.RSInterfaceBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSInterfaceBox.Name = "RSInterfaceBox";
            this.RSInterfaceBox.Size = new System.Drawing.Size(138, 28);
            this.RSInterfaceBox.TabIndex = 14;
            this.RSInterfaceBox.Tag = "RS";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 20);
            this.label17.TabIndex = 13;
            this.label17.Text = "IP*";
            // 
            // RSIPBox
            // 
            this.RSIPBox.AccessibleName = "RSIP";
            this.RSIPBox.Location = new System.Drawing.Point(55, 103);
            this.RSIPBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSIPBox.Name = "RSIPBox";
            this.RSIPBox.Size = new System.Drawing.Size(114, 27);
            this.RSIPBox.TabIndex = 12;
            this.RSIPBox.Tag = "RS";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(142, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "Прибор";
            // 
            // RSTypeBox
            // 
            this.RSTypeBox.AccessibleName = "TYPEID";
            this.RSTypeBox.FormattingEnabled = true;
            this.RSTypeBox.Location = new System.Drawing.Point(207, 141);
            this.RSTypeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSTypeBox.Name = "RSTypeBox";
            this.RSTypeBox.Size = new System.Drawing.Size(138, 28);
            this.RSTypeBox.TabIndex = 10;
            this.RSTypeBox.Tag = "RS";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(163, 20);
            this.label15.TabIndex = 9;
            this.label15.Text = "Родительский прибор";
            // 
            // RSParentBox
            // 
            this.RSParentBox.AccessibleName = "PARID";
            this.RSParentBox.FormattingEnabled = true;
            this.RSParentBox.Location = new System.Drawing.Point(207, 293);
            this.RSParentBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSParentBox.Name = "RSParentBox";
            this.RSParentBox.Size = new System.Drawing.Size(138, 28);
            this.RSParentBox.TabIndex = 8;
            this.RSParentBox.Tag = "RS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(160, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 20);
            this.label14.TabIndex = 7;
            this.label14.Text = "Порт";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(119, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 6;
            this.label13.Text = "Компьютер";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Адрес*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "ID*";
            // 
            // RSAddressBox
            // 
            this.RSAddressBox.Location = new System.Drawing.Point(55, 60);
            this.RSAddressBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSAddressBox.Name = "RSAddressBox";
            this.RSAddressBox.Size = new System.Drawing.Size(31, 27);
            this.RSAddressBox.TabIndex = 3;
            this.RSAddressBox.Tag = "RS";
            // 
            // RSPortBox
            // 
            this.RSPortBox.AccessibleName = "PORTID";
            this.RSPortBox.FormattingEnabled = true;
            this.RSPortBox.Location = new System.Drawing.Point(207, 256);
            this.RSPortBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSPortBox.Name = "RSPortBox";
            this.RSPortBox.Size = new System.Drawing.Size(138, 28);
            this.RSPortBox.TabIndex = 2;
            this.RSPortBox.Tag = "RS";
            this.RSPortBox.SelectedIndexChanged += new System.EventHandler(this.RSPortBox_SelectedIndexChanged);
            // 
            // RSPCBox
            // 
            this.RSPCBox.AccessibleName = "PCID";
            this.RSPCBox.FormattingEnabled = true;
            this.RSPCBox.Location = new System.Drawing.Point(207, 217);
            this.RSPCBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSPCBox.Name = "RSPCBox";
            this.RSPCBox.Size = new System.Drawing.Size(138, 28);
            this.RSPCBox.TabIndex = 1;
            this.RSPCBox.Tag = "RS";
            this.RSPCBox.SelectedIndexChanged += new System.EventHandler(this.RSPCBox_SelectedIndexChanged);
            // 
            // RSIDBox
            // 
            this.RSIDBox.AccessibleName = "RSID";
            this.RSIDBox.Location = new System.Drawing.Point(55, 20);
            this.RSIDBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSIDBox.Name = "RSIDBox";
            this.RSIDBox.Size = new System.Drawing.Size(31, 27);
            this.RSIDBox.TabIndex = 0;
            this.RSIDBox.Tag = "RS";
            // 
            // AutoSettings
            // 
            this.AutoSettings.AutoSize = true;
            this.AutoSettings.Location = new System.Drawing.Point(1191, 7);
            this.AutoSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoSettings.Name = "AutoSettings";
            this.AutoSettings.Size = new System.Drawing.Size(220, 24);
            this.AutoSettings.TabIndex = 10;
            this.AutoSettings.Text = "Автоматическая настройка";
            this.AutoSettings.UseVisualStyleBackColor = true;
            // 
            // TabSelect
            // 
            this.TabSelect.Controls.Add(this.CompGB);
            this.TabSelect.Controls.Add(this.PortGB);
            this.TabSelect.Controls.Add(this.RSGB);
            this.TabSelect.Controls.Add(this.Pass);
            this.TabSelect.Enabled = false;
            this.TabSelect.Location = new System.Drawing.Point(14, 45);
            this.TabSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabSelect.Name = "TabSelect";
            this.TabSelect.SelectedIndex = 0;
            this.TabSelect.Size = new System.Drawing.Size(371, 480);
            this.TabSelect.TabIndex = 17;
            this.TabSelect.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // CompGB
            // 
            this.CompGB.Controls.Add(this.CompCB);
            this.CompGB.Controls.Add(this.CompNameBox);
            this.CompGB.Controls.Add(this.CompAllCheck);
            this.CompGB.Controls.Add(this.CompIDBox);
            this.CompGB.Controls.Add(this.CompAutoIP);
            this.CompGB.Controls.Add(this.CompIPBox);
            this.CompGB.Controls.Add(this.CompAutoID);
            this.CompGB.Controls.Add(this.label1);
            this.CompGB.Controls.Add(this.label3);
            this.CompGB.Controls.Add(this.label2);
            this.CompGB.Location = new System.Drawing.Point(4, 29);
            this.CompGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompGB.Name = "CompGB";
            this.CompGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CompGB.Size = new System.Drawing.Size(363, 447);
            this.CompGB.TabIndex = 0;
            this.CompGB.Tag = "PC";
            this.CompGB.Text = "Компьютер";
            this.CompGB.UseVisualStyleBackColor = true;
            // 
            // PortGB
            // 
            this.PortGB.Controls.Add(this.label10);
            this.PortGB.Controls.Add(this.ComIPBox);
            this.PortGB.Controls.Add(this.label9);
            this.PortGB.Controls.Add(this.ComIDBox);
            this.PortGB.Controls.Add(this.label8);
            this.PortGB.Controls.Add(this.ComPCIDBox);
            this.PortGB.Controls.Add(this.label7);
            this.PortGB.Controls.Add(this.ComNumBox);
            this.PortGB.Controls.Add(this.label6);
            this.PortGB.Controls.Add(this.ComAdaptorBox);
            this.PortGB.Controls.Add(this.ComAutoIP);
            this.PortGB.Controls.Add(this.ComTypeBox);
            this.PortGB.Controls.Add(this.label5);
            this.PortGB.Controls.Add(this.ComBaudBox);
            this.PortGB.Controls.Add(this.label4);
            this.PortGB.Controls.Add(this.ComAutoID);
            this.PortGB.Location = new System.Drawing.Point(4, 29);
            this.PortGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortGB.Name = "PortGB";
            this.PortGB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortGB.Size = new System.Drawing.Size(363, 447);
            this.PortGB.TabIndex = 1;
            this.PortGB.Tag = "PORT";
            this.PortGB.Text = "Порт";
            this.PortGB.UseVisualStyleBackColor = true;
            // 
            // RSGB
            // 
            this.RSGB.Controls.Add(this.RSAutoIP);
            this.RSGB.Controls.Add(this.RSAddressBox);
            this.RSGB.Controls.Add(this.RSAutoID);
            this.RSGB.Controls.Add(this.RSIDBox);
            this.RSGB.Controls.Add(this.label18);
            this.RSGB.Controls.Add(this.RSPCBox);
            this.RSGB.Controls.Add(this.RSInterfaceBox);
            this.RSGB.Controls.Add(this.RSPortBox);
            this.RSGB.Controls.Add(this.label17);
            this.RSGB.Controls.Add(this.label11);
            this.RSGB.Controls.Add(this.RSIPBox);
            this.RSGB.Controls.Add(this.label12);
            this.RSGB.Controls.Add(this.label16);
            this.RSGB.Controls.Add(this.label13);
            this.RSGB.Controls.Add(this.RSTypeBox);
            this.RSGB.Controls.Add(this.label14);
            this.RSGB.Controls.Add(this.label15);
            this.RSGB.Controls.Add(this.RSParentBox);
            this.RSGB.Location = new System.Drawing.Point(4, 29);
            this.RSGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RSGB.Name = "RSGB";
            this.RSGB.Size = new System.Drawing.Size(363, 447);
            this.RSGB.TabIndex = 2;
            this.RSGB.Tag = "RS";
            this.RSGB.Text = "Прибор";
            this.RSGB.UseVisualStyleBackColor = true;
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(4, 29);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(363, 447);
            this.Pass.TabIndex = 3;
            this.Pass.Text = "Пароли";
            this.Pass.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BDSet,
            this.ConnState});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.Menu.Size = new System.Drawing.Size(1406, 30);
            this.Menu.TabIndex = 18;
            this.Menu.Text = "menuStrip1";
            // 
            // BDSet
            // 
            this.BDSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BDList,
            this.PathDB});
            this.BDSet.Enabled = false;
            this.BDSet.Name = "BDSet";
            this.BDSet.Size = new System.Drawing.Size(154, 24);
            this.BDSet.Text = "Подключение к БД";
            // 
            // BDList
            // 
            this.BDList.Name = "BDList";
            this.BDList.Size = new System.Drawing.Size(121, 28);
            this.BDList.TextChanged += new System.EventHandler(this.BDList_TextChanged);
            // 
            // PathDB
            // 
            this.PathDB.Name = "PathDB";
            this.PathDB.Size = new System.Drawing.Size(251, 26);
            this.PathDB.Text = "Добавить путь к базам";
            this.PathDB.Click += new System.EventHandler(this.PathDB_Click);
            // 
            // ConnState
            // 
            this.ConnState.ForeColor = System.Drawing.Color.Red;
            this.ConnState.Name = "ConnState";
            this.ConnState.Size = new System.Drawing.Size(190, 24);
            this.ConnState.Text = "Соединение отсутствует";
            this.ConnState.Click += new System.EventHandler(this.ConnState_Click);
            // 
            // TestBT
            // 
            this.TestBT.Enabled = false;
            this.TestBT.Location = new System.Drawing.Point(898, 1);
            this.TestBT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TestBT.Name = "TestBT";
            this.TestBT.Size = new System.Drawing.Size(286, 36);
            this.TestBT.TabIndex = 10;
            this.TestBT.Text = "Тестовые добавления";
            this.TestBT.UseVisualStyleBackColor = true;
            this.TestBT.Click += new System.EventHandler(this.TestBT_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 600);
            this.Controls.Add(this.TestBT);
            this.Controls.Add(this.TabSelect);
            this.Controls.Add(this.AutoSettings);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TabSelect.ResumeLayout(false);
            this.CompGB.ResumeLayout(false);
            this.CompGB.PerformLayout();
            this.PortGB.ResumeLayout(false);
            this.PortGB.PerformLayout();
            this.RSGB.ResumeLayout(false);
            this.RSGB.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox CompCB;
        private System.Windows.Forms.CheckBox CompAllCheck;
        private System.Windows.Forms.CheckBox CompAutoIP;
        private System.Windows.Forms.CheckBox CompAutoID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CompIPBox;
        private System.Windows.Forms.TextBox CompIDBox;
        private System.Windows.Forms.TextBox CompNameBox;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TextBox ComIDBox;
        private System.Windows.Forms.ComboBox ComPCIDBox;
        private System.Windows.Forms.CheckBox ComAutoID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComBaudBox;
        private System.Windows.Forms.ComboBox ComTypeBox;
        private System.Windows.Forms.ComboBox ComAdaptorBox;
        private System.Windows.Forms.ComboBox ComNumBox;
        private System.Windows.Forms.CheckBox ComAutoIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ComIPBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox RSIDBox;
        private System.Windows.Forms.ComboBox RSPCBox;
        private System.Windows.Forms.ComboBox RSPortBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox RSAddressBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox RSParentBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox RSTypeBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox RSIPBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox RSInterfaceBox;
        private System.Windows.Forms.CheckBox RSAutoIP;
        private System.Windows.Forms.CheckBox RSAutoID;
        private System.Windows.Forms.CheckBox AutoSettings;
        private System.Windows.Forms.TabControl TabSelect;
        private System.Windows.Forms.TabPage CompGB;
        private System.Windows.Forms.TabPage PortGB;
        private System.Windows.Forms.TabPage RSGB;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem BDSet;
        private System.Windows.Forms.ToolStripComboBox BDList;
        private System.Windows.Forms.ToolStripMenuItem PathDB;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.ToolStripMenuItem ConnState;
        private System.Windows.Forms.Button TestBT;
        private System.Windows.Forms.TabPage Pass;
    }
}