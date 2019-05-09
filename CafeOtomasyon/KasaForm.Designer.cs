namespace CafeOtomasyon
{
    partial class KasaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasaForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.masaNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masaÖzetiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borçÖdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masayıBoşaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masaTaşıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ustPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.ustPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(540, 388);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masaNoToolStripMenuItem,
            this.masaÖzetiToolStripMenuItem,
            this.borçÖdeToolStripMenuItem,
            this.masayıBoşaltToolStripMenuItem,
            this.masaTaşıToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 114);
            // 
            // masaNoToolStripMenuItem
            // 
            this.masaNoToolStripMenuItem.Enabled = false;
            this.masaNoToolStripMenuItem.Name = "masaNoToolStripMenuItem";
            this.masaNoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.masaNoToolStripMenuItem.Text = "MasaNo";
            // 
            // masaÖzetiToolStripMenuItem
            // 
            this.masaÖzetiToolStripMenuItem.Name = "masaÖzetiToolStripMenuItem";
            this.masaÖzetiToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.masaÖzetiToolStripMenuItem.Text = "Masa Özeti";
            this.masaÖzetiToolStripMenuItem.Click += new System.EventHandler(this.masaÖzetiToolStripMenuItem_Click);
            // 
            // borçÖdeToolStripMenuItem
            // 
            this.borçÖdeToolStripMenuItem.Name = "borçÖdeToolStripMenuItem";
            this.borçÖdeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.borçÖdeToolStripMenuItem.Text = "Borç Öde";
            this.borçÖdeToolStripMenuItem.Click += new System.EventHandler(this.BorçÖdeToolStripMenuItem_Click);
            // 
            // masayıBoşaltToolStripMenuItem
            // 
            this.masayıBoşaltToolStripMenuItem.Name = "masayıBoşaltToolStripMenuItem";
            this.masayıBoşaltToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.masayıBoşaltToolStripMenuItem.Text = "Masayı Boşalt";
            this.masayıBoşaltToolStripMenuItem.Click += new System.EventHandler(this.masayıBoşaltToolStripMenuItem_Click);
            // 
            // masaTaşıToolStripMenuItem
            // 
            this.masaTaşıToolStripMenuItem.Name = "masaTaşıToolStripMenuItem";
            this.masaTaşıToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.masaTaşıToolStripMenuItem.Text = "Masa Taşı";
            this.masaTaşıToolStripMenuItem.Click += new System.EventHandler(this.masaTaşıToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ustPanel
            // 
            this.ustPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.ustPanel.Controls.Add(this.panel2);
            this.ustPanel.Controls.Add(this.logoPanel);
            this.ustPanel.Controls.Add(this.logoLabel);
            this.ustPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ustPanel.Location = new System.Drawing.Point(0, 0);
            this.ustPanel.Name = "ustPanel";
            this.ustPanel.Size = new System.Drawing.Size(540, 50);
            this.ustPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuImageButton2);
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(471, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(69, 50);
            this.panel2.TabIndex = 8;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(8, 10);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(24, 24);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 2;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(38, 10);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(24, 24);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 2;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPanel.BackgroundImage")));
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPanel.Location = new System.Drawing.Point(6, 2);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(38, 45);
            this.logoPanel.TabIndex = 10;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(60, 14);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(175, 21);
            this.logoLabel.TabIndex = 9;
            this.logoLabel.Text = "Restoran/Cafe - Kasa";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.ustPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.logoLabel;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // KasaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 438);
            this.Controls.Add(this.ustPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KasaForm";
            this.Text = "Kasa - Restoran/Cafe Otomasyon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KasaForm_FormClosing);
            this.Load += new System.EventHandler(this.KasaForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ustPanel.ResumeLayout(false);
            this.ustPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masaNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masaÖzetiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borçÖdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masayıBoşaltToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem masaTaşıToolStripMenuItem;
        private System.Windows.Forms.Panel ustPanel;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}