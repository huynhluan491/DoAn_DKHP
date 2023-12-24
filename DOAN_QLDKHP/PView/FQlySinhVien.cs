using DOAN_QLDKHP.DTO;
using DOAN_QLDKHP.PControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FQlySinhVien : Form
    {
        private List<tbSinhVien> sinhViens = new List<tbSinhVien>();
        private List<DTOSinhVien> dTOSinhViens = new List<DTOSinhVien>();
        private QLDangKiHPEntities db = ControlDatabase.qldkhp;
        private List<tbKhoa> khoas = new List<tbKhoa>();
        public FQlySinhVien()
        {
            InitializeComponent();
            dgvSV.AutoGenerateColumns = false;
            load();
            loadCBKhoa();
        }
        public void load()
        {
            List<string> dataGioiTinh = new List<string>();
            dataGioiTinh.Add("Nam");
            dataGioiTinh.Add("Nữ");
            dataGioiTinh.Add("Khác");
            cbGioiTinh.DataSource = dataGioiTinh;
            sinhViens = ControlSinhVien.getAll();
            dTOSinhViens = sinhViens.Select(x => new DTOSinhVien
            {
                MaSV = x.MaSV,
                MaKhoa = x.MaKhoa,
                HoTen = x.HoTen,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh.Value.Date.ToShortDateString().ToString(),
                DiaChi = x.DiaChi,
                QueQuan = x.QueQuan,
                Khoa = x.tbKhoa.TenKhoa
            }).ToList();
            dgvSV.DataSource = dTOSinhViens;
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Access the clicked row
                DataGridViewRow row = dgvSV.Rows[e.RowIndex];

                var msv = row.Cells["MaSV"].Value.ToString();
                var item = sinhViens.FirstOrDefault(k => k.MaSV == msv);
                cbKhoa.SelectedItem = khoas.FirstOrDefault(x => x.MaKhoa == item.MaKhoa).TenKhoa;
                tbMasv.Text = item.MaSV;
                ngaySinhDP.Value = DateTime.Parse(item.NgaySinh.ToString());
                hoTenTXT.Text = item.HoTen;
                diachiTXT.Text = item.DiaChi;
                noiSinhTXT.Text = item.QueQuan;
                cbGioiTinh.SelectedItem = item.GioiTinh;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            handleSearch();
        }
        private void handleSearch()
        {
            string vFind = txtSearchSV.Text;
            if (String.IsNullOrEmpty(vFind))
            {
                dgvSV.DataSource = dTOSinhViens;
                return;
            }
            bool containsNumber = Regex.IsMatch(vFind, @"\d");
            Debug.WriteLine(containsNumber);
            var newList = containsNumber ? dTOSinhViens.Where(x => x.MaSV.ToString().ToLower().Contains(vFind.ToLower())).ToList() : dTOSinhViens.Where(x => x.HoTen.ToLower().Contains(vFind.ToLower())).ToList();
            dgvSV.DataSource = newList;
        }
        private void loadCBKhoa()
        {
            khoas = ControlKhoa.getAllKhoa();
            List<String> listTenKhoa = khoas.Select(x => x.TenKhoa).ToList();
            cbKhoa.DataSource = listTenKhoa;
        }

        private void addSV()
        {

            string ten = hoTenTXT.Text;
            if (sinhViens.Any(k => k.HoTen == ten))
            {
                MessageBox.Show("Trung ten !!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rvslist = dTOSinhViens.LastOrDefault();
            string numericPart = Regex.Replace(rvslist.MaSV, @"[^\d]", "");

            int number = int.Parse(numericPart);
            string concat = (number + 1).ToString();
            Debug.WriteLine(number + 1);
            Debug.WriteLine((number + 1) <= 9);

            if ((number + 1) <= 9) concat = $"0{number + 1}";
            tbSinhVien sv = new tbSinhVien
            {
                MaSV = "SV" + concat,
                MaKhoa = khoas.FirstOrDefault(k => k.TenKhoa == cbKhoa.SelectedItem.ToString()).MaKhoa,
                HoTen = hoTenTXT.Text,
                NgaySinh = ngaySinhDP.Value,
                GioiTinh = cbGioiTinh.SelectedItem.ToString(),
                DiaChi = diachiTXT.Text,
                QueQuan = noiSinhTXT.Text
            };
            db.tbSinhViens.Add(sv);
            db.tbAccounts.Add(new tbAccount
            {
                MaSV = sv.MaSV,
                TaiKhoan = sv.MaSV,
                MatKhau = "1",
                tbSinhVien = sv
            });
            db.SaveChanges();
            load();


        }
        private void deleteSV()
        {
            DialogResult result = MessageBox.Show("Xoa sinh vien se xoa nhung du lieu lien quan den sinh vien do!! ban co muon tiep tuc ?", "Thong Bao!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string masv = tbMasv.Text;
                tbSinhVien sv = ControlSinhVien.findSv(masv);
                Debug.WriteLine(sv.MaSV);
                if (sv != null)
                {
                    if (sv.tbDiems.Any())
                    {
                        var removeObj = sv.tbDiems.FirstOrDefault();
                        db.tbDiems.Remove(removeObj);
                    }
                    if (sv.tbPhieuDangKies.Any())
                    {
                        var phieuDKs = sv.tbPhieuDangKies.ToList();
                        var chitietPhieuDKS = phieuDKs.SelectMany(x => x.tbChiTietPDKs).ToList();
                        db.tbChiTietPDKs.RemoveRange(chitietPhieuDKS);
                        db.tbPhieuDangKies.RemoveRange(phieuDKs);
                    }
                    var acc = db.tbAccounts.FirstOrDefault(x => x.MaSV == sv.MaSV);
                    if (acc != null)
                    {
                        db.tbAccounts.Remove(acc);
                    }
                    db.tbSinhViens.Remove(sv);

                }

                db.SaveChanges();
                MessageBox.Show("xoa thanh cong!", "Thong Bao !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                ResetForm();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addSV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteSV();
        }

        private void ResetForm()
        {
            cbKhoa.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
            tbMasv.Text = "";
            ngaySinhDP.Text = string.Empty;
            diachiTXT.Text = "";
            noiSinhTXT.Text = "";
            hoTenTXT.Text = "";
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
