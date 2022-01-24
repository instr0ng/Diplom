using System;
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
        public static SqlConnection sqlConnection = null;

        string currtab = null;
        string compID = "", RSTypeID = "", RScompID = "", ComID = "", RSParID = "0";

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
                    Insert(currtab, CompIDBox.Text, CompIDBox.Text, CompNameBox.Text, Gtype.ToString(), CompIPBox.Text);
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

                    Insert(currtab, ComIDBox.Text, compID, ComNumBox.Text, ComAdaptorBox.SelectedIndex.ToString(), "3", (ComTypeBox.SelectedIndex + 1).ToString(), "1", ComIPBox.Text, ComBaudBox.Text);
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

                    Insert(currtab, RSIDBox.Text, RSIDBox.Text, ComID, RSParID, RSAddressBox.Text, /*интерфейс зависит от типа порта,*/ RSTypeBox.Text + " (" + RSAddressBox.Text + ")", RSIPBox.Text, RSTypeID);
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
                    Insert(currtab, ClID.Text, ClNameBox.Text, ClFirstNameBox.Text, ClMidNameBox.Text, (ClStatusBox.SelectedIndex + 1).ToString(), ClTabID.Text, DateTime.Now.ToString());
                    UpdTextBoxes(ComAutoID, ComIDBox);
                    break;

                case "AccessZone":
                    if ((AZID.Text == "") || (AZNum.Text == "") || (AZName.Text == ""))
                    {
                        MessageBox.Show("Заполнены не все обязательные поля");
                        break;
                    }
                    Insert(currtab, AZID.Text, AZName.Text, AZNum.Text);
                    UpdTextBoxes(AZIDAuto, AZID);
                    UpdTextBoxes(AZNumAuto, AZNum);
                    break;

                case "AcessPoint":
                    if (DoorMode.Text == "вход/выход")
                    {
                        if ((InKey.Text == "") || (OutKey.Text == ""))
                        {
                            MessageBox.Show("Заполнены не все обязательные поля!");
                            break;
                        }

                        command = new SqlCommand($"select computerID from devitems where name = '{InKey.Text}'", sqlConnection);
                        string ik = command.ExecuteScalar().ToString();

                        command = new SqlCommand($"select computerID from devitems where name = '{OutKey.Text}'", sqlConnection);
                        string ok = command.ExecuteScalar().ToString();

                        if (ik != ok)
                        {
                            MessageBox.Show("Реле на вход и выход с различных компьютеров. Введите реле с одного компьютера");
                            break;
                        }

                        if ((InKey.Text.Contains("Реле 2")) || (OutKey.Text.Contains("Реле 2")))
                        {
                            MessageBox.Show("Дверь с режимом вход/выход не может открывать реле 2!");
                            break;
                        }

                        if (l1.Text.Contains("BIOAccess") || l2.Text.Contains("BIOAccess"))
                        {
                            MessageBox.Show("прибор BIOAccess не предназначин для управления двумя дверьми!");
                            break;
                        }
                    }
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

                    case "AZ":
                        if (text.AccessibleName == "AZID")
                        {
                            command = new SqlCommand("select coalesce(max(ID)+1, 1) from AccessZone", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }
                        if (text.AccessibleName == "AZNum")
                        {
                            command = new SqlCommand("select coalesce(max(Gindex)+1, 1) from AccessZone", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }
                        break;

                    case "AP":
                        if (text.AccessibleName == "APID")
                        {
                            command = new SqlCommand("select coalesce(max(ID)+1, 1) from AcessPoint", sqlConnection);
                            text.Text = command.ExecuteScalar().ToString();
                            text.Enabled = false;
                        }
                        if (text.AccessibleName == "APNum")
                        {
                            command = new SqlCommand("select coalesce(max(Gindex)+1, 1) from AcessPoint", sqlConnection);
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
            else
                AutoAddr.Enabled = true;
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
                            case "PCID":
                                ///////////////////////////////////////////////////////////////////
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
                                
                                ///////////////////////////////////////////////////////////////////
                                break;

                            case "PORTID":
                                //////////////////////////////////////////////////////////////////
                                box[i].Items.Clear();
                                box[i].Text = "";

                                command = new SqlCommand($"select cp.porttype, cp.Number from comps c join comports cp on c.id = cp.computerID where c.name = '{RSPCBox.Text}'", sqlConnection);  /*RSInterfaceBox.SelectedIndex + 1 получать список портов и по ним определять приборы которые могут быть на этом порте */
                                read = command.ExecuteReader();
                                while (read.Read())
                                {
                                    if (read.GetValue(0).ToString() == "1")
                                    {
                                        box[i].Items.Add("COM " + read.GetValue(1).ToString());
                                    }
                                    else
                                    {
                                        box[i].Items.Add("LAN " + read.GetValue(1).ToString());
                                    }
                                }
                                read.Close();
                                ///////////////////////////////////////////////////////////
                                break;

                            case "PARID":

                                command = new SqlCommand($"select cp.ID from comps c join comports cp on c.id = cp.computerID where c.name = '{RSPCBox.Text}' and cp.number = '{RSPortBox.Text[4..]}'", sqlConnection);
                                buf = command.ExecuteScalar().ToString();

                                box[i].Items.Clear();
                                box[i].Text = "";
                                box[i].Items.Add("");
                                command = new SqlCommand($"select name from rslines where comportID = {buf}", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                read.Close();
                                break;

                            case "TYPEID":
                                ///////////////////////////////////////////////////////////////////
                                
                                    box[i].Items.Clear();
                                    box[i].Text = "";
                                    command = new SqlCommand($"select coalesce(b.name + ' ' + b.DeviceVersionStr, b.name) as dev from protocoldevices a inner join interfaceprotocol v on (v.protocol_id = a.protocol_id) inner join dTypesElement b on (a.device_type_id = b.Id) and(elementtype = 4) and v.interface_id = (select PortType from ComPorts where ID = {buf})", sqlConnection);
                                    read = command.ExecuteReader();
                                    while (read.Read())
                                    {
                                        box[i].Items.Add(read.GetValue(0).ToString());
                                    }
                                    read.Close();
                                    box[i].SelectedIndex = 0;
                                
                                ////////////////////////////////////////////////////////////////////
                                break;
                        }
                        break;

                    case "APoint":
                        switch (box[i].AccessibleName)
                        {
                            case "DoorType":
                                if (box[i].SelectedIndex == -1)
                                    box[i].SelectedIndex = 0;

                                if (box[i].SelectedIndex == 0)
                                {
                                    box[i+1].Items.Clear();
                                    box[i + 1].Items.Add("Проход");
                                    box[i + 1].Items.Add("Вход");
                                    box[i + 1].Items.Add("Выход");
                                }
                                else
                                {
                                    box[i + 1].Items.Clear();
                                    box[i + 1].Items.Add("Проход");
                                    box[i + 1].Items.Add("Вход");
                                    box[i + 1].Items.Add("Выход");
                                    box[i + 1].Items.Add("Вход/Выход");
                                }
                                box[i + 1].SelectedIndex = 1;
                                break;

                            case "DoorMode":
                                switch (box[i].SelectedIndex)
                                {
                                    case 0:
                                        box[i + 1].Visible = false;
                                        label33.Visible = false;
                                        box[i + 2].Visible = false;
                                        label34.Visible = false;
                                        box[i + 3].Visible = true;
                                        label35.Visible = true;
                                        box[i + 4].Visible = false;
                                        label36.Visible = false;
                                        break;

                                    case 1:
                                        box[i + 1].Visible = true;
                                        label33.Visible = true;
                                        box[i + 2].Visible = false;
                                        label34.Visible = false;
                                        box[i + 3].Visible = true;
                                        label35.Visible = true;
                                        box[i + 4].Visible = false;
                                        label36.Visible = false;
                                        break;

                                    case 2:
                                        box[i + 1].Visible = false;
                                        label33.Visible = false;
                                        box[i + 2].Visible = true;
                                        label34.Visible = true;
                                        box[i + 3].Visible = false;
                                        label35.Visible = false;
                                        box[i + 4].Visible = true;
                                        label36.Visible = true;
                                        break;

                                    case 3:
                                        box[i + 1].Visible = true;
                                        label33.Visible = true;
                                        box[i + 2].Visible = true;
                                        label34.Visible = true;
                                        box[i + 3].Visible = true;
                                        label35.Visible = true;
                                        box[i + 4].Visible = true;
                                        label36.Visible = true;
                                        break;
                                }
                                box[i + 1].Items.Clear();
                                box[i + 2].Items.Clear();
                                box[i + 3].SelectedIndex = -1;
                                box[i + 4].SelectedIndex = -1;
                                break;

                            case "AZoneIn":
                                box[i].Items.Clear();
                                box[i].Items.Add(" ");
                                command = new SqlCommand("Select name from AccessZone", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                read.Close();
                                break;

                            case "AZoneOut":
                                box[i].Items.Clear();
                                box[i].Items.Add("");
                                command = new SqlCommand("Select name from AccessZone", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                read.Close();
                                break;

                            case "InKey":
                                box[i].Items.Clear();
                                box[i].Items.Add(" ");
                                
                                command = new SqlCommand("Select d.name from DevItems d join rslines r on d.deviceid = r.id where ItemType = 9 and ((r.devicetype = 16 or (r.devicetype = 4 and d.name like '%Реле 1%') or r.devicetype = 257 or r.devicetype = 258 or r.devicetype = 259 or r.devicetype = 261 or r.devicetype = 262) and d.id not in (select InKeyID from AcessPoint) and d.id not in (select OutKeyID from AcessPoint))", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                read.Close();
                                break;

                            case "OutKey":
                                box[i].Items.Clear();
                                box[i].Items.Add("");
                                command = new SqlCommand("Select d.name from DevItems d join rslines r on d.deviceid = r.id where ItemType = 9 and ((r.devicetype = 16 or (r.devicetype = 4 and d.name like '%Реле 1%') or r.devicetype = 257 or r.devicetype = 258 or r.devicetype = 259 or r.devicetype = 261 or r.devicetype = 262) and d.id not in (select InKeyID from AcessPoint) and d.id not in (select OutKeyID from AcessPoint))", sqlConnection);
                                read = command.ExecuteReader();
                                while (read.Read())
                                    box[i].Items.Add(read.GetValue(0).ToString());
                                read.Close();
                                break;
                        }
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
                        UpdComboBoxes(/*RSInterfaceBox, поменять порядок боксов*/ RSPCBox, RSPortBox);
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
                    currtab = "AccessZone";
                    break;

                case 5:
                    currtab = "AcessPoint";
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        UpdTextBoxes(APAutoID, APID);
                        UpdTextBoxes(APNumAuto, APNum);
                        UpdComboBoxes(DoorType, DoorMode, AZoneIn, AZoneOut, InKey, OutKey);
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

        //FUNCTIONS-----------------------------------------------------------------

        private void Insert(string table, params string[] args) // Comps - ID, GIndex, Name, GType, IP;
                                                                // ComPorts - ID, ComputerID, Number, Adaptor, PrAdaptor, PortType, ProtocolType, IP, Baud
                                                                // RSLines - ID, GIndex, ComPortID, PKUID, GLineNo, DeviceInterface, Name, type
                                                                // DevItems - ID, ComputerID, DeviceID, Address, Gindex, ItemType, Name
                                                                // pList - ID, Name, FirstName, MidName, status, Schedule, TabNumber, ChangeTime
                                                                // AccessZone - ID, Name, Gindex
                                                                // AcessPoint - ID, ComputerID, Name, Gindex, Gtype, InKeyID, OutKeyID, OutCommand, Mode, IndexZone1, IndexZone2
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

                case "AccessZone":
                    try
                    {
                        command = new SqlCommand($"insert AccessZone (ID, Name, Gindex) values ({args[0]}, '{args[1]}', '{args[2]}')", sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Введены неккоректные или повторяющиеся данные" + '\n' + '\n' + exception.Message);
                    }
                    break;

                case "AcessPoint":
                    try
                    {
                        command = new SqlCommand($"insert AcessPoint (ID, ComputerID, Name, Gindex, Gtype, InKeyID, OutKeyID, OutCommand, Mode, IndexZone1, IndexZone2) values ({args[0]}, '{args[1]}', '{args[2]}', '{args[3]}', '{args[4]}', '{args[5]}', '{args[6]}', '{args[7]}', '{args[8]}', '{args[9]}', '{args[10]}')", sqlConnection);
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
                UpdComboBoxes(RSPortBox);
        }

        private void RSPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(RSParentBox, RSTypeBox );
        }

        private void CompAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            for (int i = 0; i < 8; i++)
                CompCB.SetItemChecked(i, box.Checked);
        }

        private void AZIDAuto_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(AZIDAuto, AZID);
        }

        private void AZNumAuto_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(AZNumAuto, AZNum);
        }

        private void APAutoID_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(APAutoID, APID);
        }

        private void APNumAuto_CheckedChanged(object sender, EventArgs e)
        {
            UpdTextBoxes(APNumAuto, APNum);
        }

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

        private void DoorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(DoorType, DoorMode, AZoneIn, AZoneOut, InKey, OutKey);
        }

        private void DoorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(DoorMode, AZoneIn, AZoneOut, InKey, OutKey);
        }

        private void AZoneIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(AZoneOut);
        }

        private void AZoneOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.Focused)
                UpdComboBoxes(AZoneIn);
        }

        private void InKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InKey.Text != "")
            {
                SqlCommand command = new SqlCommand($"select r.name from Rslines r join DevItems d on r.id = d.deviceID where d.name = '{InKey.Text}'", sqlConnection);
                l1.Text = command.ExecuteScalar().ToString();
            }
            else
                l1.Text = "";
        }

        private void OutKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OutKey.Text != "")
            {
                SqlCommand command = new SqlCommand($"select r.name from Rslines r join DevItems d on r.id = d.deviceID where d.name = '{OutKey.Text}'", sqlConnection);
                l2.Text = command.ExecuteScalar().ToString();
            }
            else
                l2.Text = "";

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
                    UpdComboBoxes(RSPCBox, RSPortBox, RSParentBox, RSTypeBox/*, поправить порядок RSInterfaceBox*/);
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

                    case 4:
                        for (i = 0; i < count; i++)
                        {
                            command = new SqlCommand($"delete from AccessZone where ID = {DelID[i]}", sqlConnection);
                            command.ExecuteNonQuery();
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
    }
}