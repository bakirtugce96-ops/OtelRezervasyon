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
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            var room = new Table_Room
            {
                Room_Number = txt_oda_no.Text,
                Room_Price = Convert.ToDecimal(txt_fiyat.Text),
                RoomType_Id = (int)combo_tip.SelectedValue
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
                    Table_Room r = db.Table_Room.Find(id);
                    db.Table_Room.Remove(r);
                    db.SaveChanges();
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