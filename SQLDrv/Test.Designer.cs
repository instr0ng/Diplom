
namespace SQLDrv
{
    partial class Test
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
            this.tab = new System.Windows.Forms.TabControl();
            this.PCtP = new System.Windows.Forms.TabPage();
            this.time = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DeleteBT = new System.Windows.Forms.Button();
            this.insertBT = new System.Windows.Forms.Button();
            this.RSCBx = new System.Windows.Forms.CheckBox();
            this.potrCBx = new System.Windows.Forms.CheckBox();
            this.RSGB = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RScount = new System.Windows.Forms.NumericUpDown();
            this.rslist = new System.Windows.Forms.CheckedListBox();
            this.portGB = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComType = new System.Windows.Forms.ComboBox();
            this.PortCount = new System.Windows.Forms.NumericUpDown();
            this.PCGB = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompAllCheck = new System.Windows.Forms.CheckBox();
            this.CompCB = new System.Windows.Forms.CheckedListBox();
            this.countPC = new System.Windows.Forms.NumericUpDown();
            this.CompsName = new System.Windows.Forms.TextBox();
            this.RStP = new System.Windows.Forms.TabPage();
            this.RSPB = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.ParentCB = new System.Windows.Forms.ComboBox();
            this.RStype = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PRnum = new System.Windows.Forms.NumericUpDown();
            this.DelPR = new System.Windows.Forms.Button();
            this.InsPR = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selCom = new System.Windows.Forms.ComboBox();
            this.SelPC = new System.Windows.Forms.ComboBox();
            this.userPG = new System.Windows.Forms.TabPage();
            this.userPB = new System.Windows.Forms.ProgressBar();
            this.userINS = new System.Windows.Forms.Button();
            this.userNum = new System.Windows.Forms.NumericUpDown();
            this.pass = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.Tree = new System.Windows.Forms.TreeView();
            this.passPB = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.numPass = new System.Windows.Forms.NumericUpDown();
            this.Ruser = new System.Windows.Forms.CheckBox();
            this.TypeKeyBox = new System.Windows.Forms.ComboBox();
            this.PermBox = new System.Windows.Forms.ComboBox();
            this.passDel = new System.Windows.Forms.Button();
            this.insPass = new System.Windows.Forms.Button();
            this.userlist = new System.Windows.Forms.ComboBox();
            this.SelectTypePassBox = new System.Windows.Forms.ComboBox();
            this.tab.SuspendLayout();
            this.PCtP.SuspendLayout();
            this.RSGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RScount)).BeginInit();
            this.portGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortCount)).BeginInit();
            this.PCGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countPC)).BeginInit();
            this.RStP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PRnum)).BeginInit();
            this.userPG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userNum)).BeginInit();
            this.pass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPass)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.PCtP);
            this.tab.Controls.Add(this.RStP);
            this.tab.Controls.Add(this.userPG);
            this.tab.Controls.Add(this.pass);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(861, 510);
            this.tab.TabIndex = 0;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // PCtP
            // 
            this.PCtP.Controls.Add(this.time);
            this.PCtP.Controls.Add(this.progressBar1);
            this.PCtP.Controls.Add(this.DeleteBT);
            this.PCtP.Controls.Add(this.insertBT);
            this.PCtP.Controls.Add(this.RSCBx);
            this.PCtP.Controls.Add(this.potrCBx);
            this.PCtP.Controls.Add(this.RSGB);
            this.PCtP.Controls.Add(this.portGB);
            this.PCtP.Controls.Add(this.PCGB);
            this.PCtP.Location = new System.Drawing.Point(4, 24);
            this.PCtP.Name = "PCtP";
            this.PCtP.Padding = new System.Windows.Forms.Padding(3);
            this.PCtP.Size = new System.Drawing.Size(853, 482);
            this.PCtP.TabIndex = 0;
            this.PCtP.Text = "Компьютеры";
            this.PCtP.UseVisualStyleBackColor = true;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(8, 464);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 15);
            this.time.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 433);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(528, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // DeleteBT
            // 
            this.DeleteBT.Location = new System.Drawing.Point(542, 423);
            this.DeleteBT.Name = "DeleteBT";
            this.DeleteBT.Size = new System.Drawing.Size(140, 43);
            this.DeleteBT.TabIndex = 6;
            this.DeleteBT.Text = "Удалить по ключу";
            this.DeleteBT.UseVisualStyleBackColor = true;
            this.DeleteBT.Click += new System.EventHandler(this.DeleteBT_Click);
            // 
            // insertBT
            // 
            this.insertBT.Location = new System.Drawing.Point(688, 423);
            this.insertBT.Name = "insertBT";
            this.insertBT.Size = new System.Drawing.Size(147, 43);
            this.insertBT.TabIndex = 5;
            this.insertBT.Text = "Добавить";
            this.insertBT.UseVisualStyleBackColor = true;
            this.insertBT.Click += new System.EventHandler(this.insertBT_Click);
            // 
            // RSCBx
            // 
            this.RSCBx.AutoSize = true;
            this.RSCBx.Location = new System.Drawing.Point(564, 6);
            this.RSCBx.Name = "RSCBx";
            this.RSCBx.Size = new System.Drawing.Size(132, 19);
            this.RSCBx.TabIndex = 4;
            this.RSCBx.Text = "Добавить приборы";
            this.RSCBx.UseVisualStyleBackColor = true;
            this.RSCBx.CheckedChanged += new System.EventHandler(this.RSCBx_CheckedChanged);
            // 
            // potrCBx
            // 
            this.potrCBx.AutoSize = true;
            this.potrCBx.Location = new System.Drawing.Point(286, 6);
            this.potrCBx.Name = "potrCBx";
            this.potrCBx.Size = new System.Drawing.Size(116, 19);
            this.potrCBx.TabIndex = 3;
            this.potrCBx.Text = "Добавить порты";
            this.potrCBx.UseVisualStyleBackColor = true;
            this.potrCBx.CheckedChanged += new System.EventHandler(this.potrCBx_CheckedChanged);
            // 
            // RSGB
            // 
            this.RSGB.Controls.Add(this.label6);
            this.RSGB.Controls.Add(this.RScount);
            this.RSGB.Controls.Add(this.rslist);
            this.RSGB.Enabled = false;
            this.RSGB.Location = new System.Drawing.Point(564, 26);
            this.RSGB.Name = "RSGB";
            this.RSGB.Size = new System.Drawing.Size(272, 388);
            this.RSGB.TabIndex = 2;
            this.RSGB.TabStop = false;
            this.RSGB.Text = "Приборы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Типы приборов и их колличество";
            // 
            // RScount
            // 
            this.RScount.Location = new System.Drawing.Point(6, 191);
            this.RScount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RScount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RScount.Name = "RScount";
            this.RScount.Size = new System.Drawing.Size(74, 23);
            this.RScount.TabIndex = 1;
            this.RScount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rslist
            // 
            this.rslist.CheckOnClick = true;
            this.rslist.FormattingEnabled = true;
            this.rslist.Location = new System.Drawing.Point(6, 37);
            this.rslist.Name = "rslist";
            this.rslist.Size = new System.Drawing.Size(226, 130);
            this.rslist.TabIndex = 0;
            // 
            // portGB
            // 
            this.portGB.Controls.Add(this.label4);
            this.portGB.Controls.Add(this.label3);
            this.portGB.Controls.Add(this.ComType);
            this.portGB.Controls.Add(this.PortCount);
            this.portGB.Enabled = false;
            this.portGB.Location = new System.Drawing.Point(286, 26);
            this.portGB.Name = "portGB";
            this.portGB.Size = new System.Drawing.Size(272, 388);
            this.portGB.TabIndex = 1;
            this.portGB.TabStop = false;
            this.portGB.Text = "Порты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Тип порта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество портов";
            // 
            // ComType
            // 
            this.ComType.FormattingEnabled = true;
            this.ComType.Items.AddRange(new object[] {
            "COM ",
            "LAN",
            "USB",
            "GSM"});
            this.ComType.Location = new System.Drawing.Point(17, 95);
            this.ComType.Name = "ComType";
            this.ComType.Size = new System.Drawing.Size(121, 23);
            this.ComType.TabIndex = 1;
            this.ComType.Text = "COM ";
            // 
            // PortCount
            // 
            this.PortCount.Location = new System.Drawing.Point(17, 37);
            this.PortCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.PortCount.Name = "PortCount";
            this.PortCount.Size = new System.Drawing.Size(120, 23);
            this.PortCount.TabIndex = 0;
            // 
            // PCGB
            // 
            this.PCGB.Controls.Add(this.label5);
            this.PCGB.Controls.Add(this.label1);
            this.PCGB.Controls.Add(this.label2);
            this.PCGB.Controls.Add(this.CompAllCheck);
            this.PCGB.Controls.Add(this.CompCB);
            this.PCGB.Controls.Add(this.countPC);
            this.PCGB.Controls.Add(this.CompsName);
            this.PCGB.Location = new System.Drawing.Point(8, 26);
            this.PCGB.Name = "PCGB";
            this.PCGB.Size = new System.Drawing.Size(272, 388);
            this.PCGB.TabIndex = 0;
            this.PCGB.TabStop = false;
            this.PCGB.Text = "Компьютеры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Права доступа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ключ тестовых PC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество тестовых PC";
            // 
            // CompAllCheck
            // 
            this.CompAllCheck.AutoSize = true;
            this.CompAllCheck.Location = new System.Drawing.Point(16, 306);
            this.CompAllCheck.Name = "CompAllCheck";
            this.CompAllCheck.Size = new System.Drawing.Size(94, 19);
            this.CompAllCheck.TabIndex = 11;
            this.CompAllCheck.Text = "Выбрать все";
            this.CompAllCheck.UseVisualStyleBackColor = true;
            this.CompAllCheck.CheckedChanged += new System.EventHandler(this.CompAllCheck_CheckedChanged);
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
            this.CompCB.Location = new System.Drawing.Point(16, 152);
            this.CompCB.Name = "CompCB";
            this.CompCB.Size = new System.Drawing.Size(239, 130);
            this.CompCB.TabIndex = 10;
            // 
            // countPC
            // 
            this.countPC.Location = new System.Drawing.Point(16, 96);
            this.countPC.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.countPC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countPC.Name = "countPC";
            this.countPC.Size = new System.Drawing.Size(100, 23);
            this.countPC.TabIndex = 0;
            this.countPC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CompsName
            // 
            this.CompsName.Location = new System.Drawing.Point(16, 37);
            this.CompsName.Name = "CompsName";
            this.CompsName.Size = new System.Drawing.Size(100, 23);
            this.CompsName.TabIndex = 0;
            // 
            // RStP
            // 
            this.RStP.Controls.Add(this.RSPB);
            this.RStP.Controls.Add(this.label10);
            this.RStP.Controls.Add(this.ParentCB);
            this.RStP.Controls.Add(this.RStype);
            this.RStP.Controls.Add(this.label9);
            this.RStP.Controls.Add(this.PRnum);
            this.RStP.Controls.Add(this.DelPR);
            this.RStP.Controls.Add(this.InsPR);
            this.RStP.Controls.Add(this.label8);
            this.RStP.Controls.Add(this.label7);
            this.RStP.Controls.Add(this.selCom);
            this.RStP.Controls.Add(this.SelPC);
            this.RStP.Location = new System.Drawing.Point(4, 24);
            this.RStP.Name = "RStP";
            this.RStP.Padding = new System.Windows.Forms.Padding(3);
            this.RStP.Size = new System.Drawing.Size(853, 482);
            this.RStP.TabIndex = 1;
            this.RStP.Text = "Приборы";
            this.RStP.UseVisualStyleBackColor = true;
            // 
            // RSPB
            // 
            this.RSPB.Location = new System.Drawing.Point(7, 434);
            this.RSPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RSPB.Name = "RSPB";
            this.RSPB.Size = new System.Drawing.Size(520, 22);
            this.RSPB.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Родительский прибор";
            // 
            // ParentCB
            // 
            this.ParentCB.FormattingEnabled = true;
            this.ParentCB.Location = new System.Drawing.Point(6, 244);
            this.ParentCB.Name = "ParentCB";
            this.ParentCB.Size = new System.Drawing.Size(165, 23);
            this.ParentCB.TabIndex = 11;
            // 
            // RStype
            // 
            this.RStype.FormattingEnabled = true;
            this.RStype.Location = new System.Drawing.Point(6, 153);
            this.RStype.Name = "RStype";
            this.RStype.Size = new System.Drawing.Size(165, 23);
            this.RStype.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Тип приборa и количество";
            // 
            // PRnum
            // 
            this.PRnum.Location = new System.Drawing.Point(6, 182);
            this.PRnum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PRnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PRnum.Name = "PRnum";
            this.PRnum.Size = new System.Drawing.Size(74, 23);
            this.PRnum.TabIndex = 7;
            this.PRnum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DelPR
            // 
            this.DelPR.Location = new System.Drawing.Point(532, 427);
            this.DelPR.Name = "DelPR";
            this.DelPR.Size = new System.Drawing.Size(149, 36);
            this.DelPR.TabIndex = 5;
            this.DelPR.Text = "Удалить";
            this.DelPR.UseVisualStyleBackColor = true;
            this.DelPR.Click += new System.EventHandler(this.DelPR_Click);
            // 
            // InsPR
            // 
            this.InsPR.Location = new System.Drawing.Point(696, 427);
            this.InsPR.Name = "InsPR";
            this.InsPR.Size = new System.Drawing.Size(149, 36);
            this.InsPR.TabIndex = 4;
            this.InsPR.Text = "Добавить";
            this.InsPR.UseVisualStyleBackColor = true;
            this.InsPR.Click += new System.EventHandler(this.InsPR_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Выбор COM-порта";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Выбор компьютера";
            // 
            // selCom
            // 
            this.selCom.FormattingEnabled = true;
            this.selCom.Location = new System.Drawing.Point(6, 86);
            this.selCom.Name = "selCom";
            this.selCom.Size = new System.Drawing.Size(121, 23);
            this.selCom.TabIndex = 1;
            this.selCom.SelectedIndexChanged += new System.EventHandler(this.selCom_SelectedIndexChanged);
            // 
            // SelPC
            // 
            this.SelPC.FormattingEnabled = true;
            this.SelPC.Location = new System.Drawing.Point(6, 31);
            this.SelPC.Name = "SelPC";
            this.SelPC.Size = new System.Drawing.Size(121, 23);
            this.SelPC.TabIndex = 0;
            this.SelPC.SelectedIndexChanged += new System.EventHandler(this.SelPC_SelectedIndexChanged);
            // 
            // userPG
            // 
            this.userPG.Controls.Add(this.userPB);
            this.userPG.Controls.Add(this.userINS);
            this.userPG.Controls.Add(this.userNum);
            this.userPG.Location = new System.Drawing.Point(4, 24);
            this.userPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userPG.Name = "userPG";
            this.userPG.Size = new System.Drawing.Size(853, 482);
            this.userPG.TabIndex = 3;
            this.userPG.Text = "Пользователи";
            this.userPG.UseVisualStyleBackColor = true;
            // 
            // userPB
            // 
            this.userPB.Location = new System.Drawing.Point(8, 450);
            this.userPB.Name = "userPB";
            this.userPB.Size = new System.Drawing.Size(522, 23);
            this.userPB.TabIndex = 2;
            this.userPB.Visible = false;
            // 
            // userINS
            // 
            this.userINS.Location = new System.Drawing.Point(683, 439);
            this.userINS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userINS.Name = "userINS";
            this.userINS.Size = new System.Drawing.Size(164, 40);
            this.userINS.TabIndex = 1;
            this.userINS.Text = "Добавить";
            this.userINS.UseVisualStyleBackColor = true;
            this.userINS.Click += new System.EventHandler(this.userINS_Click);
            // 
            // userNum
            // 
            this.userNum.Location = new System.Drawing.Point(536, 450);
            this.userNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.userNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.userNum.Name = "userNum";
            this.userNum.Size = new System.Drawing.Size(131, 23);
            this.userNum.TabIndex = 0;
            this.userNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pass
            // 
            this.pass.Controls.Add(this.label11);
            this.pass.Controls.Add(this.Tree);
            this.pass.Controls.Add(this.passPB);
            this.pass.Controls.Add(this.label12);
            this.pass.Controls.Add(this.numPass);
            this.pass.Controls.Add(this.Ruser);
            this.pass.Controls.Add(this.TypeKeyBox);
            this.pass.Controls.Add(this.PermBox);
            this.pass.Controls.Add(this.passDel);
            this.pass.Controls.Add(this.insPass);
            this.pass.Controls.Add(this.userlist);
            this.pass.Controls.Add(this.SelectTypePassBox);
            this.pass.Location = new System.Drawing.Point(4, 24);
            this.pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(853, 482);
            this.pass.TabIndex = 2;
            this.pass.Text = "Пароли";
            this.pass.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Тип ключа";
            // 
            // Tree
            // 
            this.Tree.CheckBoxes = true;
            this.Tree.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tree.Location = new System.Drawing.Point(8, 75);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(323, 329);
            this.Tree.TabIndex = 17;
            this.Tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterCheck);
            // 
            // passPB
            // 
            this.passPB.Location = new System.Drawing.Point(8, 448);
            this.passPB.Name = "passPB";
            this.passPB.Size = new System.Drawing.Size(505, 23);
            this.passPB.TabIndex = 16;
            this.passPB.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(369, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "Количество паролей";
            // 
            // numPass
            // 
            this.numPass.Location = new System.Drawing.Point(369, 153);
            this.numPass.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPass.Name = "numPass";
            this.numPass.Size = new System.Drawing.Size(120, 23);
            this.numPass.TabIndex = 14;
            this.numPass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Ruser
            // 
            this.Ruser.AutoSize = true;
            this.Ruser.Location = new System.Drawing.Point(214, 6);
            this.Ruser.Name = "Ruser";
            this.Ruser.Size = new System.Drawing.Size(156, 19);
            this.Ruser.TabIndex = 13;
            this.Ruser.Text = "Случайные сотрудники";
            this.Ruser.UseVisualStyleBackColor = true;
            this.Ruser.CheckedChanged += new System.EventHandler(this.Ruser_CheckedChanged);
            // 
            // TypeKeyBox
            // 
            this.TypeKeyBox.Enabled = false;
            this.TypeKeyBox.FormattingEnabled = true;
            this.TypeKeyBox.Items.AddRange(new object[] {
            "Основной",
            "Код принуждения",
            "МАСТЕР",
            "Открывающий",
            "Закрывающий"});
            this.TypeKeyBox.Location = new System.Drawing.Point(369, 106);
            this.TypeKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TypeKeyBox.Name = "TypeKeyBox";
            this.TypeKeyBox.Size = new System.Drawing.Size(172, 23);
            this.TypeKeyBox.TabIndex = 11;
            this.TypeKeyBox.Text = "Основной";
            // 
            // PermBox
            // 
            this.PermBox.FormattingEnabled = true;
            this.PermBox.Location = new System.Drawing.Point(369, 64);
            this.PermBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PermBox.Name = "PermBox";
            this.PermBox.Size = new System.Drawing.Size(172, 23);
            this.PermBox.TabIndex = 10;
            this.PermBox.Text = "Полномочия";
            // 
            // passDel
            // 
            this.passDel.Location = new System.Drawing.Point(519, 435);
            this.passDel.Name = "passDel";
            this.passDel.Size = new System.Drawing.Size(149, 36);
            this.passDel.TabIndex = 9;
            this.passDel.Text = "Удалить";
            this.passDel.UseVisualStyleBackColor = true;
            this.passDel.Click += new System.EventHandler(this.passDel_Click);
            // 
            // insPass
            // 
            this.insPass.Location = new System.Drawing.Point(682, 435);
            this.insPass.Name = "insPass";
            this.insPass.Size = new System.Drawing.Size(149, 36);
            this.insPass.TabIndex = 8;
            this.insPass.Text = "Добавить";
            this.insPass.UseVisualStyleBackColor = true;
            this.insPass.Click += new System.EventHandler(this.insPass_Click);
            // 
            // userlist
            // 
            this.userlist.FormattingEnabled = true;
            this.userlist.Location = new System.Drawing.Point(7, 6);
            this.userlist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userlist.Name = "userlist";
            this.userlist.Size = new System.Drawing.Size(202, 23);
            this.userlist.TabIndex = 4;
            this.userlist.Text = "Сотрудник";
            // 
            // SelectTypePassBox
            // 
            this.SelectTypePassBox.FormattingEnabled = true;
            this.SelectTypePassBox.Items.AddRange(new object[] {
            "Пароль для программ",
            "PIN-код",
            "Брелок TouchMemory",
            "Proximity карта",
            "Отпечаток пальца BIOAccess",
            "Автомобильный номер",
            "PIN-код2",
            "Удаленное управление",
            "Шаблон лица BIOAccess SB101",
            "Шаблон ладони BIOAccess PA10",
            "Отпечаток пальца BIOAccess W2"});
            this.SelectTypePassBox.Location = new System.Drawing.Point(7, 32);
            this.SelectTypePassBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectTypePassBox.Name = "SelectTypePassBox";
            this.SelectTypePassBox.Size = new System.Drawing.Size(202, 23);
            this.SelectTypePassBox.TabIndex = 0;
            this.SelectTypePassBox.Text = "Тип ключа";
            this.SelectTypePassBox.SelectedIndexChanged += new System.EventHandler(this.SelectTypePass_SelectedIndexChanged);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 510);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Test";
            this.Text = "Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Test_FormClosed);
            this.Load += new System.EventHandler(this.Test_Load);
            this.tab.ResumeLayout(false);
            this.PCtP.ResumeLayout(false);
            this.PCtP.PerformLayout();
            this.RSGB.ResumeLayout(false);
            this.RSGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RScount)).EndInit();
            this.portGB.ResumeLayout(false);
            this.portGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortCount)).EndInit();
            this.PCGB.ResumeLayout(false);
            this.PCGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countPC)).EndInit();
            this.RStP.ResumeLayout(false);
            this.RStP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PRnum)).EndInit();
            this.userPG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userNum)).EndInit();
            this.pass.ResumeLayout(false);
            this.pass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage PCtP;
        private System.Windows.Forms.TabPage RStP;
        private System.Windows.Forms.GroupBox RSGB;
        private System.Windows.Forms.GroupBox portGB;
        private System.Windows.Forms.GroupBox PCGB;
        private System.Windows.Forms.CheckBox RSCBx;
        private System.Windows.Forms.CheckBox potrCBx;
        private System.Windows.Forms.NumericUpDown countPC;
        private System.Windows.Forms.TextBox CompsName;
        private System.Windows.Forms.CheckedListBox CompCB;
        private System.Windows.Forms.CheckBox CompAllCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComType;
        private System.Windows.Forms.NumericUpDown PortCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RScount;
        private System.Windows.Forms.CheckedListBox rslist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeleteBT;
        private System.Windows.Forms.Button insertBT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DelPR;
        private System.Windows.Forms.Button InsPR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox selCom;
        private System.Windows.Forms.ComboBox SelPC;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown PRnum;
        private System.Windows.Forms.ComboBox RStype;
        private System.Windows.Forms.ComboBox ParentCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar RSPB;
        private System.Windows.Forms.TabPage pass;
        private System.Windows.Forms.ComboBox SelectTypePassBox;
        private System.Windows.Forms.ComboBox userlist;
        private System.Windows.Forms.Button passDel;
        private System.Windows.Forms.Button insPass;
        private System.Windows.Forms.ComboBox PermBox;
        private System.Windows.Forms.ComboBox TypeKeyBox;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.TabPage userPG;
        private System.Windows.Forms.Button userINS;
        private System.Windows.Forms.NumericUpDown userNum;
        private System.Windows.Forms.CheckBox Ruser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numPass;
        private System.Windows.Forms.ProgressBar userPB;
        private System.Windows.Forms.ProgressBar passPB;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.Label label11;
    }
}