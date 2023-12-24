using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOAN_QLDKHP.PControl;

namespace DOAN_QLDKHP.PView
{
    public partial class FPhieuDki : Form
    {

        public FPhieuDki()
        {
            InitializeComponent();
            loadPkdy();
        }
        private void loadPkdy()
        {

            var data = ControlPDK.queryPhieuDKBySinhVien();
            gvPDK.DataSource = data;
        }
        private void phieuDKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FPhieuDki f = new FPhieuDki();
            f.Show();
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private FChiTietDK fChiTietDKForm = null;
        private void gvPDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Access the clicked row
                DataGridViewRow row = gvPDK.Rows[e.RowIndex];

                var soPDK = row.Cells["SoPDK"].Value.ToString();
                var queryCTDKResult = ControlPDK.queryCTDK(soPDK);
                /*FChiTietDK f = new FChiTietDK(queryCTDKResult);
                f.Show();*/
                if (fChiTietDKForm == null || fChiTietDKForm.IsDisposed)
                {
                    fChiTietDKForm = new FChiTietDK(queryCTDKResult);
                    fChiTietDKForm.Show();
                }
                else
                {
                    fChiTietDKForm.BringToFront(); // Bring the existing form to the front
                }

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FUser f = new FUser();
            f.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin f = new FLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin f = new FAdmin();
            f.Show();
        }
    }
}
