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
    public partial class siparisver : Form
    {
        bool a = true;
        
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=veritabani.mdb");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter adptr = new OleDbDataAdapter();
        public DataSet dataset = new DataSet();
        public DataTable dt = new DataTable();
        double boyuttutar;
        double turtutar;
        double adet;
        double tutar;
        public string mno;
        public siparisver()
        {
            InitializeComponent();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {     
        }

        private void siparisver_Load(object sender, EventArgs e)
        {

            
          
            


            conn.Open();
            OleDbCommand komut = new OleDbCommand("Select * from turu", conn); // sorgumuzu yazıyoruz.
            OleDbDataReader dr = komut.ExecuteReader();
           
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1].ToString());
                
            }
            conn.Close();
            conn.Open();
            OleDbCommand cot = new OleDbCommand("Select * from boyut", conn); // sorgumuzu yazıyoruz.
            OleDbDataReader dr2 = cot.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[1].ToString());
            }
            conn.Close();
            //conn.Open();
           // adptr = new OleDbDataAdapter("Select * From siparis", conn);
            //dt = new DataTable("siparis");
            //adptr.Fill(dt);
            //conn.Close();
            
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          //  dataGridView1.DataSource = dt;
            
           
            if (a==false || tutarbox.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || tutarbox.Text == null || comboBox3.SelectedItem == null )
            {
                MessageBox.Show("Alanları Boş Bırakmayınız");
            }
            else
            {
                try
                {
                    using (OleDbConnection conn2 = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=veritabani.mdb"))
                    {
                        conn2.Open();
                        OleDbCommand sorgu = new OleDbCommand("insert into siparis (kadi,adi,soyadi,turu,boyut,adet,tutar,tarih) VALUES (?,?,?,?,?,?,?,?)", conn2);
                        
                        sorgu.Parameters.AddWithValue("kadi", Convert.ToString(textBox1.Text));
                        sorgu.Parameters.AddWithValue("adi", Convert.ToString(adisoyadibox.Text));
                        sorgu.Parameters.AddWithValue("soyadi", Convert.ToString(soyadibox.Text));                
                        sorgu.Parameters.AddWithValue("turu", Convert.ToString(comboBox2.SelectedItem));
                        sorgu.Parameters.AddWithValue("boyut", Convert.ToString(comboBox1.SelectedItem));
                        sorgu.Parameters.AddWithValue("adet", Convert.ToInt32(comboBox3.SelectedItem));
                        sorgu.Parameters.AddWithValue("tutar", Convert.ToDouble(tutar.ToString()));
                        sorgu.Parameters.AddWithValue("tarih", Convert.ToString(dateTimePicker1.Text));
                        

                        sorgu.ExecuteNonQuery();
                        conn2.Close();




                    }
                    MessageBox.Show("YENİ KAYIT EKLENDİ", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(adisoyadibox.Text=="" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || tutarbox.Text == null ||  comboBox3.SelectedItem == null){
                MessageBox.Show("Her Alanı Doldurunuz!!");
            }
            else {
            conn.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("Select fiyat from turu where tur = '" +comboBox2.SelectedItem+"'", conn); // sorgumuzu yazıyoruz.
            DataSet dr= new DataSet();
            komut.Fill(dr);
            turtutar = Convert.ToDouble(dr.Tables[0].Rows[0]["fiyat"]);
           
            
            OleDbDataAdapter komut2 = new OleDbDataAdapter("Select fiyat from boyut where boyut = '" +comboBox1.SelectedItem+"'", conn); // sorgumuzu yazıyoruz.
            DataSet dr2= new DataSet();
            komut2.Fill(dr2);
            boyuttutar = Convert.ToDouble(dr2.Tables[0].Rows[0]["fiyat"]);
            conn.Close();
            adet = Convert.ToDouble(comboBox3.SelectedItem);
            tutar = (Convert.ToDouble(boyuttutar) + Convert.ToInt32(turtutar))*Convert.ToDouble(adet);
            tutarbox.Text = tutar+" TL";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            tutarbox.Text = null;
            comboBox3.SelectedItem = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            mno = textBox1.Text;
            OleDbCommand kaydetcmd = new OleDbCommand();
            conn.Open();
            kaydetcmd.CommandText = "select * from musteri where kadi='"+Convert.ToInt32(textBox1.Text)+"'";
            kaydetcmd.Connection = conn;
            OleDbDataReader oku = kaydetcmd.ExecuteReader();


            if (oku.Read())
            {
                a = true;


            }
            else
            {
                a = false;
            }

            if (a == false)
            {
                MessageBox.Show("Böyle bir müşteri yok");
                conn.Close();
            }
            else
            {

                
                OleDbCommand musteri = new OleDbCommand("Select * from musteri where kadi='" + Convert.ToString(textBox1.Text) + "'", conn); // sorgumuzu yazıyoruz.
                OleDbDataReader drmusteri = musteri.ExecuteReader();
                while (drmusteri.Read())
                {
                    adisoyadibox.Text = drmusteri["adi"].ToString();
                    soyadibox.Text = drmusteri["soyadi"].ToString();
                    telefonbox.Text = drmusteri["telefon"].ToString();
                    adresbox.Text = drmusteri["adres"].ToString();
                }
                conn.Close();
                conn.Open();
                dt.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select turu,boyut,adet,tutar,tarih From siparis where kadi ='" + Convert.ToString(textBox1.Text) + "'", conn);
                adtr.Fill(dt);
                dataGridView1.DataSource = dt;
                adtr.Dispose();
                conn.Close();

                             
            }
           
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.siparisTableAdapter.FillBy(this.veritabaniDataSet2.siparis);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.siparisTableAdapter.FillBy1(this.veritabaniDataSet2.siparis);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }    
    }
}
