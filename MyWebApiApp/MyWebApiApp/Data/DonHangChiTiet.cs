using System;

namespace MyWebApiApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        // Relationship
        public HangHoa HangHoa { get; set; }
        public DonHang DonHang { get; set; }
    }
}
