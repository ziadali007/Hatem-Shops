using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Models
{
    public class DailySales : BaseEntity
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
