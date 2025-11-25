using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Models
{
    public class DailySalesArchive : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; }       // Day of the sale
        public DateTime ArchivedAt { get; set; }     // When shifted
    }
}
