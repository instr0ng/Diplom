﻿using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using Microsoft.Win32;

namespace SQLDrv
{
    public partial class Settings : Form
    {

        private string codPass(byte[] pass)
        {
            char[] ascii;
            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x1 });
            string nstr = "";
            for (int i = 0; i < pass.Length; i++)
            {
                switch (pass[i])
                {
                    case 0x0:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                        nstr += ascii[0].ToString();
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x1 });
                        nstr += ascii[0].ToString();
                        break;
                    case 0xFE:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                        nstr += ascii[0].ToString();
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x2 });
                        nstr += ascii[0].ToString();
                        break;
                    case 0x20:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                        nstr += ascii[0].ToString();
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x3 });
                        nstr += ascii[0].ToString();
                        break;
                    case 0x5C:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                        nstr += ascii[0].ToString();
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x4 });
                        nstr += ascii[0].ToString();
                        break;
                    case 0xA:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                        nstr += ascii[0].ToString();
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x5 });
                        nstr += ascii[0].ToString();
                        break;
                    default:
                        ascii = Encoding.GetEncoding(0).GetChars(new byte[] { pass[i] });
                        nstr += ascii[0].ToString();
                        break;
                }
            }
            return nstr;
        }

        //Функция подсчёта конфига
        private int[] passConfig()
        {
            int[] config = new int[2];
            if (SelectTypePassBox.SelectedIndex == 0 || SelectTypePassBox.SelectedIndex == 1)
            {
                config[0] = 64;

                if (Tree.Nodes[0].Checked)
                    config[0] += 16;
                if (Tree.Nodes[1].Checked)
                {
                    config[0] += 1;

                    if (Tree.Nodes[1].Nodes[0].Checked)
                        config[0] += 512;
                    if (Tree.Nodes[1].Nodes[1].Checked)
                        config[0] += 4194304;
                    if (Tree.Nodes[1].Nodes[2].Checked)
                        config[0] += 8388608;
                    if (Tree.Nodes[1].Nodes[3].Checked)
                        config[0] += 33554432;
                    if (Tree.Nodes[1].Nodes[4].Checked)
                        config[0] += 67108864;
                    if (Tree.Nodes[1].Nodes[5].Checked)
                        config[0] += 134217728;
                    if (Tree.Nodes[1].Nodes[6].Checked)
                        config[0] += 268435456;
                    if (Tree.Nodes[1].Nodes[7].Checked)
                        config[0] += 256;
                    if (Tree.Nodes[1].Nodes[8].Checked)
                        config[1] += 1024;
                    if (Tree.Nodes[1].Nodes[9].Checked)
                        config[0] += 536870912;
                }

                if (Tree.Nodes[2].Checked)
                {
                    config[0] += 2;
                    if (Tree.Nodes[2].Nodes[0].Checked)
                        config[0] += 8;
                    if (Tree.Nodes[2].Nodes[1].Checked)
                        config[0] += 4;
                    if (Tree.Nodes[2].Nodes[2].Checked)
                        config[0] += 8192;
                    if (Tree.Nodes[2].Nodes[3].Checked)
                        config[0] += 32;
                    if (Tree.Nodes[2].Nodes[4].Checked)
                        config[1] += 4096;
                    if (Tree.Nodes[2].Nodes[5].Checked)
                        config[1] += 8192;
                }
                if (Tree.Nodes[3].Checked)
                {
                    config[0] += 2048;
                    config[1] += 2048;
                }
                if (Tree.Nodes[4].Checked)
                    config[0] += 1024;
                if (Tree.Nodes[5].Checked)
                    config[1] += 256;
                if (Tree.Nodes[6].Checked)
                    config[1] += 512;
            }
            else
            {
                if (Tree.Nodes[0].Checked)
                    config[0] += 128;
                if (Tree.Nodes[1].Checked)
                    config[0] += 1073741824;
                if (Tree.Nodes[2].Checked)
                    config[0] += 32768;
                if (Tree.Nodes[3].Checked)
                    config[0] += 16777216;
                switch (TypeKeyBox.SelectedIndex)
                {
                    case 1:
                        config[0] += 131072;
                        break;
                    case 2:
                        config[0] += 262144 + 131072;
                        break;
                    case 3:
                        config[0] += 524288;
                        break;
                    case 4:
                        config[0] += 1048576 + 131072;
                        break;
                    default:
                        break;
                }

                config[1] = 16128;
            }



            return config;
        }

        public static SqlConnection sqlConnection = null;

        string currtab = null;
        string compID = "", RSTypeID = "", RScompID = "", ComID = "", RSParID = "0";

        public static Settings f1;

        public Settings()
        {
            InitializeComponent();
        }


        //Функция для запроса имени сервера из реестра
        private string GetServerName()
        {
            RegistryKey LocalMachineRegKey;
            LocalMachineRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Bolid\ORION\CSO\DBPARAMS12");

            string server_name = (string)LocalMachineRegKey.GetValue("SERVER NAME");
            return server_name;
        }

        //Функция для запроса имени базы данных из реестра
        private string GetDbName()
        {
            RegistryKey LocalMachineRegKey;
            LocalMachineRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Bolid\ORION\CSO\DBPARAMS12");

            string DB_name = (string)LocalMachineRegKey.GetValue("DATABASE NAME");
            return DB_name;
        }


        //Функция для соединения с сервером и подключения базы данных
        private void StartConnection()
        {
            var connectionString = $@"User ID= sa;Password = 123456;Initial Catalog={GetDbName()};Data Source={GetServerName()}"; 

            //ExecuteCommandSync("sqllocaldb.exe stop MSSQLLocalDB");

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (Exception objException)
            {
                MessageBox.Show("Не удалось подключиться к базе данных" + '\n' + objException.Message);
            }

            if (sqlConnection.State == ConnectionState.Open)
            {
                ConnState.Text = "Подключение к базе данных прошло успешно";
                ConnState.ForeColor = Color.Green;

                upd.Enabled = true;
                TestBT.Enabled = true;
                TabSelect.Enabled = true;
                InsertBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                updtab.Enabled = true;
                currtab = "comps";

                UpdateTab();
            }
        }


        
        //Функция добавления выбранных объектов в базу данных
        private void INSBtn_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            switch (currtab)
            {

                case "comps":

                    if ((CompIDBox.Text == "") || (CompIPBox.Text == "") || (ComPCIDBox.Text == ""))
                    {
                        MessageBox.Show("Заполнены не все обязательные поля");
                        break;
                    }

                    double Gtype = 1;
                    for (int i = 0; i < 8; i++)
                        if (CompCB.GetItemChecked(i))
                            Gtype += Math.Pow(2, i + 1);
                    Insert("comps", CompIDBox.Text, CompIDBox.Text, CompNameBox.Text, Gtype.ToString(), CompIPBox.Text);
                    UpdTextBoxes(CompAutoID, CompIDBox);
                    break;

                case "comports":

                    if ((ComIDBox.Text == "") || (ComIPBox.Text == "") || (ComPCIDBox.Text == ""))
                    {
                        MessageBox.Show("Заполнены не все обязательные поля");
                        break;
                    }

                    command = new SqlCommand($"select id from comps where name = '{ComPCIDBox.Text}'", sqlConnection);
                    compID = command.ExecuteScalar().ToString();

                    Insert("comports", ComIDBox.Text, compID, ComNumBox.Text, ComAdaptorBox.SelectedIndex.ToString(), "3", (ComTypeBox.SelectedIndex + 1).ToString(), "1", ComIPBox.Text, ComBaudBox.Text);
                    UpdTextBoxes(ComAutoID, ComIDBox);
                    break;

                case "rslines":

                    if ((RSIDBox.Text == "") || (RSIPBox.Text == "") || (RSAddressBox.Text == "") || (RSPCBox.Text == "") || (RSPortBox.Text == ""))
                    {
                        MessageBox.Show("Заполнены не все обязательные поля");
                        break;
                    }

                    command = new SqlCommand($"select devicetype from dtypeselement where name = '{RSTypeBox.Text}'", sqlConnection);
                    RSTypeID = command.ExecuteScalar().ToString();

                    command = new SqlCommand($"select id from comps where name = '{RSPCBox.Text}'", sqlConnection);
                    RScompID = command.ExecuteScalar().ToString();

                    ComID = RSPortBox.Text.Remove(0, 3);
                    command = new SqlCommand($"select id from comports where computerID = {RScompID} and number = {ComID}", sqlConnection);
                    ComID = command.ExecuteScalar().ToString();

                    if (RSParentBox.SelectedIndex > -1)
                    {
                        command = new SqlCommand($"select id from rslines where comportID = {ComID} and name = '{RSParentBox.Text}'", sqlConnection);
                        RSParID = command.ExecuteScalar().ToString();

                    }

                    Insert("rslines", RSIDBox.Text, RSIDBox.Text, ComID, RSParID, RSAddressBox.Text, (RSInterfaceBox.SelectedIndex + 1).ToString(), RSTypeBox.Text + " (" + RSAddressBox.Text + ")", RSIPBox.Text, RSTypeID);
                    AddDev();
                    UpdTextBoxes(RSAutoID, RSIDBox);
                    UpdComboBoxes(RSPCBox, RSPortBox, RSParentBox);
                    break;

                case "plist":

                    if ((ClID.Text == "") || (ClTabID.Text == "") || (ClFirstNameBox.Text == "") || (ClNameBox.Text == "") || (ClMidNameBox.Text == "") || (ClStatusBox.Text == ""))
                    {
                        MessageBox.Show("Заполнены не все обязательные поля");
                        break;
                    }

                    Insert("plist", ClID.Text, ClNameBox.Text, ClFirstNameBox.Text, ClMidNameBox.Text, (ClStatusBox.SelectedIndex + 1).ToString(), ClTabID.Text, DateTime.Now.ToString());
                    UpdTextBoxes(ComAutoID, ComIDBox);
                    break;

                case "pmark":
                  insPass_Click();
                    break;

            }

            // Обновление таблицы справа
            UpdateTab();
        }

        //Функция обновления TextBox'ов
        private void UpdTextBoxes(CheckBox box, TextBox text)
        {
            

            if (box.Checked)
            {
                SqlCommand command;

                switch (text.Tag)
                {
                    case "PC":
                        if (text.AccessibleName == "PCID")
                        {
                            command = new SqlCommand("select COALESCE(MAX(ID) + 1, 1) from comps", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }

                        if (text.AccessibleName == "PCIP")
                        {
                            if (Dns.GetHostAddresses(Dns.GetHostName()).Length > 0)
                            {
                                int i = 0;
                                text.Text = Dns.GetHostAddresses(Dns.GetHostName())[i].ToString();
                                while (text.Text.Remove(7, text.Text.Length-7) != "192.168")
                                {
                                    text.Text = Dns.GetHostAddresses(Dns.GetHostName())[i].ToString();
                                    i++;
                                }
                            }
                            else
                                text.Text = "127.0.0.1";
                            text.Enabled = false;
                        }
                        break;
                    case "PORT":
                        if (text.AccessibleName == "PORTID")
                        {
                            command = new SqlCommand("select coalesce(max(ID)+1, 1) from comports", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }

                        if (text.AccessibleName == "PORTIP")
                        {
                            text.Text = "127.0.0.1";
                            text.Enabled = false;
                        }
                        break;
                    case "RS":
                        if (text.AccessibleName == "RSID")
                        {
                            command = new SqlCommand("select coalesce(max(ID)+1, 1) from rslines", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }

                        if (text.AccessibleName == "RSAddr")
                        {
                            command = new SqlCommand($"select coalesce(max(Glineno)+1, 1) from rslines where comportid = {RSPortBox.Text.Remove(0, 3)}", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }

                        if (text.AccessibleName == "RSIP")
                        {
                            text.Text = "127.0.0.1";
                            text.Enabled = false;
                        }
                        break;
                    case "CL":
                        if (text.AccessibleName == "CLID")
                        {
                            command = new SqlCommand("select coalesce(max(ID)+1, 1) from plist", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }

                        if (text.AccessibleName == "CLTABID")
                        {
                            command = new SqlCommand("select coalesce(max(TabNumber)+1, 1) from plist", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }
                        break;
                }
            }
            else
            {
                if (text.AccessibleName == box.AccessibleName)
                {
                    text.Enabled = true;
                    text.Text = "";
                }
            }

            if (RSPortBox.Text == "")
                AutoAddr.Enabled = false;
            else AutoAddr.Enabled = true;
        }


        //Функция обновления ComboBox'ов
        private void UpdComboBoxes(params ComboBox[] box)
        {
            SqlCommand command;
            SqlDataReader read;
            string buf = "-";
            for (int i = 0; i < box.Length; i++)
                switch (box[i].Tag)
                {
                    case "PORT":
                        switch (box[i].AccessibleName)
                        {
                            case "PCID":

                                box[i].Items.Clear();
                                box[i].Text = "";

                                command = new SqlCommand("select name from Comps", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                {
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                }
                                read.Close();
                                if (box[i].Items.Count != 0)
                                    box[i].SelectedIndex = box[i].Items.Count - 1;
                                break;
                            case "INTID":
                                box[i].SelectedIndex = 2;
                                break;
                            case "TYPEID":
                                box[i].SelectedIndex = 0;
                                break;
                            case "BAUD":
                                box[i].SelectedIndex = 0;
                                break;
                        }
                        break;
                    case "RS":
                        switch (box[i].AccessibleName)
                        {
                            case "TYPEID":
                                ///////////////////////////////////////////////////////////////////
                                if (box[i].Items.Count == 0)
                                {
                                    box[i].Items.Clear();
                                    box[i].Text = "";
                                    command = new SqlCommand("select name from dtypesElement where elementtype = 4", sqlConnection);
                                    read = command.ExecuteReader();
                                    while (read.Read())
                                    {
                                        box[i].Items.Add(read.GetValue(0).ToString());
                                    }
                                    read.Close();
                                    box[i].SelectedIndex = 0;
                                }
                                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                                break;
                            case "INTID":
                                box[i].SelectedIndex = 0;
                                break;
                            case "PCID":
                                ///////////////////////////////////////////////////////////////////
                                ///

                                box[i].Items.Clear();
                                command = new SqlCommand("select name from Comps", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                {
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                }
                                read.Close();

                                if (box[i].Items.Count == 0)
                                    box[i].Text = "";

                                if (box[i].Items.Count != 0)
                                    box[i].SelectedIndex = box[i].Items.Count - 1;

                                if (box[i].SelectedIndex != -1)
                                    buf = box[i].Text;

                                if (!box[i + 1].Focused)
                                    box[i + 1].Items.Clear();

                                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                                break;
                            case "PORTID":
                                ///////////////////////////////////////////////////////////////////////
                                if ((box[i - 1].SelectedIndex > -1))
                                {
                                    box[i].Text = "";
                                    int count = 0;
                                    command = new SqlCommand($"select cp.porttype, cp.Number from comps c join comports cp on c.id = cp.computerID where c.name = '{box[i - 1].Text}' and cp.porttype = {RSInterfaceBox.SelectedIndex + 1}", sqlConnection);
                                    read = command.ExecuteReader();
                                    while (read.Read())
                                    {
                                        box[i].Items.Add(ComTypeBox.Items[Convert.ToInt32(read.GetValue(0)) - 1] + read.GetValue(1).ToString());
                                        count++;
                                    }
                                    read.Close();

                                    if (box[i].Items.Count > count)
                                        while (count > 0)
                                        {
                                            box[i].Items.RemoveAt(box[i].Items.Count / 2 + count - 1);
                                            count--;
                                        }
                                          
                                    if (!box[i].Focused)
                                        box[i].SelectedIndex = box[i].Items.Count - 1;
                                }
                                if ((box[i].SelectedIndex > -1) && (buf != null))
                                {
                                    command = new SqlCommand($"select cp.ID from comps c join comports cp on c.id = cp.computerID where c.name = '{buf}' and number = {box[i].Items[box[i].SelectedIndex].ToString().Remove(0, 3)}", sqlConnection);
                                    buf = command.ExecuteScalar().ToString();
                                }

                                box[i + 1].Items.Clear();
                                box[i + 1].Text = "";

                                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                                break;
                            case "PARID":
                                if ((box[i - 1].SelectedIndex > -1) && (buf != "-"))
                                {
                                    box[i].Text = "";
                                    command = new SqlCommand($"select name from rslines where comportID = {buf}", sqlConnection);
                                    read = command.ExecuteReader();
                                    while (read.Read())
                                        box[i].Items.Add(read.GetValue(0).ToString());
                                    read.Close();
                                }
                                break;
                        }
                        break;
                    case "PASS":
                        userlist.Items.Clear();
                        userlist.Text = "";
                        command = new SqlCommand("select Name, Firstname, Midname, ID from pList", sqlConnection);
                        read = command.ExecuteReader();
                        while (read.Read())
                        {
                            try
                            {
                                userlist.Items.Add(read.GetValue(0).ToString() + " " + read.GetValue(1).ToString().Remove(1, read.GetValue(1).ToString().Length - 1) + ". " + read.GetValue(2).ToString().Remove(1, read.GetValue(2).ToString().Length - 1) + "." + "(" + read.GetValue(3).ToString() + ")");
                            }
                            catch
                            {
                            }

                        }
                        read.Close();

                        PermBox.Items.Clear();
                        command = new SqlCommand("select name from Groups", sqlConnection);
                        read = command.ExecuteReader();
                        while (read.Read())
                        {
                            PermBox.Items.Add(read.GetValue(0).ToString());
                        }
                        read.Close();
                        PermBox.SelectedIndex = 0;
                        userlist.SelectedIndex = userlist.Items.Count - 1;
                        break;
                }

        }

        

 

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (TabSelect.SelectedIndex)
            {

                case 0:
                    currtab = "comps";
                    break;
                case 1:
                    currtab = "comports";
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        UpdTextBoxes(ComAutoID, ComIDBox);
                        UpdTextBoxes(ComAutoIP, ComIPBox);
                        UpdComboBoxes(ComPCIDBox, ComNumBox, ComAdaptorBox, ComTypeBox, ComBaudBox);
                        UpdTextBoxes(ComAutoID, ComIDBox);
                        UpdTextBoxes(ComAutoIP, ComIPBox);
                    }
                    break;
                case 2:
                    currtab = "rslines";
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        UpdTextBoxes(RSAutoID, RSIDBox);
                        UpdTextBoxes(RSAutoIP, RSIPBox);
                        UpdTextBoxes(AutoAddr, RSAddressBox);
                        UpdComboBoxes(RSInterfaceBox, RSPCBox, RSPortBox, RSParentBox, RSTypeBox);
                    }
                    break;
                case 3:
                    currtab = "plist";
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        UpdTextBoxes(ClAutoID, ClID);
                        UpdTextBoxes(ClAutoTabID, ClTabID);
                        UpdTextBoxes(AutoAddr, RSAddressBox);
                        UpdComboBoxes(ClStatusBox);
                    }
                    break;
                case 4:
                    currtab = "pmark";
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        UpdComboBoxes(userlist);
                    }
                    break;
            }
            UpdateTab();
        }



        //RSLINES-------------------------------------------------------------------


        private void TestBT_Click(object sender, EventArgs e)
        {
            Test Test = new Test(this);
            Test.Show();
            this.Enabled = false;
        }


        //------------------------------------------------------------------------------


        //FUNCTIONS-----------------------------------------------------------------------------------------------


        private void Insert(string table, params string[] args) // Comps - ID, GIndex, Name, GType, IP;
                                                                // ComPorts - ID, ComputerID, Number, Adaptor, PrAdaptor, PortType, ProtocolType, IP, Baud
                                                                // RSLines - ID, GIndex, ComPortID, PKUID, GLineNo, DeviceInterface, Name, type
                                                                // DevItems - ID, ComputerID, DeviceID, Address, Gindex, ItemType, Name
                                                                // pList - ID, Name, FirstName, MidName, status, Schedule, TabNumber, ChangeTime
        {
            if (args.Length == 0)
                return;

            SqlCommand command;
            switch (table)
            {
                case "comps":
                    try
                    {
                        command = new SqlCommand($"insert into comps(ID, GIndex, Name, Gtype, TCP_IP) values({args[0]}, {args[1]}, '{args[2]}', {args[3]}, '{args[4]}') ", sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные." + '\n' + '\n' + exception.Message);
                    }
                    break;

                case "comports":
                    try
                    {
                        command = new SqlCommand($"insert into comports(ID, ComputerID, Number, Adaptor, PrAdaptor, PortType, Protokoltype, IPAddress, Baud) values({args[0]}, {args[1]}, {args[2]}, {args[3]}, {args[4]}, {args[5]}, {args[6]}, '{args[7]}', {args[8]}) ", sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные." + '\n' + '\n' + exception.Message);
                    }
                    break;

                case "rslines":
                    try
                    {
                        command = new SqlCommand($"insert into rslines(ID, GIndex, ComPortID, PKUID, GLineNo, DeviceInterface, Name, IPAddress, DeviceType) values({args[0]}, {args[1]}, {args[2]}, {args[3]}, {args[4]}, {args[5]},'{args[6]}', '{args[7]}', {args[8]}) ", sqlConnection);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные." + '\n' + '\n' + exception.Message);
                    }
                    break;

                case "devitems":
                    try
                    {
                        command = new SqlCommand($"insert into devitems(ID, ComputerID, DeviceID, Address, Gindex, ItemType, Name) values({args[0]}, {args[1]}, {args[2]}, {args[3]}, {args[4]}, {args[5]}, '{args[6]}') ", sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные" + '\n' + '\n' + exception.Message);
                    }
                    break;

                case "plist":
                    try
                    {
                        command = new SqlCommand($"insert pList (ID, Name, FirstName, MidName, status, Schedule, TabNumber, ChangeTime) values ({args[0]}, '{args[1]}', '{args[2]}', '{args[3]}', {args[4]}, 1, {args[5]}, '{args[6]}')", sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные" + '\n' + '\n' + exception.Message);
                    }
                    break;
            }
        }


        //Функции для обновления элементов управления при изменении их состояний
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ComPCIDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(CompAutoID, CompIDBox);
        }

        private void ComAutoID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(ComAutoID, ComIDBox);
        }

        private void RSAutoID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(RSAutoID, RSIDBox);
        }

        private void RSAutoIP_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(RSAutoIP, RSIPBox);
        }

        private void ComAutoIP_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(ComAutoIP, ComIPBox);
        }

        private void CompAutoID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(CompAutoID, CompIDBox);
        }

        private void CompAutoIP_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(CompAutoIP, CompIPBox);
        }

        private void AutoAddr_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(AutoAddr, RSAddressBox);
        }

        private void ClAutoID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(ClAutoID, ClID);
        }

        private void ClAutoTabID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(ClAutoTabID, ClTabID);
        }

        private void RSPCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(box, RSPortBox, RSParentBox);
        }

        private void RSPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(RSPCBox, box, RSParentBox);
        }

        private void RSInterfaceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(RSPCBox, RSPortBox, RSParentBox);
        }

        private void CompAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            for (int i = 0; i < 8; i++)
                CompCB.SetItemChecked(i, box.Checked);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //Запуск соединения при нажатии на кнопку
        private void ConnState_Click(object sender, EventArgs e)
        {
            StartConnection();
        }

        //Функция выделения всей строки по выделенной ячейке
        private void updtab_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < updtab.SelectedCells.Count; i++)
            {
                updtab.Rows[updtab.SelectedCells[i].RowIndex].Selected = true;
            }
        }

        //Функция обновления компонентов формы для кнопки "Обновить"
        private void upd_Click(object sender, EventArgs e)
        {
            switch (currtab)
            {
                case "comports":
                    UpdComboBoxes(ComPCIDBox, ComNumBox, ComAdaptorBox, ComTypeBox, ComBaudBox);
                    break;

                case "rslines":
                    UpdComboBoxes(RSPCBox, RSPortBox, RSParentBox, RSTypeBox, RSInterfaceBox);
                    break;
            }
           
            UpdateTab();
        }

        //Функция обновления таблицы 
        private void UpdateTab()
        {
            SqlCommand table = new SqlCommand($"select * from {currtab}", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = table;
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "name");
            updtab.DataSource = ds.Tables["name"].DefaultView;
        }


        //Функция добавления компонентов в таблицу DevItems
        private void AddDev()
        {
            SqlCommand command;
            command = new SqlCommand($"select CountReader from dTypesElement where name = '{RSTypeBox.Text}'", sqlConnection);
            int countReader = (int)command.ExecuteScalar();

            int i = 0;
            while (i --> countReader)
            {
                command = new SqlCommand("select coalesce(max(ID)+1, 1) from DevItems", sqlConnection);
                string DevItmID = command.ExecuteScalar().ToString();
                command = new SqlCommand($"insert into DevItems values ({DevItmID}, {RScompID}, {RSIDBox.Text}, {Convert.ToInt32(RSAddressBox.Text) * 256 + i}, {DevItmID}, '{"Считыватель " + i + ", Прибор " + RSAddressBox.Text}', Null, 0, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", sqlConnection);
                command.ExecuteNonQuery();
            }

            command = new SqlCommand($"select CountKey from dTypesElement where name = '{RSTypeBox.Text}'", sqlConnection);
            int countKey = (int)command.ExecuteScalar();

            i = 0;
            while (i --> countKey)
            {
                command = new SqlCommand("select coalesce(max(ID)+1, 1) from DevItems", sqlConnection);
                string DevItmID = command.ExecuteScalar().ToString();
                command = new SqlCommand($"insert into DevItems values ({DevItmID}, {RScompID}, {RSIDBox.Text}, {Convert.ToInt32(RSAddressBox.Text) * 256 + i}, {DevItmID}, '{"Реле " + i + ", Прибор " + RSAddressBox.Text}', Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", sqlConnection);
                command.ExecuteNonQuery();
            }

            command = new SqlCommand($"select CountShl from dTypesElement where name = '{RSTypeBox.Text}'", sqlConnection);
            int countShl = (int)command.ExecuteScalar();

            i = 0;
            while (i --> countShl)
            {
                command = new SqlCommand("select coalesce(max(ID)+1, 1) from DevItems", sqlConnection);
                string DevItmID = command.ExecuteScalar().ToString();
                command = new SqlCommand($"insert into DevItems values ({DevItmID}, {RScompID}, {RSIDBox.Text}, {Convert.ToInt32(RSAddressBox.Text) * 256 + i}, {DevItmID}, '{"ШС " + i + ", Прибор " + RSAddressBox.Text}', Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", sqlConnection);
                command.ExecuteNonQuery();
            }
        }

        private void Tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Доступ к АБД")
            {
                if (e.Node.Checked)
                    for (int i = 0; i < 10; i++)
                        Tree.Nodes[1].Nodes[i].Checked = true;
                else
                    for (int i = 0; i < 10; i++)
                        Tree.Nodes[1].Nodes[i].Checked = false;
            }

            if (e.Node.Text == "Оперативная задача")
            {
                if (e.Node.Checked)
                    for (int i = 0; i < 6; i++)
                        Tree.Nodes[2].Nodes[i].Checked = true;
                else
                    for (int i = 0; i < 6; i++)
                        Tree.Nodes[2].Nodes[i].Checked = false;
            }
        }

        //Функции изменения окна с параметрами пароля
        private void SelectTypePass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tree.Nodes.Clear();
            switch (SelectTypePassBox.SelectedIndex)
            {
                case 0 or 1:
                    TypeKeyBox.Enabled = false;
                    Tree.Nodes.Add("Менеджер сервера");
                    Tree.Nodes.Add("Доступ к АБД");
                    Tree.Nodes[1].Nodes.Add("Доступ к охранно-пожарной системе");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Доступ\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Сценарии управления\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Дерево управления\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Расписания\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Окна времени\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Уровни доступа\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Персонал\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Автомобили\"");
                    Tree.Nodes[1].Nodes.Add("Доступ к вкладке \"Пароли\"");
                    Tree.Nodes.Add("Оперативная задача");
                    Tree.Nodes[2].Nodes.Add("Управление отдельными выходами");
                    Tree.Nodes[2].Nodes.Add("Управление особо охраняемыми входами");
                    Tree.Nodes[2].Nodes.Add("Управление системой пожаротушения");
                    Tree.Nodes[2].Nodes.Add("Обрабатывать тревоги");
                    Tree.Nodes[2].Nodes.Add("Права на управление включением-выключением");
                    Tree.Nodes[2].Nodes.Add("Комментировать события");
                    Tree.Nodes.Add("Учёт рабочего времени");
                    Tree.Nodes.Add("Генератор отчётов");
                    Tree.Nodes.Add("Оболочка");
                    Tree.Nodes.Add("Персональная карточка");
                    break;
                case 2 or 3:
                    TypeKeyBox.Enabled = true;
                    TypeKeyBox.SelectedIndex = 0;
                    Tree.Nodes.Add("Хранить код ключа в приборах");
                    Tree.Nodes[0].Checked = true;
                    Tree.Nodes.Add("Хранить код ключа в ПКУ");
                    Tree.Nodes.Add("Ключ заблокирован");
                    Tree.Nodes.Add("Стоп-лист");
                    break;
            }
        }



        //Добавление пароля----------------
        private void insPass_Click()
        {
            byte[] hex;


            switch (SelectTypePassBox.SelectedIndex)
            {
                case 0 or 1:
                    hex = new byte[PasswordBox.Text.Length+1];
                    hex[0] = (byte)PasswordBox.Text.Length;
                    for (int i = 1; i < hex.Length; i++)
                        hex[i] = Encoding.GetEncoding(0).GetBytes(PasswordBox.Text)[i - 1];

                    for (int i = 1; i < hex.Length; i++)
                    {
                        hex[i] += hex[i - 1];
                    }
                    insertPass(codPass(hex), SelectTypePassBox.SelectedIndex + 1);
                    break;

                case 2 or 3:
                    hex = BitConverter.GetBytes(Convert.ToUInt64(PasswordBox.Text,16));
                    insertPass(Encoding.GetEncoding(0).GetChars(new byte[] { 0x1 })[0].ToString() + codPass(hex), SelectTypePassBox.SelectedIndex + 1);
                    break;
            }

        }


        private void insertPass(string pass, int typePass)
        {
            if ((userlist.Items.Count > 0))
            {
                SqlCommand command;
                command = new SqlCommand("select coalesce(max(ID) + 1, 1) from pMark", Settings.sqlConnection);
                string passID = command.ExecuteScalar().ToString();
                command = new SqlCommand("select ID from Groups where Name = @name", sqlConnection);
                command.Parameters.AddWithValue("name", PermBox.Text);
                int PermID = (int)command.ExecuteScalar();
                string name;
                Random rand = new Random();
                name = userlist.Text;
                string owner = "";
                owner = name.Remove(0, name.LastIndexOf("(") + 1);
                owner = owner.Remove(owner.Length - 1, 1);
                int[] config = passConfig();
                command = new SqlCommand("insert pMark values (@ID, @typeP, 0, @conf, @key, @key2, @conf2, @owner, @name, 1, @PermID, @ds, @de, 0, NULL, NULL, 1, NULL, NULL)", Settings.sqlConnection);
                command.Parameters.AddWithValue("ID", passID);
                command.Parameters.AddWithValue("typeP", typePass);
                command.Parameters.AddWithValue("conf", config[0]);
                command.Parameters.AddWithValue("key", pass);
                command.Parameters.AddWithValue("key2", "ю");
                command.Parameters.AddWithValue("conf2", config[1]);
                command.Parameters.AddWithValue("owner", owner);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("PermID", PermID);
                command.Parameters.AddWithValue("ds", "22.07.2020 0:00:00");
                command.Parameters.AddWithValue("de", "22.07.2031 23:59:59");
                //command.Parameters.AddWithValue("pc", "DEMO-12");
                command.ExecuteScalar();
            }
        }

        //DELETE FUNCTIONS-----------------------------------------------------------------------------------------------

        //Функция удаления строк вручную
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (updtab.CurrentRow != null)
            {
                SqlCommand command;
                string[] DelID;
                int i = 0;
                int count = 0;

                DelID = new string[updtab.SelectedRows.Count];
                while (i < updtab.SelectedRows.Count)
                {
                    if (updtab.SelectedRows[i].Cells[0].Value != null)
                    {
                        DelID[i] = updtab.SelectedRows[i].Cells[0].Value.ToString();
                    }
                    i++;
                }
                count = updtab.SelectedRows.Count;
                
                
                switch (TabSelect.SelectedIndex)
                {
                    case 0:
                        for (i = 0; i < count; i++)
                        {
                            if (DelID[i] != null)
                            {
                                command = new SqlCommand($"delete from devitems where computerID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete r from Comports c join rslines r on c.id = r.comportID where c.computerID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from comports where computerID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from comps where ID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        }
                        break;

                    case 1:
                        for (i = 0; i < count; i++)
                        {
                            if (DelID[i] != null)
                            {
                                command = new SqlCommand($"delete d from RsLines as r inner join DevItems as d on r.id = d.deviceID where r.comportID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from RSLines where comportID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from comports where ID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        }
                        break;

                    case 2:
                        for (i = 0; i < count; i++)
                        {
                            if (DelID[i] != null)
                            {
                                command = new SqlCommand($"delete from DevItems where DeviceID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from RSLines where ID = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        }
                        break;
                    case 3:
                        for (i = 0; i < count; i++)
                        {
                            if (DelID[i] != null)
                            {
                                command = new SqlCommand($"delete from pmark where owner = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();

                                command = new SqlCommand($"delete from plist where id = {DelID[i]}", sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        }
                        break;

                }
                UpdateTab();
            }
            else
            {
                MessageBox.Show("Не выбрана строка удаления, либо выбрана пустая строка.");
            }
        }
        
        //---------------------------------------------------------------------------------------------------------------
    }
}
