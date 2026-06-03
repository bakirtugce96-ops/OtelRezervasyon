using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otelRezervasyon1
{
    public partial class Form2 : Form
    {
        otelRezervasyon1Context db = new otelRezervasyon1Context();

        public Form2()
        {
            InitializeComponent();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Table_Guest.ToList();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            var guest = new Table_Guest
            {
                Guest_Name = txt_isim.Text,
                Guest_Surname = txt_soyisim.Text,
                Guest_Phone = txt_telefon.Text,
                Guest_Email = txt_email.Text
            };
            db.Table_Guest.Add(guest);
            db.SaveChanges();
            MessageBox.Show("Misafir eklendi!");
            btn_listele.PerformClick();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_isim.Text = dataGridView1.Rows[e.RowIndex].Cells["Guest_Name"].Value.ToString();
                txt_soyisim.Text = dataGridView1.Rows[e.RowIndex].Cells["Guest_Surname"].Value.ToString();
                txt_telefon.Text = dataGridView1.Rows[e.RowIndex].Cells["Guest_Phone"].Value.ToString();
                txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells["Guest_Email"].Value.ToString();
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Guest_Id"].Value);

                using (var db2 = new otelRezervasyon1Context())
                {
                    Table_Guest g = db2.Table_Guest.Find(id);
                    if (g != null)
                    {
                        
                        g.Guest_Name = txt_isim.Text;
                        g.Guest_Surname = txt_soyisim.Text;
                        g.Guest_Phone = txt_telefon.Text;
                        g.Guest_Email = txt_email.Text;

                        
                        db2.SaveChanges();
                        MessageBox.Show("Güncellendi!");

                        
                        dataGridView1.CurrentRow.Cells["Guest_Name"].Value = txt_isim.Text;
                        dataGridView1.CurrentRow.Cells["Guest_Surname"].Value = txt_soyisim.Text;
                        dataGridView1.CurrentRow.Cells["Guest_Phone"].Value = txt_telefon.Text;
                        dataGridView1.CurrentRow.Cells["Guest_Email"].Value = txt_email.Text;

                        
                        btn_listele.PerformClick();
                        Temizle();
                    }
                }
            }
        }


        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var onay = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Guest_Id"].Value);
                    Table_Guest g = db.Table_Guest.Find(id);
                    db.Table_Guest.Remove(g);
                    db.SaveChanges();
                    btn_listele.PerformClick();
                    Temizle();
                }
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Temizle()
        {
            txt_isim.Text = "";
            txt_soyisim.Text = "";
            txt_telefon.Text = "";
            txt_email.Text = "";
        }

        private void txt_telefon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}