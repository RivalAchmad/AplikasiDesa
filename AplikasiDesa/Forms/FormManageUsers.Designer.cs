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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            lblTitle = new Label();
            dataGridViewUsers = new DataGridView();
            btnDeleteUser = new Button();
            btnChangeRole = new Button();
            lblTotalUsers = new Label();
            dataGridViewLoginLogs = new DataGridView();
            lblTotalLogs = new Label();
            panelMain = new Panel();
            label1 = new Label();
            btnRefreshLogs = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoginLogs).BeginInit();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(26, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manajemen Pengguna";
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(0, 102, 204);
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewUsers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle14.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewUsers.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewUsers.Location = new Point(26, 93);
            dataGridViewUsers.Margin = new Padding(3, 4, 3, 4);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.White;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = Color.White;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.RowTemplate.Height = 35;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(1090, 271);
            dataGridViewUsers.TabIndex = 2;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteUser.BackColor = Color.Crimson;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(949, 381);
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
            btnChangeRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeRole.BackColor = Color.FromArgb(0, 123, 255);
            btnChangeRole.FlatAppearance.BorderSize = 0;
            btnChangeRole.FlatStyle = FlatStyle.Flat;
            btnChangeRole.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeRole.ForeColor = Color.White;
            btnChangeRole.Location = new Point(731, 381);
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
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Segoe UI", 10F);
            lblTotalUsers.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotalUsers.Location = new Point(26, 368);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(146, 23);
            lblTotalUsers.TabIndex = 4;
            lblTotalUsers.Text = "Total Pengguna: 0";
            // 
            // dataGridViewLoginLogs
            // 
            dataGridViewLoginLogs.AllowUserToAddRows = false;
            dataGridViewLoginLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewLoginLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLoginLogs.BackgroundColor = Color.White;
            dataGridViewLoginLogs.BorderStyle = BorderStyle.None;
            dataGridViewLoginLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewLoginLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(0, 102, 204);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = Color.White;
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dataGridViewLoginLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewLoginLogs.ColumnHeadersHeight = 40;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Window;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle17.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle17.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
            dataGridViewLoginLogs.DefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewLoginLogs.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewLoginLogs.Location = new Point(26, 499);
            dataGridViewLoginLogs.Margin = new Padding(3, 4, 3, 4);
            dataGridViewLoginLogs.Name = "dataGridViewLoginLogs";
            dataGridViewLoginLogs.ReadOnly = true;
            dataGridViewLoginLogs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = Color.White;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = Color.White;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
            dataGridViewLoginLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            dataGridViewLoginLogs.RowHeadersVisible = false;
            dataGridViewLoginLogs.RowHeadersWidth = 51;
            dataGridViewLoginLogs.RowTemplate.Height = 35;
            dataGridViewLoginLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLoginLogs.Size = new Size(1090, 306);
            dataGridViewLoginLogs.TabIndex = 5;
            dataGridViewLoginLogs.Click += btnRefreshLogs_Click;
            // 
            // lblTotalLogs
            // 
            lblTotalLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalLogs.AutoSize = true;
            lblTotalLogs.Font = new Font("Segoe UI", 10F);
            lblTotalLogs.ForeColor = Color.FromArgb(64, 64, 64);
            lblTotalLogs.Location = new Point(26, 809);
            lblTotalLogs.Name = "lblTotalLogs";
            lblTotalLogs.Size = new Size(97, 23);
            lblTotalLogs.TabIndex = 8;
            lblTotalLogs.Text = "Total Log: 0";
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(btnRefreshLogs);
            panelMain.Controls.Add(lblTotalLogs);
            panelMain.Controls.Add(dataGridViewLoginLogs);
            panelMain.Controls.Add(lblTotalUsers);
            panelMain.Controls.Add(btnChangeRole);
            panelMain.Controls.Add(btnDeleteUser);
            panelMain.Controls.Add(dataGridViewUsers);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(1143, 867);
            panelMain.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 447);
            label1.Name = "label1";
            label1.Size = new Size(266, 38);
            label1.TabIndex = 6;
            label1.Text = "Log Aktifitas Login";
            // 
            // btnRefreshLogs
            // 
            btnRefreshLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshLogs.BackColor = Color.Green;
            btnRefreshLogs.FlatAppearance.BorderSize = 0;
            btnRefreshLogs.FlatStyle = FlatStyle.Flat;
            btnRefreshLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRefreshLogs.ForeColor = Color.White;
            btnRefreshLogs.Location = new Point(971, 813);
            btnRefreshLogs.Margin = new Padding(3, 4, 3, 4);
            btnRefreshLogs.Name = "btnRefreshLogs";
            btnRefreshLogs.Size = new Size(145, 47);
            btnRefreshLogs.TabIndex = 7;
            btnRefreshLogs.Text = "Refresh Log";
            btnRefreshLogs.UseVisualStyleBackColor = false;
            btnRefreshLogs.Click += btnRefreshLogs_Click;
            // 
            // FormManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1143, 867);
            Controls.Add(panelMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormManageUsers";
            Text = "Manajemen Pengguna";
            FormClosing += FormManageUsers_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoginLogs).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
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
        private Label label1;
        private Button btnRefreshLogs;
    }
}
