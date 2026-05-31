using System;
using System.Linq;
using System.Windows.Forms;

namespace otelRezervasyon1
{
    public partial class Form4 : Form
    {
        otelRezervasyon1Context db = new otelRezervasyon1Context();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            combo_misafir.DataSource = db.Table_Guest.ToList();
            combo_misafir.DisplayMember = "Guest_Name";
            combo_misafir.ValueMember = "Guest_Id";

            combo_oda.DataSource = db.Table_Room.ToList();
            combo_oda.DisplayMember = "Room_Number";
            combo_oda.ValueMember = "Room_Id";
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Table_Reservation
                .Select(r => new {
                    r.Reservation_Id,
                    Misafir = r.Guest.Guest_Name + " " + r.Guest.Guest_Surname,
                    Oda = r.Room.Room_Number,
                    r.CheckIn_Date,
                    r.CheckOut_Date
                }).ToList();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            var res = new Table_Reservation
            {
                Guest_Id = (int)combo_misafir.SelectedValue,
                Room_Id = (int)combo_oda.SelectedValue,
                CheckIn_Date = dtp_giris.Value,
                CheckOut_Date = dtp_cikis.Value
            };
            db.Table_Reservation.Add(res);
            db.SaveChanges();
            MessageBox.Show("Rezervasyon eklendi!");
            btn_listele.PerformClick();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var onay = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Reservation_Id"].Value);
                    Table_Reservation r = db.Table_Reservation.Find(id);
                    db.Table_Reservation.Remove(r);
                    db.SaveChanges();
                    btn_listele.PerformClick();
                }
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}