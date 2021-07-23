using System;
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


namespace SQLDrv
{
    

    public partial class SQLDEVICE : Form
    {
        public static SqlConnection sqlConnection = null;
        public static int formstyle = 0;

        public SQLDEVICE()
        {
            InitializeComponent();
        }




        private void BDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            
        }

        private void TypeSettings_Click(object sender, EventArgs e)
        {
            Settings form1 = new Settings();

            if (sqlConnection.State == ConnectionState.Open)
            {
               formstyle = 0; form1.ShowDialog();
            }  
            else MessageBox.Show("Нет соединения с БД");
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SQLDEVICE_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            BDList.Items.Add(sqlConnection.ConnectionString);
        }

        private void SQLDEVICE_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection.Close();
        }
    }



}