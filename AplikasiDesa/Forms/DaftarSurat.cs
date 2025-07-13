using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiDesa
{
    internal class DaftarSurat
    {
        public int Id { get; set; }
        public DateTime? Tanggal_Terbit { get; set; }
        public string Nomor_Surat { get; set; }
        public string NIK_Terlapor { get; set; }
        public string Nama_Terlapor { get; set; }
        public DateTime? Tanggal_Kematian { get; set; }
        public string Penyebab_Kematian { get; set; }
        public string Nama_Pelapor { get; set; }
        public string Nama_Petugas {  get; set; }
    }
}
