using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class CTHoaDon
    {
        public int HoaDonId { get; set; }
        public int? SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        public decimal? Gia { get; set; }

        //public virtual HoaDon HoaDon { get; set; } = null!;
        //public virtual SanPham? SanPham { get; set; }
    }
}
