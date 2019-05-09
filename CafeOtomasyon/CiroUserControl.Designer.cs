namespace CafeOtomasyon
{
    partial class CiroUserControl
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

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.gunlukCiroPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.yillikCiroButton = new System.Windows.Forms.Button();
            this.aylikCiroButton = new System.Windows.Forms.Button();
            this.gunlukCiroButton = new System.Windows.Forms.Button();
            this.gunlukCiroLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toplamCiroPanel = new System.Windows.Forms.Panel();
            this.toplamCiroLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toplamSiparisSayisiPanel = new System.Windows.Forms.Panel();
            this.toplamSiparisSayisiLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toplamMasaSayisiPanel = new System.Windows.Forms.Panel();
            this.toplamMasaSayisiLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doluMasaSayisiLabel = new System.Windows.Forms.Label();
            this.doluMasaSayisiPanel = new System.Windows.Forms.Label();
            this.flowLayoutPanel5.SuspendLayout();
            this.gunlukCiroPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toplamCiroPanel.SuspendLayout();
            this.toplamSiparisSayisiPanel.SuspendLayout();
            this.toplamMasaSayisiPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoScroll = true;
            this.flowLayoutPanel5.Controls.Add(this.gunlukCiroPanel);
            this.flowLayoutPanel5.Controls.Add(this.toplamCiroPanel);
            this.flowLayoutPanel5.Controls.Add(this.toplamSiparisSayisiPanel);
            this.flowLayoutPanel5.Controls.Add(this.toplamMasaSayisiPanel);
            this.flowLayoutPanel5.Controls.Add(this.panel3);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(425, 519);
            this.flowLayoutPanel5.TabIndex = 10;
            this.flowLayoutPanel5.Visible = false;
            // 
            // gunlukCiroPanel
            // 
            this.gunlukCiroPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(49)))), ((int)(((byte)(89)))));
            this.gunlukCiroPanel.Controls.Add(this.panel2);
            this.gunlukCiroPanel.Controls.Add(this.gunlukCiroLabel);
            this.gunlukCiroPanel.Controls.Add(this.label1);
            this.gunlukCiroPanel.Location = new System.Drawing.Point(3, 3);
            this.gunlukCiroPanel.Name = "gunlukCiroPanel";
            this.gunlukCiroPanel.Size = new System.Drawing.Size(400, 125);
            this.gunlukCiroPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.yillikCiroButton);
            this.panel2.Controls.Add(this.aylikCiroButton);
            this.panel2.Controls.Add(this.gunlukCiroButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 125);
            this.panel2.TabIndex = 2;
            // 
            // yillikCiroButton
            // 
            this.yillikCiroButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yillikCiroButton.FlatAppearance.BorderSize = 0;
            this.yillikCiroButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.yillikCiroButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.yillikCiroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yillikCiroButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yillikCiroButton.ForeColor = System.Drawing.Color.White;
            this.yillikCiroButton.Location = new System.Drawing.Point(0, 82);
            this.yillikCiroButton.Name = "yillikCiroButton";
            this.yillikCiroButton.Size = new System.Drawing.Size(100, 40);
            this.yillikCiroButton.TabIndex = 0;
            this.yillikCiroButton.Text = "Yıllık";
            this.yillikCiroButton.UseVisualStyleBackColor = true;
            // 
            // aylikCiroButton
            // 
            this.aylikCiroButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aylikCiroButton.FlatAppearance.BorderSize = 0;
            this.aylikCiroButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.aylikCiroButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.aylikCiroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aylikCiroButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aylikCiroButton.ForeColor = System.Drawing.Color.White;
            this.aylikCiroButton.Location = new System.Drawing.Point(0, 42);
            this.aylikCiroButton.Name = "aylikCiroButton";
            this.aylikCiroButton.Size = new System.Drawing.Size(100, 40);
            this.aylikCiroButton.TabIndex = 0;
            this.aylikCiroButton.Text = "Aylık";
            this.aylikCiroButton.UseVisualStyleBackColor = true;
            // 
            // gunlukCiroButton
            // 
            this.gunlukCiroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.gunlukCiroButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunlukCiroButton.FlatAppearance.BorderSize = 0;
            this.gunlukCiroButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.gunlukCiroButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.gunlukCiroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gunlukCiroButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunlukCiroButton.ForeColor = System.Drawing.Color.White;
            this.gunlukCiroButton.Location = new System.Drawing.Point(0, 2);
            this.gunlukCiroButton.Name = "gunlukCiroButton";
            this.gunlukCiroButton.Size = new System.Drawing.Size(100, 40);
            this.gunlukCiroButton.TabIndex = 0;
            this.gunlukCiroButton.Text = "Günlük";
            this.gunlukCiroButton.UseVisualStyleBackColor = false;
            // 
            // gunlukCiroLabel
            // 
            this.gunlukCiroLabel.AutoSize = true;
            this.gunlukCiroLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunlukCiroLabel.ForeColor = System.Drawing.Color.White;
            this.gunlukCiroLabel.Location = new System.Drawing.Point(107, 51);
            this.gunlukCiroLabel.Name = "gunlukCiroLabel";
            this.gunlukCiroLabel.Size = new System.Drawing.Size(153, 57);
            this.gunlukCiroLabel.TabIndex = 1;
            this.gunlukCiroLabel.Text = "100 ₺";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(113, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Günlük Ciro";
            // 
            // toplamCiroPanel
            // 
            this.toplamCiroPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(49)))), ((int)(((byte)(89)))));
            this.toplamCiroPanel.Controls.Add(this.toplamCiroLabel);
            this.toplamCiroPanel.Controls.Add(this.label11);
            this.toplamCiroPanel.Location = new System.Drawing.Point(3, 134);
            this.toplamCiroPanel.Name = "toplamCiroPanel";
            this.toplamCiroPanel.Size = new System.Drawing.Size(400, 125);
            this.toplamCiroPanel.TabIndex = 0;
            // 
            // toplamCiroLabel
            // 
            this.toplamCiroLabel.AutoSize = true;
            this.toplamCiroLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplamCiroLabel.ForeColor = System.Drawing.Color.White;
            this.toplamCiroLabel.Location = new System.Drawing.Point(3, 53);
            this.toplamCiroLabel.Name = "toplamCiroLabel";
            this.toplamCiroLabel.Size = new System.Drawing.Size(153, 57);
            this.toplamCiroLabel.TabIndex = 1;
            this.toplamCiroLabel.Text = "100 ₺";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(13, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "Toplam Ciro";
            // 
            // toplamSiparisSayisiPanel
            // 
            this.toplamSiparisSayisiPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(49)))), ((int)(((byte)(89)))));
            this.toplamSiparisSayisiPanel.Controls.Add(this.toplamSiparisSayisiLabel);
            this.toplamSiparisSayisiPanel.Controls.Add(this.label9);
            this.toplamSiparisSayisiPanel.Location = new System.Drawing.Point(3, 265);
            this.toplamSiparisSayisiPanel.Name = "toplamSiparisSayisiPanel";
            this.toplamSiparisSayisiPanel.Size = new System.Drawing.Size(400, 125);
            this.toplamSiparisSayisiPanel.TabIndex = 0;
            // 
            // toplamSiparisSayisiLabel
            // 
            this.toplamSiparisSayisiLabel.AutoSize = true;
            this.toplamSiparisSayisiLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplamSiparisSayisiLabel.ForeColor = System.Drawing.Color.White;
            this.toplamSiparisSayisiLabel.Location = new System.Drawing.Point(3, 50);
            this.toplamSiparisSayisiLabel.Name = "toplamSiparisSayisiLabel";
            this.toplamSiparisSayisiLabel.Size = new System.Drawing.Size(112, 57);
            this.toplamSiparisSayisiLabel.TabIndex = 1;
            this.toplamSiparisSayisiLabel.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Toplam Sipariş Sayısı";
            // 
            // toplamMasaSayisiPanel
            // 
            this.toplamMasaSayisiPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(49)))), ((int)(((byte)(89)))));
            this.toplamMasaSayisiPanel.Controls.Add(this.toplamMasaSayisiLabel);
            this.toplamMasaSayisiPanel.Controls.Add(this.label16);
            this.toplamMasaSayisiPanel.Location = new System.Drawing.Point(3, 396);
            this.toplamMasaSayisiPanel.Name = "toplamMasaSayisiPanel";
            this.toplamMasaSayisiPanel.Size = new System.Drawing.Size(197, 125);
            this.toplamMasaSayisiPanel.TabIndex = 0;
            // 
            // toplamMasaSayisiLabel
            // 
            this.toplamMasaSayisiLabel.AutoSize = true;
            this.toplamMasaSayisiLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplamMasaSayisiLabel.ForeColor = System.Drawing.Color.White;
            this.toplamMasaSayisiLabel.Location = new System.Drawing.Point(3, 50);
            this.toplamMasaSayisiLabel.Name = "toplamMasaSayisiLabel";
            this.toplamMasaSayisiLabel.Size = new System.Drawing.Size(112, 57);
            this.toplamMasaSayisiLabel.TabIndex = 1;
            this.toplamMasaSayisiLabel.Text = "100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(4, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "Toplam Masa Sayısı";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(49)))), ((int)(((byte)(89)))));
            this.panel3.Controls.Add(this.doluMasaSayisiLabel);
            this.panel3.Controls.Add(this.doluMasaSayisiPanel);
            this.panel3.Location = new System.Drawing.Point(206, 396);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 125);
            this.panel3.TabIndex = 1;
            // 
            // doluMasaSayisiLabel
            // 
            this.doluMasaSayisiLabel.AutoSize = true;
            this.doluMasaSayisiLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doluMasaSayisiLabel.ForeColor = System.Drawing.Color.White;
            this.doluMasaSayisiLabel.Location = new System.Drawing.Point(3, 51);
            this.doluMasaSayisiLabel.Name = "doluMasaSayisiLabel";
            this.doluMasaSayisiLabel.Size = new System.Drawing.Size(112, 57);
            this.doluMasaSayisiLabel.TabIndex = 1;
            this.doluMasaSayisiLabel.Text = "100";
            // 
            // doluMasaSayisiPanel
            // 
            this.doluMasaSayisiPanel.AutoSize = true;
            this.doluMasaSayisiPanel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.doluMasaSayisiPanel.ForeColor = System.Drawing.Color.White;
            this.doluMasaSayisiPanel.Location = new System.Drawing.Point(4, 15);
            this.doluMasaSayisiPanel.Name = "doluMasaSayisiPanel";
            this.doluMasaSayisiPanel.Size = new System.Drawing.Size(135, 21);
            this.doluMasaSayisiPanel.TabIndex = 0;
            this.doluMasaSayisiPanel.Text = "Dolu Masa Sayısı";
            // 
            // CiroUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel5);
            this.Name = "CiroUserControl";
            this.Size = new System.Drawing.Size(425, 519);
            this.Load += new System.EventHandler(this.CiroUserControl_Load);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.gunlukCiroPanel.ResumeLayout(false);
            this.gunlukCiroPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toplamCiroPanel.ResumeLayout(false);
            this.toplamCiroPanel.PerformLayout();
            this.toplamSiparisSayisiPanel.ResumeLayout(false);
            this.toplamSiparisSayisiPanel.PerformLayout();
            this.toplamMasaSayisiPanel.ResumeLayout(false);
            this.toplamMasaSayisiPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel gunlukCiroPanel;
        public System.Windows.Forms.Label gunlukCiroLabel;
        public System.Windows.Forms.Panel toplamCiroPanel;
        public System.Windows.Forms.Label toplamCiroLabel;
        public System.Windows.Forms.Panel toplamSiparisSayisiPanel;
        public System.Windows.Forms.Label toplamSiparisSayisiLabel;
        public System.Windows.Forms.Panel toplamMasaSayisiPanel;
        public System.Windows.Forms.Label toplamMasaSayisiLabel;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label doluMasaSayisiLabel;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button yillikCiroButton;
        public System.Windows.Forms.Button aylikCiroButton;
        public System.Windows.Forms.Button gunlukCiroButton;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label doluMasaSayisiPanel;
    }
}
