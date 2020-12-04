using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Collections;

namespace Satış
{
    public partial class sorgula : Form
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=veritabani.mdb");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter adptr = new OleDbDataAdapter();
        public DataSet dataset = new DataSet();
        bool a = true;
     
        
        public sorgula()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

           
           OleDbCommand kaydetcmd = new OleDbCommand(); 
           conn.Open();
           kaydetcmd.CommandText = "select * from musteri where kadi='1111'";
            kaydetcmd.Connection = conn;
            OleDbDataReader oku = kaydetcmd.ExecuteReader();          

            
            if(oku.Read()){
                a = true;
               
            }
                else {
                a = false;
        }
            
            if (a == false)
            {
                MessageBox.Show("Böyle bir müşteri yok");
                conn.Close();
            }
            else
            {

               


            }
           
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sorgula_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
