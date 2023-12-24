using DOAN_QLDKHP.PControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{

    public partial class FKhoa : Form
    {
        private List<tbKhoa> khoas = new List<tbKhoa>();
        public FKhoa()
        {
            InitializeComponent();
            dgvKhoa.AutoGenerateColumns = false;
            load();
            bindingFirstItem();
        }
        private void bindingFirstItem()
        {
            if(khoas.Count > 0)
            {
                var item = khoas[0];
                tenkhoa.Text = item.TenKhoa;
                sdt.Text = item.SoDienThoaiLienLac;
                diachiTXT.Text = item.DiaDiemVanPhong;
                makhoa.Text = item.MaKhoa;
            }
        }
        private void load()
        {
            khoas = ControlKhoa.getAllKhoa();
            dgvKhoa.DataSource = khoas;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tenkhoa.Text.Length == 0 || sdt.Text.Length == 0 || diachiTXT.Text.Length == 0)
            {
                MessageBox.Show("error input", "Thong Bao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            addKhoa();

        }
        private void addKhoa()
        {
            
            QLDangKiHPEntities db = ControlDatabase.qldkhp;
            string ten = tenkhoa.Text;
            if(khoas.Any(k=>k.TenKhoa == ten))
            {
                MessageBox.Show("Trung ten khoa !!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int countKhoa = khoas.Count();
            string concat = countKhoa.ToString();
            if (countKhoa < 10) concat = $"0{countKhoa +1}";
            tbKhoa khoa = new tbKhoa
            {
                MaKhoa = "KH" + concat,
                TenKhoa = ten,
                SoDienThoaiLienLac = sdt.Text,
                DiaDiemVanPhong = diachiTXT.Text
            };
            db.tbKhoas.Add(khoa);
            db.SaveChanges();
            load();

        }

        private void editKhoa()
        {
            QLDangKiHPEntities db = ControlDatabase.qldkhp;

            string makh = makhoa.Text;
            tbKhoa khoa = ControlKhoa.getKhoaById(makh);
            khoa.TenKhoa = tenkhoa.Text;
            khoa.SoDienThoaiLienLac = sdt.Text;
            khoa.DiaDiemVanPhong = diachiTXT.Text;
            db.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tenkhoa.Text.Length == 0 || sdt.Text.Length == 0 || diachiTXT.Text.Length == 0)
            {
                MessageBox.Show("error input", "Thong Bao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            editKhoa();
            load();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Access the clicked row
                DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];

                var mk = row.Cells["MK"].Value.ToString();
                var item = khoas.FirstOrDefault(k => k.MaKhoa == mk);
                tenkhoa.Text = item.TenKhoa;
                sdt.Text = item.SoDienThoaiLienLac;
                diachiTXT.Text = item.DiaDiemVanPhong;
                makhoa.Text = item.MaKhoa;
            }
                
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void handleSearch()
        {
            string vFind = tbFind.Text;
            if (String.IsNullOrEmpty(vFind))
            {
                dgvKhoa.DataSource = khoas;
                return;
            }
            bool containsNumber = Regex.IsMatch(vFind, @"\d");
            Debug.WriteLine(containsNumber);
            var newList = containsNumber ? khoas.Where(x => x.MaKhoa.ToString().ToLower().Contains(vFind.ToLower())).ToList() : khoas.Where(x => x.TenKhoa.ToLower().Contains(vFind.ToLower())).ToList();
            dgvKhoa.DataSource = newList;
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            handleSearch();
        }
    }
}
