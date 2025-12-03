using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AddCoverResultDto
    {
        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
