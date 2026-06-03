using System;
using System.Linq;
using System.Windows.Forms;

namespace otelRezervasyon1
{
    public partial class Form3 : Form
    {
        otelRezervasyon1Context db = new otelRezervasyon1Context();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ComboBoxDoldur();
        }
        private void OdaSayisiniGuncelle()
        {
            int standartSayi = db.Table_Room.Count(r => r.RoomType_Id == 1);
            int deluxeSayi = db.Table_Room.Count(r => r.RoomType_Id == 2);
            int suiteSayi = db.Table_Room.Count(r => r.RoomType_Id == 3);

            lbl_standart.Text = $"Standart: {standartSayi}/25";
            lbl_deluxe.Text = $"Deluxe: {deluxeSayi}/15";
            lbl_suite.Text = $"Suite: {suiteSayi}/10";
        }

        private void ComboBoxDoldur()
        {
            combo_tip.DataSource = db.Table_RoomType.ToList();
            combo_tip.DisplayMember = "RoomType_Name";
            combo_tip.ValueMember = "RoomType_Id";
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Table_Room
                .Select(r => new {
                    r.Room_Id,
                    r.Room_Number,
                    r.Room_Price,
                    RoomType_Adi = r.RoomType.RoomType_Name
                }).ToList();
            OdaSayisiniGuncelle();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            int seciliTipId = (int)combo_tip.SelectedValue;
            string seciliTipAdi = combo_tip.Text;

            
            int mevcutSayi = db.Table_Room.Count(r => r.RoomType_Id == seciliTipId);

            int maksimum = 0;
            if (seciliTipAdi == "Suite") maksimum = 10;
            else if (seciliTipAdi == "Deluxe") maksimum = 15;
            else if (seciliTipAdi == "Standart") maksimum = 25;

            if (mevcutSayi >= maksimum)
            {
                MessageBox.Show($"{seciliTipAdi} tipi için maksimum oda sayısına ({maksimum}) ulaşıldı!");
                return;
            }

            var room = new Table_Room
            {
                Room_Number = txt_oda_no.Text,
                Room_Price = Convert.ToDecimal(txt_fiyat.Text),
                RoomType_Id = seciliTipId
            };
            db.Table_Room.Add(room);
            db.SaveChanges();
            MessageBox.Show("Oda eklendi!");
            btn_listele.PerformClick();
            Temizle();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var onay = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Room_Id"].Value);
                    using (var db2 = new otelRezervasyon1Context())
                    {
                        
                        var rezervasyonlar = db2.Table_Reservation.Where(r => r.Room_Id == id).ToList();
                        db2.Table_Reservation.RemoveRange(rezervasyonlar);

                        
                        Table_Room oda = db2.Table_Room.Find(id);
                        db2.Table_Room.Remove(oda);
                        db2.SaveChanges();
                    }
                    btn_listele.PerformClick();
                }
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Temizle()
        {
            txt_oda_no.Text = "";
            txt_fiyat.Text = "";
        }
    }
}