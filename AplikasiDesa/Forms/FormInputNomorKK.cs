using AplikasiDesa.Utils;

namespace AplikasiDesa.Forms
{
    public partial class FormInputNomorKK : Form
    {
        public string NomorKK { get; private set; }

        public FormInputNomorKK()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!InputSanitizer.ValidateNIK(txtNomorKK.Text))
            {
                MessageBox.Show("Nomor KK harus terdiri dari 16 angka.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NomorKK = txtNomorKK.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
