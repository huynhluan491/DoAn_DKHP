using DOAN_QLDKHP.DTO;
using DOAN_QLDKHP.PControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FMonHoc : Form
    {
        BindingList<DTOMonHoc> listMHDK = new BindingList<DTOMonHoc>();
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;

        public FMonHoc()
        {
            InitializeComponent();
            LoadDSMonHoc();
            LoadDSKhoa();
        }

        void LoadDSMonHoc()
        {
            var listMH = ControlMonHoc.FindAll();
            dgvListMH.DataSource = listMH;
        }

        void LoadDSKhoa()
        {
            var listKhoa = db.tbKhoas.ToList();
            cbTenKhoa.DataSource = listKhoa;
            cbTenKhoa.DisplayMember = "TenKhoa";
            cbTenKhoa.ValueMember = "MaKhoa";
            
        }

        private void FMonHoc_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv != null)
                {
                    DataGridViewCell maMH = dgv.Rows[e.RowIndex].Cells[0];
                    DataGridViewCell maKhoa = dgv.Rows[e.RowIndex].Cells[1];
                    DataGridViewCell tenMH = dgv.Rows[e.RowIndex].Cells[2];
                    DataGridViewCell soTC = dgv.Rows[e.RowIndex].Cells[3];

                    txtMaMH.Text = maMH?.Value.ToString();
                    txtTenMonHoc.Text = tenMH?.Value.ToString();
                    cbTenKhoa.SelectedValue = maKhoa?.Value.ToString();
                    if (int.TryParse(soTC.Value?.ToString(), out int numericValue))
                    {
                        nmrSTC.Value = numericValue;
                    }
                }
            }
        }

        private void btnThem(object sender, EventArgs e)
        {
            var rvslist = db.tbMonHocs.ToList().LastOrDefault();
            string numericPart = Regex.Replace(rvslist.MaMH, @"[^\d]", "");

            int number = int.Parse(numericPart);
            string concat = (number + 1).ToString();
            Debug.WriteLine(number + 1);
            Debug.WriteLine((number + 1) <= 9);

            if ((number + 1) <= 9) concat = $"0{number + 1}";

            var mhLength = db.tbMonHocs.ToList().Count;

            tbMonHoc mh = new tbMonHoc
            {
                MaMH = "MH" + concat,
                MaKhoa = cbTenKhoa.SelectedValue.ToString(),
                TenMH = txtTenMonHoc.Text,
                SoTinChi = nmrSTC.Value.ToString()
            };
            Debug.WriteLine($"MaMH: {mh.MaMH}, MaKhoa: {mh.MaKhoa}, TenMH: {mh.TenMH}, SoTinChi: {mh.SoTinChi}");
            ControlMonHoc.Add(mh);
            LoadDSMonHoc();
            resetText();

        }

        public void resetText()
        {
            txtMaMH.Text = "";
            cbTenKhoa.SelectedValue = "";
            txtTenMonHoc.Text = "";
            nmrSTC.Value = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Chắc chắn muốn xóa môn học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                int index = dgvListMH.CurrentCell.RowIndex;
                string mamh = dgvListMH.Rows[index].Cells[0].Value + "";
                ControlMonHoc.Delete(ControlMonHoc.FindMH(mamh));
                resetText();
                LoadDSMonHoc();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Chắc chắn muốn cập nhật môn học?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                int index = dgvListMH.CurrentCell.RowIndex;
                string mamh = dgvListMH.Rows[index].Cells[0].Value + "";
                tbMonHoc mh = ControlMonHoc.FindMH(mamh);
                mh.MaKhoa = cbTenKhoa.SelectedValue.ToString();
                mh.TenMH = txtTenMonHoc.Text;
                mh.SoTinChi = nmrSTC.Value.ToString();
                ControlMonHoc.Update(mh);
                LoadDSMonHoc();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var list = ControlMonHoc.TimKiemMonHoc(txtSearchMH.Text);
            dgvListMH.DataSource = list;
        }

        private void cbTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
