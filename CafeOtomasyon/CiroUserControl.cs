using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyon
{
    public partial class CiroUserControl : UserControl
    {
        public CiroUserControl()
        {
            InitializeComponent();
        }

        public void YenidenBoyutlandir()
        {
            int Width = flowLayoutPanel5.Width;
            gunlukCiroPanel.Size = new Size(Width - 25, gunlukCiroPanel.Height);
            toplamCiroPanel.Size = new Size(Width - 25, toplamCiroPanel.Height);
            toplamSiparisSayisiPanel.Size = new Size(Width - 25, toplamSiparisSayisiPanel.Height);
            toplamMasaSayisiPanel.Size = new Size(Width / 2 - 15, toplamMasaSayisiPanel.Height);
            panel3.Size = new Size(Width / 2 - 15, panel3.Height);
        }

        private void CiroUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
