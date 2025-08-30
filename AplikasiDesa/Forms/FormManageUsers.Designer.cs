namespace AplikasiDesa.Forms
{
    partial class FormManageUsers
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            lblTitle = new Label();
            dataGridViewUsers = new DataGridView();
            btnDeleteUser = new Button();
            btnChangeRole = new Button();
            lblTotalUsers = new Label();
            dataGridViewLoginLogs = new DataGridView();
            lblTotalLogs = new Label();
            panelMain = new Panel();
            panel1 = new Panel();
            btnRefreshLogs = new Button();
            panel2 = new Panel();
            btnHapusLog = new Button();
            panel3 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoginLogs).BeginInit();
            panelMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(397, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(387, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MANAJEMEN PENGGUNA";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 247, 250);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(139, 150, 178);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(57, 67, 100);
            dataGridViewUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.BackgroundColor = Color.FromArgb(230, 233, 240);
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(57, 67, 100);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(38, 45, 67);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(139, 150, 178);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(57, 67, 100);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewUsers.EnableHeadersVisualStyles = false;
            dataGridViewUsers.GridColor = Color.FromArgb(139, 150, 178);
            dataGridViewUsers.Location = new Point(43, 91);
            dataGridViewUsers.Margin = new Padding(3, 4, 3, 4);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.RowTemplate.Height = 35;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(1061, 298);
            dataGridViewUsers.TabIndex = 2;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Right;
            btnDeleteUser.BackColor = Color.Crimson;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(937, 397);
            btnDeleteUser.Margin = new Padding(3, 4, 3, 4);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(167, 47);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Hapus Pengguna";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnChangeRole
            // 
            btnChangeRole.Anchor = AnchorStyles.Right;
            btnChangeRole.BackColor = Color.FromArgb(0, 123, 255);
            btnChangeRole.FlatAppearance.BorderSize = 0;
            btnChangeRole.FlatStyle = FlatStyle.Flat;
            btnChangeRole.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeRole.ForeColor = Color.White;
            btnChangeRole.Location = new Point(708, 397);
            btnChangeRole.Margin = new Padding(3, 4, 3, 4);
            btnChangeRole.Name = "btnChangeRole";
            btnChangeRole.Size = new Size(213, 47);
            btnChangeRole.TabIndex = 3;
            btnChangeRole.Text = "Jadikan Admin Utama";
            btnChangeRole.UseVisualStyleBackColor = false;
            btnChangeRole.Click += btnChangeRole_Click;
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.Anchor = AnchorStyles.Left;
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Segoe UI", 10F);
            lblTotalUsers.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotalUsers.Location = new Point(43, 409);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(146, 23);
            lblTotalUsers.TabIndex = 4;
            lblTotalUsers.Text = "Total Pengguna: 0";
            // 
            // dataGridViewLoginLogs
            // 
            dataGridViewLoginLogs.AllowUserToAddRows = false;
            dataGridViewLoginLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(245, 247, 250);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(139, 150, 178);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(57, 67, 100);
            dataGridViewLoginLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewLoginLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewLoginLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLoginLogs.BackgroundColor = Color.FromArgb(230, 233, 240);
            dataGridViewLoginLogs.BorderStyle = BorderStyle.None;
            dataGridViewLoginLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewLoginLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(57, 67, 100);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(38, 45, 67);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewLoginLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewLoginLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle7.Padding = new Padding(8, 6, 8, 6);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(139, 150, 178);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(57, 67, 100);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridViewLoginLogs.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewLoginLogs.EnableHeadersVisualStyles = false;
            dataGridViewLoginLogs.GridColor = Color.FromArgb(139, 150, 178);
            dataGridViewLoginLogs.Location = new Point(43, 578);
            dataGridViewLoginLogs.Margin = new Padding(3, 4, 3, 4);
            dataGridViewLoginLogs.Name = "dataGridViewLoginLogs";
            dataGridViewLoginLogs.ReadOnly = true;
            dataGridViewLoginLogs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewLoginLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewLoginLogs.RowHeadersVisible = false;
            dataGridViewLoginLogs.RowHeadersWidth = 51;
            dataGridViewLoginLogs.RowTemplate.Height = 35;
            dataGridViewLoginLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLoginLogs.Size = new Size(1061, 221);
            dataGridViewLoginLogs.TabIndex = 5;
            dataGridViewLoginLogs.Click += btnRefreshLogs_Click;
            // 
            // lblTotalLogs
            // 
            lblTotalLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalLogs.AutoSize = true;
            lblTotalLogs.Font = new Font("Segoe UI", 10F);
            lblTotalLogs.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotalLogs.Location = new Point(43, 330);
            lblTotalLogs.Name = "lblTotalLogs";
            lblTotalLogs.Size = new Size(97, 23);
            lblTotalLogs.TabIndex = 8;
            lblTotalLogs.Text = "Total Log: 0";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.WhiteSmoke;
            panelMain.Controls.Add(lblTotalUsers);
            panelMain.Controls.Add(btnChangeRole);
            panelMain.Controls.Add(btnDeleteUser);
            panelMain.Controls.Add(dataGridViewUsers);
            panelMain.Controls.Add(panel1);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1143, 466);
            panelMain.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(57, 67, 100);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1143, 64);
            panel1.TabIndex = 5;
            // 
            // btnRefreshLogs
            // 
            btnRefreshLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshLogs.BackColor = Color.Green;
            btnRefreshLogs.FlatAppearance.BorderSize = 0;
            btnRefreshLogs.FlatStyle = FlatStyle.Flat;
            btnRefreshLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRefreshLogs.ForeColor = Color.White;
            btnRefreshLogs.Location = new Point(959, 318);
            btnRefreshLogs.Margin = new Padding(3, 4, 3, 4);
            btnRefreshLogs.Name = "btnRefreshLogs";
            btnRefreshLogs.Size = new Size(145, 47);
            btnRefreshLogs.TabIndex = 7;
            btnRefreshLogs.Text = "Refresh Log";
            btnRefreshLogs.UseVisualStyleBackColor = false;
            btnRefreshLogs.Click += btnRefreshLogs_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(btnHapusLog);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(btnRefreshLogs);
            panel2.Controls.Add(lblTotalLogs);
            panel2.Location = new Point(0, 489);
            panel2.Name = "panel2";
            panel2.Size = new Size(1143, 378);
            panel2.TabIndex = 9;
            // 
            // btnHapusLog
            // 
            btnHapusLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHapusLog.BackColor = Color.Crimson;
            btnHapusLog.FlatAppearance.BorderSize = 0;
            btnHapusLog.FlatStyle = FlatStyle.Flat;
            btnHapusLog.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnHapusLog.ForeColor = Color.White;
            btnHapusLog.Location = new Point(809, 318);
            btnHapusLog.Margin = new Padding(3, 4, 3, 4);
            btnHapusLog.Name = "btnHapusLog";
            btnHapusLog.Size = new Size(135, 47);
            btnHapusLog.TabIndex = 10;
            btnHapusLog.Text = "Hapus Log";
            btnHapusLog.UseVisualStyleBackColor = false;
            btnHapusLog.Click += btnHapusLog_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(57, 67, 100);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1143, 64);
            panel3.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(427, 11);
            label1.Name = "label1";
            label1.Size = new Size(336, 41);
            label1.TabIndex = 0;
            label1.Text = "LOG AKTIVITAS LOGIN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1143, 867);
            Controls.Add(panelMain);
            Controls.Add(dataGridViewLoginLogs);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormManageUsers";
            Text = "Manajemen Pengguna";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoginLogs).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Label lblTitle;
        private DataGridView dataGridViewUsers;
        private Button btnDeleteUser;
        private Button btnChangeRole;
        private Label lblTotalUsers;
        private DataGridView dataGridViewLoginLogs;
        private Label lblTotalLogs;
        private Panel panelMain;
        private Button btnRefreshLogs;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Button btnHapusLog;
    }
}
