using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class SanPham
    {
        //public SanPham()
        //{
        //    CthoaDons = new HashSet<CthoaDon>();
        //    GioHangs = new HashSet<GioHang>();
        //}

        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public string? MoTa { get; set; }
        public int? DanhMucId { get; set; }
        public string? Url { get; set; }
        public string? ThanhPhan { get; set; }
        public string? DacDiem { get; set; }
        public string? CongDung { get; set; }
        public string? ChiDinh { get; set; }
        public string? LieuLuong { get; set; }
        public decimal Gia { get; set; }
        public int? NhaCungCaoId { get; set; }

        //public virtual DanhMuc? DanhMuc { get; set; }
        //public virtual NhaCungCap? NhaCungCao { get; set; }
        //public virtual ICollection<CthoaDon> CthoaDons { get; set; }
        //public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
