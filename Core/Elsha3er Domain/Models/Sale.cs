using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Domain.Models
{
    public class Sale : BaseEntity, IHasName
    {
        public string Type { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }  // mapped

        public void CalculateTotal()
        {
            Total = Quantity * Price;
        }

        public DateTime Time { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
    }
}
