using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ArchiveGroupDto
    {
        public DateTime Date { get; set; }            // The archive day (only the date part)
        public int TotalQuantity { get; set; }        // Total quantity sold that day
        public decimal TotalAmount { get; set; }      // Total money earned that day
        public List<ArchiveItemDto> Items { get; set; } = new();
    }
}
