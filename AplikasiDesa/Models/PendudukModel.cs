namespace AplikasiDesa.Models
{
    // Attribute untuk menandai properti yang harus dienkripsi
    [AttributeUsage(AttributeTargets.Property)]
    public class EncryptAttribute : Attribute { }

    public class PendudukModel
    {
        public string NIK { get; set; }
        public string Nomor_KK { get; set; }

        [Encrypt]
        public string Nama_Lengkap { get; set; }

        public string Status_Hubungan_Dalam_Keluarga { get; set; }
        public string Gelar_Depan { get; set; }
        public string Gelar_Belakang { get; set; }

        [Encrypt]
        public string Passport_Number { get; set; }

        public DateTime? Tgl_Berakhir_Paspor { get; set; }

        [Encrypt]
        public string Nama_Sponsor { get; set; }

        public string Tipe_Sponsor { get; set; }

        [Encrypt]
        public string Alamat_Sponsor { get; set; }

        public string Jenis_Kelamin { get; set; }

        [Encrypt]
        public string Tempat_Lahir { get; set; }

        public DateTime? Tanggal_Lahir { get; set; }
        public string Kewarganegaraan { get; set; }

        [Encrypt]
        public string No_SK_Penetapan_WNI { get; set; }

        public string Akta_Lahir { get; set; }

        [Encrypt]
        public string Nomor_Akta_Kelahiran { get; set; }

        public string Golongan_Darah { get; set; }
        public string Agama { get; set; }
        public string Nama_Organisasi_Kepercayaan { get; set; }
        public string Status_Perkawinan { get; set; }
        public string Akta_Perkawinan { get; set; }

        [Encrypt]
        public string Nomor_Akta_Perkawinan { get; set; }

        public DateTime? Tanggal_Perkawinan { get; set; }
        public string Akta_Cerai { get; set; }

        [Encrypt]
        public string Nomor_Akta_Cerai { get; set; }

        public DateTime? Tanggal_Perceraian { get; set; }
        public string Kelainan_Fisik_dan_Mental { get; set; }
        public string Penyandang_Cacat { get; set; }
        public string Pendidikan_Terakhir { get; set; }
        public string Jenis_Pekerjaan { get; set; }

        [Encrypt]
        public string Nomor_ITAS_ITAP { get; set; }

        public string Tempat_Terbit_ITAS_ITAP { get; set; }
        public DateTime? Tanggal_Terbit_ITAS_ITAP { get; set; }
        public DateTime? Tanggal_Akhir_ITAS_ITAP { get; set; }
        public string Tempat_Datang_Pertama { get; set; }
        public DateTime? Tanggal_Kedatangan_Pertama { get; set; }

        [Encrypt]
        public string NIK_Ibu { get; set; }

        [Encrypt]
        public string Nama_Ibu { get; set; }

        [Encrypt]
        public string NIK_Ayah { get; set; }

        [Encrypt]
        public string Nama_Ayah { get; set; }

        public DateTime? Tanggal_Masuk { get; set; }

        [Encrypt]
        public string alamat { get; set; }

        public string kode_pos { get; set; }
        public string rt { get; set; }
        public string rw { get; set; }

        [Encrypt]
        public string no_hp { get; set; }

        [Encrypt]
        public string email { get; set; }

        public string nama_provinsi { get; set; }
        public string nama_kabupaten { get; set; }
        public string nama_kecamatan { get; set; }
        public string nama_desa { get; set; }
        public string nama_dusun { get; set; }

        [Encrypt]
        public string alamat_luar_negeri { get; set; }

        public string kota_luar_negeri { get; set; }
        public string provinsi_negara_bagian_luar_negeri { get; set; }
        public string kode_pos_luar_negeri { get; set; }
        public string kode_negara { get; set; }
        public string nama_negara { get; set; }
        public string kode_perwakilan_ri { get; set; }

        [Encrypt]
        public string nama_perwakilan_ri { get; set; }

        public string Status_Kependudukan { get; set; }
        public DateTime? Tgl_Kematian { get; set; }
    }

    public class PetugasModel
    {
        [Encrypt]
        public string nama_petugas { get; set; }

        [Encrypt]
        public string email { get; set; }

        [Encrypt]
        public string username { get; set; }

        public string jabatan { get; set; }
        public string password_hash { get; set; }
        public string password_salt { get; set; }
        public DateTime created_at { get; set; }
        public int failed_login_attempts { get; set; }
    }

    public class SessionTokenModel
    {
        [Encrypt]
        public string session_token { get; set; }
    }

    public class ResetTokenModel
    {
        [Encrypt]
        public string token { get; set; }
    }
}