using DOAN_QLDKHP.PControl;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PView
{
    public partial class FLogin : Form
    {
        public static tbAccount userInfo;
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ControlAccount.Login(textBox1.Text, textBox2.Text))
            {
                ControlAccount.Account = ControlAccount.db.tbAccounts.FirstOrDefault(x => x.TaiKhoan == textBox1.Text && x.MatKhau == textBox2.Text);
                if (ControlAccount.Account.tbSinhVien.NgaySinh == null)
                {
                    GlobalVars.Instance.role = 1;

                }
                else
                {
                    GlobalVars.Instance.userInfo = ControlAccount.Account.tbSinhVien;
                    Debug.WriteLine(GlobalVars.Instance.userInfo.MaKhoa);
                    GlobalVars.Instance.role = 0;
                }
                this.Hide();
                FAdmin f = new FAdmin();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
