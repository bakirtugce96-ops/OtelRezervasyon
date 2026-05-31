using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace otelRezervasyon1
{
    public partial class Form5 : Form
    {
        otelRezervasyon1Context db = new otelRezervasyon1Context();

        public Form5()
        {
            InitializeComponent();
        }

        private void rd_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_1.Checked)
            {
                var result = db.Table_Reservation
                    .GroupBy(r => new {
                        r.Guest.Guest_Id,
                        r.Guest.Guest_Name,
                        r.Guest.Guest_Surname
                    })
                    .Select(g => new {
                        Ad = g.Key.Guest_Name + " " + g.Key.Guest_Surname,
                        Toplam = g.Count()
                    })
                    .OrderByDescending(x => x.Toplam)
                    .FirstOrDefault();

                lbl_sonuc1.Text = result != null
                    ? result.Ad + " — " + result.Toplam + " rezervasyon"
                    : "Veri yok";
            }
        }

        private void rd_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_2.Checked)
            {
                var result = db.Table_Reservation
                    .Include(r => r.Room.RoomType)
                    .GroupBy(r => r.Room.RoomType.RoomType_Name)
                    .Select(g => new {
                        Tip = g.Key,
                        Gelir = g.Sum(r => r.Room.Room_Price)
                    })
                    .OrderByDescending(x => x.Gelir)
                    .FirstOrDefault();

                lbl_sonuc2.Text = result != null
                    ? result.Tip + " — " + result.Gelir + " TL"
                    : "Veri yok";
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}