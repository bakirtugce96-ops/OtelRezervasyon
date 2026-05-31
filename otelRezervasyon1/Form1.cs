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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            ShowPanel(pnl_AnaMenu);
        }

        private void ShowPanel(Panel aktifPanel)
        {
            pnl_AnaMenu.Visible = false;
            aktifPanel.Visible = true;
        }

        private void btn_gitMisafirler_Click(object sender, EventArgs e)
        {
           
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void btn_gitOdalar_Click(object sender, EventArgs e)
        {
            
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void btn_gitRezervasyonlar_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void btn_gitRaporlar_Click(object sender, EventArgs e)
        {
            
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        
            pnl_AnaMenu.Visible = true;
            pnl_misafirler.Visible = true;
            pnl_odalar.Visible = true;
            pnl_rezervasyonlar.Visible = true;
            pnl_raporlar.Visible = true;

            pnl_AnaMenu.BringToFront();
        
    }

        private void pnl_AnaMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}