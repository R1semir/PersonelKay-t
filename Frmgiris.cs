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
    public partial class Frmgiris : Form
    {
        public Frmgiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LEGEND\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani2;Integrated Security=True");
        private void Frmgiris_Load(object sender, EventArgs e)
        {

        }

        private void girisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where Kullaniciad=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@p2", txsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Hatalı Şifre!");
            }
            baglanti.Close();
        }
    }
}
