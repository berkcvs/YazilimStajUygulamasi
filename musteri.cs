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
    public partial class musteri : Form
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=veritabani.mdb");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter adptr = new OleDbDataAdapter();
        public DataSet dataset = new DataSet();
        public DataTable dt = new DataTable();
        int toplam;
        int toplam2;
        int kull;
        public musteri()
        {

            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (kuladi.Text == "" || adi2.Text == "" || soyadi2.Text == "" || telefon2.Text == "" || adres2.Text == "")
            {
                MessageBox.Show("Her Alanı Doladurun !");
            }
            else
            {

                try
                {
                    using (OleDbConnection conn2 = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=veritabani.mdb"))
                    {
                        conn2.Open();
                        OleDbCommand sorgu = new OleDbCommand("insert into musteri (kadi,adi,soyadi,telefon,adres) VALUES (?,?,?,?,?)", conn2);
                        sorgu.Parameters.AddWithValue("kadi", kuladi.Text);
                        sorgu.Parameters.AddWithValue("adi", adi2.Text);
                        sorgu.Parameters.AddWithValue("soyadi", soyadi2.Text);
                        sorgu.Parameters.AddWithValue("telefon", telefon2.Text);
                        sorgu.Parameters.AddWithValue("adres", adres2.Text);

                        sorgu.ExecuteNonQuery();
                        conn2.Close();
                        this.musteriTableAdapter.Fill(this.veritabaniDataSet.musteri);




                    }
                    MessageBox.Show("YENİ KAYIT EKLENDİ", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam2 = Convert.ToInt32(dataGridView1.Rows.Count);

            }
            toplam = Convert.ToInt32(toplam2) + 1;
            kuladi.Text = Convert.ToString(toplam);
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void musteri_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'veritabaniDataSet.musteri' table. You can move, or remove it, as needed.
            this.musteriTableAdapter.Fill(this.veritabaniDataSet.musteri);
            conn.Open();
            OleDbCommand komut = new OleDbCommand("Select MAX(kadi) From musteri", conn);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                toplam = Convert.ToInt32(dr[0].ToString());
            }
            kull = toplam + 1;
            kuladi.Text = Convert.ToString(kull);
            conn.Close();
            
          /*  for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam2 = Convert.ToInt32(dataGridView1.Rows.Count);

            }
            toplam = Convert.ToInt32(toplam2) + 1; */
          
          
            

            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("delete from musteri where kadi=@id", conn);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.musteriTableAdapter.Fill(this.veritabaniDataSet.musteri);
     
        }

        private void musteriBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("delete from musteri where kadi=@id", conn);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.musteriTableAdapter.Fill(this.veritabaniDataSet.musteri);
            this.Refresh();
            conn.Open();
            OleDbCommand komut = new OleDbCommand("Select MAX(kadi) From musteri", conn);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                toplam = Convert.ToInt32(dr[0].ToString());
            }
            kull = toplam + 1;
            kuladi.Text = Convert.ToString(kull);
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select kadi,adi,soyadi,telefon,adres From musteri where kadi ='" + Convert.ToString(aramaBox.Text) + "'", conn);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
          
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand komut = new OleDbCommand("Select MAX(kadi) From musteri", conn);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                toplam = Convert.ToInt32(dr[0].ToString());
            }
            kull = toplam + 1;
            kuladi.Text = Convert.ToString(kull);
            conn.Close();
            
 

        }

        private void adi2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void soyadi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void telefon2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void adres2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void aramaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        
        
    }
}
