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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FAdmin : Form
    {
        BindingList<DTOMonHoc> listMHDK = new BindingList<DTOMonHoc>();
        tbSinhVien userInfo = GlobalVars.Instance.userInfo;
        private int role = GlobalVars.Instance.role;
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;

        public FAdmin()
        {
            InitializeComponent();
            dataGridView1.DataSource = listMHDK;
            if (role == 1)
            {
                sinhVienToolStripMenuItem.Visible = false;
                PhieuDKy.Visible = false;
                dgvAD.Visible = false;
                dataGridView1.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                cbHocKi.Visible = false;
            } else
            {
                mhStrip.Visible = false;
                khoaStrip.Visible = false;
                qliKhoaStrip.Visible = false;
                LoadDSMonHoc();
            }
        }

        void LoadDSMonHoc()
        {
            var ctrlMH = new ControlMonHoc();
            var listMH = ctrlMH.FindMonHocByMaMaKhoa();
            Debug.Write(listMH.ToString());
            AddCheckboxColumn();
            dgvAD.DataSource = listMH;
        }

        private void dgvAD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Assuming the checkbox column is the first column
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)dgvAD.Rows[e.RowIndex].Cells[0];
                // Check the checkbox state
                bool isChecked = Convert.ToBoolean(checkboxCell.Value);
                checkboxCell.Value = !isChecked;
                DTOMonHoc item = (DTOMonHoc)dgvAD.Rows[e.RowIndex].DataBoundItem;
                bool isAllowed = true;

                var listMTQ = db.tbMonHocs.FirstOrDefault(s => s.MaMH == item.MaMH).tbMonHoc1.ToList();
                if (listMTQ.Count > 0)
                {
                    foreach (var item1 in listMTQ)
                    {
                        double? diemtb = 0;
                        var listDiem = userInfo.tbDiems.FirstOrDefault(s => s.MaMH == item1.MaMH);
                        diemtb = 5;
                        
                        if (diemtb < 5)
                        {
                            isAllowed = false;
                            MessageBox.Show("Điều kiện môn tiên quyết chưa phù hợp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            checkboxCell.Value = false;
                            break;
                        }
                    }
                }

                if (!isChecked && isAllowed)
                {
                    // If checked, add the item to the list
                    if (!listMHDK.Contains(item))
                    {
                        listMHDK.Add(item);
                        Debug.WriteLine("list", listMHDK.ToString());
                    }
                }
                else
                {
                    // If unchecked, remove the item from the list
                    if (listMHDK.Contains(item))
                    {
                        listMHDK.Remove(item);
                        Debug.WriteLine("list", listMHDK.ToString());
                    }
                }
            }
        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin f = new FLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void AddCheckboxColumn()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Width = 50; // You can set the width as needed
            checkBoxColumn.Name = "checkBoxColumn";
            dgvAD.Columns.Insert(0, checkBoxColumn); // Adds the column as the first column
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FAdmin_Load(object sender, EventArgs e)
        {

        }


        private void phieuDKyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FPhieuDki f = new FPhieuDki();
            f.Show();
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FUser f = new FUser();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedHK = cbHocKi.SelectedItem as string;
            ControlPDK.AddPDK(selectedHK, listMHDK.ToList());
            LoadDSMonHoc();
            listMHDK.Clear();
            dataGridView1.DataSource = listMHDK;
        }

        private void cbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(role);
           if(role == 1)
            {
                FKhoa f = new FKhoa();
                f.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (role == 1)
            {
                FMonHoc f = new FMonHoc();
                f.Show();
            }
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (role == 1)
            {
                FQlySinhVien f = new FQlySinhVien();
                f.Show();
            }
        }
    }
}
