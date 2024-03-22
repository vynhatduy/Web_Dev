using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class DanhMuc
    {
        //public DanhMuc()
        //{
        //    SanPhams = new HashSet<SanPham>();
        //}

        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public string? MoTa { get; set; }

        //public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
