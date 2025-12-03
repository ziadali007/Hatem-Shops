using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Domain.Models
{
    public class Cable : BaseEntity,IHasName
    {
       
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}
