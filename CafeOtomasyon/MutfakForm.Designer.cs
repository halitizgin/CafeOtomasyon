namespace CafeOtomasyon
{
    partial class MutfakForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MutfakForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.siparişNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişDurumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hazırlanıyorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hazılanıyorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gönderildiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teslimEdildiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişİptalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ustPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
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
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(691, 394);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siparişNoToolStripMenuItem,
            this.siparişDurumToolStripMenuItem,
            this.siparişİptalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // siparişNoToolStripMenuItem
            // 
            this.siparişNoToolStripMenuItem.Enabled = false;
            this.siparişNoToolStripMenuItem.Name = "siparişNoToolStripMenuItem";
            this.siparişNoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.siparişNoToolStripMenuItem.Text = "Sipariş No";
            // 
            // siparişDurumToolStripMenuItem
            // 
            this.siparişDurumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hazırlanıyorToolStripMenuItem,
            this.hazılanıyorToolStripMenuItem,
            this.gönderildiToolStripMenuItem,
            this.teslimEdildiToolStripMenuItem});
            this.siparişDurumToolStripMenuItem.Name = "siparişDurumToolStripMenuItem";
            this.siparişDurumToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.siparişDurumToolStripMenuItem.Text = "Sipariş Durum";
            this.siparişDurumToolStripMenuItem.Click += new System.EventHandler(this.siparişDurumToolStripMenuItem_Click);
            // 
            // hazırlanıyorToolStripMenuItem
            // 
            this.hazırlanıyorToolStripMenuItem.Name = "hazırlanıyorToolStripMenuItem";
            this.hazırlanıyorToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.hazırlanıyorToolStripMenuItem.Text = "Alındı";
            this.hazırlanıyorToolStripMenuItem.Click += new System.EventHandler(this.hazırlanıyorToolStripMenuItem_Click);
            // 
            // hazılanıyorToolStripMenuItem
            // 
            this.hazılanıyorToolStripMenuItem.Name = "hazılanıyorToolStripMenuItem";
            this.hazılanıyorToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.hazılanıyorToolStripMenuItem.Text = "Hazırlanıyor";
            this.hazılanıyorToolStripMenuItem.Click += new System.EventHandler(this.hazılanıyorToolStripMenuItem_Click);
            // 
            // gönderildiToolStripMenuItem
            // 
            this.gönderildiToolStripMenuItem.Name = "gönderildiToolStripMenuItem";
            this.gönderildiToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.gönderildiToolStripMenuItem.Text = "Hazır";
            this.gönderildiToolStripMenuItem.Click += new System.EventHandler(this.gönderildiToolStripMenuItem_Click);
            // 
            // teslimEdildiToolStripMenuItem
            // 
            this.teslimEdildiToolStripMenuItem.Name = "teslimEdildiToolStripMenuItem";
            this.teslimEdildiToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.teslimEdildiToolStripMenuItem.Text = "Teslim Edildi";
            this.teslimEdildiToolStripMenuItem.Click += new System.EventHandler(this.teslimEdildiToolStripMenuItem_Click);
            // 
            // siparişİptalToolStripMenuItem
            // 
            this.siparişİptalToolStripMenuItem.Name = "siparişİptalToolStripMenuItem";
            this.siparişİptalToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.siparişİptalToolStripMenuItem.Text = "Sipariş İptal";
            this.siparişİptalToolStripMenuItem.Click += new System.EventHandler(this.siparişİptalToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.ustPanel;
            this.bunifuDragControl1.Vertical = true;
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
            this.ustPanel.Size = new System.Drawing.Size(691, 50);
            this.ustPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuImageButton2);
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(622, 0);
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
            this.logoPanel.Location = new System.Drawing.Point(6, 3);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(38, 45);
            this.logoPanel.TabIndex = 10;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(60, 13);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(194, 21);
            this.logoLabel.TabIndex = 9;
            this.logoLabel.Text = "Restoran/Cafe - Mutfak";
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
            // MutfakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 444);
            this.Controls.Add(this.ustPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MutfakForm";
            this.Text = "Mutfak - Restoran/Cafe Otomasyon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MutfakForm_FormClosing);
            this.Load += new System.EventHandler(this.MutfakForm_Load);
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
        private System.Windows.Forms.ToolStripMenuItem siparişDurumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hazırlanıyorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hazılanıyorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gönderildiToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem teslimEdildiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişİptalToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel ustPanel;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
    }
}