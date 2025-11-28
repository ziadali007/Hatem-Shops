using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AddSaleResultDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total { get; set; }  // mapped

        public DateTime Time { get; set; } = DateTime.Now;
    }
}
