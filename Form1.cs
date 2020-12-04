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
    public partial class Form1 : Form
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=veritabani.mdb");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter adptr = new OleDbDataAdapter();
        public DataSet dataset = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siparisver frm1 = new siparisver();
            frm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri frm = new musteri();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gunluk frm = new gunluk();
            frm.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
