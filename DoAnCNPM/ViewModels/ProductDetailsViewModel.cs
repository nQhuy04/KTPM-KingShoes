using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCNPM.ViewModel
{
    public class ProductDetailsViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; } // Nullable nếu Price có thể là null
        public string ImageProduct { get; set; }
        public List<int> AvailableSizes { get; set; } // Giả sử Size là int
    }
}