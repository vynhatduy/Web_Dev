using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class HoaDon
    {
        public int Id { get; set; }
        public string? Sdt { get; set; }
        public DateTime Ngay { get; set; }
        public string? MoTa { get; set; }
        public decimal? TongGia { get; set; }

        //public virtual NguoiDung? SdtNavigation { get; set; }
        //public virtual CthoaDon? CthoaDon { get; set; }
    }
}
