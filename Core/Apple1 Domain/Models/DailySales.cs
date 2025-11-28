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
        public string ProductName { get; set; }

        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}
