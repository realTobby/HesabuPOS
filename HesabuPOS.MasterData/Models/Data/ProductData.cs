using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS.MasterData.Models.Data
{
    public class ProductData
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}
