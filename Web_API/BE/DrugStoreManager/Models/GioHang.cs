using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class GioHang
    {
        public string Sdt { get; set; } = null!;
        public int? SanPhamId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? TongGia { get; set; }

        //public virtual SanPham? SanPham { get; set; }
        //public virtual NguoiDung SdtNavigation { get; set; } = null!;
    }
}
