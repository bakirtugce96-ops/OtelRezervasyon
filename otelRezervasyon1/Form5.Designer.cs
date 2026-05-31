namespace otelRezervasyon1
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rd_1 = new System.Windows.Forms.RadioButton();
            this.rd_2 = new System.Windows.Forms.RadioButton();
            this.lbl_sonuc1 = new System.Windows.Forms.Label();
            this.lbl_sonuc2 = new System.Windows.Forms.Label();
            this.btn_geri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rd_1
            // 
            this.rd_1.AutoSize = true;
            this.rd_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.rd_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rd_1.ForeColor = System.Drawing.Color.White;
            this.rd_1.Location = new System.Drawing.Point(202, 50);
            this.rd_1.Name = "rd_1";
            this.rd_1.Size = new System.Drawing.Size(507, 36);
            this.rd_1.TabIndex = 0;
            this.rd_1.TabStop = true;
            this.rd_1.Text = "En çok rezervaasyon yapan misafir";
            this.rd_1.UseVisualStyleBackColor = false;
            this.rd_1.CheckedChanged += new System.EventHandler(this.rd_1_CheckedChanged);
            // 
            // rd_2
            // 
            this.rd_2.AutoSize = true;
            this.rd_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(62)))));
            this.rd_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rd_2.ForeColor = System.Drawing.Color.White;
            this.rd_2.Location = new System.Drawing.Point(202, 250);
            this.rd_2.Name = "rd_2";
            this.rd_2.Size = new System.Drawing.Size(367, 36);
            this.rd_2.TabIndex = 1;
            this.rd_2.TabStop = true;
            this.rd_2.Text = "En yüksek gelirli oda tipi";
            this.rd_2.UseVisualStyleBackColor = false;
            this.rd_2.CheckedChanged += new System.EventHandler(this.rd_2_CheckedChanged);
            // 
            // lbl_sonuc1
            // 
            this.lbl_sonuc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(174)))));
            this.lbl_sonuc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sonuc1.ForeColor = System.Drawing.Color.Green;
            this.lbl_sonuc1.Location = new System.Drawing.Point(199, 99);
            this.lbl_sonuc1.Name = "lbl_sonuc1";
            this.lbl_sonuc1.Size = new System.Drawing.Size(378, 82);
            this.lbl_sonuc1.TabIndex = 2;
            this.lbl_sonuc1.Text = "label1";
            // 
            // lbl_sonuc2
            // 
            this.lbl_sonuc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(174)))));
            this.lbl_sonuc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sonuc2.ForeColor = System.Drawing.Color.Green;
            this.lbl_sonuc2.Location = new System.Drawing.Point(197, 304);
            this.lbl_sonuc2.Name = "lbl_sonuc2";
            this.lbl_sonuc2.Size = new System.Drawing.Size(378, 93);
            this.lbl_sonuc2.TabIndex = 3;
            this.lbl_sonuc2.Text = "label2";
            // 
            // btn_geri
            // 
            this.btn_geri.BackColor = System.Drawing.Color.Gray;
            this.btn_geri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_geri.Location = new System.Drawing.Point(681, 379);
            this.btn_geri.Name = "btn_geri";
            this.btn_geri.Size = new System.Drawing.Size(96, 50);
            this.btn_geri.TabIndex = 4;
            this.btn_geri.Text = "Geri";
            this.btn_geri.UseVisualStyleBackColor = false;
            this.btn_geri.Click += new System.EventHandler(this.btn_geri_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_geri);
            this.Controls.Add(this.lbl_sonuc2);
            this.Controls.Add(this.lbl_sonuc1);
            this.Controls.Add(this.rd_2);
            this.Controls.Add(this.rd_1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rd_1;
        private System.Windows.Forms.RadioButton rd_2;
        private System.Windows.Forms.Label lbl_sonuc1;
        private System.Windows.Forms.Label lbl_sonuc2;
        private System.Windows.Forms.Button btn_geri;
    }
}