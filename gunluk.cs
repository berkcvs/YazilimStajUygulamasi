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
    public partial class gunluk : Form
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=veritabani.mdb");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter adptr = new OleDbDataAdapter();
        public DataSet dataset = new DataSet();
        public DataTable dt = new DataTable();
        public gunluk()
        {
            InitializeComponent();
        }

        private void gunluk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabaniDataSet5.siparis' table. You can move, or remove it, as needed.
            this.siparisTableAdapter2.Fill(this.veritabaniDataSet5.siparis);
            // TODO: This line of code loads data into the 'veritabaniDataSet.musteri' table. You can move, or remove it, as needed.
            this.musteriTableAdapter.Fill(this.veritabaniDataSet.musteri);
            // TODO: This line of code loads data into the 'veritabaniDataSet4.siparis' table. You can move, or remove it, as needed.
            this.siparisTableAdapter.Fill(this.veritabaniDataSet1.siparis);
            int toplam = 0;
            int toplamfiyat = 0;
        
            label2.Text = DateTime.Today.ToShortDateString();
           conn.Open();
           dt.Clear();
          OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From siparis where tarih='"+Convert.ToString(label2.Text)+"'", conn);
         adtr.Fill(dt);
        dataGridView1.DataSource = dt;
       adtr.Dispose();
      conn.Close();
      foreach (DataGridViewRow satir in dataGridView1.Rows)
      {
          toplamfiyat = Convert.ToInt32(satir.Cells[6].Value.ToString());
          toplam += toplamfiyat;

      }
      label4.Text = Convert.ToString(toplam) + " TL";
      this.siparisTableAdapter.Fill(this.veritabaniDataSet1.siparis);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
