using DOAN_QLDKHP.PControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FUser : Form
    {

        private static tbSinhVien userInfo = GlobalVars.Instance.userInfo;
        public FUser()
        {
            InitializeComponent();
            loadData();
        }

        private void phieuDKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FPhieuDki f = new FPhieuDki();
            f.Show();
        }
        private void loadData()
        {
            hoTenTXT.Text = userInfo.HoTen;
            tbMasv.Text = userInfo.MaSV;
            ngaySinhDP.Value = DateTime.Parse(userInfo.NgaySinh.ToString());
            makhoa.Text = userInfo.MaKhoa;
            noiSinhTXT.Text = userInfo.QueQuan;
            string gt = userInfo.GioiTinh;
            List<string> dataGioiTinh = new List<string>();
            dataGioiTinh.Add("Nam");
            dataGioiTinh.Add("Nữ");
            dataGioiTinh.Add("Khác");
            cbGioiTinh.DataSource = dataGioiTinh;
            cbGioiTinh.SelectedItem = gt;
            diachiTXT.Text = userInfo.DiaChi;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                QLDangKiHPEntities db = ControlDatabase.qldkhp;
                tbSinhVien sv = ControlSinhVien.findSv(tbMasv.Text);
                sv.HoTen = hoTenTXT.Text;
                sv.NgaySinh = ngaySinhDP.Value;
                sv.GioiTinh = cbGioiTinh.SelectedItem.ToString();
                sv.DiaChi = diachiTXT.Text;
                sv.QueQuan = noiSinhTXT.Text;
                Debug.WriteLine(sv.HoTen);
                db.SaveChanges();
                loadData();
                MessageBox.Show("Cập nhật thành công!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FUser fUser = new FUser();
            fUser.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin f = new FAdmin();
            f.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin f = new FLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
