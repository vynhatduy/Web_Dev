using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class NguoiDung
    {
        //public NguoiDung()
        //{
        //    HoaDons = new HashSet<HoaDon>();
        //}

        public string Ten { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string? Mk { get; set; }
        public int? QuenId { get; set; }

        //public virtual QuyenNguoiDung? Quen { get; set; }
        //public virtual GioHang? GioHang { get; set; }
        //public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
