using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Domain.Models
{
    public class DailySalesArchive : BaseEntity
    {
       
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public DateTime ArchivedDate { get; set; }
    }
}
