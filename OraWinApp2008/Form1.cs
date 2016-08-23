using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // C# ODP.NET Oracle managed provider

namespace OraWinApp2008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oradb_2 = "Data Source=(DESCRIPTION="
             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=VALME_29)(PORT=1521)))"
             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=valme29)));"
             + "User Id=INTEGRADORDAE;Password=Verlo$c0n1;";

//            OracleConnection conn = new OracleConnection(oradb_2); // C#
            using (OracleConnection conn = new OracleConnection(oradb_2)) // C#
            {

                conn.Open();

                string sql = "select * from ADM_M_MOTIVO_INGRESO"; // C#
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader(); // C#
                dr.Read();

                label1.Text = dr["DESC_MOTIVO"].ToString(); // C# retrieve by column name
                label1.Text = dr.GetString(1).ToString();  // return a .NET data type
                label1.Text = dr.GetOracleString(1).ToString();  // return an Oracle data type

//                conn.Close();   // C#
//                conn.Dispose(); // C#
            }

        }
    }
}
