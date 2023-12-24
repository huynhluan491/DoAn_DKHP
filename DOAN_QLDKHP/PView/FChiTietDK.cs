using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FChiTietDK : Form
    {
        private dynamic chiTietPDK;
        public FChiTietDK(dynamic data)
        {
            InitializeComponent();
            chiTietPDK = data;
            loadData();
        }
        private void loadData()
        {
            gvCTDK.DataSource = chiTietPDK;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin f = new FAdmin();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Hide();
            FUser f = new FUser();
            f.Show();
        }
    }
}
