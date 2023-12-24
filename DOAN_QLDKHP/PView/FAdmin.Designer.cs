namespace DOAN_QLDKHP.PView
{
    partial class FAdmin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhieuDKy = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoaStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mhStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.qliKhoaStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvAD = new System.Windows.Forms.DataGridView();
            this.MaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cbHocKi = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(28)))), ((int)(((byte)(104)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.PhieuDKy,
            this.sinhVienToolStripMenuItem,
            this.khoaStrip,
            this.mhStrip,
            this.qliKhoaStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(124, 682);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // PhieuDKy
            // 
            this.PhieuDKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PhieuDKy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PhieuDKy.Name = "PhieuDKy";
            this.PhieuDKy.Size = new System.Drawing.Size(115, 20);
            this.PhieuDKy.Text = "PhieuDKy";
            this.PhieuDKy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PhieuDKy.Click += new System.EventHandler(this.phieuDKyToolStripMenuItem_Click_1);
            // 
            // sinhVienToolStripMenuItem
            // 
            this.sinhVienToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sinhVienToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sinhVienToolStripMenuItem.Name = "sinhVienToolStripMenuItem";
            this.sinhVienToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.sinhVienToolStripMenuItem.Text = "Sinh Vien";
            this.sinhVienToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sinhVienToolStripMenuItem.Click += new System.EventHandler(this.sinhVienToolStripMenuItem_Click);
            // 
            // khoaStrip
            // 
            this.khoaStrip.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.khoaStrip.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.khoaStrip.Name = "khoaStrip";
            this.khoaStrip.Size = new System.Drawing.Size(115, 20);
            this.khoaStrip.Text = "Khoa";
            this.khoaStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.khoaStrip.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // mhStrip
            // 
            this.mhStrip.AccessibleName = "monHocStrip";
            this.mhStrip.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mhStrip.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mhStrip.Name = "mhStrip";
            this.mhStrip.Size = new System.Drawing.Size(115, 20);
            this.mhStrip.Text = "MonHoc";
            this.mhStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mhStrip.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // qliKhoaStrip
            // 
            this.qliKhoaStrip.AccessibleName = "monHocStrip";
            this.qliKhoaStrip.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.qliKhoaStrip.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.qliKhoaStrip.Name = "qliKhoaStrip";
            this.qliKhoaStrip.Size = new System.Drawing.Size(115, 20);
            this.qliKhoaStrip.Text = "Qly Sinh Vien";
            this.qliKhoaStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.qliKhoaStrip.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // dgvAD
            // 
            this.dgvAD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAD.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMH,
            this.MaKhoa,
            this.TenMH,
            this.SoTinChi});
            this.dgvAD.Location = new System.Drawing.Point(131, 56);
            this.dgvAD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAD.Name = "dgvAD";
            this.dgvAD.RowHeadersWidth = 51;
            this.dgvAD.Size = new System.Drawing.Size(1019, 295);
            this.dgvAD.TabIndex = 72;
            this.dgvAD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAD_CellContentClick);
            // 
            // MaMH
            // 
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Ma mon hoc";
            this.MaMH.MinimumWidth = 10;
            this.MaMH.Name = "MaMH";
            // 
            // MaKhoa
            // 
            this.MaKhoa.DataPropertyName = "MaKhoa";
            this.MaKhoa.HeaderText = "Ma khoa";
            this.MaKhoa.MinimumWidth = 10;
            this.MaKhoa.Name = "MaKhoa";
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TenMH";
            this.TenMH.HeaderText = "Ten mon hoc";
            this.TenMH.MinimumWidth = 10;
            this.TenMH.Name = "TenMH";
            // 
            // SoTinChi
            // 
            this.SoTinChi.DataPropertyName = "SoTinChi";
            this.SoTinChi.HeaderText = "So tin chi";
            this.SoTinChi.MinimumWidth = 10;
            this.SoTinChi.Name = "SoTinChi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView1.Location = new System.Drawing.Point(131, 370);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 242);
            this.dataGridView1.TabIndex = 73;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaMH";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ma mon hoc";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaKhoa";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ma khoa";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TenMH";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ten mon hoc";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SoTinChi";
            this.dataGridViewTextBoxColumn4.HeaderText = "So tin chi";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(999, 626);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 43);
            this.button1.TabIndex = 74;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbHocKi
            // 
            this.cbHocKi.FormattingEnabled = true;
            this.cbHocKi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbHocKi.Location = new System.Drawing.Point(245, 18);
            this.cbHocKi.Margin = new System.Windows.Forms.Padding(1);
            this.cbHocKi.Name = "cbHocKi";
            this.cbHocKi.Size = new System.Drawing.Size(149, 21);
            this.cbHocKi.TabIndex = 75;
            this.cbHocKi.SelectedIndexChanged += new System.EventHandler(this.cbHocKi_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 76;
            this.textBox1.Text = "Hoc Ki";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1168, 682);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbHocKi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvAD);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FAdmin";
            this.Text = "FAdmin";
            this.Load += new System.EventHandler(this.FAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTinChi;
        private System.Windows.Forms.ToolStripMenuItem PhieuDKy;
        private System.Windows.Forms.ToolStripMenuItem sinhVienToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbHocKi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem khoaStrip;
        private System.Windows.Forms.ToolStripMenuItem mhStrip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem qliKhoaStrip;
    }
}