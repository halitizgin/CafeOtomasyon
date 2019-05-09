namespace CafeOtomasyon
{
    partial class OptimizasyonUserControl
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
            this.optimizasyonPanel = new System.Windows.Forms.Panel();
            this.temizleButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tamamiCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.belirliCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.optimizasyonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // optimizasyonPanel
            // 
            this.optimizasyonPanel.Controls.Add(this.temizleButton);
            this.optimizasyonPanel.Controls.Add(this.comboBox1);
            this.optimizasyonPanel.Controls.Add(this.numericUpDown1);
            this.optimizasyonPanel.Controls.Add(this.label3);
            this.optimizasyonPanel.Controls.Add(this.tamamiCheckBox);
            this.optimizasyonPanel.Controls.Add(this.label2);
            this.optimizasyonPanel.Controls.Add(this.belirliCheckBox);
            this.optimizasyonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optimizasyonPanel.Location = new System.Drawing.Point(0, 0);
            this.optimizasyonPanel.Name = "optimizasyonPanel";
            this.optimizasyonPanel.Size = new System.Drawing.Size(342, 223);
            this.optimizasyonPanel.TabIndex = 11;
            this.optimizasyonPanel.Visible = false;
            // 
            // temizleButton
            // 
            this.temizleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.temizleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.temizleButton.FlatAppearance.BorderSize = 0;
            this.temizleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.temizleButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.temizleButton.ForeColor = System.Drawing.Color.White;
            this.temizleButton.Location = new System.Drawing.Point(12, 155);
            this.temizleButton.Name = "temizleButton";
            this.temizleButton.Size = new System.Drawing.Size(131, 47);
            this.temizleButton.TabIndex = 4;
            this.temizleButton.Text = "Temizle";
            this.temizleButton.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Gün",
            "Ay",
            "Yıl"});
            this.comboBox1.Location = new System.Drawing.Point(208, 55);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 30);
            this.comboBox1.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDown1.Location = new System.Drawing.Point(12, 55);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(190, 31);
            this.numericUpDown1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.label3.Location = new System.Drawing.Point(38, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tamamını Temizle";
            // 
            // tamamiCheckBox
            // 
            this.tamamiCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.tamamiCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.tamamiCheckBox.Checked = false;
            this.tamamiCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.tamamiCheckBox.ForeColor = System.Drawing.Color.White;
            this.tamamiCheckBox.Location = new System.Drawing.Point(12, 110);
            this.tamamiCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.tamamiCheckBox.Name = "tamamiCheckBox";
            this.tamamiCheckBox.Size = new System.Drawing.Size(20, 20);
            this.tamamiCheckBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(38, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Belirtilen Tarihten Öncekileri Temizle";
            // 
            // belirliCheckBox
            // 
            this.belirliCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.belirliCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.belirliCheckBox.Checked = true;
            this.belirliCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(110)))), ((int)(((byte)(198)))));
            this.belirliCheckBox.ForeColor = System.Drawing.Color.White;
            this.belirliCheckBox.Location = new System.Drawing.Point(12, 19);
            this.belirliCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.belirliCheckBox.Name = "belirliCheckBox";
            this.belirliCheckBox.Size = new System.Drawing.Size(20, 20);
            this.belirliCheckBox.TabIndex = 0;
            // 
            // OptimizasyonUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.optimizasyonPanel);
            this.Name = "OptimizasyonUserControl";
            this.Size = new System.Drawing.Size(342, 223);
            this.optimizasyonPanel.ResumeLayout(false);
            this.optimizasyonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button temizleButton;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.Label label3;
        public Bunifu.Framework.UI.BunifuCheckbox tamamiCheckBox;
        public System.Windows.Forms.Label label2;
        public Bunifu.Framework.UI.BunifuCheckbox belirliCheckBox;
        public System.Windows.Forms.Panel optimizasyonPanel;
    }
}
