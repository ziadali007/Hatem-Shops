using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Models
{
    [NotMapped]
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
