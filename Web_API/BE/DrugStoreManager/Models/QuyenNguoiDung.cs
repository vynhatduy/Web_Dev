using System;
using System.Collections.Generic;

namespace DrugStoreManager.Models
{
    public partial class QuyenNguoiDung
    {
        //public QuyenNguoiDung()
        //{
        //    NguoiDungs = new HashSet<NguoiDung>();
        //}

        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }

        //public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
