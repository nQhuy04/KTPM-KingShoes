using DoAnCNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCNPM.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> NikeProducts { get; set; }
        public List<Product> AdidasProducts { get; set; }
        public List<Product> JordanProducts { get; set; }
        public List<Product> YeezyProducts { get; set; }
    }
}