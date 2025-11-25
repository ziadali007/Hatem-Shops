using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Models
{
    public class Screen : BaseEntity, IHasName
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
