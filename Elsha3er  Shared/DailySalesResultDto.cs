using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Shared
{
    public class DailySalesResultDto
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
