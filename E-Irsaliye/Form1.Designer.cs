namespace E_Irsaliye
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIrsaliye = new System.Windows.Forms.Button();
            this.chbKargoBilgileri = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnIrsaliye
            // 
            this.btnIrsaliye.Location = new System.Drawing.Point(488, 148);
            this.btnIrsaliye.Name = "btnIrsaliye";
            this.btnIrsaliye.Size = new System.Drawing.Size(204, 88);
            this.btnIrsaliye.TabIndex = 0;
            this.btnIrsaliye.Text = "E-Irsaliye";
            this.btnIrsaliye.UseVisualStyleBackColor = true;
            this.btnIrsaliye.Click += new System.EventHandler(this.btnIrsaliye_Click);
            // 
            // chbKargoBilgileri
            // 
            this.chbKargoBilgileri.AutoSize = true;
            this.chbKargoBilgileri.Location = new System.Drawing.Point(497, 88);
            this.chbKargoBilgileri.Name = "chbKargoBilgileri";
            this.chbKargoBilgileri.Size = new System.Drawing.Size(181, 21);
            this.chbKargoBilgileri.TabIndex = 1;
            this.chbKargoBilgileri.Text = "Kargo bilgileri gözüksün";
            this.chbKargoBilgileri.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chbKargoBilgileri);
            this.Controls.Add(this.btnIrsaliye);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIrsaliye;
        private System.Windows.Forms.CheckBox chbKargoBilgileri;
    }
}

