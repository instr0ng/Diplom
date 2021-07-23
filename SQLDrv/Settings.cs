using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.ComponentModel;
using Microsoft.Win32;

namespace SQLDrv
{
    public partial class Settings : Form
    {
        public static SqlConnection sqlConnection = null;
        string datapath = "C:/ORIONBASE/MSDE2012";

        Server server;

        string currtab = null;
        string compID = "", RSTypeID = "", RScompID = "", ComID = "", RSParID = "0";
        
       
        public Settings()
        {
            InitializeComponent();
        }

        private string UPDDataPath(string datapath) 
        {
            var s = datapath.ToCharArray();
            var data = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '/')
                    s[i] = @"\"[0];
                data += s[i];
            }
            return data;
        }

        public void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                //MessageBox.Show(result);
                // Display the command output.
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }


        private string GetServerName()
        {
            RegistryKey LocalMachineRegKey;
            LocalMachineRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Bolid\ORION\CSO\DBPARAMS12");

            string server_name = (string)LocalMachineRegKey.GetValue("SERVER NAME");
            return server_name;
        }

        private string GetDbName()
        {
            RegistryKey LocalMachineRegKey;
            LocalMachineRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Bolid\ORION\CSO\DBPARAMS12");

            string DB_name = (string)LocalMachineRegKey.GetValue("DATABASE NAME");
            return DB_name;
        }

        private void BDList_TextChanged(object sender, EventArgs e) //{UPDDataPath(datapath)}\
        {
           
        }

        private void StartConnection()
        {
            var connectionString = $@"User ID= sa;Password = 123456;Initial Catalog={GetDbName()};Data Source={GetServerName()}"; //new
            //MessageBox.Show(connectionString);
            // Console.Read("sqllocaldb.exe stop MSSQLLocalDB");
            ExecuteCommandSync("sqllocaldb.exe stop MSSQLLocalDB");


            //System.Diagnostics.Process.Start("cmd.exe", "/C sqllocaldb.exe stop MSSQLLocalDB");



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


                TestBT.Enabled = true;
                TabSelect.Enabled = true;
                InsertBtn.Enabled = true;
                UpdateBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                dataGridView1.Enabled = true;
                AutoSettings.Enabled = true;
                currtab = "comps";

                UpdateTab();
            }
        }


        public void Settings_Load(object sender, EventArgs e)
        {
            var i = 0;
            if (Directory.Exists(datapath))
                while (i < Directory.GetFiles(datapath, "*.mdf").Length)
                {
                    BDList.Items.Add(Directory.GetFiles(datapath, "*.mdf")[i].Remove(0, Directory.GetFiles(datapath, "*.mdf")[i].LastIndexOf(@"\") + 1));
                    i++;
                }

            
        }



        //DATABASES-----------------------------------------------------------------------------------------------------------------





        private void PathDB_Click(object sender, EventArgs e)
        {
            BDList.Items.Clear();
            FolderDialog.ShowDialog();
            datapath = FolderDialog.SelectedPath;
            var i = 0;
            var name = "";

            if (datapath != "")
                while (i < Directory.GetFiles(datapath, "*.mdf").Length)
                {
                    name = Directory.GetFiles(datapath, "*.mdf")[i].Remove(0, Directory.GetFiles(datapath, "*.mdf")[i].LastIndexOf(@"\") + 1);
                    BDList.Items.Add(name);
                    i++;
                }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------






        private void CompAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            for (int i = 0; i < 8; i++)
                CompCB.SetItemChecked(i, box.Checked);
        }

        private void INSBtn_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            switch (currtab)
            {

                case "comps":

                    if ((CompIDBox.Text == "") || (CompIPBox.Text == ""))
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

                    if ((ComIDBox.Text == "") || (ComIPBox.Text == ""))
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

                    if ((RSIDBox.Text == "") || (RSIPBox.Text == "") || (RSAddressBox.Text == ""))
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
                   
            }


            

            // Обновление таблицы справа
            UpdateTab();
        }

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
                                while (text.Text.Remove(7, text.Text.Length-7) != "192.168")    //text.Text.Remove(7, text.Text.Length - 7) != "192.168"
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

                        if (text.AccessibleName == "RSIP")
                        {
                            text.Text = "127.0.0.1";
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
        }


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
                                if (box[i].Items.Count == 0)
                                {
                                    box[i].Items.Clear();
                                    box[i].Text = "";

                                    command = new SqlCommand("select name from Comps", sqlConnection);
                                    read = command.ExecuteReader();
                                    while (read.Read())
                                    {
                                        box[i].Items.Add(read.GetValue(0).ToString());
                                    }
                                    read.Close();

                                    box[i].SelectedIndex = box[i].Items.Count - 1;
                                }
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
                                if (box[i].Items.Count == 0)
                                {
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

                                    if (box[i].Text == "")
                                        box[i].SelectedIndex = box[i].Items.Count - 1;
                                    
                                }
                                if (box[i].SelectedIndex > -1)
                                    buf = box[i].Text;

                                if (!box[i + 1].Focused)
                                    box[i + 1].Items.Clear();

                                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                                break;
                            case "PORTID":
                                ///////////////////////////////////////////////////////////////////////
                                if (box[i].Items.Count == 0)
                                    if ((box[i - 1].SelectedIndex > -1)&& (buf != "-"))
                                    {
                                        //MessageBox.Show(buf);
                                        box[i].Text = "";
                                        command = new SqlCommand($"select cp.Number from comps c join comports cp on c.id = cp.computerID where c.name = '{buf}'", sqlConnection);
                                        read = command.ExecuteReader();
                                        while (read.Read())
                                            box[i].Items.Add("COM" + read.GetValue(0).ToString());
                                        read.Close();
                                        if (!box[i].Focused)
                                            box[i].SelectedIndex = box[i].Items.Count - 1;
                                    }
                                //MessageBox.Show(box[i].SelectedIndex.ToString());
                                if ((box[i].SelectedIndex > -1) && (buf != "-") && (buf != null))
                                {
                                    command = new SqlCommand($"select cp.ID from comps c join comports cp on c.id = cp.computerID where c.name = '{buf}' and number = {box[i].Text.Remove(0, 3)}", sqlConnection);
                                    //MessageBox.Show(command.CommandText);
                                    buf = command.ExecuteScalar().ToString();
                                }

                                box[i + 1].Items.Clear();
                                box[i + 1].Text = "";

                                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                                break;
                            case "PARID":
                                if ((box[i - 1].SelectedIndex > -1)&&(buf != "-"))
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
                }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            switch (TabSelect.SelectedIndex)
            {
                case 0:
                    SqlCommand command;
                    string DelcompID=dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    command = new SqlCommand($"delete from devitems where computerID = {DelcompID}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete r from Comports c join rslines r on c.id = r.comportID where c.computerID = {DelcompID}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete from comports where computerID = {DelcompID}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete from comps where ID = {DelcompID}", sqlConnection);
                    command.ExecuteNonQuery();
                    break;

                case 1:

                    string delportID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    command = new SqlCommand($"delete d from RsLines as r inner join DevItems as d on r.id = d.deviceID where r.comportID = {delportID}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete from RSLines where comportID = {delportID}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete from comports where ID = {delportID}", sqlConnection);
                    command.ExecuteNonQuery();
                    break;

                case 2:
                    string delRS = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    command = new SqlCommand($"delete from DevItems where DeviceID = {delRS}", sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"delete from RSLines where ID = {delRS}D", sqlConnection);
                    command.ExecuteNonQuery();
                    break;
            
            
            
            }
            UpdateTab();
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
                        UpdComboBoxes(ComPCIDBox, ComNumBox, ComAdaptorBox, ComTypeBox, ComBaudBox);
                    }
                    break;
                case 2:
                    currtab = "rslines";
                    if (sqlConnection.State == ConnectionState.Open)
                    {

                        UpdComboBoxes(RSPCBox, RSPortBox, RSParentBox, RSTypeBox, RSInterfaceBox);
                    }
                    break;
            }
            UpdateTab();
        }



        //RSLINES-------------------------------------------------------------------


        private void TestBT_Click(object sender, EventArgs e)
        {
            Form Test = new Test();
            Test.Show();
        }


        //------------------------------------------------------------------------------


        //FUNCTIONS-----------------------------------------------------------------------------------------------


        private void Insert(string table, params string[] args) // Comps - ID, GIndex, Name, GType, IP;
                                                                // ComPorts - ID, ComputerID, Number, Adaptor, PrAdaptor, PortType, ProtocolType, IP, Baud
                                                                // RSLines - ID, GIndex, ComPortID, PKUID, GLineNo, DeviceInterface, Name, type
                                                                // DevItems - ID, ComputerID, DeviceID, Address, Gindex, ItemType, Name
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
            }
        }

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

        private void ConnState_Click(object sender, EventArgs e)
        {
            StartConnection();
        }

        private string Select(string table, string column, string where) 
        {
            SqlCommand command;
            command = new SqlCommand($"select { column } from { table } where { where}", sqlConnection);
            return command.ExecuteScalar().ToString();
        }

        private void UpdateTab()
        {
            SqlCommand table = new SqlCommand($"select * from {currtab}", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = table;
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "name");
            dataGridView1.DataSource = ds.Tables["name"].DefaultView;
        }

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

        //private void UpdatePage()
        //{
        //    SqlCommand command;
        //    SqlDataReader read = null;
        //    RSTypeID = null;
        //}

        //---------------------------------------------------------------------------------------------------------------

        //DELETE FUNCTIONS-----------------------------------------------------------------------------------------------

        private void DeleteRS(string portID, string compID)
        {
            
        }


        //---------------------------------------------------------------------------------------------------------------
    }
}
