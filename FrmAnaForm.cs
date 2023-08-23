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

namespace PersonelKayıt
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LEGEND\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani2;Integrated Security=True");
        void temizle()
        {
            txid.Text = "";
            txad.Text = "";
            txsoyad.Text = "";
            rad1.Checked = false;
            rad2.Checked = false;
            mskmeslek.Text = "";
            cmsehir.Text = "";
            mskmaas.Text = "";
            txad.Focus();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_Personel1TableAdapter.Fill(this.personelVeriTabani2DataSet.Tbl_Personel1);


        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_Personel1TableAdapter.Fill(this.personelVeriTabani2DataSet.Tbl_Personel1);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel1 (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@v1,@v2,@v3,@v4,@v5,@v6)", baglanti);
            komut.Parameters.AddWithValue("@v1", txad.Text);
            komut.Parameters.AddWithValue("@v2", txsoyad.Text);
            komut.Parameters.AddWithValue("@v3", cmsehir.Text);
            komut.Parameters.AddWithValue("@v4", mskmaas.Text);
            komut.Parameters.AddWithValue("@v5", mskmeslek.Text);
            komut.Parameters.AddWithValue("@v6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void rad1_CheckedChanged(object sender, EventArgs e)
        {
            if(rad1.Checked==true)
            label8.Text = "True";

        }

        private void rad2_CheckedChanged(object sender, EventArgs e)
        {
            if(rad2.Checked==true)
            label8.Text = "False";
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txid.Text =     dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txad.Text =     dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txsoyad.Text =  dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmsehir.Text =  dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text =  dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text =   dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            mskmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
           
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                rad1.Checked = true;

            }
            if (label8.Text == "False")
            {
                rad2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel1 where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel1 set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", mskmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Güncellendi.");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
